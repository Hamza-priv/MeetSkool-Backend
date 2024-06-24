using System.ComponentModel.DataAnnotations;

namespace Notification.Core.Entities;

public class OrderToken
{
    [Key]
    public Guid TokenId { get; set; }
    public string? Teacher { get; set; }
    public required string Token { get; set; }
    
    public bool Confirmed { get; set; } = false;
    public DateTime CreatedDate { get; set; } = DateTime.Now.ToLocalTime();
}