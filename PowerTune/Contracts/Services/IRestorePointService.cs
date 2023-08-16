namespace PowerTune.Contracts.Services;

public interface IRestorePointService
{
    Task<bool> RunRestorePoint();
}