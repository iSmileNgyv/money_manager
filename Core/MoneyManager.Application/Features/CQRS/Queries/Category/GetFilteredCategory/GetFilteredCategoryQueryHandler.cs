using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Category.GetFilteredCategory;

public class GetFilteredCategoryQueryHandler(
    ICategoryService service
    ) : IRequestHandler<GetFilteredCategoryQueryRequest, List<GetFilteredCategoryQueryResponse>>
{
    public async Task<List<GetFilteredCategoryQueryResponse>> Handle(GetFilteredCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetFilteredCategoriesAsync(request, cancellationToken);
    }
}