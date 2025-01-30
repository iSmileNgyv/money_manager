using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Exceptions.Cashback;
using MoneyManager.Application.Exceptions.Category;
using MoneyManager.Application.Features.CQRS.Commands.Category.CreateCategory;
using MoneyManager.Application.Features.CQRS.Commands.Category.RemoveCategory;
using MoneyManager.Application.Features.CQRS.Commands.Category.UpdateCategory;
using MoneyManager.Application.Features.CQRS.Queries.Category.GetAllCategory;
using MoneyManager.Application.Features.CQRS.Queries.Category.GetAllCategoryWithoutPagination;
using MoneyManager.Application.Features.CQRS.Queries.Category.GetFilteredCategory;
using MoneyManager.Application.Features.CQRS.Queries.Common;
using MoneyManager.Application.Repositories.Category;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Application.Services.Log;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Persistence.Services.Entities;

public class CategoryService(
    ICategoryWriteRepository writeRepository,
    ICategoryReadRepository readRepository,
    IConfiguration configuration,
    ILogService logService
    ) : ICategoryService
{
    public async Task<CreateCategoryCommandResponse> CreateCategoryAsync(CreateCategoryCommandRequest request, CancellationToken ct)
    {
        try
        {
            Category category;
            if (request.CategoryId != null)
            {
                Category? parentCategory = await readRepository.GetByIdAsync(request.CategoryId.Value, false);
                if (parentCategory == null)
                {
                    throw new UnknownErrorException();
                }

                category = new()
                {
                    Name = request.Name,
                    Description = request.Description,
                    CategoryId = request.CategoryId,
                    Image = request.Image,
                    CategoryType = request.CategoryType,
                    Level = parentCategory.Level + 1
                };
            }
            else
            {
                category = new()
                {
                    Name = request.Name,
                    CategoryType = request.CategoryType,
                    Image = request.Image,
                    Description = request.Description,
                    Level = 1
                };
            }
            await writeRepository.AddAsync(category);
            await writeRepository.SaveAsync();
            return new();
        }
        catch (Exception ex)
        {
            throw new UnknownErrorException();
        }
    }

    public async Task<UpdateCategoryCommandResponse> UpdateCategoryAsync(UpdateCategoryCommandRequest updateCategoryCommandRequest, CancellationToken ct)
    {
        try
        {
            Category? category = await readRepository.GetByIdAsync(updateCategoryCommandRequest.Id);
            if (category == null)
            {
                throw new CategoryNotFoundException();
            }
            category.Name = updateCategoryCommandRequest.Name;
            category.Description = updateCategoryCommandRequest.Description;
            category.CategoryId = updateCategoryCommandRequest.CategoryId;
            category.CategoryType = updateCategoryCommandRequest.CategoryType;
            category.Image = updateCategoryCommandRequest.Image;
            writeRepository.Update(category);
            await writeRepository.SaveAsync();
            return new();
        }
        catch (Exception ex)
        {
            throw new UnknownErrorException();
        }
    }

    public async Task<RemoveCategoryCommandResponse> RemoveCategoryAsync(RemoveCategoryCommandRequest removeCategoryCommandRequest, CancellationToken ct)
    {
        try
        {
            Category? category = await readRepository.GetByIdAsync(removeCategoryCommandRequest.Id, false);
            if (category == null)
                throw new CategoryNotFoundException();
            writeRepository.Remove(category);
            await writeRepository.SaveAsync();
            logService.LogInformation("Category removed", category);
        }
        catch (DbUpdateException ex) when (ex.InnerException is Npgsql.PostgresException { SqlState: "23503" })
        {
            logService.LogError("Category remove error: " + nameof(CashbackInUseErrorException));
            throw new CashbackInUseErrorException();
        }
        catch(Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public async Task<List<GetAllCategoryQueryResponse>> GetAllCategoriesAsync(GetAllCategoryQueryRequest request, CancellationToken ct)
    {
        IQueryable<Category> categories = readRepository.GetAll(false)
            .Include(c => c.ParentCategory)
            .Skip(request.Page * request.Size)
            .Take(request.Size);
        return await categories.Select(c => new GetAllCategoryQueryResponse()
        {
            Id = c.Id,
            Name = c.Name,
            Image = new ImageResponse {Path = c.Image, FullPath = configuration["BaseStorageUrl"] + "/" +c.Image },
            Description = c.Description,
            CategoryId = c.CategoryId,
            ParentCategoryName = c.ParentCategory != null ? c.ParentCategory.Name : null,
            Level = c.Level,
            CategoryType = c.CategoryType,
            CreatedDate = c.CreatedDate
        }).ToListAsync(cancellationToken: ct);
    }

    public async Task<List<GetFilteredCategoryQueryResponse>> GetFilteredCategoriesAsync(GetFilteredCategoryQueryRequest request, CancellationToken ct)
    {
        List<Category> categories = await readRepository.FilterAsync(request);
        return categories.Select(c => new GetFilteredCategoryQueryResponse
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            CategoryId = c.CategoryId,
            Image = new ImageResponse {Path = c.Image, FullPath = configuration["BaseStorageUrl"] + "/" +c.Image },
            Level = c.Level,
            CategoryType = c.CategoryType,
            CreatedDate = c.CreatedDate
        }).ToList();
    }

    public async Task<List<GetAllCategoryWithoutPaginationQueryResponse>> GetAllCategoriesWithoutPaginationAsync(
        GetAllCategoryWithoutPaginationQueryRequest getAllCategoryWithoutPaginationQueryRequest, CancellationToken ct)
    {
        IQueryable<Category> categories = readRepository.GetAll(false);
        return await categories.Select(c => new GetAllCategoryWithoutPaginationQueryResponse()
        {
            Id = c.Id,
            Name = c.Name,
            Description = c.Description,
            CategoryId = c.CategoryId,
            Level = c.Level,
            Type = c.CategoryType,
            CreatedDate = c.CreatedDate
        }).ToListAsync(cancellationToken: ct);
    }
}