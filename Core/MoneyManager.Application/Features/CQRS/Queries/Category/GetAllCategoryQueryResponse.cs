namespace MoneyManager.Application.Features.CQRS.Queries.Category;

public class GetAllCategoryQueryResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Image { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}