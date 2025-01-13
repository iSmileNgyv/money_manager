using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.Category.CreateCategory;
using MoneyManager.Application.Features.CQRS.Commands.Category.RemoveCategory;
using MoneyManager.Application.Features.CQRS.Commands.Category.UpdateCategory;
using MoneyManager.Application.Features.CQRS.Queries.Category.GetAllCategory;
using MoneyManager.Application.Features.CQRS.Queries.Category.GetAllCategoryWithoutPagination;
using MoneyManager.Application.Features.CQRS.Queries.Category.GetFilteredCategory;

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
    
    [HttpPut]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }
    
    [HttpDelete]
    public async Task<IActionResult> RemoveCategory(RemoveCategoryCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoryQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllCategoriesWithoutPagination([FromQuery] GetAllCategoryWithoutPaginationQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }
    
    [HttpGet("filter")]
    public async Task<IActionResult> GetFilteredCategories([FromQuery] GetFilteredCategoryQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}