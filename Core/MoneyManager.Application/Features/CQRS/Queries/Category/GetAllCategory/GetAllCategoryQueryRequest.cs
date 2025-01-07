using MediatR;

namespace MoneyManager.Application.Features.CQRS.Queries.Category.GetAllCategory;

public class GetAllCategoryQueryRequest : IRequest<List<GetAllCategoryQueryResponse>>
{
    public int Page { get; set; } = 0;
    public int Size { get; set; } = 10;
}