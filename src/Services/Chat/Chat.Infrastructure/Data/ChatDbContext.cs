using Chat.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Chat.Infrastructure.Data;

public class ChatDbContext : DbContext
{
    public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
    {
    }

    public DbSet<Messages> Messages { get; set; }
    public DbSet<Groups> Groups { get; set; }
    public DbSet<UserConnections> UserConnections { get; set; }
    public DbSet<Conversations> Conversations { get; set; }
}