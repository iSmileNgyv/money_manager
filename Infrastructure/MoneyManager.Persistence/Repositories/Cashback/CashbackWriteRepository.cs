using MoneyManager.Application.Repositories.Cashback;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Cashback;

public class CashbackWriteRepository(MainContext context) : WriteRepository<Domain.Entities.Cashback>(context), ICashbackWriteRepository;