﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Core.Entities;

public class Student
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public required string StudentId { get; set; }

    public string? StudentName { get; set; }
    public string? Descriptions { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string? TotalOrder { get; set; }
}