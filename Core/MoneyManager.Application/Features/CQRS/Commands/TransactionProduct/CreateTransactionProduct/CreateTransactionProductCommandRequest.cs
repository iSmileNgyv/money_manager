using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.CreateTransactionProduct;

public class CreateTransactionProductCommandRequest: IRequest<CreateTransactionProductCommandResponse>
{
    public Guid TransactionId { get; set; }
    public Guid ProductId { get; set; }
    public float Quantity { get; set; } = 0;
    public decimal Price { get; set; }
}