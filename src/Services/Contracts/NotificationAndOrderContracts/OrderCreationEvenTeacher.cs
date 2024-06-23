namespace Contracts.NotificationAndOrderContracts;

public class OrderCreationEvenTeacher
{
    public string? OrderId { get; set; }
    public string? StudentId { get; set; }
    public string? TeacherId { get; set; }
    public DateTime CreationDate { get; set; }
}