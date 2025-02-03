using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Transaction.CreateTransaction;

public class CreateTransactionCommandRequest: IRequest<CreateTransactionCommandResponse>
{
    public Guid PaymentMethodId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid? StockId { get; set; }
    public DateOnly EventDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow.Date);
    public decimal Amount { get; set; } = 0;
    public decimal CashbackAmount { get; set; } = 0;
}