using System.ComponentModel.DataAnnotations;
using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Domain.Entities;

public class Category : BaseEntity
{
    [MaxLength(100)]
    public required string Name { get; set; }
    [MaxLength(1000)]
    public required string Image { get; set; }
    [MaxLength(2000)]
    public string? Description { get; set; }
    public int Level { get; set; }
    public Guid CategoryId { get; set; }
}