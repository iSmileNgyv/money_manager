using MediatR;
using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Application.Features.CQRS.Queries.Category.GetFilteredCategory;

public class GetFilteredCategoryQueryRequest : IRequest<List<GetFilteredCategoryQueryResponse>>
{
    public string? Name { get; set; }
    public CategoryType? CategoryType { get; set; }
}