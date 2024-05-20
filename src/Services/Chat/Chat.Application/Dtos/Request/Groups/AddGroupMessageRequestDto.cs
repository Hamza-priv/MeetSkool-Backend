namespace Chat.Application.Dtos.Request.Groups;

public class AddGroupMessageRequestDto
{
    public string? Message { get; set; }
    public string? SenderId { get; set; }
    public string? SenderName { get; set; }
    public string? GroupId { get; set; }
}