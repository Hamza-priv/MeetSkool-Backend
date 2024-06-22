using Notification.Core.Entities;

namespace Notification.Core.IRepository;

public interface IOrderTokenRepository
{
    Task AddToken(string token, string teacherId);
    Task<OrderToken?> GetToken(string token);
}