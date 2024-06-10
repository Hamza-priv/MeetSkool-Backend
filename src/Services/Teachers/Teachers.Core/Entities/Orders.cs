using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teachers.Core.Entities;

public class Orders
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid OrderId { get; set; }

    public string? OrderById { get; set; }
    public string? OrderToId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? Status { get; set; }
}