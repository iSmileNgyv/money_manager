using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Transaction.CreateTransaction;

public class CreateTransactionCommandHandler(
    ITransactionService service
    ): IRequestHandler<CreateTransactionCommandRequest, CreateTransactionCommandResponse>
{
    public async Task<CreateTransactionCommandResponse> Handle(CreateTransactionCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.CreateTransactionAsync(request, cancellationToken);
    }
}