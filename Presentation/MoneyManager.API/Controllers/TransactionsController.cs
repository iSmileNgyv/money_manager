using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.Transaction.CreateTransaction;
using MoneyManager.Application.Features.CQRS.Commands.Transaction.RemoveTransaction;
using MoneyManager.Application.Features.CQRS.Commands.Transaction.UpdateTransaction;
using MoneyManager.Application.Features.CQRS.Queries.Transaction.GetAllTransaction;
using MoneyManager.Application.Features.CQRS.Queries.Transaction.GetFilteredTransaction;

namespace MoneyManager.API.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]
public class TransactionsController(
    IMediator mediator
    ): Controller
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateTransactionCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTransactionCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(RemoveTransactionCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetAllTransactionQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet("filter")]
    public async Task<IActionResult> Filter([FromQuery] GetFilteredTransactionQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}