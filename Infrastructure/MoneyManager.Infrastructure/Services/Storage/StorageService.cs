using Microsoft.AspNetCore.Http;
using MoneyManager.Application.Services.Storage;

namespace MoneyManager.Infrastructure.Services.Storage;

public class StorageService(IStorage storage) : IStorageService
{
    public async Task<List<(string fileName, string path)>> UploadFileAsync(string pathOrContainerName, IFormFileCollection files)
    {
        return await storage.UploadFileAsync(pathOrContainerName, files);
    }

    public async Task<(string fileName, string path)> SingleUploadFileAsync(string pathOrContainerName, IFormFile file)
    {
        return await storage.SingleUploadFileAsync(pathOrContainerName, file);
    }

    public async Task DeleteAsync(string pathOrContainerName, string fileName)
    {
        await storage.DeleteAsync(pathOrContainerName, fileName);
    }

    public async Task DeleteAsync(string fullPath)
    {
        await storage.DeleteAsync(fullPath);
    }

    public List<string> GetFiles(string pathOrContainerName)
    {
        return storage.GetFiles(pathOrContainerName);
    }

    public bool HasFile(string pathOrContainerName, string fileName)
    {
        return storage.HasFile(pathOrContainerName, fileName);
    }

    public string StorageName => storage.GetType().Name;
}