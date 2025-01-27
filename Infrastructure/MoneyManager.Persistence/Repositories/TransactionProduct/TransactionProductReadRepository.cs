using MoneyManager.Application.Repositories.TransactionProduct;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.TransactionProduct;

public class TransactionProductReadRepository(MainContext context) : ReadRepository<Domain.Entities.TransactionProduct>(context), ITransactionProductReadRepository;