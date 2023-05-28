using Microsoft.EntityFrameworkCore;

namespace Thoth.Common.Infrastructure;

public class DatabaseContextFactory
{
    private readonly Action<DbContextOptionsBuilder> _configureDbContextBuilder;
    public DatabaseContextFactory(Action<DbContextOptionsBuilder> configureDbContextBuilder)
    {
        _configureDbContextBuilder = configureDbContextBuilder;
    }

    public DatabaseContext CreateDbContext()
    {
        DbContextOptionsBuilder<DatabaseContext> optionsBuilder = new();
        _configureDbContextBuilder(optionsBuilder);

        return new DatabaseContext(optionsBuilder.Options);
    }
}
