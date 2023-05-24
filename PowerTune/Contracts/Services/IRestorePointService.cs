namespace PowerTune.Services;

public interface IRestorePointService
{
    Task<bool> RunRestorePoint();
}