namespace Contracts.NotificationAndOrderContracts;

public class OrderCompletionEventTeacher
{
    public required string OrderId { get; set; }
    public required string TeacherId { get; set; }
    public DateTime ConfirmationDate { get; set; } = DateTime.Now.ToLocalTime();
}