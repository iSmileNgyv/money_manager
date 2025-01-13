using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Product.UpdateProduct;

public class UpdateProductCommandRequest : IRequest<UpdateProductCommandResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Image { get; set; }
    public decimal Price { get; set; } = 0;
    public string? Description { get; set; }
    public Guid CategoryId { get; set; }
}