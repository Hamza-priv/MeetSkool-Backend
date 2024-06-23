using Contracts.NotificationAndOrderContracts;
using MassTransit;
using Teachers.Application.DTOS.Request.OrderDto;
using Teachers.Application.Services.Interfaces;
using Teachers.Infrastructure;

namespace Teachers.Application.Consumers;

public class AddOrderConsumer : IConsumer<OrderCreationEvenTeacher>
{
    private readonly IOrderServices _orderServices;

    public AddOrderConsumer(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }
    public async Task Consume(ConsumeContext<OrderCreationEvenTeacher> context)
    {
        try
        {
            var order = new AddOrderRequestDto()
            {
                OrderToId = context.Message.TeacherId,
                OrderById = context.Message.StudentId,
                Status = Status.Pending,
                OrderId = context.Message.OrderId,
                CreatedDate = context.Message.CreationDate
            };
            
            await _orderServices.CreateOrder(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}