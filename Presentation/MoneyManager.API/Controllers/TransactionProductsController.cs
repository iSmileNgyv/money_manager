using MediatR;
using Microsoft.AspNetCore.Mvc;
using MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.CreateTransactionProduct;
using MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.RemoveTransactionProduct;
using MoneyManager.Application.Features.CQRS.Commands.TransactionProduct.UpdateTransactionProduct;
using MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetAllTransactionProduct;
using MoneyManager.Application.Features.CQRS.Queries.TransactionProduct.GetByTransactionIdTransactionProduct;

namespace MoneyManager.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class TransactionProductsController(
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
    public async Task<IActionResult> GetAll(GetAllTransactionProductQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }

    [HttpGet("{transactionId}")]
    public async Task<IActionResult> GetByTransactionId(GetByTransactionIdTransactionProductQueryRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}