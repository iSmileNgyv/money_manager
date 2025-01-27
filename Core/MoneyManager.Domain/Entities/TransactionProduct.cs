using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Domain.Entities;

public class TransactionProduct: BaseEntity
{
    public Guid TransactionId { get; set; }
    public Guid ProductId { get; set; }
    public float Quantity { get; set; } = 0;
    public decimal Price { get; set; }
    public Transaction Transaction { get; set; }
    public Product Product { get; set; }
}