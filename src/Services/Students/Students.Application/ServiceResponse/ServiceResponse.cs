namespace Students.Application.ServiceResponse;

public class ServiceResponse<T> 
{
    public T? Data { get; set; }
    public bool Success { get; set; } = true;
    public List<string> Messages { get; set; } = new List<string>();
    public List<string> Error { get; set; } = new List<string>();
}