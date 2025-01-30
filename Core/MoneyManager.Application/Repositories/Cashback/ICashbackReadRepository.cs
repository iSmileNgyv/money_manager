using MoneyManager.Application.Features.CQRS.Queries.Cashback.GetFilteredCashback;

namespace MoneyManager.Application.Repositories.Cashback;

public interface ICashbackReadRepository : IReadRepository<Domain.Entities.Cashback>
{
    Task<List<Domain.Entities.Cashback>> FilterAsync(GetFilteredCashbackQueryRequest request);
}