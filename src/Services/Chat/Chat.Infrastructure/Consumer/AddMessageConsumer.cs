using Chat.Core.IRepository;
using Chat.Core.Models;
using MassTransit;

namespace Chat.Infrastructure.Consumer;

public class AddMessageConsumer : IConsumer<Messages>
{
    private readonly IMessageRepository _messageRepository;

    public AddMessageConsumer(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task Consume(ConsumeContext<Messages> context)
    {
        try
        {
            await _messageRepository.AddAsync(context.Message);
            Console.WriteLine("Worked hurry");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}