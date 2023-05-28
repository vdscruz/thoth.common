using System.Linq.Expressions;
using Thoth.Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Thoth.Common.Infrastructure.Repositories;

public class AssetRepository : IRepository<Asset>
{
    private readonly DatabaseContext _context;

    public AssetRepository(DatabaseContext context)
    {
        _context = context;
    }

    public Task CreateAsync(Asset entity)
    {        
        _context.Assets.Add(entity);

        // _ = await _context.SaveChangesAsync();

        return Task.CompletedTask;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);

        if (entity is null) return false;

        _context.Assets.Remove(entity);
        // _ = await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<Asset>> GetAllAsync()
    {
        return await _context.Assets.AsNoTracking().ToListAsync<Asset>();
    }

    public async Task<IEnumerable<Asset>> GetByFilterAsync(Expression<Func<Asset, bool>> filter)
    {
        return await _context.Assets.AsNoTracking().Where(filter).ToListAsync();
    }

    public async Task<Asset?> GetByIdAsync(Guid id)
    {
        return await _context.Assets.AsNoTracking()
                //.Include(e => e.Movements)
                .FirstOrDefaultAsync(e => e.Id == id);
    }

    public Task UpdateAsync(Asset entity)
    {
        entity.UpdatedAt = DateTime.Now;
        _context.Assets.Update(entity);

        // _ = await _context.SaveChangesAsync();
        return Task.CompletedTask;
    }
}
