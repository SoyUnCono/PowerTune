using System.Text;
using Newtonsoft.Json;
using PowerTune.Core.Contracts.Services;

namespace PowerTune.Core.Services;

public class FileService : IFileService
{
    public async Task<T> Read<T>(string folderPath, string fileName)
    {
        var path = Path.Combine(folderPath, fileName);
        if (!File.Exists(path))
            return default;

        var json = await File.ReadAllTextAsync(path);
        return JsonConvert.DeserializeObject<T>(json);

    }

    public Task Save<T>(string folderPath, string fileName, T content)
    {
        if (!Directory.Exists(folderPath))
        {
            if (folderPath != null)
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        var fileContent = JsonConvert.SerializeObject(content);
        File.WriteAllText(Path.Combine(folderPath ?? string.Empty, fileName), fileContent, Encoding.UTF8);
        return Task.CompletedTask;
    }

    public Task Delete(string folderPath, string fileName)
    {
        if (fileName != null && File.Exists(Path.Combine(folderPath, fileName)))
        {
            File.Delete(Path.Combine(folderPath, fileName));
        }

        return Task.CompletedTask;
    }
}
