using AutoMapper;
using Teachers.Application.DTOS.Request.OrderDto;
using Teachers.Application.DTOS.Response.OrderDto;
using Teachers.Application.ServiceResponse;
using Teachers.Application.Services.Interfaces;
using Teachers.Core.Entities;
using Teachers.Core.IRepository;
using Teachers.Infrastructure;

namespace Teachers.Application.Services.Implementation;

public class OrderServices : IOrderServices
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly ITeacherRepository _teacherRepository;

    public OrderServices(IOrderRepository orderRepository, IMapper mapper, ITeacherRepository teacherRepository)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _teacherRepository = teacherRepository;
    }

    // will be called in consumers

    public async Task CreateOrder(AddOrderRequestDto orderRequestDto)
    {
        try
        {
            var order = _mapper.Map<Order>(orderRequestDto);
            await _orderRepository.AddAsync(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task ConfirmOrder(string orderId, DateTime confirmationDate)
    {
        try
        {
            var dbOrder = await _orderRepository.GetByIdAsync(orderId);
            if (dbOrder is not null)
            {
                dbOrder.Status = Status.Confirmed;
                dbOrder.CreatedDate = confirmationDate;
                await _orderRepository.UpdateAsync(dbOrder);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task CancelOrder(string orderId, DateTime cancelTime)
    {
        try
        {
            var dbOrder = await _orderRepository.GetByIdAsync(orderId);
            if (dbOrder is not null)
            {
                dbOrder.Status = Status.Cancelled;
                dbOrder.CreatedDate = cancelTime;
                await _orderRepository.UpdateAsync(dbOrder);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task CompleteOrder(string orderId, string studentId, DateTime completeTime)
    {
        try
        {
            var dbOrder = await _orderRepository.GetByIdAsync(orderId);
            if (dbOrder is not null)
            {
                dbOrder.Status = Status.Completed;
                dbOrder.CreatedDate = completeTime;
                await _orderRepository.UpdateAsync(dbOrder);
            }

            var teacher = await _teacherRepository.GetByIdAsync(studentId);
            if (teacher is not null)
            {
                // var totalOrders = (in) student.TotalOrder 
                // plus total orders
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<ServiceResponse<List<GetOrdersResponseDto>>> GetOrders(string orderById)
    {
        var orderListResponse = new ServiceResponse<List<GetOrdersResponseDto>>();
        try
        {
            if (string.IsNullOrEmpty(orderById))
            {
                var list = await _orderRepository.GetOrders(orderById);
                if (list.Count > 0)
                {
                    orderListResponse.Data = _mapper.Map<List<GetOrdersResponseDto>>(list);
                    orderListResponse.Messages.Add("Order List Found");
                    return orderListResponse;
                }

                orderListResponse.Error.Add("Order List Not Found");
                orderListResponse.Success = false;
                return orderListResponse;
            }

            orderListResponse.Error.Add("OrderById Not Found");
            orderListResponse.Success = false;
            return orderListResponse;
        }
        catch (Exception e)
        {
            orderListResponse.Error.Add(e.Message);
            orderListResponse.Success = false;
            return orderListResponse;
        }
    }
}