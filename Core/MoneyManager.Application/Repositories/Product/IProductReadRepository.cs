using MoneyManager.Application.Features.CQRS.Queries.Product.GetFilteredProduct;

namespace MoneyManager.Application.Repositories.Product;

public interface IProductReadRepository : IReadRepository<Domain.Entities.Product>
{
    Task<List<Domain.Entities.Product>> FilterAsync(GetFilteredProductQueryRequest request);
}