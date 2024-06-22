using Contracts.NotificationAndOrderContracts;
using MassTransit;
using Students.Application.Services.Interfaces;

namespace Students.Application.Consumers;

public class CancelOrderConsumer : IConsumer<OrderCancellationEventStudent>
{
    private readonly IOrderServices _orderServices;

    public CancelOrderConsumer(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }
    public async Task Consume(ConsumeContext<OrderCancellationEventStudent> context)
    {
        try
        {
            if (context.Message.OrderId != null)
                await _orderServices.CancelOrder(context.Message.OrderId, context.Message.CancelTime);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}