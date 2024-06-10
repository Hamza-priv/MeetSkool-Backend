namespace Students.Application.DTOS.Request.OrderDto;

public class AddOrderRequestDto
{
    public string? OrderById { get; set; }
    public string? OrderToId { get; set; }
    public string? Status { get; set; }
}