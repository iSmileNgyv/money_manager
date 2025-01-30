using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Features.CQRS.Queries.Product.GetFilteredProduct;
using MoneyManager.Application.Repositories.Product;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.Product;

public class ProductReadRepository(MainContext context) : ReadRepository<Domain.Entities.Product>(context), IProductReadRepository
{
    private readonly MainContext _context = context;

    public async Task<List<Domain.Entities.Product>> FilterAsync(GetFilteredProductQueryRequest request)
    {
        IQueryable<Domain.Entities.Product> query = _context.Products.AsNoTracking();
        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(p => p.Name.ToLower().Contains(request.Name.ToLower()));
        }

        if (!string.IsNullOrEmpty(request.CategoryId.ToString()))
        {
            query = query.Where(p => p.CategoryId == request.CategoryId);
        }

        return await query.ToListAsync();
    }
}