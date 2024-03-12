using Microsoft.AspNetCore.Identity;

namespace Identity.Core.Entities;

public class MeetSkoolIdentityUser : IdentityUser<Guid>
{
    public string? FullName { get; set; }
    
    public string? UserImage { get; set; } 
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}