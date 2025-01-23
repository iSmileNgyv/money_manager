using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Stock.GetAllStock;

public class GetAllStockQueryRequest: IRequest<List<GetAllStockQueryResponse>>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
}