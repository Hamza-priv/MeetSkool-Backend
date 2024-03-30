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
        return await _studentDbContext.Set<T>().ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _studentDbContext.Set<T>().FindAsync(id) ?? default(T);
    }

    public async Task<T?> GetByIdAsync(string id)
    {
        return await _studentDbContext.Set<T>().FindAsync(id) ?? default(T);
    }

    public async Task<T> AddAsync(T entity)
    {
        _studentDbContext.Set<T>().Add(entity);
        await _studentDbContext.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        _studentDbContext.Entry(entity).State = EntityState.Modified;
        await _studentDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _studentDbContext.Entry(entity).State = EntityState.Deleted;
        await _studentDbContext.SaveChangesAsync();
    }
}