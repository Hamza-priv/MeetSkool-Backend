﻿namespace Contracts.NotificationAndOrderContracts;

public class OrderCreationEventStudent
{
    public string? OrderId { get; set; }
    public string? StudentId { get; set; }
    public string? TeacherId { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now.ToLocalTime();

}