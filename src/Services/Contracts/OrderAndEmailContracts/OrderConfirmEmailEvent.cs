namespace Contracts.OrderAndEmailContracts;

public class OrderConfirmEmailEvent
{
    public required string TeacherId { get; set; }
    public required string StudentId { get; set; }
}