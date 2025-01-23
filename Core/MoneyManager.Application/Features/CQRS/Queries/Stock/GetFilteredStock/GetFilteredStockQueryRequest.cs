using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Stock.GetFilteredStock;

public class GetFilteredStockQueryRequest: IRequest<List<GetFilteredStockQueryResponse>>
{
    public string? Name { get; set; }
}