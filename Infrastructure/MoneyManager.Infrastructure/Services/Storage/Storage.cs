using MoneyManager.Infrastructure.Operations;

namespace MoneyManager.Infrastructure.Services.Storage;

public class Storage
{
    protected delegate bool HasFile(string pathOrContainerName, string fileName);
    protected async Task<string> FileRenameAsync(string path, string fileName, HasFile hasFile)
    {
        string extension = Path.GetExtension(fileName);
        string oldName = Path.GetFileNameWithoutExtension(fileName);
        string newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";
        int counter = 1;
        while(await Task.Run(() => hasFile(path, newFileName)))
        {
            newFileName = $"{NameOperation.CharacterRegulatory(oldName)}-{counter}{extension}";
            counter++;
        }
        return newFileName;
    }
}