namespace Chat.Application.Dtos.Response.Messages;

public class GetUserConversationResponseDto
{
    public Guid MessageId { get; set; }
    public string? Message { get; set; }
    public string? SenderName { get; set; }
    public string? ReceiverName { get; set; }
    public string? SenderId { get; set; }
    public string? ReceiverId { get; set; }
    public DateTime Date { get; set; }
}