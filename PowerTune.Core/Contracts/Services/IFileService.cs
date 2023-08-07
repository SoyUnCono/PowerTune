namespace PowerTune.Core.Contracts.Services;

public interface IFileService
{
    Task<T> Read<T>(string folderPath, string fileName);

    Task Save<T>(string folderPath, string fileName, T content);

    Task Delete(string folderPath, string fileName);
}

