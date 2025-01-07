using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Category.RemoveCategory;

public class RemoveCategoryCommandRequest : IRequest<RemoveCategoryCommandResponse>
{
    public Guid Id { get; set; }
}