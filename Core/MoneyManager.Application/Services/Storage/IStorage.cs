using Microsoft.AspNetCore.Http;

namespace MoneyManager.Application.Services.Storage;

public interface IStorage
{
    Task<List<(string fileName, string path)>> UploadFileAsync(string pathOrContainerName, IFormFileCollection files);
    Task<(string fileName, string path)> SingleUploadFileAsync(string pathOrContainerName, IFormFile file);
    Task DeleteAsync(string pathOrContainerName, string fileName);
    Task DeleteAsync(string fullPath);
    List<string> GetFiles(string pathOrContainerName);
    bool HasFile(string pathOrContainerName, string fileName);
}