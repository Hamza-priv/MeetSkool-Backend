namespace Contracts.NotificationAndOrderContracts;

public class OrderCompletionEventTeacher
{
    public required string OrderId { get; set; }
    public DateTime CompletionDate { get; set; }

    public required string TeacherId { get; set; }
}