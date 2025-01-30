using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.CreateTransactionProduct;

public class CreateTransactionProductCommandHandler(
    ITransactionProductService service
    ): IRequestHandler<CreateTransactionProductCommandRequest, CreateTransactionProductCommandResponse>
{
    public async Task<CreateTransactionProductCommandResponse> Handle(CreateTransactionProductCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.CreateTransactionProductAsync(request, cancellationToken);
    }
}