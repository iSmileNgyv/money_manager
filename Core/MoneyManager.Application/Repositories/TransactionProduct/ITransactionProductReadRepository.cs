namespace MoneyManager.Application.Repositories.TransactionProduct;

public interface ITransactionProductReadRepository : IReadRepository<Domain.Entities.TransactionProduct>
{
    IQueryable<Domain.Entities.TransactionProduct> GetByTransactionIdAsync(Guid transactionId, CancellationToken ct = default);
}