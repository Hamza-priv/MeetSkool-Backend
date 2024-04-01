﻿namespace Students.Application.DTOS.Response.StudentDto;

public class UpdateStudentResponseDto
{
    public string? Descriptions { get; set; }
    public List<string>? Subjects { get; set; } = new List<string>();
    public string? TotalOrder { get; set; }
}