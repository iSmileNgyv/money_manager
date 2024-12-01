using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Domain.Entities;

public class ProductCategory : BaseEntity
{
    public required string Name { get; set; }
    public required string Image { get; set; }
    public string? Description { get; set; }
    public Guid? ParentCategoryId { get; set; }
    public int Level { get; set; } = 1;
    public ICollection<Product> Products { get; set; } = new List<Product>();
}