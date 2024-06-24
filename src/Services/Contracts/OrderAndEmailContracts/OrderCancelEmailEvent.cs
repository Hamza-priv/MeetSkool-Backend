namespace Contracts.OrderAndEmailContracts;

public class OrderCancelEmailEvent
{
    public required string TeacherId { get; set; }
    public required string StudentId { get; set; }
}