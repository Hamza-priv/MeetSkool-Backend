namespace Notification.Application.Services.Interfaces;

public interface IOrderNotificationServices
{
    Task UserConnected(string userId);
    Task CreateOrderToken(string token, string studentId, Guid orderId);
    Task ConfirmOrder();
}