using MoneyManager.Application.Features.CQRS.Queries.Transaction.GetFilteredTransaction;

namespace MoneyManager.Application.Repositories.Transaction;

public interface ITransactionReadRepository : IReadRepository<Domain.Entities.Transaction>
{
    Task<List<Domain.Entities.Transaction>> FilterAsync(GetFilteredTransactionQueryRequest request, CancellationToken ct = default);
}