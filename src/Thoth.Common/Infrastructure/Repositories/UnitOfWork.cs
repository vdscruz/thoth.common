namespace Thoth.Common.Infrastructure.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly DatabaseContext _context;
    private Dictionary<Type, object> _repositories;

    public UnitOfWork(DatabaseContextFactory factory)
    {
        _context = factory.CreateDbContext();
        _repositories = new Dictionary<Type, object>();
    }

    public async Task<int> CommitAsync()
    {
        return await _context.SaveChangesAsync();        
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public Task RollBackAsync()
    {
        throw new NotImplementedException();
    }

    TRepository IUnitOfWork.GetRepository<TRepository, TEntity>()
    {
        var type = typeof(TEntity);

        if (_repositories.ContainsKey(type))
        {
            return (TRepository)_repositories[type];
        }
        else
        {
            var repositoryType = typeof(TRepository);
            // var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
            var repositoryInstance = Activator.CreateInstance(repositoryType, _context);
            ArgumentNullException.ThrowIfNull(repositoryInstance, nameof(repositoryType));
            _repositories.Add(type, repositoryInstance);
        }

        return (TRepository)_repositories[type];
    }
}
