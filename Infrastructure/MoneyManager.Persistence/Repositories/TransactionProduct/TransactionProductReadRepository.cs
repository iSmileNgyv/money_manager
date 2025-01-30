using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Repositories.TransactionProduct;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.TransactionProduct;

public class TransactionProductReadRepository(MainContext context) : ReadRepository<Domain.Entities.TransactionProduct>(context), ITransactionProductReadRepository
{
    private readonly MainContext _context = context;

    public IQueryable<Domain.Entities.TransactionProduct> GetByTransactionIdAsync(Guid transactionId, CancellationToken ct = default)
    {
        return _context.TransactionProducts.AsNoTracking().Where(x => x.TransactionId == transactionId);
    }
}