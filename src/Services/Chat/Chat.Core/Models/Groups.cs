using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Core.Models;

public class Groups
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public required string GroupId { get; set; }

    public required string GroupOwnerId { get; set; }
    public required string GroupName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now.ToLocalTime();
    public ICollection<GroupMember>? GroupMembers { get; set; } = new List<GroupMember>();
}