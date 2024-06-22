namespace Students.Application.DTOS.Request.OrderDto;

public class AddOrderRequestDto
{
    public string? OrderId { get; set; }
    public string? OrderById { get; set; }
    public string? OrderToId { get; set; }
    public string? Status { get; set; }

    public DateTime Date { get; set; }
}