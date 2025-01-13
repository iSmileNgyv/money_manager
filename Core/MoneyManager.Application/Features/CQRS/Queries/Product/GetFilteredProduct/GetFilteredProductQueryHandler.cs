using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Product.GetFilteredProduct;

public class GetFilteredProductQueryHandler(
    IProductService service
    ) : IRequestHandler<GetFilteredProductQueryRequest, List<GetFilteredProductQueryResponse>>
{
    public async Task<List<GetFilteredProductQueryResponse>> Handle(GetFilteredProductQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.FilterProductsAsync(request, cancellationToken);
    }
}