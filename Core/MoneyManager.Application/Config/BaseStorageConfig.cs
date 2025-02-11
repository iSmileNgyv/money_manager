namespace MoneyManager.Application.Config;

public static class BaseStorageConfig
{
    public static string GetBaseStorageUrl()
    {
        var configuration = Configuration.GetConfiguration();

        string? selectedStorage = configuration["Storage:SelectedStorage"];

        if (string.IsNullOrEmpty(selectedStorage))
        {
            selectedStorage = "LocalStorage";
        }

        string? baseUrl = configuration[$"Storage:{selectedStorage}:Url"];

        if (string.IsNullOrEmpty(baseUrl))
        {
            throw new Exception($"Storage URL not found: {selectedStorage}");
        }

        return baseUrl;
    }

    public static string FullPath(string? fileId)
    {
        var baseUrl = GetBaseStorageUrl();
        return $"{baseUrl}/{fileId}";
    }
}