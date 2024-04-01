using Microsoft.EntityFrameworkCore;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly StudentDbContext _studentDbContext;

    protected GenericRepository(StudentDbContext studentDbContext)
    {
        _studentDbContext = studentDbContext;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        try
        {
            return await _studentDbContext.Set<T>().ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        try
        {
            return await _studentDbContext.Set<T>().FindAsync(id) ?? default(T);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        try
        {
            return await _studentDbContext.Set<T>().FindAsync(id) ?? default(T);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<T> AddAsync(T entity)
    {
        try
        {
            _studentDbContext.Set<T>().Add(entity);
            await _studentDbContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task UpdateAsync(T entity)
    {
        try
        {
            _studentDbContext.Entry(entity).State = EntityState.Modified;
            await _studentDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task DeleteAsync(T entity)
    {
        try
        {
            _studentDbContext.Entry(entity).State = EntityState.Deleted;
            await _studentDbContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}