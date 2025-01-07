using MediatR;
using MoneyManager.Application.Services.Entities;

namespace MoneyManager.Application.Features.CQRS.Commands.Category.UpdateCategory;

public class UpdateCategoryCommandHandler(
    ICategoryService service
    ) : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
{
    public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        return await service.UpdateCategoryAsync(request, cancellationToken);
    }
}