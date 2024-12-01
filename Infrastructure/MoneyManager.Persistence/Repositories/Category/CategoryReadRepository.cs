using MoneyManager.Application.Repositories.Category;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Category;

public class CategoryReadRepository(MainContext context) : ReadRepository<Domain.Entities.Category>(context), ICategoryReadRepository
{
    
}