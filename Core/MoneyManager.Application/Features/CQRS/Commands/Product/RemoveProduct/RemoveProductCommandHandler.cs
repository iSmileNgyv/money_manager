using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Product.RemoveProduct;

public class RemoveProductCommandHandler(
    IProductService service
    ) : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
{
    public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.RemoveProductAsync(request, cancellationToken);
    }
}