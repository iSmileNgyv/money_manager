namespace MoneyManager.Application.Features.CQRS.Queries.Transaction.GetAllTransaction;

public class GetAllTransactionQueryResponse
{
    public Guid Id { get; set; }
    public Guid PaymentMethodId { get; set; }
    public required string PaymentMethodName { get; set; }
    public Guid CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public Guid? StockId { get; set; }
    public string? StockName { get; set; }
    public decimal Amount { get; set; } = 0;
    public decimal CashbackAmount { get; set; } = 0;
}