using MoneyManager.Application.Repositories.Transaction;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Transaction;

public class TransactionWriteRepository(MainContext context) : WriteRepository<Domain.Entities.Transaction>(context), ITransactionWriteRepository;