using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Stock.GetAllStockWithoutPagination;

public class GetAllStockWithoutPaginationQueryRequest: IRequest<List<GetAllStockWithoutPaginationQueryResponse>>;