using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teachers.Core.Entities;

public class Teacher
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public required string TeacherId { get; set; }
    public string? TeacherName { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? TotalOrderCompleted { get; set; }
}