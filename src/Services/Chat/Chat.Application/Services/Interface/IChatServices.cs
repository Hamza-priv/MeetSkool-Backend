namespace Chat.Application.Services.Interface;

public interface IChatServices
{
    Task UserConnected(string userId);
    Task CreateGroup(string groupId);
    Task AddUserToGroup(string userJoinedMessage);
    Task RemoveUserFromGroup(string userLeftMessage);
    Task SendMessageToGroup(string message);
    
    Task SendMessageToUser(string fromuserId, string message);
}