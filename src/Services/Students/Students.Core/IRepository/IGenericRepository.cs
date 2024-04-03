namespace Students.Core.IRepository;

public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetByIdAsync(string id);
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
}