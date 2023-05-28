using System.Linq.Expressions;
using Thoth.Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Thoth.Common.Infrastructure.Repositories;

public class IncomeRepository: IRepository<Income>
{
    private readonly DatabaseContext _context;

    public IncomeRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Task CreateAsync(Income entity)
    {
        _context.Incomes.Add(entity);
        // _ = await _context.SaveChangesAsync();
        return Task.CompletedTask;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);

        if (entity is null) return false;

        _context.Incomes.Remove(entity);
        _ = await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<Income>> GetAllAsync() =>
         await _context.Incomes.AsNoTracking().ToListAsync<Income>();

    public async Task<IEnumerable<Income>> GetByFilterAsync(Expression<Func<Income, bool>> filter) =>
        await _context.Incomes.AsNoTracking().Where(filter).ToListAsync();
    

    public async Task<Income?> GetByIdAsync(Guid id)
    {
        return await _context.Incomes.AsNoTracking()
                //.Include(e => e.Incomes)
                .FirstOrDefaultAsync(e => e.Id == id);
    }

    public Task UpdateAsync(Income entity)
    {
        entity.UpdatedAt = DateTime.Now;
        _context.Incomes.Update(entity);

        // _ = await _context.SaveChangesAsync();
        return Task.CompletedTask;
    }
}
