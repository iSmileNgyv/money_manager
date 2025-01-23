using System.ComponentModel.DataAnnotations;
using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Domain.Entities;

public class Product : BaseEntity
{
     [MaxLength(100)]
     public required string Name { get; set; }
     [MaxLength(1000)]
     public string? Image { get; set; }

     public decimal Price { get; set; } = 0;
     [MaxLength(2000)]
     public string? Description { get; set; }
     public Guid CategoryId { get; set; }
     public Category Category { get; set; }
     public Media? Media { get; set; }
}