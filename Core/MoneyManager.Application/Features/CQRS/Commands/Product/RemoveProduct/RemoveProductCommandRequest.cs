using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Product.RemoveProduct;

public class RemoveProductCommandRequest : IRequest<RemoveProductCommandResponse>
{
    public Guid Id { get; set; }
}