using Contracts.NotificationAndOrderContracts;
using MassTransit;
using Students.Application.Services.Interfaces;

namespace Students.Application.Consumers;

public class CompleteOrderConsumer : IConsumer<OrderCompletionEventStudent>
{
    private readonly IOrderServices _orderServices;

    public CompleteOrderConsumer(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }
    public async Task Consume(ConsumeContext<OrderCompletionEventStudent> context)
    {
        try
        {
            await _orderServices.CompleteOrder(context.Message.OrderId, context.Message.StudentId,
                context.Message.CompletionDate);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}