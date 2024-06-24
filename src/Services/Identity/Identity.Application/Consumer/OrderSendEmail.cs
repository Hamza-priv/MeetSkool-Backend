using Contracts.OrderAndEmailContracts;
using Identity.Application.Services.Interfaces;
using Identity.Core.Entities;
using MassTransit;
using Microsoft.AspNetCore.Identity;

namespace Identity.Application.Consumer;

public class OrderSendEmail : IConsumer<OrderSentEmailEvent>
{
    private readonly UserManager<MeetSkoolIdentityUser> _userManager;
    private readonly IEmailServices _emailServices;

    public OrderSendEmail(UserManager<MeetSkoolIdentityUser> userManager, IEmailServices emailServices)
    {
        _userManager = userManager;
        _emailServices = emailServices;
    }
    public async Task Consume(ConsumeContext<OrderSentEmailEvent> context)
    {
        try
        {
            var teacher = await _userManager.FindByIdAsync(context.Message.TeacherId);
            if (teacher != null)
            {
                var teacherEmail = teacher.Email;
                var teacherName = teacher.FullName;
                if (teacherName != null)
                    if (teacherEmail != null)
                        await _emailServices.OrderSentEmail(context.Message.TeacherId, teacherName, teacherEmail);
            }

            var student = await _userManager.FindByIdAsync(context.Message.StudentId);
            if (student != null)
            {
                var studentEmail = student.Email;
                var studentName = student.FullName;
                if (studentEmail != null && studentName != null)
                {
                    await _emailServices.OrderSentEmail(context.Message.StudentId, studentName, studentEmail);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}