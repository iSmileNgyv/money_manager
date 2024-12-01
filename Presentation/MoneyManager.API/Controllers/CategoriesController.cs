using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.Category.CreateCategory;
using MoneyManager.Application.Features.CQRS.Queries.Category;

namespace MoneyManager.API.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class CategoriesController(
    IMediator mediator
    ) : Controller
{
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoryQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}