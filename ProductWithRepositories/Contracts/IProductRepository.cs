using ProductWithRepositories.Entities;

namespace ProductWithRepositories.Contracts;

public interface IProductRepository : IGenericRepository<Product>
{
  Task<Product?> GetById(Guid? Id);
}