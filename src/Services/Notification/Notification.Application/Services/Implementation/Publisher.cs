using Contracts.NotificationAndOrderContracts;
using MassTransit;
using Notification.Application.Services.Interfaces;

namespace Notification.Application.Services.Implementation;

public class Publisher : IPublish
{
    private readonly IPublishEndpoint _publisher;

    public Publisher(IPublishEndpoint publisher)
    {
        _publisher = publisher;
    }
    public async Task PublishOrderToStudent(string studentId, string orderId, string teacherId)
    {
        try
        {
            var order = new OrderCreationEventStudent()
            {
                OrderId = orderId,
                StudentId = studentId,
                TeacherId = teacherId
            };
            
            await _publisher.Publish(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task PublishOrderToTeacher(string teacherId, string orderId, string studentId)
    {
        try
        {
            var order = new OrderCreationEvenTeacher()
            {
                OrderId = orderId,
                TeacherId = teacherId,
                StudentId = studentId
            };
            
            await _publisher.Publish(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task PublishOrderConfirmation(string orderId)
    {
        try
        {
            var order = new OrderConfirmationEvent()
            {
                OrderId = orderId,
            };

            await _publisher.Publish(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task PublishOrderCancellationToStudent(string orderId)
    {
        try
        {
            var order = new OrderCancellationEventStudent()
            {
                OrderId = orderId
            };
            await  _publisher.Publish(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    

    public async Task PublishOrderCompleteToTeacher(string teacherId, string orderId)
    {
        throw new NotImplementedException();
    }

    public async Task PublishOrderCompleteToStudent(string studentId, string orderId)
    {
        throw new NotImplementedException();
    }
}