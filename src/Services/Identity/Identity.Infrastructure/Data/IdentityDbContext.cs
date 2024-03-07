using Identity.Core.Entities;

namespace Identity.Infrastructure.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class IdentityDbContext : IdentityDbContext<MeetSkoolIdentityUser, MeetSkoolIdentityRole, Guid>,
    IIdentityDbContext
{
    public IdentityDbContext()
    {
    }

    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<MeetSkoolIdentityRole>().HasData(PreConfiguredRoles());
        builder.Entity<IdentityUserRole<Guid>>().HasData(PreConfiguredUserRoles());
        builder.Entity<MeetSkoolIdentityUser>().HasData(PreConfiguredUsers());

        base.OnModelCreating(builder);
    }

    private static IEnumerable<MeetSkoolIdentityUser> PreConfiguredUsers()
    {
        return new List<MeetSkoolIdentityUser>
        {
            new MeetSkoolIdentityUser
            {
                Id = Guid.Parse("D9EE83BA-5C37-4568-8741-6D32FE6ABE31"),
                Email = "meetskooladmin@gmail.com",
                UserName = "meetskooladmin@gmail.com",
                NormalizedEmail = "meetskooladmin@gmail.com",
                NormalizedUserName = "meetskooladmin@gmail.com",
                PasswordHash =
                    "AQAAAAEAACcQAAAAEFJBsZTjE9AqOrwS+CySVTD0kxEzyfTse193tEbIu1i/lLd8KIyggZ07addvMEJqBA==",
                EmailConfirmed = true,
                SecurityStamp = "FWAW2AFMQGJ3SHHOHGEBLIQN4JLVRO3N",
                ConcurrencyStamp = "4d058224-0e54-476a-81d0-0215890c2ebb",
                PhoneNumber = "1111111111",
                PhoneNumberConfirmed = true,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0,
                CreatedDate = DateTime.Now,
                FullName = "Hamza Ahmed Khan"
            }
        };
    }

    private static IEnumerable<IdentityUserRole<Guid>> PreConfiguredUserRoles()
    {
        return new List<IdentityUserRole<Guid>>
        {
            new IdentityUserRole<Guid>
            {
                UserId = Guid.Parse("D9EE83BA-5C37-4568-8741-6D32FE6ABE31"),
                RoleId = Guid.Parse("E8D090A8-208A-4E6C-87A4-BF0E10D03D60")
            }
        };
    }

    private static IEnumerable<MeetSkoolIdentityRole> PreConfiguredRoles()
    {
        return new List<MeetSkoolIdentityRole>
        {
            new MeetSkoolIdentityRole
            {
                Name = Constants.SuperAdmin,
                NormalizedName = Constants.SuperAdmin,
                Id = Guid.Parse("E8D090A8-208A-4E6C-87A4-BF0E10D03D60")
            },
            new MeetSkoolIdentityRole
            {
                Name = Constants.Student,
                NormalizedName = Constants.Student,
                Id = Guid.Parse("3C933802-7908-401A-B452-8FDD0D23B860")
            },
            new MeetSkoolIdentityRole
            {
                Name = Constants.Teacher,
                NormalizedName = Constants.Teacher,
                Id = Guid.Parse("670BDE63-66C5-47BF-97B4-975077AF7927")
            }
        };
    }
}