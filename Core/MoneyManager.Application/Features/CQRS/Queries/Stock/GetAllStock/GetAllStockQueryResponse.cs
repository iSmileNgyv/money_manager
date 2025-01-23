using MoneyManager.Application.Features.CQRS.Queries.Common;

namespace MoneyManager.Application.Features.CQRS.Queries.Stock.GetAllStock;

public class GetAllStockQueryResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ImageResponse? Image { get; set; }
    public DateTime CreatedDate { get; set; }
}