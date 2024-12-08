using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Category.CreateCategory;

public class CreateCategoryCommandHandler(
    ICategoryService service
    ) : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
{
    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.CreateCategoryAsync(request, cancellationToken);
    }
}