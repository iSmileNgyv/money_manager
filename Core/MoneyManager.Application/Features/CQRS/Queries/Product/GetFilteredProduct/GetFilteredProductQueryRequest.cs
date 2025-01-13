using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Product.GetFilteredProduct;

public class GetFilteredProductQueryRequest : IRequest<List<GetFilteredProductQueryResponse>>
{
    public string? Name { get; set; }
    public Guid? CategoryId { get; set; }
}