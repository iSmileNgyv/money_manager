using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Category.GetAllCategoryWithoutPagination;

public class GetAllCategoryWithoutPaginationQueryHandler(
    ICategoryService service
    ) : IRequestHandler<GetAllCategoryWithoutPaginationQueryRequest, List<GetAllCategoryWithoutPaginationQueryResponse>>
{
    public async Task<List<GetAllCategoryWithoutPaginationQueryResponse>> Handle(GetAllCategoryWithoutPaginationQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetAllCategoriesWithoutPaginationAsync(request, cancellationToken);
    }
}