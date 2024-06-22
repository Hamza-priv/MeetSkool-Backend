using AutoMapper;
using Contracts.NotificationAndOrderContracts;
using MassTransit;
using Students.Application.DTOS.Request.OrderDto;
using Students.Application.Services.Interfaces;
using Students.Infrastructure;

namespace Students.Application.Consumers;

public class AddOrderConsumers : IConsumer<OrderCreationEventStudent>
{
    private readonly IOrderServices _orderServices;
    private readonly IMapper _mapper;

    public AddOrderConsumers(IOrderServices orderServices, IMapper mapper)
    {
        _orderServices = orderServices;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<OrderCreationEventStudent> context)
    {
        try
        {
            var order = new AddOrderRequestDto()
            {
                OrderToId = context.Message.TeacherId,
                OrderById = context.Message.StudentId,
                Status = Status.Pending,
                OrderId = context.Message.OrderId,
                Date = context.Message.CreationDate
            };
            await _orderServices.CreateOrder(order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}