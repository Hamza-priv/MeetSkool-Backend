namespace Chat.Core.IRepository;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByIdAsync(string id);
    Task<bool> AddAsync(T entity);
    Task<bool> DeleteAsync(T entity);
}