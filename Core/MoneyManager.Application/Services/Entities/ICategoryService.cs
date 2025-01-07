using MoneyManager.Application.Features.CQRS.Commands.Category.CreateCategory;
using MoneyManager.Application.Features.CQRS.Commands.Category.RemoveCategory;
using MoneyManager.Application.Features.CQRS.Commands.Category.UpdateCategory;
using MoneyManager.Application.Features.CQRS.Queries.Category.GetAllCategory;
using MoneyManager.Application.Features.CQRS.Queries.Category.GetAllCategoryWithoutPagination;
using MoneyManager.Application.Features.CQRS.Queries.Category.GetFilteredCategory;

namespace MoneyManager.Application.Services.Entities;

public interface ICategoryService
{
    Task<CreateCategoryCommandResponse> CreateCategoryAsync(CreateCategoryCommandRequest createCategoryCommandRequest, CancellationToken ct);
    Task<UpdateCategoryCommandResponse> UpdateCategoryAsync(UpdateCategoryCommandRequest updateCategoryCommandRequest, CancellationToken ct);
    Task<RemoveCategoryCommandResponse> RemoveCategoryAsync(RemoveCategoryCommandRequest removeCategoryCommandRequest, CancellationToken ct);
    Task<List<GetAllCategoryQueryResponse>> GetAllCategoriesAsync(GetAllCategoryQueryRequest request, CancellationToken ct);
    Task<List<GetFilteredCategoryQueryResponse>> GetFilteredCategoriesAsync(GetFilteredCategoryQueryRequest request, CancellationToken ct);
    Task<List<GetAllCategoryWithoutPaginationQueryResponse>> GetAllCategoriesWithoutPaginationAsync(GetAllCategoryWithoutPaginationQueryRequest getAllCategoryWithoutPaginationQueryRequest, CancellationToken ct);
}