using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Stock.RemoveStock;

public class RemoveStockCommandRequest: IRequest<RemoveStockCommandResponse>
{
    public Guid Id { get; set; }
}