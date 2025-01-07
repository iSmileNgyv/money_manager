using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Category.RemoveCategory;

public class RemoveCategoryCommandHandler(
    ICategoryService service
    ) : IRequestHandler<RemoveCategoryCommandRequest, RemoveCategoryCommandResponse>
{
    public async Task<RemoveCategoryCommandResponse> Handle(RemoveCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.RemoveCategoryAsync(request, cancellationToken);
    }
}