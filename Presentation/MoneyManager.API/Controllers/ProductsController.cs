using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.Product.CreateProduct;
using MoneyManager.Application.Features.CQRS.Commands.Product.RemoveProduct;
using MoneyManager.Application.Features.CQRS.Commands.Product.UpdateProduct;
using MoneyManager.Application.Features.CQRS.Queries.Product.GetAllProduct;

namespace MoneyManager.API.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController(
    IMediator mediator
    ) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateProductCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }
    [HttpPut]
    public async Task<IActionResult> Update(UpdateProductCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(RemoveProductCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProductQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetFilter([FromQuery] GetAllProductQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }
    
}