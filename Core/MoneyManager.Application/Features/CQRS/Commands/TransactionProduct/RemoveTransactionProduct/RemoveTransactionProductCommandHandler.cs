using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.RemoveTransactionProduct;

public class RemoveTransactionProductCommandHandler(
    ITransactionProductService service
    ): IRequestHandler<RemoveTransactionProductCommandRequest, RemoveTransactionProductCommandResponse>
{
    public async Task<RemoveTransactionProductCommandResponse> Handle(RemoveTransactionProductCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.RemoveTransactionProductAsync(request, cancellationToken);
    }
}