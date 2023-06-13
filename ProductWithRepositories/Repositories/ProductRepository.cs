using Microsoft.EntityFrameworkCore;
using ProductWithRepositories.AppDbContext;
using ProductWithRepositories.Contracts;
using ProductWithRepositories.Entities;

namespace ProductWithRepositories.Repositories;

public class ProductRepository : GenericRepository<Product> ,IProductRepository
{
    private readonly Context _context;
    public ProductRepository(Context context) : base(context)
    {
        _context = context;
    }


    public async Task<Product?> GetById(Guid? Id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(i => i.Id == Id);
        return product;
    }
}