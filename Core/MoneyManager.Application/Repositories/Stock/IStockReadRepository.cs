using MoneyManager.Application.Features.CQRS.Queries.Stock.GetFilteredStock;

namespace MoneyManager.Application.Repositories.Stock;

public interface IStockReadRepository : IReadRepository<Domain.Entities.Stock>
{
    Task<List<Domain.Entities.Stock>> FilterAsync(GetFilteredStockQueryRequest request, CancellationToken ct = default);
}