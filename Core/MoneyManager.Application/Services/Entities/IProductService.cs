using MoneyManager.Application.Features.CQRS.Commands.Product.CreateProduct;
using MoneyManager.Application.Features.CQRS.Commands.Product.RemoveProduct;
using MoneyManager.Application.Features.CQRS.Commands.Product.UpdateProduct;
using MoneyManager.Application.Features.CQRS.Queries.Product.GetAllProduct;
using MoneyManager.Application.Features.CQRS.Queries.Product.GetFilteredProduct;

namespace MoneyManager.Application.Services.Entities;

public interface IProductService
{
    Task<CreateProductCommandResponse> CreateProductAsync(CreateProductCommandRequest request, CancellationToken ct = default);
    Task<UpdateProductCommandResponse> UpdateProductAsync(UpdateProductCommandRequest request, CancellationToken ct = default);
    Task<RemoveProductCommandResponse> RemoveProductAsync(RemoveProductCommandRequest request, CancellationToken ct = default);
    Task<List<GetFilteredProductQueryResponse>> FilterProductsAsync(GetFilteredProductQueryRequest request, CancellationToken ct = default);
    Task<List<GetAllProductQueryResponse>> GetAllProductsAsync(GetAllProductQueryRequest request, CancellationToken ct = default);
}