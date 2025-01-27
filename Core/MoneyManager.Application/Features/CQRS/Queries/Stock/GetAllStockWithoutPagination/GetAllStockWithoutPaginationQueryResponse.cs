namespace MoneyManager.Application.Features.CQRS.Queries.Stock.GetAllStockWithoutPagination;

public class GetAllStockWithoutPaginationQueryResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}