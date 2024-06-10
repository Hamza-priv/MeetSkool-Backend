using AutoMapper;
using Students.Application.DTOS.Request.OrderDto;
using Students.Application.DTOS.Response.OrderDto;
using Students.Application.ServiceResponse;
using Students.Application.Services.Interfaces;
using Students.Core.Entities;
using Students.Core.IRepository;

namespace Students.Application.Services.Implementation;

public class OrderServices : IOrderServices
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderServices(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
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

    public async Task ConfirmOrder(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteOrder(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateOrder(Guid orderId)
    {
        try
        {
            var orderToDb = await _orderRepository.GetByIdAsync(orderId);
            if (orderToDb != null)
            {
                await _orderRepository.UpdateAsync(orderToDb);
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