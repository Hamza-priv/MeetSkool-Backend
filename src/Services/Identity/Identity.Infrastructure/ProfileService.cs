using System.Security.Claims;
using Identity.Core.Entities;
using Identity.Infrastructure.Data;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Identity.Infrastructure;

public class ProfileService : IProfileService
{
    /// The user claims principal factory.
    /// </summary>
    private readonly IUserClaimsPrincipalFactory<MeetSkoolIdentityUser> _userClaimsPrincipalFactory;

    /// <summary>
    /// The user manager.
    /// </summary>
    private readonly UserManager<MeetSkoolIdentityUser> _userManager;

    /// <summary>
    /// The role manager.
    /// </summary>
    private readonly RoleManager<MeetSkoolIdentityRole> _roleManager;

    /// <summary>
    /// IdentityDbContext.
    /// </summary>
    private readonly IdentityDbContext _dbContext;

    public ProfileService(IUserClaimsPrincipalFactory<MeetSkoolIdentityUser> userClaimsPrincipalFactory,
        UserManager<MeetSkoolIdentityUser> userManager, RoleManager<MeetSkoolIdentityRole> roleManager,
        IdentityDbContext identityDbContext, ILogger<ProfileService> logger)
    {
        this._userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        this._userManager = userManager;
        this._roleManager = roleManager;
        this._dbContext = identityDbContext;
    }

    public async Task GetProfileDataAsync(ProfileDataRequestContext context)
    {
        var sub = context.Subject.GetSubjectId();

        var user = await this.GetUserWithNavigationProperties(sub);
        var userClaims = await this._userClaimsPrincipalFactory.CreateAsync(user);
        var claims = userClaims.Claims.ToList();
        claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

        claims.Add(new Claim("UserId", user.Id.ToString()));

        if (this._userManager.SupportsUserRole)
        {
            var userclaims = await this._userManager.GetClaimsAsync(user);
            if (userclaims != null)
            {
                foreach (var userclaim in userclaims)
                {
                    claims.Add(new Claim(userclaim.Type, userclaim.Value));
                }
            }

            var roles = await this._userManager.GetRolesAsync(user);
            foreach (var roleName in roles)
            {
                claims.Add(new Claim(JwtClaimTypes.Role, roleName));
                if (!this._roleManager.SupportsRoleClaims) continue;
                var role = await this._roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    claims.AddRange(await this._roleManager.GetClaimsAsync(role));
                }
            }
        }

        context.IssuedClaims = claims;
    }


    public async Task IsActiveAsync(IsActiveContext context)
    {
        var sub = context.Subject.GetSubjectId();
        var applicationUser = await this._userManager.FindByIdAsync(sub);
        context.IsActive = applicationUser != null;
    }

    /// <summary>
    /// This method load required navigation prop.
    /// </summary>
    /// <param name="subjectId">The subjectId<see cref="string"/>.</param>
    /// <returns>The <see cref="Task{ApplicationUser}"/>.</returns>
    private async Task<MeetSkoolIdentityUser> GetUserWithNavigationProperties(string subjectId)
    {
        var user = await this._userManager.Users
            .FirstOrDefaultAsync(x => x.Id == Guid.Parse(subjectId));
        return user;
    }
}