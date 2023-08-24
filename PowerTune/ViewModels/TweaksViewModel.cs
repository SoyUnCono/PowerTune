using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PowerTune.Core.Contracts.Services;
using PowerTune.Helpers;
using PowerTune.Services;
using PowerTune.Strings;

namespace PowerTune.ViewModels;

public class AppSettings
{
    public bool IsBoldCheck
    {
        get;
        init;
    }

    public bool DefaultDPI
    {
        get;
        init;
    }

    public bool VisualFeedBack
    {
        get;
        init;
    }

    public bool HideScrollBar
    {
        get;
        init;
    }

    public int SelectedTitleBarSize
    {
        get;
        init;
    }

    public bool ShowDisplayVersion
    {
        get;
        init;
    }
}

public partial class TweaksViewModel : ObservableRecipient
{
    private readonly IFileService _fileService;

    [ObservableProperty] private bool _isBoldCheck;
    [ObservableProperty] private bool _visualFeedBack;
    [ObservableProperty] private bool _showErrorDialog;
    [ObservableProperty] private bool _hideScrollBar;
    [ObservableProperty] private bool _showDisplayVersion;
    [ObservableProperty] private bool _setWindowsDPI;

    [ObservableProperty] private int _selectedTitleBarSize;

    [ObservableProperty] private string? _selectedString;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;

    public bool IsNotBusy => !IsBusy;
    public static List<int> TitlebarSizes => DictionaryStrings.TitlebarSize;

    public TweaksViewModel(IFileService fileService)
    {
        _fileService = fileService;
        LoadSettingsAsync().ConfigureAwait(true);
    }

    private async Task LoadSettingsAsync()
    {
        var settings = await _fileService.Read<AppSettings>($"{Constants.PowerTunePath}", "AppSettings.json");
        ErrorCodeStrings.ErrorHandler.TryGetValue("ErrorCode-LoadSettings", out var errorData);

        if (settings == null)
            await ContentDialogService.ShowDialogAsync(errorData.title, errorData.description, errorData.errorCode);

        SelectedTitleBarSize = settings!.SelectedTitleBarSize;
        IsBoldCheck = settings.IsBoldCheck;
        VisualFeedBack = settings.VisualFeedBack;
        HideScrollBar = settings.HideScrollBar;
        ShowDisplayVersion = settings.ShowDisplayVersion;
        SetWindowsDPI = settings.DefaultDPI;
    }

    private async Task SaveSettings()
    {
        ErrorCodeStrings.ErrorHandler.TryGetValue("ErrorCode-SaveSettings", out var errorData);
        try
        {
            IsBusy = true;
            await _fileService.Save($"{Constants.PowerTunePath}", "AppSettings.json", new AppSettings
            {
                HideScrollBar = HideScrollBar,
                IsBoldCheck = IsBoldCheck,
                SelectedTitleBarSize = SelectedTitleBarSize,
                VisualFeedBack = VisualFeedBack,
                ShowDisplayVersion = ShowDisplayVersion,
                DefaultDPI = ShowDisplayVersion,
            });
        }
        catch
        {
            
            await ContentDialogService.ShowDialogAsync(errorData.title, errorData.description, errorData.errorCode);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    private void ApplyBasicsOptimizations()
    {
        // Indicate that an operation is in progress
        IsBusy = true;

        // Retrieve the current operating system version
        var osVersion = Environment.OSVersion.Version;

        // Check if the OS version is Windows 10 (specifically 10.0)
        // Apply Windows 10 registry optimizations
        if (osVersion is { Major: 10, Minor: 0 })
            RegistryHelper.ImportRegistryFromString(RawString.RawBasicsOptimizationsW10);

        // Check if the OS version is Windows 11 with a build number greater than or equal to 22000
        // Apply Windows 11 registry optimizations
        if (osVersion is { Major: >= 10, Build: >= 22000 })
            RegistryHelper.ImportRegistryFromString(RawString.RawBasicsOptimizationsW11);

        // Indicate that the operation is complete
        IsBusy = false;
    }

    public async void ApplyTitleBarSizeAsync()
    {
        // Indicate that an operation is in progress
        IsBusy = true;

        // Try to get the selected title bar size from the dictionary
        if (DictionaryStrings.StringData.TryGetValue(SelectedTitleBarSize, out var stringPair))
        {
            // Check if the IsBoldCheck is false
            if (IsBoldCheck == false)
                SelectedString = stringPair.REGULAR; // Use the regular string

            // Check if the IsBoldCheck is true
            if (IsBoldCheck)
                SelectedString = stringPair.BOLD; // Use the bold string
        }

        // Check if the SelectedString is null or empty
        if (string.IsNullOrEmpty(SelectedString))
        {
            // Show an error dialog if the selected string is missing or empty
            await ContentDialogService.ShowDialogAsync(
                title: "Error Applying Title Bar Size",
                description: "Failed to apply title bar size. The selected string is missing or empty.",
                errorCode: "Please ensure that a valid title bar size is selected before applying.");

            IsBusy = false; // Indicate that the operation is complete
            return; // Exit the method to avoid further execution
        }

        // Import registry settings from the SelectedString
        RegistryHelper.ImportRegistryFromString(SelectedString);

        // Save settings
        await SaveSettings();
        // Indicate that the operation is complete
        IsBusy = false;
    }


    public async Task ApplyToggleSwitchValue(object sender, RoutedEventArgs e)
    {
        // Get the ToggleSwitch that triggered the event
        // Get the identifier for the ToggleSwitch
        // Get the registry command
        // Get the state of the ToggleSwitch
        var toggleSwitch = (ToggleSwitch)sender;
        var toggleSwitchId = toggleSwitch.Tag.ToString();
        var customCommand = RegistryHelper.SetRegistryValue;
        var check = toggleSwitch.IsOn;
        ErrorCodeStrings.ErrorHandler.TryGetValue("ErrorCode-DefaultError", out var errorData);
        var removeCommand = RegistryHelper.RemoveRegistryKey;

        switch (toggleSwitchId)
        {
            case "HideScrollBar":
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.ShowAlwaysScrollBarPath,
                    ValueStrings.ShowAlwaysScrollBarValue, check ? 1 : 0);
                HideScrollBar = check;
                await SaveSettings().ConfigureAwait(true);
                break;

            case "VisualFeedBack":
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.VisualFeedBackPath,
                    ValueStrings.VisualFeedBackvalue1,
                    check ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.VisualFeedBackPath,
                    ValueStrings.VisualFeedBackvalue1,
                    check ? 0 : 1f);
                VisualFeedBack = check;
                await SaveSettings().ConfigureAwait(true);
                break;
            case "ShowWindowsDesktopVersion":
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.DisplayVersionPath,
                    ValueStrings.ShowDisplayVersionValue, check
                        ? 1
                        : 0);
                ShowDisplayVersion = check;
                await SaveSettings().ConfigureAwait(true);
                break;
            case "SetWindowsDPI":
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.WindowsDPIPath, ValueStrings.WindowsDPIValue,
                    00000096);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.WindowsDPIPath2, ValueStrings.WindowsDPIValue2,
                    check ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.WindowsDPIPath2, ValueStrings.WindowsDPIValue3,
                    check ? 00000096 : 0);
                removeCommand("HKEY_CURRENT_USER", @"Control Panel\Desktop\PerMonitorSettings");
                await SaveSettings().ConfigureAwait(true);
                break;
            default:
                await ContentDialogService.ShowDialogAsync(errorData.title, errorData.description, errorData.errorCode);
                break;
        }
    }
}