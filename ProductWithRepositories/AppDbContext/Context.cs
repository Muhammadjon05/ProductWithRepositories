using Microsoft.EntityFrameworkCore;
using ProductWithRepositories.Entities;

namespace ProductWithRepositories.AppDbContext;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
     {
        
    }
    public DbSet<Product> Products => Set<Product>();
}