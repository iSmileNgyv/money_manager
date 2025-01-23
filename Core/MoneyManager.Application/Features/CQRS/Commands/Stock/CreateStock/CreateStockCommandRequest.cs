using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Stock.CreateStock;

public class CreateStockCommandRequest: IRequest<CreateStockCommandResponse>
{
    public required string Name { get; set; }
    public string? Image { get; set; }
}