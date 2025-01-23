using MoneyManager.Application.Repositories.Cashback;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Cashback;

public class CashbackReadRepository(MainContext context) : ReadRepository<Domain.Entities.Cashback>(context), ICashbackReadRepository;