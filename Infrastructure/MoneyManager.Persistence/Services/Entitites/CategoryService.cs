using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Features.CQRS.Commands.Category.CreateCategory;
using MoneyManager.Application.Features.CQRS.Queries.Category;
using MoneyManager.Application.Repositories.Category;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Persistence.Services.Entitites;

public class CategoryService(
    ICategoryWriteRepository writeRepository,
    ICategoryReadRepository readRepository
    ) : ICategoryService
{
    public async Task<CreateCategoryCommandResponse> CreateCategoryAsync(CreateCategoryCommandRequest request, CancellationToken ct)
    {
        try
        {
            Category category;
            if (request.CategoryId != null)
            {
                var parentCategory = await readRepository.GetByIdAsync(Guid.Parse(request.CategoryId));
                if (parentCategory == null)
                {
                    throw new UnknownErrorException();
                }

                category = new()
                {
                    Name = request.Name,
                    Image = request.Image,
                    Description = request.Description,
                    CategoryId = Guid.Parse(request.CategoryId),
                    Level = parentCategory.Level + 1
                };
            }
            else
            {
                     category = new()
                {
                    Name = request.Name,
                    Image = request.Image,
                    Description = request.Description
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

    public async Task<List<GetAllCategoryQueryResponse>> GetAllCategoriesAsync(GetAllCategoryQueryRequest request, CancellationToken ct)
    {
        IQueryable<Category> categories = readRepository.GetAll(false);
        return await categories.Select(c => new GetAllCategoryQueryResponse()
        {
            Id = c.Id,
            Name = c.Name,
            Image = c.Image,
            Description = c.Description,
            CreatedDate = c.CreatedDate,
            UpdatedDate = c.UpdatedDate
        }).ToListAsync(cancellationToken: ct);
    }
}