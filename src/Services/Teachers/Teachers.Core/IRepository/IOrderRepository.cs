using Teachers.Core.Entities;

namespace Teachers.Core.IRepository;

public interface IOrderRepository : IGenericRepository<Order>
{
    Task<List<Order>> GetOrders(string orderById);
}