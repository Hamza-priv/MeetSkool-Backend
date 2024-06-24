namespace Contracts.NotificationAndOrderContracts;

public class OrderCompletionEventStudent
{
    public required string OrderId { get; set; }
    public required string StudentId { get; set; }
    public DateTime CompletionDate { get; set; } 
    
}