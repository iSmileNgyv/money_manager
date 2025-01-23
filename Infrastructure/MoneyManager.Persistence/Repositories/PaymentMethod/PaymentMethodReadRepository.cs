using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetFilteredPaymentMethod;
using MoneyManager.Application.Repositories.PaymentMethod;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories.PaymentMethod;

public class PaymentMethodReadRepository(MainContext context) : ReadRepository<Domain.Entities.PaymentMethod>(context), IPaymentMethodReadRepository
{
    private readonly MainContext _context = context;

    public async Task<List<Domain.Entities.PaymentMethod>> FilterAsync(GetFilteredPaymentMethodQueryRequest request)
    {
        IQueryable<Domain.Entities.PaymentMethod> query = _context.PaymentMethods;
        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(p => p.Name.Trim().ToLower().Contains(request.Name.Trim().ToLower()));
        }

        return await query.ToListAsync();
    }
}