using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Category;

public class GetAllCategoryQueryHandler(
    ICategoryService service
    ) : IRequestHandler<GetAllCategoryQueryRequest, List<GetAllCategoryQueryResponse>>
{
    public async Task<List<GetAllCategoryQueryResponse>> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetAllCategoriesAsync(request, cancellationToken);
    }
}