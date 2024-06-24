using Contracts.NotificationAndOrderContracts;
using Contracts.OrderAndEmailContracts;
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
                TeacherId = teacherId,
                CreationDate = DateTime.Now.ToLocalTime()
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
                StudentId = studentId,
                CreationDate = DateTime.Now.ToLocalTime()
            };

            await _publisher.Publish(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task PublishOrderConfirmationStudent(string orderId)
    {
        try
        {
            var order = new OrderConfirmationEventStudent()
            {
                OrderId = orderId,
                ConfirmationDate = DateTime.Now.ToLocalTime()
            };

            await _publisher.Publish(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task PublishOrderConfirmationTeacher(string orderId)
    {
        try
        {
            var order = new OrderConfirmationEventTeacher()
            {
                OrderId = orderId,
                ConfirmationDate = DateTime.Now.ToLocalTime()
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
                OrderId = orderId,
                CancelTime = DateTime.Now.ToLocalTime()
            };
            await _publisher.Publish(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task PublishOrderCancellationToTeacher(string orderId)
    {
        try
        {
            var order = new OrderCancellationEventStudent()
            {
                OrderId = orderId,
                CancelTime = DateTime.Now.ToLocalTime()
            };
            await _publisher.Publish(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    public async Task PublishOrderCompleteToTeacher(string orderId, string teacherId)
    {
        try
        {
            var order = new OrderCompletionEventTeacher()
            {
                OrderId = orderId,
                CompletionDate = DateTime.Now.ToLocalTime(),
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

    public async Task PublishOrderCompleteToStudent(string orderId, string studentId)
    {
        try
        {
            var order = new OrderCompletionEventStudent()
            {
                OrderId = orderId,
                CompletionDate = DateTime.Now.ToLocalTime(),
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

    public async Task PublishOrderSentEmail(string teacherId, string studentId)
    {
        try
        {
            var info = new OrderSentEmailEvent()
            {
                TeacherId = teacherId,
                StudentId = studentId
            };
            await _publisher.Publish(info);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task PublishOrderConfirmEmail(string teacherId, string studentId)
    {
        try
        {
            var info = new OrderConfirmEmailEvent()
            {
                TeacherId = teacherId,
                StudentId = studentId
            };
            await _publisher.Publish(info);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task PublishOrderCancelEmail(string teacherId, string studentId)
    {
        try
        {
            var info = new OrderCancelEmailEvent()
            {
                TeacherId = teacherId,
                StudentId = studentId
            };
            await _publisher.Publish(info);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task PublishOrderCompleteEmail(string teacherId, string studentId)
    {
        try
        {
            var info = new OrderCompleteEmailEvent()
            {
                TeacherId = teacherId,
                StudentId = studentId
            };
            await _publisher.Publish(info);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}