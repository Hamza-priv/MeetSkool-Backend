using Notification.Core.Entities;

namespace Notification.Core.IRepository;

public interface IOrderTokenRepository
{
    Task AddToken(string token, string teacherId);
    Task<OrderToken?> GetToken(string token);

    Task<List<string?>> Get24HourOldToken();
    Task<List<string?>> Get48HourOldToken();
    Task<List<string?>> Get72HourOldToken();
}