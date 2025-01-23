using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.Stock.CreateStock;
using MoneyManager.Application.Features.CQRS.Commands.Stock.RemoveStock;
using MoneyManager.Application.Features.CQRS.Commands.Stock.UpdateStock;
using MoneyManager.Application.Features.CQRS.Queries.Stock.GetAllStock;
using MoneyManager.Application.Features.CQRS.Queries.Stock.GetFilteredStock;

namespace MoneyManager.API.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class StocksController(IMediator mediator) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateStockCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateStockCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(RemoveStockCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllStockQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] GetFilteredStockQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}