using System.ComponentModel.DataAnnotations;

namespace Chat.Core.Models;

public class UserConnections
{
    [Key] public string? UserId { get; set; }
    public string? ConnectionId { get; set; }
}