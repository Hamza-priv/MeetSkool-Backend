using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Core.Models;

public class GroupMember
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string? GroupMemberId { get; set; }
    public string? GroupMemberName { get; set; }
    public DateTime JoinedAt { get; set; } = DateTime.Now.ToLocalTime();
}