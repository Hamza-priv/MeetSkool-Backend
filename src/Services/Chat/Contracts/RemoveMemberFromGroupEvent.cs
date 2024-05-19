namespace Contracts;

public class RemoveMemberFromGroupEvent
{
    public string? MemberId { get; set; }
    public string? GroupId { get; set; }
}