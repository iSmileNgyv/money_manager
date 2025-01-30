using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.UpdateTransactionProduct;

public class UpdateTransactionProductCommandHandler(
    ITransactionProductService service
    ): IRequestHandler<UpdateTransactionProductCommandRequest, UpdateTransactionProductCommandResponse>
{
    public async Task<UpdateTransactionProductCommandResponse> Handle(UpdateTransactionProductCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.UpdateTransactionProductAsync(request, cancellationToken);
    }
}