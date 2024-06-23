namespace Contracts.NotificationAndOrderContracts;

public class OrderConfirmationEventTeacher
{
    public required string OrderId { get; set; }
    public DateTime ConfirmationDate { get; set; } 
}