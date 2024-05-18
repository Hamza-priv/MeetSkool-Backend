namespace Chat.Application.Dtos.Request.Messages;

public class GetUserConversationRequestDto
{
    public string? SenderId { get; set; }
    public string? ReceiverId { get; set; }
}