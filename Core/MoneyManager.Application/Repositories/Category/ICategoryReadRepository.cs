using MoneyManager.Application.Features.CQRS.Queries.Category.GetFilteredCategory;

namespace MoneyManager.Application.Repositories.Category;

public interface ICategoryReadRepository : IReadRepository<Domain.Entities.Category>
{
    Task<List<Domain.Entities.Category>> FilterAsync(GetFilteredCategoryQueryRequest request);
}