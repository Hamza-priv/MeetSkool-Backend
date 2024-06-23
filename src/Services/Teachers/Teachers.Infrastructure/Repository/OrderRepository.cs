using Microsoft.EntityFrameworkCore;
using Teachers.Core.Entities;
using Teachers.Core.IRepository;
using Teachers.Infrastructure.Data;

namespace Teachers.Infrastructure.Repository;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    private readonly TeacherDbContext _teacherDbContext;

    protected OrderRepository(TeacherDbContext teacherDbContext) : base(teacherDbContext)
    {
        _teacherDbContext = teacherDbContext;
    }

    public async Task<List<Order>> GetOrders(string orderById)
    {
        try
        {
            return await _teacherDbContext.Orders.Where(x => x.OrderById == orderById).ToListAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}