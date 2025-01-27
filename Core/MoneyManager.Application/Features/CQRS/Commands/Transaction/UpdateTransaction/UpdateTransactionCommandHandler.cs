using MediatR;
using MoneyManager.Application.Features.CQRS.Commands.Transaction.RemoveTransaction;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Transaction.UpdateTransaction;

public class UpdateTransactionCommandHandler(
    ITransactionService service
    ): IRequestHandler<UpdateTransactionCommandRequest, UpdateTransactionCommandResponse>
{
    public async Task<UpdateTransactionCommandResponse> Handle(UpdateTransactionCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.UpdateTransactionAsync(request, cancellationToken);
    }
}