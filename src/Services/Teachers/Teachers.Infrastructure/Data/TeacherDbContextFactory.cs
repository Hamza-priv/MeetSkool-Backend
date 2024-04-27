using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Teachers.Infrastructure.Data;

public class TeacherDbContextFactory : IDesignTimeDbContextFactory<TeacherDbContext>
{
    public TeacherDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TeacherDbContext>();
        optionsBuilder.UseSqlServer(
            "Server=.;Database=MeetSkoolTeacherDb;TrustServerCertificate=true;Trusted_Connection=True;MultipleActiveResultSets=true");
        return new TeacherDbContext(optionsBuilder.Options);
    }
}