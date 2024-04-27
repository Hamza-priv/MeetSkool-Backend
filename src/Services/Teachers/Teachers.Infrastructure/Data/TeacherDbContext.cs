using Microsoft.EntityFrameworkCore;
using Teachers.Core.Entities;

namespace Teachers.Infrastructure.Data;

public class TeacherDbContext : DbContext
{
    public TeacherDbContext(DbContextOptions<TeacherDbContext> options) : base(options)
    {
    }

    public DbSet<Education> Educations { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<TeacherSubject> TeacherSubjects { get; set; }
    public DbSet<Comments> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TeacherSubject>()
            .HasKey(x => new { x.TeacherId, x.SubjectId });
    }
}