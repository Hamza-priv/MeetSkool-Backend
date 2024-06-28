using Microsoft.EntityFrameworkCore;
using Teachers.Core.IRepository;
using Teachers.Infrastructure.Data;

namespace Teachers.Infrastructure.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly TeacherDbContext _teacherDbContext;

    protected GenericRepository(TeacherDbContext teacherDbContext)
    {
        _teacherDbContext = teacherDbContext;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        try
        {
            return await _teacherDbContext.Set<T>().ToListAsync();
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
            return await _teacherDbContext.Set<T>().FindAsync(id) ?? default(T);
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
            return await _teacherDbContext.Set<T>().FindAsync(id) ?? default(T);
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
            _teacherDbContext.Set<T>().Add(entity);
            await _teacherDbContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<T> UpdateAsync(T entity)
    {
        try
        {
            _teacherDbContext.Entry(entity).State = EntityState.Modified;
            await _teacherDbContext.SaveChangesAsync();
            return entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<bool> DeleteAsync(T entity)
    {
        try
        {
            _teacherDbContext.Entry(entity).State = EntityState.Deleted;
            await _teacherDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}