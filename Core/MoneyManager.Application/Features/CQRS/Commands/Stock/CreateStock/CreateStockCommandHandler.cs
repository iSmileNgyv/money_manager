using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Stock.CreateStock;

public class CreateStockCommandHandler(
    IStockService service
    ): IRequestHandler<CreateStockCommandRequest, CreateStockCommandResponse>
{
    public async Task<CreateStockCommandResponse> Handle(CreateStockCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.CreateStockAsync(request, cancellationToken);
    }
}