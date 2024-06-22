namespace Notification.Application.Services.Interfaces;

public interface IOrderNotificationServices
{
    Task UserConnected(string userId);
    Task CreateOrderToken(string token, string studentId, string orderId);
    Task ConfirmOrder(string message);
    Task CancelOrder(string message);
}