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
    readonly INavigationService _navigationService;

    const string LessThan75Perccent =
        "You can still store data, but monitor usage to avoid running out of space. Review and delete unnecessary files regularly.";

    const string MoreThan75Perccent =
        "Memory usage exceeded 75%. Delete unnecessary files or apps to free up memory. Consider resetting device if issues persist.";

    const string MoreThan90Perccent =
        "Memory usage exceeded 90%. Reset device to free up space and resolve memory issues. Back up critical data before resetting.";

    [ObservableProperty] private string? _username;
    [ObservableProperty] private string? _tip;
    [ObservableProperty] private string? _systeminformation;
    [ObservableProperty] private string? _storage;
    [ObservableProperty] private string? _lastchecked;
    [ObservableProperty] private string? _fulldatastorage;
    [ObservableProperty] private int _index;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool _isBusy;

    [ObservableProperty] private string? _notificationTitle;
    [ObservableProperty] private string? _notificationMessage;
    [ObservableProperty] private string? _notificationsIconSource;
    [ObservableProperty] private string? _isRunAsAdmin;
    [ObservableProperty] private bool _isNotificationOpen = false;
    [ObservableProperty] private bool _canCloseNotification = false;
    [ObservableProperty] private bool _notificationIconsVisible = false;

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(IsNotWindows11))]
    private bool _isWindows11;

    public ICommand OpenWindowsUpdatesCommand
    {
        get;
    }

    public ICommand NavigateToTweaksPageCommand
    {
        get;
    }

    public bool IsNotBusy => !IsBusy;
    public bool IsNotWindows11 => !IsWindows11;
    public bool DontShowHeader => !HeaderViewContent;

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

    [ObservableProperty] [NotifyPropertyChangedFor(nameof(DontShowHeader))]
    private bool _headerViewContent;

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
        var restorePointExists = await RestorePointService.CheckIfRestorePointExists(Constants.restorePointServiceName);

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
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TaskbarPositionPath,
                    Constants.TaskbarPositionValue, 1);
                break;

            case "Left":
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TaskbarPositionPath,
                    Constants.TaskbarPositionValue, 0);
                break;

            default:
                break;
        }
    }

    private void GetSystemInformation()
    {
        var osVersion = Environment.OSVersion.Version;
        var editionID =
            Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "EditionID",
                null) as string;

        if (osVersion.Major == 10 && osVersion.Minor == 0)
            Systeminformation = $"You're currently running Windows 10 {editionID} ({osVersion})";
        IsWindows11 = false;

        if (osVersion.Major == 10 && osVersion.Minor == 0 && osVersion.Build >= 22000)
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

        const string registryKeyPathUac = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.UacPath}";
        const string registryKeyPathApplicationPath = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.ApplicationPath}";
        const string registryKeyPathTaskbarAlignment =
            $"{Constants.HKEY_CURRENT_USER}\\{Constants.TaskbarPositionPath}";
        const string registryKeyPathAltTab = $"{Constants.HKEY_CURRENT_USER}\\{Constants.AltTabPath}";
        const string registryKeyPathOldSoundMixer = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.OldSoundMixerPath}";
        const string registryKeyPathBackgroundApps =
            $"{Constants.HKEY_CURRENT_USER}\\{Constants.BackgroundAccessApplicationsPath}";
        const string registryKeyPathEaseOfAccess = $"{Constants.HKEY_CURRENT_USER}\\{Constants.NarratorPath}";
        const string registryKeyPathAccount = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.AutoFinishSetupPath}";
        const string registryKeyPathApps = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.AutoUpdateMapsPath}";
        const string registryKeyPathPersonalization =
            $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.RecentlyAddedAppsPath1}";
        const string registryKeyPathNotifications = $"{Constants.HKEY_CURRENT_USER}\\{Constants.NotificationsPath1}";

        UacToggleSwitchValue = customCommand(registryKeyPathUac, Constants.UacValue, 0);
        StartUpTimeToggleSwitchValue = customCommand(registryKeyPathApplicationPath, Constants.StartUpTimeValue, 1);
        ComboboxIndex = customCommand(registryKeyPathTaskbarAlignment, Constants.TaskbarPositionValue, 0);
        AltTabValue = customCommand(registryKeyPathAltTab, Constants.AltTabValue, 1);
        OldSoundMixer = customCommand(registryKeyPathOldSoundMixer, Constants.OldSoundMixerValue, 1);
        CheckBoxDialog = customCommand(registryKeyPathApplicationPath, Constants.DialogStatus, 1);
        HeaderViewContent = customCommand(registryKeyPathApplicationPath, Constants.HeaderViewContentValue, 1);
        DisableAppsBackground = customCommand(registryKeyPathBackgroundApps, Constants.GlobalUserDisabledValue, 1);
        EaseOfAccess = customCommand(registryKeyPathEaseOfAccess, Constants.WinEnterLaunchEnabledValue, 0);
        Account = customCommand(registryKeyPathAccount, Constants.DisableAutomaticRestartSignOnValue, 1);
        Apps = customCommand(registryKeyPathApps, Constants.AutoUpdateEnabledValue, 0);
        Personalization = customCommand(registryKeyPathPersonalization, Constants.HideRecentlyAddedAppsValue1, 1);
        Notifications = customCommand(registryKeyPathNotifications, Constants.NotificationsValue1, 0);
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
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.UacPath, Constants.UacValue,
                    toggleSwitch.IsOn ? 0 : 1);
                break;

            case "Start_Up_Time":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.ApplicationPath, Constants.StartUpTimeValue,
                    toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.VerbosePath, Constants.VerboseValue,
                    toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.SerializePath, Constants.SerializeValue,
                    toggleSwitch.IsOn ? 0 : 1);
                break;
            case "Backgrounds_Apps":
                customCommand(Constants.HKEY_CURRENT_USER, Constants.BackgroundAccessApplicationsPath,
                    Constants.GlobalUserDisabledValue, toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.SearchPath,
                    Constants.BackgroundAppGlobalToggleValue, toggleSwitch.IsOn ? 0 : 1);
                break;
            case "Ease_of_Access":
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NarratorPath, Constants.WinEnterLaunchEnabledValue,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.StickyKeysPath, Constants.StickyKeysFlagsValue,
                    toggleSwitch.IsOn ? 506 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.ToggleKeysPath, Constants.ToggleKeysFlagsValue,
                    toggleSwitch.IsOn ? 34 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.KeyboardResponsePath,
                    Constants.KeyboardResponseFlagsValue, toggleSwitch.IsOn ? 2 : 0);
                break;
            case "Account":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.AutoFinishSetupPath,
                    Constants.DisableAutomaticRestartSignOnValue, toggleSwitch.IsOn ? 1 : 0);
                break;
            case "Apps":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.AutoUpdateMapsPath,
                    Constants.AutoUpdateEnabledValue, toggleSwitch.IsOn ? 0 : 1);
                removeCommand(Constants.HKEY_LOCAL_MACHINE, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                removeCommand(Constants.HKEY_CURRENT_USER, @"Software\Microsoft\Windows\CurrentVersion\Run");
                break;
            case "Personalization":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.RecentlyAddedAppsPath1,
                    Constants.HideRecentlyAddedAppsValue1, toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.RecentlyAddedAppsPath2,
                    Constants.HideRecentlyAddedAppsValue2, toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.AlwaysShowIconsPath, Constants.EnableAutoTrayValue,
                    toggleSwitch.IsOn ? 0 : 1);
                break;
            case "Notifications":
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath1, Constants.NotificationsValue1,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath1, Constants.NotificationsValue2,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath1, Constants.NotificationsValue8,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath2, Constants.NotificationsPath3,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath2, Constants.NotificationsPath4,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath3, Constants.NotificationsValue5,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath4, Constants.NotificationsValue6,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath5, Constants.NotificationsValue7,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath6, Constants.NotificationsValue7,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath1, Constants.TabletModeValue1,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath1, Constants.TabletModeValue2,
                    toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath1, Constants.TabletModeValue3,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath2, Constants.TabletModeValue4,
                    toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath2, Constants.TabletModeValue5,
                    toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath2, Constants.VirtualDesktopsValue1,
                    toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath2, Constants.VirtualDesktopsValue2,
                    toggleSwitch.IsOn ? 1 : 0);
                break;
            case "HeaderView":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.ApplicationPath, Constants.HeaderViewContentValue,
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
                customCommand(Constants.HKEY_CURRENT_USER, Constants.AltTabPath, Constants.AltTabValue,
                    checkStatus ? 1 : 0);
                break;
            case "Old_Sound_Mixer":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.OldSoundMixerPath, Constants.OldSoundMixerValue,
                    checkStatus ? 1 : 0);
                break;
            case "Dialog_Visibility":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.ApplicationPath, Constants.DialogStatus,
                    checkStatus ? 1 : 0);
                break;
            default:
                break;
        }
    }
}