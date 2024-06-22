using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Notification.Infrastructure.Data;

public class NotificationDbContextFactory : IDesignTimeDbContextFactory<NotificationDbContext>
{
    public NotificationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<NotificationDbContext>();
        optionsBuilder.UseSqlServer("Server=.;Database=MeetSkoolNotificationDb;TrustServerCertificate=true;Trusted_Connection=True;MultipleActiveResultSets=true");
        return new NotificationDbContext(optionsBuilder.Options);
    }
}