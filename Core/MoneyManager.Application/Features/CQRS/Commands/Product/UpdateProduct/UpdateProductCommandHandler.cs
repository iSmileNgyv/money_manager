using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Product.UpdateProduct;

public class UpdateProductCommandHandler(
    IProductService service
    ) : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
{
    public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.UpdateProductAsync(request, cancellationToken);
    }
}