using MoneyManager.Application.Repositories.TransactionProduct;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.TransactionProduct;

public class TransactionProductWriteRepository(MainContext context) : WriteRepository<Domain.Entities.TransactionProduct>(context), ITransactionProductWriteRepository;