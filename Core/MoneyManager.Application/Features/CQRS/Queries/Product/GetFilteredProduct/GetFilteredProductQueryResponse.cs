using MoneyManager.Application.Features.CQRS.Queries.Common;

namespace MoneyManager.Application.Features.CQRS.Queries.Product.GetFilteredProduct;

public class GetFilteredProductQueryResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ImageResponse? Image { get; set; }
    public Guid CategoryId { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
}