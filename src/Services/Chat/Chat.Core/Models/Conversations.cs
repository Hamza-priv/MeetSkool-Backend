using System.ComponentModel.DataAnnotations;

namespace Chat.Core.Models;

public class Conversations
{
    [Key] public Guid ConversationId { get; set; } = Guid.NewGuid();
    public string? UserId { get; set; }
    public string? ParticipantId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now.ToLocalTime();
}