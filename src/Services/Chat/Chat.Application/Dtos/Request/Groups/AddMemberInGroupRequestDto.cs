namespace Chat.Application.Dtos.Request.Groups;

public class AddMemberInGroupRequestDto
{
    public string? MemberId { get; set; }
    public string? GroupId { get; set; }
    public string? MemberName { get; set; }
}