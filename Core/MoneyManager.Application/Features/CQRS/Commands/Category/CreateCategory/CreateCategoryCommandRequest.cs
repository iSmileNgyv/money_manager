using MediatR;

namespace MoneyManager.Application.Features.CQRS.Commands.Category.CreateCategory;

public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
{
    public required string Name { get; set; }
    public required string Image { get; set; }
    public string? Description { get; set; }
    public string? CategoryId { get; set; }
}