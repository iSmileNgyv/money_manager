using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Features.CQRS.Queries.Category.GetFilteredCategory;
using MoneyManager.Application.Repositories.Category;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Category;

public class CategoryReadRepository(MainContext context) : ReadRepository<Domain.Entities.Category>(context), ICategoryReadRepository
{
    public async Task<List<Domain.Entities.Category>> FilterAsync(GetFilteredCategoryQueryRequest request)
    {
        IQueryable<Domain.Entities.Category> query = context.Categories;
        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(c => c.Name.Trim().ToLower().Contains(request.Name.Trim().ToLower()));
        }
        
        if(request.CategoryType != null)
        {
            query = query.Where(c => c.CategoryType == request.CategoryType);
        }

        return await query.ToListAsync();
    }
}