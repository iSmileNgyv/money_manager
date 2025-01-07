using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Application.Features.CQRS.Queries.Category.GetAllCategory;

public class GetAllCategoryQueryResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string? Image { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? CategoryId { get; set; }
    public CategoryType CategoryType { get; set; }
    public int Level { get; set; }
}