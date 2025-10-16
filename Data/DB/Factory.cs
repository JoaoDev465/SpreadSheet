using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Scaffolding;

namespace Data.DB;

public class Factory: IDesignTimeDbContextFactory<Context>
{
    public Context CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<Context>().
            UseSqlite(" Data Source=database.db");
        return new Context(optionsBuilder.Options);
    }
}