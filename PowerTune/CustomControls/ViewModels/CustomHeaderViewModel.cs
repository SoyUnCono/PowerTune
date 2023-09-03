using CommunityToolkit.Mvvm.ComponentModel;
using PowerTune.Contracts.Services;
using PowerTune.Helpers;

namespace PowerTune.CustomControls.ViewModels;

public partial class CustomHeaderViewModel : ObservableRecipient
{
    private readonly ISystemInformationService _informationService;

    [ObservableProperty] private string? _systemInformationLabel;
    [ObservableProperty] private string? _nameInformationLabel;
    [ObservableProperty] private string? _motherBoardInformationLabel;
    [ObservableProperty] private string? _laptopOrDesktop;

    public CustomHeaderViewModel(ISystemInformationService informationService)
    {
        _informationService = informationService;
        LoadDataComputer();
    }

    private void LoadDataComputer()
    {
        var isDesktop = _informationService.IsDesktop();
        var getVersion = _informationService.IsWindows11();

        LaptopOrDesktop = isDesktop ? "Device : Desktop" : "Device : Laptop";
        SystemInformationLabel = getVersion ? "Operating System: Windows 11 " : "Operating System: Windows 10";
        NameInformationLabel = _informationService.GetComputerName();
        MotherBoardInformationLabel = _informationService.GetMotherBoardInformationLabel();
    }
}