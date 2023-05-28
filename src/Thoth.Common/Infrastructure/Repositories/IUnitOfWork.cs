using Thoth.Common.Domain.Entities;

namespace Thoth.Common.Infrastructure.Repositories;

public interface IUnitOfWork
{
    TRepository GetRepository<TRepository, TEntity>() where TRepository : class, IRepository<TEntity> where TEntity : ModelBase;
    Task<int> CommitAsync();
    Task RollBackAsync();

    void Dispose();
}
