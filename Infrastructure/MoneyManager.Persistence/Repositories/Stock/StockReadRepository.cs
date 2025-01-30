using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Features.CQRS.Queries.Stock.GetFilteredStock;
using MoneyManager.Application.Repositories.Stock;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Stock;

public class StockReadRepository(MainContext context) : ReadRepository<Domain.Entities.Stock>(context), IStockReadRepository
{
    private readonly MainContext _context = context;

    public async Task<List<Domain.Entities.Stock>> FilterAsync(GetFilteredStockQueryRequest request, CancellationToken ct = default)
    {
        IQueryable<Domain.Entities.Stock> query = _context.Stocks.AsNoTracking();
        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(stock => stock.Name.Trim().ToLower().Contains(request.Name.Trim().ToLower()));
        }

        return await query.ToListAsync(ct);
    }
}