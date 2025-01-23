using MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetFilteredPaymentMethod;

namespace MoneyManager.Application.Repositories.PaymentMethod;

public interface IPaymentMethodReadRepository : IReadRepository<Domain.Entities.PaymentMethod>
{
    Task<List<Domain.Entities.PaymentMethod>> FilterAsync(GetFilteredPaymentMethodQueryRequest request);
}