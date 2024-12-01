using MoneyManager.Application.Features.CQRS.Commands.Category.CreateCategory;
using MoneyManager.Application.Features.CQRS.Queries.Category;

namespace MoneyManager.Application.Services.Entities;

public interface ICategoryService
{
    Task<CreateCategoryCommandResponse> CreateCategoryAsync(CreateCategoryCommandRequest createCategoryCommandRequest, CancellationToken ct);
    Task<List<GetAllCategoryQueryResponse>> GetAllCategoriesAsync(GetAllCategoryQueryRequest request, CancellationToken ct);
}