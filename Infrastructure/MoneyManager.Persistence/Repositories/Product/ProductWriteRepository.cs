using MoneyManager.Application.Repositories.Product;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Product;

public class ProductWriteRepository(MainContext context) : WriteRepository<Domain.Entities.Product>(context), IProductWriteRepository;