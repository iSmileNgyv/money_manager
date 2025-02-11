using Microsoft.AspNetCore.Http;
using MoneyManager.Application.Services.Storage.GoogleDrive;

namespace MoneyManager.Infrastructure.Services.Storage.GoogleDrive;

public class GoogleDriveStorage: Storage, IGoogleDriveStorage
{
    public Task<List<(string fileName, string path)>> UploadFileAsync(string pathOrContainerName, IFormFileCollection files)
    {
        throw new NotImplementedException();
    }

    public Task<(string fileName, string path)> SingleUploadFileAsync(string pathOrContainerName, IFormFile file)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string pathOrContainerName, string fileName)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(string fullPath)
    {
        throw new NotImplementedException();
    }

    public List<string> GetFiles(string pathOrContainerName)
    {
        throw new NotImplementedException();
    }

    public bool HasFile(string pathOrContainerName, string fileName)
    {
        throw new NotImplementedException();
    }
}