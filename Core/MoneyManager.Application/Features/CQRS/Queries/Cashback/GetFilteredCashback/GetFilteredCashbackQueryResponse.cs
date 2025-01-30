namespace MoneyManager.Application.Features.CQRS.Queries.Cashback.GetFilteredCashback;

public class GetFilteredCashbackQueryResponse
{
    public Guid Id { get; set; }
    public required string PaymentMethodName { get; set; }
    public Guid PaymentMethodId { get; set; }
    public string? StockName { get; set; }
    public Guid? StockId { get; set; }
    public string? CategoryName { get; set; }
    public Guid? CategoryId { get; set; }
    public float Percentage { get; set; }
    public DateTime CreatedDate { get; set; }
}