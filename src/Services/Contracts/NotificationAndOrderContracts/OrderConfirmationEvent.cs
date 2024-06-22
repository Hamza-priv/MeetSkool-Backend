﻿namespace Contracts.NotificationAndOrderContracts;

public class OrderConfirmationEvent
{
    public required string OrderId { get; set; }
    public DateTime ConfirmationDate { get; set; } = DateTime.Now.ToLocalTime();
}