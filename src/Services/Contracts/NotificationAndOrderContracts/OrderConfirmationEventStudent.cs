namespace Contracts.NotificationAndOrderContracts;

public class OrderConfirmationEventStudent
{
    public required string OrderId { get; set; }
    public DateTime ConfirmationDate { get; set; }
}