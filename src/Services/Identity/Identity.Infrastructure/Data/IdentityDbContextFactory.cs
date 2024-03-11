using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Identity.Infrastructure.Data;

public class IdentityDbContextFactory : IDesignTimeDbContextFactory<IdentityDbContext>
{
    public IdentityDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<IdentityDbContext>();
        optionsBuilder.UseSqlServer(
            "Server=.;Database=MeetSkoolIdentityDb;TrustServerCertificate=true;Trusted_Connection=True;MultipleActiveResultSets=true");

        return new IdentityDbContext(optionsBuilder.Options);
    }
}