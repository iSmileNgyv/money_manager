namespace MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetAllTransactionProduct;

public class GetAllTransactionProductQueryResponse
{
    public Guid Id { get; set; }
    public Guid TransactionId { get; set; }
    public Guid ProductId { get; set; }
    public required string ProductName { get; set; }
    public float Quantity { get; set; }
    public decimal Price { get; set; }
    
}