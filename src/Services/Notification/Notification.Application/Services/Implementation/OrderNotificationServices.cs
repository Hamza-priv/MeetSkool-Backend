using Microsoft.AspNetCore.SignalR;
using Notification.Application.Services.Interfaces;

namespace Notification.Application.Services.Implementation;

public class OrderNotificationServices : Hub<IOrderNotificationServices>
{
    private readonly ITokenServices _tokenServices;

    public OrderNotificationServices(ITokenServices tokenServices)
    {
        _tokenServices = tokenServices;
    }
    public override async Task OnConnectedAsync()
    {
        try
        {
            // todo need to store connection Id in db

            await Clients.Client(Context.ConnectionId)
                .UserConnected("Your are connected to our system " + $"{Context.ConnectionId}");
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
            var token = await _tokenServices.GenerateToken();
            var orderId = Guid.NewGuid();
            if (!string.IsNullOrEmpty(token))
            {
                await Clients.Client(teacherId).CreateOrderToken(token, studentId, orderId);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task ConfirmOrder(string token, string studentId)
    {
        try
        {
            var isToken = await _tokenServices.GetToken(token);
            if (isToken)
            {
                await Clients.Client(Context.ConnectionId).ConfirmOrder();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}