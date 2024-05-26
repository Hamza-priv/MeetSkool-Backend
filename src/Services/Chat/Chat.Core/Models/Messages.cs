using System.ComponentModel.DataAnnotations;

namespace Chat.Core.Models;

public class Messages
{
    [Key]
    public Guid MessageId { get; set; } = Guid.NewGuid();
    public string? Message { get; set; }
    public string? SenderId { get; set; }
    public string? SenderName { get; set; }
    public string? ReceiverId { get; set; }
    public string? ReceiverName { get; set; }
    public string? GroupId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now.ToLocalTime();
}