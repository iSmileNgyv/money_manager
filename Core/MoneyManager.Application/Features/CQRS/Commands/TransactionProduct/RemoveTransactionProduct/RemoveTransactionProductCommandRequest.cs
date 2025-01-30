using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.RemoveTransactionProduct;

public class RemoveTransactionProductCommandRequest: IRequest<RemoveTransactionProductCommandResponse>
{
    public Guid Id { get; set; }
}