﻿using Contracts.NotificationAndOrderContracts;
using MassTransit;
using Students.Application.Services.Interfaces;

namespace Students.Application.Consumers;

public class ConfirmOrderConsumer : IConsumer<OrderConfirmationEventStudent>
{
    private readonly IOrderServices _orderServices;

    public ConfirmOrderConsumer(IOrderServices orderServices)
    {
        _orderServices = orderServices;
    }
    public async Task Consume(ConsumeContext<OrderConfirmationEventStudent> context)
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