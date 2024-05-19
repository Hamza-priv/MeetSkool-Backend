using Chat.Core.IRepository;
using Contracts;
using MassTransit;

namespace Chat.Infrastructure.Consumer;

public sealed class AddMemberToGroupConsumer : IConsumer<AddMemberInGroupEvent>
{
    private readonly IGroupRepository _groupRepository;

    public AddMemberToGroupConsumer(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task Consume(ConsumeContext<AddMemberInGroupEvent> context)
    {
        try
        {
            if (context.Message is { MemberId: not null, MemberName: not null, GroupId: not null })
                await _groupRepository.AddMemberToGroup(context.Message.MemberId, context.Message.GroupId,
                    context.Message.MemberName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}