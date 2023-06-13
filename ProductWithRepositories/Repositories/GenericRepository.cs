using Microsoft.EntityFrameworkCore;
using ProductWithRepositories.AppDbContext;
using ProductWithRepositories.Contracts;

namespace ProductWithRepositories.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly Context _context;

    public GenericRepository(Context context)
    {
        _context = context;
    }

    public async Task<T> GetAsync(Guid? Id)
    {
        if (Id is null)
        {
            return null;
        }

        return await _context.Set<T>().FindAsync(Id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        var list = await _context.Set<T>().ToListAsync();
        if (list == null)
        {
            return null;
        }
        return list;
    }

    public async Task<T> AddAsync(T entity)
    {
       await _context.AddAsync(entity);
       await _context.SaveChangesAsync();
       return entity;
    }

    public async Task DeleteAsync(Guid Id)
    {
        if (Id == null)
        {
            return ;
        }

        var entity =  await GetAsync(Id);
        if (entity == null)
        {
            return;
        }

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();

    }

    public async Task UpdateAsync(T entity)
    {
        _context.Update(entity);
        await _context.SaveChangesAsync();
    }
}