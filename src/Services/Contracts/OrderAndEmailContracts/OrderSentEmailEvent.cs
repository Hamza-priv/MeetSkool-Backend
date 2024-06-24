namespace Contracts.OrderAndEmailContracts;

public class OrderSentEmailEvent
{
    public required string TeacherId { get; set; }
    public required string StudentId { get; set; }
}