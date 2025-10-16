using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.DB;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options): base(options){}

    public  DbSet<Transactions> Transactions { get; set;}
    
    public  DbSet<Category> Categories { get; set;}
    
}