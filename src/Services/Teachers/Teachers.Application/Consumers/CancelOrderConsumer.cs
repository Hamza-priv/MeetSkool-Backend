using Contracts.NotificationAndOrderContracts;
using MassTransit;
using Teachers.Application.Services.Interfaces;

namespace Teachers.Application.Consumers;

public class CancelOrderConsumer: IConsumer<OrderCancellationEventTeacher>
{
    private readonly IOrderServices _orderServices;

    public CancelOrderConsumer(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }
    public async Task Consume(ConsumeContext<OrderCancellationEventTeacher> context)
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