namespace Contracts;

public class AddMemberInGroupEvent
{
    public string? MemberId { get; set; }
    public string? GroupId { get; set; }
    public string? MemberName { get; set; }
}