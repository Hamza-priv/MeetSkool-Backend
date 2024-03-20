using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace Students.Core.Entities;

public class Friend
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string? FriendId { get; set; }
    public string? FriendName { get; set; }
    public string? StudentId { get; set; }
    public DateTime FriendSince { get; set; } = DateTime.Now;
}