using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Transaction.RemoveTransaction;

public class RemoveTransactionCommandHandler(
    ITransactionService service
    ): IRequestHandler<RemoveTransactionCommandRequest, RemoveTransactionCommandResponse>
{
    public async Task<RemoveTransactionCommandResponse> Handle(RemoveTransactionCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.RemoveTransactionAsync(request, cancellationToken);
    }
}