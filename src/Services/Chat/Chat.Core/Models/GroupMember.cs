using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chat.Core.Models;

public abstract class GroupMember
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string? GroupMemberId { get; set; }

    public string? GroupMemberName { get; set; }
}