namespace Notification.Core.Entities;

public class OrderToken
{
    public Guid TokenId { get; set; }
    public string? Teacher { get; set; }
    public required string Token { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now.ToLocalTime();
}