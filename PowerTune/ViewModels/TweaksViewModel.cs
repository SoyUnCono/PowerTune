using System.CodeDom;
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
    public bool SecurityFileDownloads
    {
        get;
        init;
    }

    public bool IsBoldCheck
    {
        get;
        init;
    }

    public bool DefaultDpi
    {
        get;
        init;
    }

    public bool EnhancedSearchIndexing
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
    [ObservableProperty] private bool _setWindowsDpi;
    [ObservableProperty] private bool _enhancedSearchIndexing;
    [ObservableProperty] private bool _securityFileDownload;

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
        SetWindowsDpi = settings.DefaultDpi;
        EnhancedSearchIndexing = settings.EnhancedSearchIndexing;
        SecurityFileDownload = settings.SecurityFileDownloads;
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
                DefaultDpi = SetWindowsDpi,
                EnhancedSearchIndexing = EnhancedSearchIndexing,
                SecurityFileDownloads = SecurityFileDownload,
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
        ErrorCodeStrings.ErrorHandler.TryGetValue("Error-Applying-TitleBarSize", out var errorData);

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
            await ContentDialogService.ShowDialogAsync(errorData.title, errorData.description, errorData.errorCode);

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
        ErrorCodeStrings.ErrorHandler.TryGetValue("ErrorCode-DefaultError", out var errorData);

        var toggleSwitch = (ToggleSwitch)sender;
        var toggleSwitchId = toggleSwitch.Tag.ToString();
        var customCommand = RegistryHelper.SetRegistryValue;
        var check = toggleSwitch.IsOn;
        var removeCommand = RegistryHelper.RemoveRegistryKey;

        switch (toggleSwitchId)
        {
            case "SecuritySettingsFileDownload":
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.SecurityFileDownloadPath,
                    ValueStrings.SecurityFileDownloadValue, check ? "no" : 0);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.SecurityFileDownloadPath,
                    ValueStrings.SecurityFileDownloadValue1, check ? 00000001 : 0);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.SecurityFileDownloadPath1,
                    ValueStrings.SecurityFileDownloadValue2, check ? 00000001 : 0);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.SecurityFileDownloadPath2,
                    ValueStrings.SecurityFileDownloadValue3,
                    check
                        ? ".zip;.rar;.nfo;.txt;.exe;.bat;.com;.cmd;.reg;.msi;.htm;.html;.gif;.bmp;.jpg;.avi;.mpg;.mpeg;.mov;.mp3;.m3u;.msu;.wav;"
                        : 0);
                SecurityFileDownload = check;
                await SaveSettings().ConfigureAwait(true);
                break;
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
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.WindowsDpiPath, ValueStrings.WindowsDpiValue,
                    00000096);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.WindowsDpiPath2, ValueStrings.WindowsDpiValue2,
                    check ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.WindowsDpiPath2, ValueStrings.WindowsDpiValue3,
                    check ? 00000096 : 0);
                removeCommand("HKEY_CURRENT_USER", @"Control Panel\Desktop\PerMonitorSettings");
                SetWindowsDpi = check;
                await SaveSettings().ConfigureAwait(true);
                break;
            case "EnhancedSearchIndexing":
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.EnhancedSearchIndexingPath,
                    ValueStrings.EnhancedSearchIndexingValue, check ? 0 : 0000001);
                EnhancedSearchIndexing = check;
                await SaveSettings().ConfigureAwait(true);
                break;
            default:
                await ContentDialogService.ShowDialogAsync(errorData.title, errorData.description, errorData.errorCode);
                break;
        }
    }
}