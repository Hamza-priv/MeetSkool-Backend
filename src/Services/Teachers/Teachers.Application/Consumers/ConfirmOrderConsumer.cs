using Contracts.NotificationAndOrderContracts;
using MassTransit;
using Teachers.Application.Services.Interfaces;

namespace Teachers.Application.Consumers;

public class ConfirmOrderConsumer : IConsumer<OrderConfirmationEventTeacher>
{
    private readonly IOrderServices _orderServices;

    public ConfirmOrderConsumer(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }

    public async Task Consume(ConsumeContext<OrderConfirmationEventTeacher> context)
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