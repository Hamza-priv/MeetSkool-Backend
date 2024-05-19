namespace Chat.Application.Dtos.Request.Groups;

public class RemoveMemberFromGroupRequestDto
{
    public string? MemberId { get; set; }
    public string? GroupId { get; set; }
}