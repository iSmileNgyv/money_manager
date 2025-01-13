using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Queries.Product.GetAllProduct;

public class GetAllProductQueryHandler(
    IProductService service
    ) : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
{
    public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
    {
        return await service.GetAllProductsAsync(request, cancellationToken);
    }
}