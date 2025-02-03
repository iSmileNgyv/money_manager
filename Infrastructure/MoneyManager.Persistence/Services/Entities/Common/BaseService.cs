using Microsoft.Extensions.Configuration;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Features.CQRS.Queries.Common;
using MoneyManager.Application.Repositories;
using MoneyManager.Domain.Entities.Common;

namespace MoneyManager.Persistence.Services.Entities.Common;

public abstract class BaseService<TEntity, TCreateRequest, TUpdateRequest, TGetAllResponse>(
    IReadRepository<TEntity> readRepository,
    IWriteRepository<TEntity> writeRepository
    ) where TEntity : BaseEntity
{
    public virtual async Task<BaseCommandResponse> CreateAsync(TCreateRequest request)
    {
        try
        {
            var entity = this.MapCreateRequestToEntity(request);
            await writeRepository.AddAsync(entity);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public virtual async Task<BaseCommandResponse> UpdateAsync(TUpdateRequest request)
    {
        try
        {
            var entity = this.MapUpdateRequestToEntity(request);
            writeRepository.Update(entity);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public virtual async Task<BaseCommandResponse> RemoveAsync(BaseRemoveRequest request)
    {
        try
        {
            var entity = await readRepository.GetByIdAsync(request.Id);
            if (entity == null)
                throw CreateNotFoundException(typeof(TEntity).Name);
            writeRepository.Remove(entity);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public virtual List<TGetAllResponse> GetAll(
        BasePaginationRequest request,
        Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
    {
        IQueryable<TEntity> query = readRepository.GetAll(false);
        if (include != null)
        {
            query = include(query);
        }
        query = query
            .Skip(request.Page * request.Size)
            .Take(request.Size);
        return query.AsEnumerable().Select(MapEntityToGetAllResponse).ToList();
    }
    
    protected virtual Exception CreateNotFoundException(string entityName)
    {
        var exceptionTypeName = $"MoneyManager.Application.Exceptions.{entityName}.{entityName}NotFoundException";
        var exceptionType = Type.GetType(exceptionTypeName);

        if (exceptionType == null)
        {
            return new BaseException($"{entityName} not found.", 404);
        }

        var exception = Activator.CreateInstance(exceptionType) as Exception;
        return exception ?? new BaseException($"{entityName} not found.", 404);
    }
    protected abstract TEntity MapCreateRequestToEntity(TCreateRequest request);
    protected abstract TEntity MapUpdateRequestToEntity(TUpdateRequest request);
    protected abstract TGetAllResponse MapEntityToGetAllResponse(TEntity entity);
}