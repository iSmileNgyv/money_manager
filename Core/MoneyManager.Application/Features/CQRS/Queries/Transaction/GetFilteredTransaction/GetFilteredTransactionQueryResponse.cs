using MoneyManager.Application.Features.CQRS.Queries.Common;
using MoneyManager.Application.Features.CQRS.Queries.Transaction.GetAllTransaction;

namespace MoneyManager.Application.Features.CQRS.Queries.Transaction.GetFilteredTransaction;

public class GetFilteredTransactionQueryResponse
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
    public DateOnly EventDate { get; set; }
    public decimal CashbackAmount { get; set; } = 0;
    public DateTime CreatedDate { get; set; }
}