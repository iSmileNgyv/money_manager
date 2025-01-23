using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Stock.RemoveStock;

public class RemoveStockCommandHandler(
    IStockService service
    ): IRequestHandler<RemoveStockCommandRequest, RemoveStockCommandResponse>
{
    public async Task<RemoveStockCommandResponse> Handle(RemoveStockCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.RemoveStockAsync(request, cancellationToken);
    }
}