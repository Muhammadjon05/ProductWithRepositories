namespace ProductWithRepositories.Contracts;

public interface IGenericRepository<T> where T: class
{
    Task<T> GetAsync(Guid? Id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task DeleteAsync(Guid Id);
    Task UpdateAsync(T entity);
}