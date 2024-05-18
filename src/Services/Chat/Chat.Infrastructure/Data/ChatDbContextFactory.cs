using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Chat.Infrastructure.Data;

public class ChatDbContextFactory : IDesignTimeDbContextFactory<ChatDbContext>
{
    public ChatDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ChatDbContext>();
        optionsBuilder.UseSqlServer(
            "Server=.;Database=MeetChatDb;TrustServerCertificate=true;Trusted_Connection=True;MultipleActiveResultSets=true");
        return new ChatDbContext(optionsBuilder.Options);
    }
}