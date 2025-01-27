using MoneyManager.Application.Features.CQRS.Queries.Common;
using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Application.Features.CQRS.Queries.Category.GetFilteredCategory;

public class GetFilteredCategoryQueryResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public ImageResponse? Image { get; set; }
    public Guid? CategoryId { get; set; }
    public CategoryType CategoryType { get; set; }
    public int Level { get; set; }
}