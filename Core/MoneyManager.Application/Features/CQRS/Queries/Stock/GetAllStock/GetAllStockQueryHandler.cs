using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Stock.GetAllStock;

public class GetAllStockQueryHandler(
    IStockService service
    ): IRequestHandler<GetAllStockQueryRequest, List<GetAllStockQueryResponse>>
{
    public async Task<List<GetAllStockQueryResponse>> Handle(GetAllStockQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetAllStocksAsync(request, cancellationToken);
    }
}