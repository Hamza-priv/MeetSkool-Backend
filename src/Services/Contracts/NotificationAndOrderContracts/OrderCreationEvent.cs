namespace Contracts.NotificationAndOrderContracts;

public class OrderCreationEvent
{
    public Guid OrderId { get; set; }
    public string? OrderById { get; set; }
    public string? OrderToId { get; set; }
}