using Chat.Core.IRepository;
using Contracts;
using MassTransit;

namespace Chat.Infrastructure.Consumer;

public sealed class RemoveMemberFromGroupConsumer : IConsumer<RemoveMemberFromGroupEvent>
{
    private readonly IGroupRepository _groupRepository;

    public RemoveMemberFromGroupConsumer(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task Consume(ConsumeContext<RemoveMemberFromGroupEvent> context)
    {
        try
        {
            if (context.Message is { GroupId: not null, MemberId: not null })
                await _groupRepository.RemoveMemberFromGroup(context.Message.MemberId, context.Message.GroupId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}