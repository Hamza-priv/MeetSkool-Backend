namespace Contracts.OrderAndEmailContracts;

public class OrderCompleteEmailEvent
{
    public required string TeacherId { get; set; }
    public required string StudentId { get; set; }
}