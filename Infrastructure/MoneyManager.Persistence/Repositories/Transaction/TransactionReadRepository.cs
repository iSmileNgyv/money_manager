using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Features.CQRS.Queries.Transaction.GetFilteredTransaction;
using MoneyManager.Application.Repositories.Transaction;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Transaction;

public class TransactionReadRepository(MainContext context) : ReadRepository<Domain.Entities.Transaction>(context), ITransactionReadRepository
{
    private readonly MainContext _context = context;

    public async Task<List<Domain.Entities.Transaction>> FilterAsync(GetFilteredTransactionQueryRequest request, CancellationToken ct = default)
    {
        IQueryable<Domain.Entities.Transaction> query = _context.Transactions.AsNoTracking()
            .Include(t => t.PaymentMethod)
            .Include(t => t.Stock)
            .Include(t => t.Category)
            .OrderByDescending(t => t.EventDate)
            .ThenByDescending(t => t.CreatedDate);
        if (request.CategoryId.HasValue)
        {
            query = query.Where(t => t.CategoryId == request.CategoryId);
        }

        if (request.StockId.HasValue)
        {
            query = query.Where(t => t.StockId == request.StockId);
        }

        return await query.ToListAsync(ct);
    }
}