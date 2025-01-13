using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Product.CreateProduct;

public class CreateProductCommandHandler(
    IProductService service
    ) : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
{
    public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.CreateProductAsync(request, cancellationToken);
    }
}