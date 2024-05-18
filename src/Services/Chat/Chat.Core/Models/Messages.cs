namespace Chat.Core.Models;

public class Messages
{
    public Guid MessageId { get; set; } = Guid.NewGuid();
    public string? Message { get; set; }
    public string? SendById { get; set; }
    public string? SendToId { get; set; }
    public string? GroupId { get; set; }
    public DateTime Date { get; set; } = DateTime.Now.ToLocalTime();
}