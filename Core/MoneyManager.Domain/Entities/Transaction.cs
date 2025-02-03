using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Domain.Entities;

public class Transaction: BaseEntity
{
    public Guid PaymentMethodId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? StockId { get; set; }
    public DateOnly EventDate { get; set; }
    public decimal Amount { get; set; } = 0;
    public decimal CashbackAmount { get; set; } = 0;
    public ICollection<TransactionProduct>? TransactionProducts { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public Category Category { get; set; }
    public Stock? Stock { get; set; }
}