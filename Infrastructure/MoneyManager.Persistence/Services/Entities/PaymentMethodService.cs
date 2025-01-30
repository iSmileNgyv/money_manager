using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoneyManager.Application.Exceptions;
using MoneyManager.Application.Exceptions.PaymentMethod;
using MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.CreatePaymentMethod;
using MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.RemovePaymentMethod;
using MoneyManager.Application.Features.CQRS.Commands.PaymentMethod.UpdatePaymentMethod;
using MoneyManager.Application.Features.CQRS.Queries.Common;
using MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetAllPaymentMethod;
using MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetAllPaymentMethodWithoutPagination;
using MoneyManager.Application.Features.CQRS.Queries.PaymentMethod.GetFilteredPaymentMethod;
using MoneyManager.Application.Repositories.PaymentMethod;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Domain.Entities;

namespace MoneyManager.Persistence.Services.Entities;

public class PaymentMethodService(
    IPaymentMethodWriteRepository writeRepository,
    IPaymentMethodReadRepository readRepository,
    IConfiguration configuration
    ): IPaymentMethodService
{
    public async Task<CreatePaymentMethodCommandResponse> CreatePaymentMethodAsync(CreatePaymentMethodCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            PaymentMethod paymentMethod = new()
            {
                Name = request.Name,
                Image = request.Image
            };
            await writeRepository.AddAsync(paymentMethod);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public async Task<UpdatePaymentMethodCommandResponse> UpdatePaymentMethodAsync(UpdatePaymentMethodCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            PaymentMethod paymentMethod = new()
            {
                Id = request.Id,
                Name = request.Name,
                Image = request.Image
            };
            writeRepository.Update(paymentMethod);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }

        return new();
    }

    public async Task<RemovePaymentMethodCommandResponse> RemovePaymentMethodAsync(RemovePaymentMethodCommandRequest request, CancellationToken ct = default)
    {
        try
        {
            PaymentMethod? paymentMethod = await readRepository.GetByIdAsync(request.Id, false);
            if (paymentMethod == null)
                throw new PaymentMethodNotFoundException();
            writeRepository.Remove(paymentMethod);
            await writeRepository.SaveAsync();
        }
        catch (Exception)
        {
            throw new UnknownErrorException();
        }
        return new();
    }

    public async Task<List<GetAllPaymentMethodQueryResponse>> GetAllPaymentMethodsAsync(GetAllPaymentMethodQueryRequest request, CancellationToken ct = default)
    {
        IQueryable<PaymentMethod> paymentMethods = readRepository.GetAll(false)
            .Take(request.Size)
            .Skip(request.Size * request.Page);
        return await paymentMethods.Select(p => new GetAllPaymentMethodQueryResponse()
        {
            Id = p.Id,
            Name = p.Name,
            Image = new ImageResponse {Path = p.Image, FullPath = configuration["BaseStorageUrl"] + "/" +p.Image },
            CreatedDate = p.CreatedDate
        }).ToListAsync(ct);
    }

    public async Task<List<GetFilteredPaymentMethodQueryResponse>> GetFilteredPaymentMethodsAsync(GetFilteredPaymentMethodQueryRequest request, CancellationToken ct = default)
    {
        List<PaymentMethod> paymentMethods = await readRepository.FilterAsync(request);
        return paymentMethods.Select(p => new GetFilteredPaymentMethodQueryResponse
        {
            Id = p.Id,
            Name = p.Name,
            Image = new ImageResponse {Path = p.Image, FullPath = p.Image },
            CreatedDate = p.CreatedDate
        }).ToList();
    }

    public async Task<List<GetAllPaymentMethodWithoutPaginationQueryResponse>> GetAllPaymentMethodsWithoutPaginationAsync(GetAllPaymentMethodWithoutPaginationQueryRequest request,
        CancellationToken ct = default)
    {
        IQueryable<PaymentMethod> paymentMethods = readRepository.GetAll(false);
        return await paymentMethods.Select(p => new GetAllPaymentMethodWithoutPaginationQueryResponse
        {
            Id = p.Id,
            Name = p.Name
        }).ToListAsync(ct);
    }
}