using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Stock.UpdateStock;

public class UpdateStockCommandRequest: IRequest<UpdateStockCommandResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? Image { get; set; }
}