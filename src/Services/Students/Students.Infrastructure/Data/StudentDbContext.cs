using Microsoft.EntityFrameworkCore;
using Students.Core.Entities;

namespace Students.Infrastructure.Data;

public class StudentDbContext : DbContext
{
    public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
    {
    }

    public DbSet<Education> Educations { get; set; }
    public DbSet<Friend> Friends { get; set; }
    public DbSet<Student> Students { get; set; }
}