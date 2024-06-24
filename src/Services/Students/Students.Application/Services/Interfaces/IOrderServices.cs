using Students.Application.DTOS.Request.OrderDto;
using Students.Application.DTOS.Response.OrderDto;
using Students.Application.ServiceResponse;
using Students.Core.Entities;

namespace Students.Application.Services.Interfaces;

public interface IOrderServices
{ 
    Task CreateOrder(AddOrderRequestDto orderRequestDto);
    Task ConfirmOrder(string orderId, DateTime confirmationDate);
    Task CancelOrder(string orderId, DateTime cancelTime);
    Task CompleteOrder(string orderId, string studentId, DateTime completeTime);
    
    Task<ServiceResponse<List<GetOrdersResponseDto>>> GetOrders(string orderById);
}