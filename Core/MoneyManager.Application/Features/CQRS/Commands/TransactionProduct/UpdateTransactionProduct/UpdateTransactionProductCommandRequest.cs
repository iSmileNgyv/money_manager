using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.UpdateTransactionProduct;

public class UpdateTransactionProductCommandRequest: IRequest<UpdateTransactionProductCommandResponse>
{
    public Guid Id { get; set; }
    public Guid TransactionId { get; set; }
    public Guid ProductId { get; set; }
    public float Quantity { get; set; } = 0;
    public decimal Price { get; set; }
}