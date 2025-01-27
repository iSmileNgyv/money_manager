using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Stock.GetAllStockWithoutPagination;

public class GetAllStockWithoutPaginationQueryHandler(
    IStockService service
    ): IRequestHandler<GetAllStockWithoutPaginationQueryRequest, List<GetAllStockWithoutPaginationQueryResponse>>
{
    public async Task<List<GetAllStockWithoutPaginationQueryResponse>> Handle(GetAllStockWithoutPaginationQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetAllStocksWithoutPaginationAsync(request, cancellationToken);
    }
}