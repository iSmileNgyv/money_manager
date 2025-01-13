using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MoneyManager.Application.Services.Storage.Local;

namespace MoneyManager.Infrastructure.Services.Storage.Local;

public class LocalStorage(IWebHostEnvironment webHostEnvironment) : Storage, ILocalStorage
{
    public async Task<List<(string fileName, string path)>> UploadFileAsync(string path, IFormFileCollection files)
    {
        string uploadPath = Path.Combine(webHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        List<(string fileName, string path)> datas = new();
        foreach (IFormFile file in files)
        {
            string fileNewName = await FileRenameAsync(path, file.FileName, HasFile);
            await CopyFileAsync($"{uploadPath}/{fileNewName}", file);
            datas.Add((fileNewName, $"{path}/{fileNewName}"));
        }

        return datas;
    }

    public async Task<(string fileName, string path)> SingleUploadFileAsync(string path, IFormFile file)
    {
        string uploadPath = Path.Combine(webHostEnvironment.WebRootPath, path);
        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);
        string fileNewName = await FileRenameAsync(path, file.Name, HasFile);
        await CopyFileAsync($"{uploadPath}/{fileNewName}", file);
        return (fileNewName, $"{path}/{fileNewName}");
    }

    public Task DeleteAsync(string path, string fileName)
    {
        File.Delete($"{path}/{fileName}");
        return Task.CompletedTask;
    }

    public Task DeleteAsync(string fullPath)
    {
        string path = Path.Combine(webHostEnvironment.WebRootPath, fullPath);
        File.Delete(path);
        return Task.CompletedTask;
    }

    public List<string> GetFiles(string path)
    {
        DirectoryInfo directory = new(path);
        return directory.GetFiles().Select(f => f.Name).ToList();
    }

    public new bool HasFile(string path, string fileName)
        => File.Exists(Path.Combine(webHostEnvironment.WebRootPath, path, fileName));
    
    async Task CopyFileAsync(string path, IFormFile file)
    {
        try
        {
            await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);

            await file.CopyToAsync(fileStream);
            await fileStream.FlushAsync();
        }
        catch (Exception ex)
        {
            //todo log!
            throw ex;
        }
    }
}