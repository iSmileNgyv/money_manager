using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Product.GetAllProductWithoutPagination;

public class GetAllProductWithoutPaginationQueryHandler(
    IProductService service
    ): IRequestHandler<GetAllProductWithoutPaginationQueryRequest, List<GetAllProductWithoutPaginationQueryResponse>>
{
    public async Task<List<GetAllProductWithoutPaginationQueryResponse>> Handle(GetAllProductWithoutPaginationQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetAllProductWithoutPaginationAsync(request, cancellationToken);
    }
}