using System.Collections;
using System.ComponentModel.DataAnnotations;
using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Domain.Entities;

public class Stock: BaseEntity
{
    [MaxLength(50)]
    public required string Name { get; set; }
    [MaxLength(1000)]
    public string? Image { get; set; }
    public ICollection<Cashback>? Cashbacks { get; set; }
}