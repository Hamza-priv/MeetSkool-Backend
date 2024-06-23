using Teachers.Application.DTOS.Request.OrderDto;
using Teachers.Application.DTOS.Response.OrderDto;
using Teachers.Application.ServiceResponse;

namespace Teachers.Application.Services.Interfaces;

public interface IOrderServices
{
    Task CreateOrder(AddOrderRequestDto orderRequestDto);
    Task ConfirmOrder(string orderId, DateTime confirmationDate);
    Task CancelOrder(string orderId, DateTime cancelTime);
    Task CompleteOrder(string orderId);
    
    Task<ServiceResponse<List<GetOrdersResponseDto>>> GetOrders(string orderById);
}