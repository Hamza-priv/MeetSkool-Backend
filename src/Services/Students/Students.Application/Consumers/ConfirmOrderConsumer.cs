using Contracts.NotificationAndOrderContracts;
using MassTransit;
using Students.Application.Services.Interfaces;

namespace Students.Application.Consumers;

public class ConfirmOrderConsumer : IConsumer<OrderConfirmationEvent>
{
    private readonly IOrderServices _orderServices;

    public ConfirmOrderConsumer(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }
    public async Task Consume(ConsumeContext<OrderConfirmationEvent> context)
    {
        try
        {
            await _orderServices.ConfirmOrder(context.Message.OrderId, context.Message.ConfirmationDate);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}