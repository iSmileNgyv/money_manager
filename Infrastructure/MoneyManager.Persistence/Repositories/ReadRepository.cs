using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Repositories;
using MoneyManager.Domain.Entities.Common;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories;

public class ReadRepository<T>(MainContext context) : IReadRepository<T> where T : BaseEntity
{
    public DbSet<T> Table => context.Set<T>();
    public IQueryable<T> GetAll(bool tracking = true)
    {
        IQueryable<T> query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
    {
        IQueryable<T> query = Table.Where(method);
        if(!tracking)
            query = query.AsNoTracking();
        return query;
    }

    public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
    {
        IQueryable<T> query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(method);
    }

    public async Task<T?> GetByIdAsync(Guid id, bool tracking = true)
    {
        IQueryable<T> query = Table.AsQueryable();
        if (!tracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }
}