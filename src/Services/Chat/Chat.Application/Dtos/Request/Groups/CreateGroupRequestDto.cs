namespace Chat.Application.Dtos.Request.Groups;

public class CreateGroupRequestDto
{
    public required string GroupId { get; set; }
    public required string GroupOwnerName { get; set; }
}