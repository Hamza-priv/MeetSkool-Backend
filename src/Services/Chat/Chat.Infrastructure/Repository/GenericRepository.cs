using Chat.Core.IRepository;
using Chat.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ChatDbContext _chatDbContext;

    protected GenericRepository(ChatDbContext chatDbContext)
    {
        _chatDbContext = chatDbContext;
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        try
        {
            return await _chatDbContext.Set<T>().FindAsync(id) ?? default(T);
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
            return await _chatDbContext.Set<T>().FindAsync(id) ?? default(T);
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
            _chatDbContext.Set<T>().Add(entity);
            await _chatDbContext.SaveChangesAsync();
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
            _chatDbContext.Entry(entity).State = EntityState.Deleted;
            await _chatDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}