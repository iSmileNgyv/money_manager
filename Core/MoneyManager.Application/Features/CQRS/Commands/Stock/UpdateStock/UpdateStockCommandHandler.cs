using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Stock.UpdateStock;

public class UpdateStockCommandHandler(
    IStockService service
    ): IRequestHandler<UpdateStockCommandRequest, UpdateStockCommandResponse>
{
    public async Task<UpdateStockCommandResponse> Handle(UpdateStockCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.UpdateStockAsync(request, cancellationToken);
    }
}