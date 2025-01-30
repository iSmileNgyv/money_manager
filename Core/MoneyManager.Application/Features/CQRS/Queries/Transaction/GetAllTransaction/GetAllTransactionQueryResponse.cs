using MoneyManager.Application.Features.CQRS.Queries.Common;

namespace MoneyManager.Application.Features.CQRS.Queries.Transaction.GetAllTransaction;

public class GetAllTransactionQueryResponse
{
    public Guid Id { get; set; }
    public Guid PaymentMethodId { get; set; }
    public required string PaymentMethodName { get; set; }
    public ImageResponse? PaymentMethodImage { get; set; }
    public Guid CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public ImageResponse? CategoryImage { get; set; }
    public Guid? StockId { get; set; }
    public string? StockName { get; set; }
    public ImageResponse? StockImage { get; set; }
    public decimal Amount { get; set; } = 0;
    public decimal CashbackAmount { get; set; } = 0;
    public DateTime CreatedDate { get; set; }
}