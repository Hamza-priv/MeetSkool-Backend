using Chat.Core.IRepository;
using Chat.Core.Models;
using MassTransit;

namespace Chat.Infrastructure.Consumer;

public class AddGroupConsumer : IConsumer<Groups>
{
    private readonly IGroupRepository _groupRepository;

    public AddGroupConsumer(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task Consume(ConsumeContext<Groups> context)
    {
        try
        {
            var res = await _groupRepository.AddAsync(context.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}