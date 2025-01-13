using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoneyManager.Application.Exceptions.Media;
using MoneyManager.Application.Features.CQRS.Commands.Media.CreateMedia;
using MoneyManager.Application.Features.CQRS.Commands.Media.RemoveMedia;
using MoneyManager.Application.Features.CQRS.Queries.Media.GetAllMedia;
using MoneyManager.Application.Repositories.Media;
using MoneyManager.Application.Services.Entities;
using MoneyManager.Application.Services.Storage;
using MoneyManager.Domain.Entities;
using Npgsql;
namespace MoneyManager.Persistence.Services.Entities;

public class MediaService(
    IStorageService storageService,
    IMediaWriteRepository writeRepository,
    IMediaReadRepository readRepository,
    IConfiguration configuration
    ) : IMediaService
{
    public async Task<List<CreateMediaCommandResponse>> CreateMediaAsync(CreateMediaCommandRequest request, CancellationToken ct = default)
    {
        List<(string fileName, string pathOrContainerName)> result = await storageService.UploadFileAsync("images", request.Files);
        var mediaEntities = result.Select(f => new Media
        {
            Path = f.pathOrContainerName,
            FileName = f.fileName
        }).ToList();
    
        await writeRepository.AddRangeAsync(mediaEntities);
        await writeRepository.SaveAsync();

        return mediaEntities.Select(m => new CreateMediaCommandResponse
        {
            Id = m.Id,
            FileName = m.FileName
        }).ToList();
    }

    public async Task<List<GetAllMediaQueryResponse>> GetAllMediaAsync(GetAllMediaQueryRequest request, CancellationToken cancellationToken)
    {
        IQueryable<Media> medias = readRepository.GetAll(false);
        return await medias.Select(m => new GetAllMediaQueryResponse
        {
            Id = m.Id,
            Path = m.Path,
            FullPath = configuration["BaseStorageUrl"] + "/" + m.Path,
            FileName = m.FileName
        }).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<RemoveMediaCommandResponse> RemoveMediaAsync(RemoveMediaCommandRequest request, CancellationToken cancellationToken)
    {
        Media? media = await readRepository.GetByIdAsync(request.Id, false);
        if (media == null)
            throw new MediaNotFoundException();
        try
        {
            await writeRepository.RemoveAsync(request.Id);
            await writeRepository.SaveAsync();
            await storageService.DeleteAsync(media.Path);
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException is PostgresException pgEx)
            {
                if (pgEx.SqlState == "23503")
                {
                    throw new MediaInUseException();
                }
                throw new Exception("Unknown error");
            }
        }
        
        return new();
    }
}