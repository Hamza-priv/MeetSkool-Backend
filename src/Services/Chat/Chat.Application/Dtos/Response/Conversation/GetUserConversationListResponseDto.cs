namespace Chat.Application.Dtos.Response.Conversation;

public class GetUserConversationListResponseDto
{
    public Guid ConversationId { get; set; }
    public string? UserId { get; set; }
    public string? ParticipantId { get; set; }}