using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Notification.Application.Services.Interfaces;

namespace Notification.Application.Services.Implementation;

/*
[Authorize(Roles = "Teacher,Student")]
*/
public class OrderNotificationServices : Hub<IOrderNotificationServices>
{
    private readonly ITokenServices _tokenServices;
    private readonly IPublish _publish;

    public OrderNotificationServices(ITokenServices tokenServices, IPublish publish)
    {
        _tokenServices = tokenServices;
        _publish = publish;
    }
    public override async Task OnConnectedAsync()
    {
        try
        {
            await Clients.Client(Context.UserIdentifier)
                .UserConnected("Your are connected to our system " + $"{Context.UserIdentifier}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task CreateOrderToken(string teacherId, string studentId)
    {
        try
        {
            var token = await _tokenServices.GenerateToken(teacherId);
            var orderId = Guid.NewGuid().ToString();
            if (!string.IsNullOrEmpty(token))
            {
                await Clients.Client(teacherId).CreateOrderToken(token, studentId, orderId);
                
                _ = _publish.PublishOrderToStudent(studentId, orderId,teacherId);
                _ = _publish.PublishOrderToTeacher(teacherId, orderId, studentId);
                _ = _publish.PublishOrderSentEmail(teacherId, studentId);

            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task ConfirmOrder(string token, string studentId, string teacherName, string orderId, string teacherId)
    {
        try
        {
            var isToken = await _tokenServices.GetToken(token);
            if (isToken)
            {
                await Clients.Client(studentId).ConfirmOrder("Your Order To " + $"{teacherName} is confirmed");
                _ = _publish.PublishOrderConfirmationStudent(orderId);
                _ = _publish.PublishOrderConfirmEmail(teacherId, studentId);
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task CancelOrder(string orderId, string studentId, string teacherName, string teacherId)
    {
        try
        {
            await Clients.Client(studentId).CancelOrder($"Your order to {teacherName} is canceled");
            _ = _publish.PublishOrderCancellationToStudent(orderId);
            _ = _publish.PublishOrderCancelEmail(teacherId, studentId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}