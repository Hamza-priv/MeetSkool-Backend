using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Students.Infrastructure.Data;

public class StudentDbContextFactory : IDesignTimeDbContextFactory<StudentDbContext>
{
    public StudentDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<StudentDbContext>();
        optionsBuilder.UseSqlServer("Server=.;Database=MeetSkoolStudentDb;TrustServerCertificate=true;Trusted_Connection=True;MultipleActiveResultSets=true");
        return new StudentDbContext(optionsBuilder.Options);
    }
}