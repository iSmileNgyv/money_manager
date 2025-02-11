using Microsoft.EntityFrameworkCore;
using MoneyManager.Application.Config;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Exceptions.Product;
using MoneyManager.Application.Features.CQRS.Commands.Product.CreateProduct;
using MoneyManager.Application.Features.CQRS.Commands.Product.RemoveProduct;
using MoneyManager.Application.Features.CQRS.Commands.Product.UpdateProduct;
using MoneyManager.Application.Features.CQRS.Queries.Common;
using MoneyManager.Application.Features.CQRS.Queries.Product.GetAllProduct;
using MoneyManager.Application.Features.CQRS.Queries.Product.GetAllProductWithoutPagination;
using MoneyManager.Application.Features.CQRS.Queries.Product.GetFilteredProduct;
using MoneyManager.Application.Repositories.Product;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Persistence.Services.Entities;

public class ProductService(
    IProductWriteRepository writeRepository,
    IProductReadRepository readRepository
    ) : IProductService
{
    public async Task<CreateProductCommandResponse> CreateProductAsync(CreateProductCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            Product product = new Product
            {
                Name = request.Name,
                CategoryId = request.CategoryId,
                Image = request.Image,
                Price = request.Price,
                Description = request.Description,
            };
            await writeRepository.AddAsync(product);
            await writeRepository.SaveAsync();
            return new();
        }
        catch (Exception ex)
        {
            throw new UnknownErrorException();
        }
    }

    public async Task<UpdateProductCommandResponse> UpdateProductAsync(UpdateProductCommandRequest request, CancellationToken ct = default)
    {
        Product? product = await readRepository.GetByIdAsync(request.Id);
        if (product == null)
            throw new ProductNotFoundException();
        product.Name = request.Name;
        product.CategoryId = request.CategoryId;
        product.Image = request.Image;
        product.Price = request.Price;
        product.Description = request.Description;
        writeRepository.Update(product);
        await writeRepository.SaveAsync();
        return new();
    }

    public async Task<RemoveProductCommandResponse> RemoveProductAsync(RemoveProductCommandRequest request, CancellationToken ct = default)
    {
        Product? product = await readRepository.GetByIdAsync(request.Id, false);
        if(product == null)
            throw new ProductNotFoundException();
        writeRepository.Remove(product);
        await writeRepository.SaveAsync();
        return new();
    }

    public async Task<List<GetFilteredProductQueryResponse>> FilterProductsAsync(GetFilteredProductQueryRequest request, CancellationToken ct = default)
    {
        List<Product> product = await readRepository.FilterAsync(request);
        return product.Select(p => new GetFilteredProductQueryResponse
        {
            Id = p.Id,
            Name = p.Name,
            CategoryId = p.CategoryId,
            Image = new ImageResponse {Path = p.Image, FullPath = BaseStorageConfig.FullPath(p.Image) },
            Price = p.Price,
            Description = p.Description,
            CreatedDate = p.CreatedDate
        }).ToList();
    }

    public async Task<List<GetAllProductQueryResponse>> GetAllProductsAsync(GetAllProductQueryRequest request, CancellationToken ct = default)
    {
        IQueryable<Product> product = readRepository.GetAll(false)
            .Include(p => p.Category)
            .Skip(request.Page * request.Size)
            .Take(request.Size);
        return await product.Select(p => new GetAllProductQueryResponse
        {
            Id = p.Id,
            Name = p.Name,
            CategoryId = p.CategoryId,
            Image = new ImageResponse {Path = p.Image, FullPath = BaseStorageConfig.FullPath(p.Image) },
            Price = p.Price,
            Description = p.Description,
            CategoryName = p.Category.Name,
            CreatedDate = p.CreatedDate
        }).ToListAsync(cancellationToken: ct);
    }

    public async Task<List<GetAllProductWithoutPaginationQueryResponse>> GetAllProductWithoutPaginationAsync(GetAllProductWithoutPaginationQueryRequest request,
        CancellationToken ct)
    {
        IQueryable<Product> product = readRepository.GetAll(false)
            .Include(p => p.Category);
        return await product.Select(p => new GetAllProductWithoutPaginationQueryResponse
        {
            Id = p.Id,
            Name = p.Name,
            CategoryId = p.CategoryId,
            Image = new ImageResponse {Path = p.Image, FullPath = BaseStorageConfig.FullPath(p.Image) },
            Price = p.Price,
            Description = p.Description,
            CategoryName = p.Category.Name,
            CreatedDate = p.CreatedDate
        }).ToListAsync(cancellationToken: ct);
    }
}