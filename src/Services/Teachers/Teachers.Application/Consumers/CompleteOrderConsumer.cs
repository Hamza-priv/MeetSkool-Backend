using Contracts.NotificationAndOrderContracts;
using MassTransit;

namespace Teachers.Application.Consumers;

public class CompleteOrderConsumer : IConsumer<OrderCompletionEventTeacher>
{
    public CompleteOrderConsumer()
    {
        
    }
    public async Task Consume(ConsumeContext<OrderCompletionEventTeacher> context)
    {
        try
        {
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}