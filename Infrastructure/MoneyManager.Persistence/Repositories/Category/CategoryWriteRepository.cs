using MoneyManager.Application.Repositories.Category;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Category;

public class CategoryWriteRepository(MainContext context) : WriteRepository<Domain.Entities.Category>(context), ICategoryWriteRepository
{
    
}