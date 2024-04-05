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
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<StudentSubject> StudentSubjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentSubject>()
            .HasKey(x => new { x.StudentId, x.SubjectId });
        modelBuilder.Entity<Friend>()
            .HasKey(x => new { x.StudentId, x.FriendId });
    }
}