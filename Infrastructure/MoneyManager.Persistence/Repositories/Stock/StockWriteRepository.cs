using MoneyManager.Application.Repositories.Stock;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Stock;

public class StockWriteRepository(MainContext context) : WriteRepository<Domain.Entities.Stock>(context), IStockWriteRepository;