using System.ComponentModel.DataAnnotations;
using MoneyManager.Domain.Entities.Common;
using MoneyManager.Domain.Entities.Identity;

namespace MoneyManager.Domain.Entities;

public class Category : BaseEntity
{
    [MaxLength(100)]
    public required string Name { get; set; }
    [MaxLength(1000)]
    public string? Image { get; set; }
    public Media? Media { get; set; }
    [MaxLength(2000)]
    public string? Description { get; set; }
    public int Level { get; set; }
    public CategoryType CategoryType { get; set; } = CategoryType.Minus;
    [MaxLength(100)]
    public Guid? CategoryId { get; set; }
    public Category? ParentCategory { get; set; }
    public ICollection<Product>? Products { get; set; }
    public ICollection<Cashback>? Cashbacks { get; set; }
    public ICollection<Transaction>? Transactions { get; set; }
}