using FluentValidation;
using MoneyManager.Application.Features.CQRS.Commands.Category.CreateCategory;

namespace MoneyManager.Application.Validators.Category;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommandRequest>
{
    public CreateCategoryCommandValidator()
    {
        
    }
}