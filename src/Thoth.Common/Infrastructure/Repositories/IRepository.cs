using Thoth.Common.Domain.Entities;
using System.Linq.Expressions;

namespace Thoth.Common.Infrastructure.Repositories;

public interface IRepository<T> where T : ModelBase
{
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task<bool> DeleteAsync(Guid id);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
}
