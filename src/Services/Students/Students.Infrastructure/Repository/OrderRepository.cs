using Microsoft.EntityFrameworkCore;
using Students.Core.Entities;
using Students.Core.IRepository;
using Students.Infrastructure.Data;

namespace Students.Infrastructure.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly StudentDbContext _studentDbContext;

    public OrderRepository(StudentDbContext studentDbContext) : base(studentDbContext)
    {
        _studentDbContext = studentDbContext;
    }


    public async Task<List<Order>> GetOrders(string orderById)
    {
        try
        {
            return await _studentDbContext.Orders.Where(x => x.OrderById == orderById).ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}