using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Product.GetAllProduct;

public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
}