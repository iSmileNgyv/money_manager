using Microsoft.EntityFrameworkCore;
using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Application.Repositories;

public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}