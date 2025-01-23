using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Domain.Entities;

public class Cashback: BaseEntity
{
    public Guid PaymentMethodId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public Guid? StockId { get; set; }
    public Stock? Stock { get; set; }
    public Guid? CategoryId { get; set; }
    public Category? Category { get; set; }
    public float Percentage { get; set; } = 0;
}