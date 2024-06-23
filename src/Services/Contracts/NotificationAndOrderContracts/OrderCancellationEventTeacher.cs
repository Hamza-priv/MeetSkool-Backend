namespace Contracts.NotificationAndOrderContracts;

public class OrderCancellationEventTeacher
{
    public string? OrderId { get; set; }
    public DateTime CancelTime { get; set; } = DateTime.Now.ToLocalTime();
}