namespace PowerTune.Contracts.Services;

public interface ISystemInformationService
{
    string GetMotherBoardInformationLabel();
    string GetComputerName();
    bool IsWindows11();
    bool IsDesktop();
    bool IsRunAsAdmin();
    
    
}