using MoneyManager.Application.Repositories.Transaction;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Transaction;

public class TransactionReadRepository(MainContext context) : ReadRepository<Domain.Entities.Transaction>(context), ITransactionReadRepository;