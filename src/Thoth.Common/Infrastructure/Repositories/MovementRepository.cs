using System.Linq.Expressions;
using Thoth.Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Thoth.Common.Infrastructure.Repositories;

public class MovementRepository: IRepository<Movement>
{
    private readonly DatabaseContext _context;

    public MovementRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Task CreateAsync(Movement entity)
    {
        _context.Movements.Add(entity);

        // _ = await _context.SaveChangesAsync();
        return Task.CompletedTask;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);

        if (entity is null) return false;

        _context.Movements.Remove(entity);
        _ = await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<Movement>> GetAllAsync()
    {
        return await _context.Movements.AsNoTracking().ToListAsync<Movement>();
    }

    public async Task<IEnumerable<Movement>> GetByFilterAsync(Expression<Func<Movement, bool>> filter)
    {
        return await _context.Movements.AsNoTracking().Where(filter).ToListAsync();
    }

    public async Task<Movement?> GetByIdAsync(Guid id)
    {
        return await _context.Movements.AsNoTracking()
                //.Include(e => e.Movements)
                .FirstOrDefaultAsync(e => e.Id == id);
    }

    public Task UpdateAsync(Movement entity)
    {
        entity.UpdatedAt = DateTime.Now;
        _context.Movements.Update(entity);

        // _ = await _context.SaveChangesAsync();
        return Task.CompletedTask;
    }
}
