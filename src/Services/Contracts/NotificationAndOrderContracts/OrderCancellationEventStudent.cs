namespace Contracts.NotificationAndOrderContracts;

public class OrderCancellationEventStudent
{
    public string? OrderId { get; set; }
    public DateTime CancelTime { get; set; }
}