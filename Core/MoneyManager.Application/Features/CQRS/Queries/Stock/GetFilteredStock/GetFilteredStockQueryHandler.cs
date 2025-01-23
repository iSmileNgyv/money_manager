using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Stock.GetFilteredStock;

public class GetFilteredStockQueryHandler(
    IStockService service
    ): IRequestHandler<GetFilteredStockQueryRequest, List<GetFilteredStockQueryResponse>>
{
    public async Task<List<GetFilteredStockQueryResponse>> Handle(GetFilteredStockQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.FilterStocksAsync(request, cancellationToken);
    }
}