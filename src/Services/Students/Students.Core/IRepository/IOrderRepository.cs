using Students.Core.Entities;

namespace Students.Core.IRepository;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<List<Order>> GetOrders(string orderById);
}