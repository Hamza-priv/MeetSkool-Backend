using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Core.Entities;

public class Order
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid OrderId { get; set; } = Guid.NewGuid();
    public string? OrderById { get; set; }
    public string? OrderToId { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now.ToLocalTime();
    public string? Status { get; set; }
}