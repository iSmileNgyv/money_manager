using MoneyManager.Application.Features.CQRS.Queries.Common;

namespace MoneyManager.Application.Features.CQRS.Queries.Product.GetAllProduct;

public class GetAllProductQueryResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ImageResponse? Image { get; set; }
    public decimal Price { get; set; } = 0;
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
    public required string CategoryName { get; set; }
    public DateTime CreatedDate { get; set; }
}