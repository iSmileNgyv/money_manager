using System.ComponentModel.DataAnnotations;
using MoneyManager.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
namespace MoneyManager.Domain.Entities;
[Index(nameof(Path))]
public class Media : BaseEntity
{
    [MaxLength(1000)]
    public required string Path { get; set; }
    [MaxLength(500)]
    public required string FileName { get; set; }
    public ICollection<Category>? Categories { get; set; }
    public ICollection<PaymentMethod>? PaymentMethods { get; set; }
    public ICollection<Product>? Products { get; set; }
}