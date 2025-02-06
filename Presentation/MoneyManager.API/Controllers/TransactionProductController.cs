using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.CreateTransactionProduct;
using MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.RemoveTransactionProduct;
using MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.UpdateTransactionProduct;
using MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetAllTransactionProduct;
using MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetByTransactionIdTransactionProduct;

namespace MoneyManager.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
//[Authorize(AuthenticationSchemes = "Admin")]
public class TransactionProductController(
    IMediator mediator
) : Controller
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateTransactionProductCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateTransactionProductCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpDelete]
    public async Task<IActionResult> Remove(RemoveTransactionProductCommandRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllTransactionProductQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet("transaction")]
    public async Task<IActionResult> GetByTransactionId([FromQuery] GetByTransactionIdTransactionProductQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}