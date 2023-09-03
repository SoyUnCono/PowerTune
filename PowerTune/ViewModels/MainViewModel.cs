using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Win32;
using PowerTune.Contracts.Services;
using PowerTune.Helpers;
using PowerTune.Services;
using PowerTune.Strings;
using Windows.System;

namespace PowerTune.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    private readonly INavigationService _navigationService;

    private const string LessThan75Perccent =
        "You can still store data, but monitor usage to avoid running out of space. Review and delete unnecessary files regularly.";

    private const string MoreThan75Perccent =
        "Memory usage exceeded 75%. Delete unnecessary files or apps to free up memory. Consider resetting device if issues persist.";

    private const string MoreThan90Perccent =
        "Memory usage exceeded 90%. Reset device to free up space and resolve memory issues. Back up critical data before resetting.";

    [ObservableProperty] private string? _username;
    [ObservableProperty] private string? _tip;
    [ObservableProperty] private string? _systeminformation;
    [ObservableProperty] private string? _storage;
    [ObservableProperty] private string? _lastchecked;
    [ObservableProperty] private string? _fulldatastorage;
    [ObservableProperty] private int _index;
    [ObservableProperty] private string? _notificationTitle;
    [ObservableProperty] private string? _notificationMessage;
    [ObservableProperty] private string? _notificationsIconSource;
    [ObservableProperty] private string? _isRunAsAdmin;
    [ObservableProperty] private bool _uacToggleSwitchValue;
    [ObservableProperty] private bool _startUpTimeToggleSwitchValue;
    [ObservableProperty] private bool _altTabValue;
    [ObservableProperty] private bool _comboboxIndex;
    [ObservableProperty] private bool _oldSoundMixer;
    [ObservableProperty] private bool _checkBoxDialog;
    [ObservableProperty] private bool _disableAppsBackground;
    [ObservableProperty] private bool _easeOfAccess;
    [ObservableProperty] private bool _account;
    [ObservableProperty] private bool _apps;
    [ObservableProperty] private bool _personalization;
    [ObservableProperty] private bool _notifications;
    [ObservableProperty] private bool _isNotificationOpen = false;
    [ObservableProperty] private bool _canCloseNotification = false;
    [ObservableProperty] private bool _notificationIconsVisible = false;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool _isBusy;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsWindows10))]
    private bool _isWindows11;
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(DontShowHeader))]
    private bool _headerViewContent;

    public bool IsWindows10 => !IsWindows11;
    public bool DontShowHeader => !HeaderViewContent;
    public bool IsNotBusy => !IsBusy;


    public ICommand OpenWindowsUpdatesCommand
    {
        get;
    }

    public ICommand NavigateToTweaksPageCommand
    {
        get;
    }
    public MainViewModel(INavigationService navigationService)
    {
        _ = StartupAsyncTasks();

        OpenWindowsUpdatesCommand = new RelayCommand(OnWindowsUpdatesAsync);
        NavigateToTweaksPageCommand = new RelayCommand(OnNavigateToTweaksPage);

        _navigationService = App.GetService<INavigationService>();
        _navigationService = navigationService;
    }

    private async Task StartupAsyncTasks()
    {
        IsBusy = true;
        GetUsernamePc();
        GetSystemInformation();
        GetDiskInformation();
        GetLastChecked();
        SetStateInitialValues();
        await NotificationTask();

        IsBusy = false;
    }

    private void GetUsernamePc() => Username = Environment.UserName;

    private static async void OnWindowsUpdatesAsync() =>
        await Launcher.LaunchUriAsync(new Uri("ms-settings:windowsupdate"));

    private void OnNavigateToTweaksPage() => _navigationService.NavigateTo(typeof(TweaksViewModel).FullName!);

    private void GetDiskInformation()
    {
        var driveName = Path.GetPathRoot(Environment.SystemDirectory);
        if (driveName == null) return;
        var driveInfo = new DriveInfo(driveName);
        var totalSpaceInBytes = driveInfo.TotalSize;
        var freeSpaceInBytes = driveInfo.TotalFreeSpace;
        var usedSpaceInBytes = totalSpaceInBytes - freeSpaceInBytes;
        var usedSpacePercentage = (double)usedSpaceInBytes / totalSpaceInBytes * 100;
        var freeSpaceInGb = Math.Floor((double)freeSpaceInBytes / (1024 * 1024 * 1024));

        Storage = $"{Math.Round(usedSpacePercentage, 0, MidpointRounding.ToZero)}% full";

        if (usedSpacePercentage < 75)
            Fulldatastorage =
                $"Your storage device is currently utilizing {Storage} of space, leaving you with {freeSpaceInGb}GB of free space. {LessThan75Perccent}";

        if (usedSpacePercentage >= 75 && usedSpacePercentage < 90)
            Fulldatastorage =
                $"Your storage device is currently utilizing {Storage} of space, leaving you with {freeSpaceInGb}GB of free space. {MoreThan75Perccent}";

        if (usedSpacePercentage >= 90)
            Fulldatastorage =
                $"Your storage device is currently utilizing {Storage} of space, leaving you with {freeSpaceInGb}GB of free space. {MoreThan90Perccent}";
    }

    private async Task NotificationTask()
    {
        var restorePointExists = await RestorePointService.CheckIfRestorePointExists(Constants.RestorePointServiceName);

        IsNotificationOpen = true;
        CanCloseNotification = true;
        NotificationIconsVisible = true;
        NotificationTitle = "Information about the status of the restore point.";
        NotificationMessage =
            $"{(restorePointExists ? "Restore point already detected, operation aborted." : $"The restore point has been successfully created at {DateTime.Now}.")}";
    }

    public void TaskBarFunctions(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = (ComboBox)sender;
        var selectedItem = (ComboBoxItem)comboBox.SelectedItem;
        var customCommand = RegistryHelper.SetRegistryValue;
        if (selectedItem == null) return;

        var userChoice = selectedItem.Content.ToString();

        switch (userChoice)
        {
            case "Center":
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.TaskbarPositionPath,
                    ValueStrings.TaskbarPositionValue, 1);
                break;

            case "Left":
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.TaskbarPositionPath,
                    ValueStrings.TaskbarPositionValue, 0);
                break;

        }
    }

    private void GetSystemInformation()
    {
        var osVersion = Environment.OSVersion.Version;
        var editionID =
            Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "EditionID",
                null) as string;

        if (osVersion is { Major: 10, Minor: 0 })
            Systeminformation = $"You're currently running Windows 10 {editionID} ({osVersion})";
        IsWindows11 = false;

        if (osVersion is { Major: 10, Minor: 0, Build: >= 22000 })
            Systeminformation = $"You're currently running Windows 11 {editionID} ({osVersion})";
        IsWindows11 = true;
    }

    private void GetLastChecked()
    {
        var systemPath = Environment.SystemDirectory;
        var systemFile = new FileInfo(Path.Combine(systemPath, "ntoskrnl.exe"));
        var lastUpdate = systemFile.LastWriteTime;

        Lastchecked = $"The last time the system was updated was: {lastUpdate}";
    }

    private void SetStateInitialValues()
    {
        var customCommand = RegistryHelper.GetToggleSwitchInitialValue;

        const string registryKeyPathUac = $"{RootKeys.HKEY_LOCAL_MACHINE}\\{PathStrings.UacPath}";
        const string registryKeyPathApplicationPath = $"{RootKeys.HKEY_LOCAL_MACHINE}\\{PathStrings.ApplicationPath}";
        const string registryKeyPathTaskbarAlignment =
            $"{RootKeys.HKEY_CURRENT_USER}\\{PathStrings.TaskbarPositionPath}";
        const string registryKeyPathAltTab = $"{RootKeys.HKEY_CURRENT_USER}\\{PathStrings.AltTabPath}";
        const string registryKeyPathOldSoundMixer = $"{RootKeys.HKEY_LOCAL_MACHINE}\\{PathStrings.OldSoundMixerPath}";
        const string registryKeyPathBackgroundApps =
            $"{RootKeys.HKEY_CURRENT_USER}\\{PathStrings.BackgroundAccessApplicationsPath}";
        const string registryKeyPathEaseOfAccess = $"{RootKeys.HKEY_CURRENT_USER}\\{PathStrings.NarratorPath}";
        const string registryKeyPathAccount = $"{RootKeys.HKEY_LOCAL_MACHINE}\\{PathStrings.AutoFinishSetupPath}";
        const string registryKeyPathApps = $"{RootKeys.HKEY_LOCAL_MACHINE}\\{PathStrings.AutoUpdateMapsPath}";
        const string registryKeyPathPersonalization =
            $"{RootKeys.HKEY_LOCAL_MACHINE}\\{PathStrings.RecentlyAddedAppsPath1}";
        const string registryKeyPathNotifications = $"{RootKeys.HKEY_CURRENT_USER}\\{PathStrings.NotificationsPath1}";

        UacToggleSwitchValue = customCommand(registryKeyPathUac, ValueStrings.UacValue, 0);
        StartUpTimeToggleSwitchValue = customCommand(registryKeyPathApplicationPath, ValueStrings.StartUpTimeValue, 1);
        ComboboxIndex = customCommand(registryKeyPathTaskbarAlignment, ValueStrings.TaskbarPositionValue, 0);
        AltTabValue = customCommand(registryKeyPathAltTab, ValueStrings.AltTabValue, 1);
        OldSoundMixer = customCommand(registryKeyPathOldSoundMixer, ValueStrings.OldSoundMixerValue, 1);
        CheckBoxDialog = customCommand(registryKeyPathApplicationPath, ValueStrings.DialogStatus, 1);
        HeaderViewContent = customCommand(registryKeyPathApplicationPath, ValueStrings.HeaderViewContentValue, 1);
        DisableAppsBackground = customCommand(registryKeyPathBackgroundApps, ValueStrings.GlobalUserDisabledValue, 1);
        EaseOfAccess = customCommand(registryKeyPathEaseOfAccess, ValueStrings.WinEnterLaunchEnabledValue, 0);
        Account = customCommand(registryKeyPathAccount, ValueStrings.DisableAutomaticRestartSignOnValue, 1);
        Apps = customCommand(registryKeyPathApps, ValueStrings.AutoUpdateEnabledValue, 0);
        Personalization = customCommand(registryKeyPathPersonalization, ValueStrings.HideRecentlyAddedAppsValue1, 1);
        Notifications = customCommand(registryKeyPathNotifications, ValueStrings.NotificationsValue1, 0);
    }

    public void SetWindowsRegistryToggle(object sender, RoutedEventArgs e)
    {
        var toggleSwitch = (ToggleSwitch)sender;
        var toggleSwitchId = toggleSwitch.Tag as string;

        var customCommand = RegistryHelper.SetRegistryValue;
        var removeCommand = RegistryHelper.RemoveRegistryKey;

        switch (toggleSwitchId)
        {
            case "UAC":
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.UacPath, ValueStrings.UacValue,
                    toggleSwitch.IsOn ? 0 : 1);
                break;

            case "Start_Up_Time":
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.ApplicationPath, ValueStrings.StartUpTimeValue,
                    toggleSwitch.IsOn ? 1 : 0);
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.VerbosePath, ValueStrings.VerboseValue,
                    toggleSwitch.IsOn ? 1 : 0);
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.SerializePath, ValueStrings.SerializeValue,
                    toggleSwitch.IsOn ? 0 : 1);
                break;
            case "Backgrounds_Apps":
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.BackgroundAccessApplicationsPath,
                    ValueStrings.GlobalUserDisabledValue, toggleSwitch.IsOn ? 1 : 0);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.SearchPath,
                    ValueStrings.BackgroundAppGlobalToggleValue, toggleSwitch.IsOn ? 0 : 1);
                break;
            case "Ease_of_Access":
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.NarratorPath, ValueStrings.WinEnterLaunchEnabledValue,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.StickyKeysPath, ValueStrings.StickyKeysFlagsValue,
                    toggleSwitch.IsOn ? 506 : 0);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.ToggleKeysPath, ValueStrings.ToggleKeysFlagsValue,
                    toggleSwitch.IsOn ? 34 : 0);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.KeyboardResponsePath,
                    ValueStrings.KeyboardResponseFlagsValue, toggleSwitch.IsOn ? 2 : 0);
                break;
            case "Account":
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.AutoFinishSetupPath,
                    ValueStrings.DisableAutomaticRestartSignOnValue, toggleSwitch.IsOn ? 1 : 0);
                break;
            case "Apps":
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.AutoUpdateMapsPath,
                    ValueStrings.AutoUpdateEnabledValue, toggleSwitch.IsOn ? 0 : 1);
                removeCommand(RootKeys.HKEY_LOCAL_MACHINE, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                removeCommand(RootKeys.HKEY_CURRENT_USER, @"Software\Microsoft\Windows\CurrentVersion\Run");
                break;
            case "Personalization":
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.RecentlyAddedAppsPath1,
                    ValueStrings.HideRecentlyAddedAppsValue1, toggleSwitch.IsOn ? 1 : 0);
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.RecentlyAddedAppsPath2,
                    ValueStrings.HideRecentlyAddedAppsValue2, toggleSwitch.IsOn ? 1 : 0);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.AlwaysShowIconsPath, ValueStrings.EnableAutoTrayValue,
                    toggleSwitch.IsOn ? 0 : 1);
                break;
            case "Notifications":
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.NotificationsPath1, ValueStrings.NotificationsValue1,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.NotificationsPath1, ValueStrings.NotificationsValue2,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.NotificationsPath1, ValueStrings.NotificationsValue8,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.NotificationsPath2, PathStrings.NotificationsPath3,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.NotificationsPath2, PathStrings.NotificationsPath4,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.NotificationsPath3, ValueStrings.NotificationsValue5,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.NotificationsPath4, ValueStrings.NotificationsValue6,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.NotificationsPath5, ValueStrings.NotificationsValue7,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.NotificationsPath6, ValueStrings.NotificationsValue7,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.TabletModePath1, ValueStrings.TabletModeValue1,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.TabletModePath1, ValueStrings.TabletModeValue2,
                    toggleSwitch.IsOn ? 1 : 0);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.TabletModePath1, ValueStrings.TabletModeValue3,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.TabletModePath2, ValueStrings.TabletModeValue4,
                    toggleSwitch.IsOn ? 1 : 0);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.TabletModePath2, ValueStrings.TabletModeValue5,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.TabletModePath2, ValueStrings.VirtualDesktopsValue1,
                    toggleSwitch.IsOn ? 1 : 0);
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.TabletModePath2, ValueStrings.VirtualDesktopsValue2,
                    toggleSwitch.IsOn ? 1 : 0);
                break;
            case "HeaderView":
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.ApplicationPath, ValueStrings.HeaderViewContentValue,
                    toggleSwitch.IsOn ? 1 : 0);
                break;

            // Default Case
            default:
                break;
        }
    }

    public void SetWindowsRegistryCheckBox(object sender, RoutedEventArgs e)
    {
        var checkBox = (CheckBox)sender;
        var checkBoxId = checkBox.Tag as string;

        var checkStatus = (bool)checkBox.IsChecked!;

        var customCommand = RegistryHelper.SetRegistryValue;

        switch (checkBoxId)
        {
            case "Alt_Tab":
                customCommand(RootKeys.HKEY_CURRENT_USER, PathStrings.AltTabPath, ValueStrings.AltTabValue,
                    checkStatus ? 1 : 0);
                break;
            case "Old_Sound_Mixer":
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.OldSoundMixerPath, ValueStrings.OldSoundMixerValue,
                    checkStatus ? 1 : 0);
                break;
            case "Dialog_Visibility":
                customCommand(RootKeys.HKEY_LOCAL_MACHINE, PathStrings.ApplicationPath, ValueStrings.DialogStatus,
                    checkStatus ? 1 : 0);
                break;
            default:
                break;
        }
    }
}