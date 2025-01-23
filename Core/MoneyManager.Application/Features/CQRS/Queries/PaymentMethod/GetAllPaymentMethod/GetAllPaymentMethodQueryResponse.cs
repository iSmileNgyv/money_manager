using MoneyManager.Application.Features.CQRS.Queries.Common;

namespace MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetAllPaymentMethod;

public class GetAllPaymentMethodQueryResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public ImageResponse? Image { get; set; }
    public DateTime CreatedDate { get; set; }
}