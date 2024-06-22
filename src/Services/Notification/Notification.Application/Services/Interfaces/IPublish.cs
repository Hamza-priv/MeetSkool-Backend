namespace Notification.Application.Services.Interfaces;

public interface IPublish
{
    // pending
    public Task PublishOrderToStudent(string studentId, string orderId, string teacherId);
    public Task PublishOrderToTeacher(string teacherId, string orderId, string studentId);
    // confirmed
    public Task PublishOrderConfirmation (string orderId);
    // declined
    public Task PublishOrderCancellationToStudent(string orderId);  
    // complete 
    public Task PublishOrderCompleteToTeacher(string teacherId, string orderId);
    public Task PublishOrderCompleteToStudent(string studentId, string orderId);
    
}