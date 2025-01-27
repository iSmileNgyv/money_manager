using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Transaction.RemoveTransaction;

public class RemoveTransactionCommandRequest: IRequest<RemoveTransactionCommandResponse>
{
    public Guid Id { get; set; }
}