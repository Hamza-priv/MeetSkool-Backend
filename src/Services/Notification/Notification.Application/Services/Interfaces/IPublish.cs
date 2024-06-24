namespace Notification.Application.Services.Interfaces;

public interface IPublish
{
    // pending
    public Task PublishOrderToStudent(string studentId, string orderId, string teacherId);

    public Task PublishOrderToTeacher(string teacherId, string orderId, string studentId);

    // confirmed
    public Task PublishOrderConfirmationStudent(string orderId);

    public Task PublishOrderConfirmationTeacher(string orderId);

    // declined
    public Task PublishOrderCancellationToStudent(string orderId);

    public Task PublishOrderCancellationToTeacher(string orderId);

    // complete 
    public Task PublishOrderCompleteToTeacher(string orderId, string teacherId);
    public Task PublishOrderCompleteToStudent(string orderId, string studentId);
    
    // Email publishers
    
    // todo
    public Task PublishOrderSentEmail(string teacherId, string studentId);
    public Task PublishOrderConfirmEmail(string teacherId, string studentId);
    public Task PublishOrderCancelEmail(string teacherId, string studentId);
    public Task PublishOrderCompleteEmail(string teacherId, string studentId);
}