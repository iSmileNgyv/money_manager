using MoneyManager.Application.Features.CQRS.Queries.Common;

namespace MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetAllPaymentMethodWithoutPagination;

public class GetAllPaymentMethodWithoutPaginationQueryResponse
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
}