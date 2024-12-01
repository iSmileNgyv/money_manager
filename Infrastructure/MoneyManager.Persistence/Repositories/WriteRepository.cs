using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoneyManager.Application.Repositories;
using MoneyManager.Domain.Entities.Common;
using MoneyManager.Persistence.Contexts;

namespace MoneyManager.Persistence.Repositories;

public class WriteRepository<T>(MainContext context) : IWriteRepository<T> where T : BaseEntity
{
    public DbSet<T> Table => context.Set<T>();
    public async Task<bool> AddAsync(T model)
    {
        EntityEntry entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> datas)
    {
        try
        {
            await Table.AddRangeAsync(datas);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Remove(T model)
    {
        try
        {
            EntityEntry entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        T? entity = await Table.FirstOrDefaultAsync(x => x.Id == id);
        if (entity == null)
            return false;
        return Remove(entity);
    }

    public bool RemoveRange(List<T?> datas)
    {
        try
        {
            var nonNullData = datas.Where(item => item != null).Cast<T>().ToList();
            Table.RemoveRange(nonNullData);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public bool Update(T model)
    {
        try
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    public async Task<int> SaveAsync() => await context.SaveChangesAsync();
}