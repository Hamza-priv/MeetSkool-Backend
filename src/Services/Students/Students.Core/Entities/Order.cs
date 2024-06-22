using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Core.Entities;

public class Order
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public string? OrderId { get; set; }
    public string? OrderById { get; set; }
    public string? OrderToId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? Status { get; set; }
}