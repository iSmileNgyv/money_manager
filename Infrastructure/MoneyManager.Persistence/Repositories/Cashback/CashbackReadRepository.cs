using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Features.CQRS.Queries.Cashback.GetFilteredCashback;
using MoneyManager.Application.Repositories.Cashback;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Cashback;

public class CashbackReadRepository(MainContext context) : ReadRepository<Domain.Entities.Cashback>(context), ICashbackReadRepository
{
    private readonly MainContext _context = context;

    public async Task<List<Domain.Entities.Cashback>> FilterAsync(GetFilteredCashbackQueryRequest request)
    {
        IQueryable<Domain.Entities.Cashback> query = _context.Cashbacks.AsNoTracking();
        if (request.CategoryId.HasValue)
        {
            query = query.Where(p => p.CategoryId == request.CategoryId);
        }

        if (request.PaymentMethodId.HasValue)
        {
            query = query.Where(p => p.PaymentMethodId == request.PaymentMethodId);
        }

        if (request.StockId.HasValue)
        {
            query = query.Where(p => p.StockId == request.StockId);
        }

        query = query.Include(p => p.Category)
            .Include(p => p.PaymentMethod)
            .Include(p => p.Stock);
        return await query.ToListAsync();
    }
}