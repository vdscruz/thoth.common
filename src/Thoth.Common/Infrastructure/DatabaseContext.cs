using Thoth.Common.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Thoth.Common.Infrastructure;

public class DatabaseContext: DbContext 
{
    public DatabaseContext(DbContextOptions options): base(options)
    {
        
    }

    public DbSet<Asset> Assets { get; set; }
    public DbSet<Income> Incomes { get; set; }
    public DbSet<Movement> Movements { get; set; }
}
