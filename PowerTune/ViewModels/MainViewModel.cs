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

    const string LessThan75Perccent = "You can still store data, but monitor usage to avoid running out of space. Review and delete unnecessary files regularly.";
    const string MoreThan75Perccent = "Memory usage exceeded 75%. Delete unnecessary files or apps to free up memory. Consider resetting device if issues persist.";
    const string MoreThan90Perccent = "Memory usage exceeded 90%. Reset device to free up space and resolve memory issues. Back up critical data before resetting.";

    [ObservableProperty] string? username;
    [ObservableProperty] string? tip;
    [ObservableProperty] string? systeminformation;
    [ObservableProperty] string? storage;
    [ObservableProperty] string? lastchecked;
    [ObservableProperty] string? fulldatastorage;
    [ObservableProperty] int index;
    [ObservableProperty][NotifyPropertyChangedFor(nameof(IsNotBusy))] bool isBusy;

    [ObservableProperty] string? notificationTitle;
    [ObservableProperty] string? notificationMessage;
    [ObservableProperty] string? notificationsIconSource;
    [ObservableProperty] string? isRunAsAdmin;
    [ObservableProperty] bool isNotificationOpen = false;
    [ObservableProperty] bool canCloseNotification = false;
    [ObservableProperty] bool notificationIconsVisible = false;
    [ObservableProperty][NotifyPropertyChangedFor(nameof(IsNotWindows11))] bool isWindows11;

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

    [ObservableProperty] bool uacToggleSwitchValue;
    [ObservableProperty] bool startUp_Time_ToggleSwitchValue;
    [ObservableProperty] bool alt_TabValue;
    [ObservableProperty] bool comboboxIndex;
    [ObservableProperty] bool old_Sound_Mixer;
    [ObservableProperty] bool checkBox_Dialog;
    [ObservableProperty] bool disable_Apps_Background;
    [ObservableProperty] bool ease_of_Access;
    [ObservableProperty] bool account;
    [ObservableProperty] bool apps;
    [ObservableProperty] bool personalization;
    [ObservableProperty] bool notifications;
    [ObservableProperty][NotifyPropertyChangedFor(nameof(DontShowHeader))] bool headerViewContent;

    public MainViewModel(INavigationService navigationService)
    {
        _ = StartupAsyncTasks();

        OpenWindowsUpdatesCommand = new RelayCommand(OnWindowsUpdatesAsync);
        NavigateToTweaksPageCommand = new RelayCommand(OnNavigateToTweaksPage);

        _navigationService = App.GetService<INavigationService>();
        _navigationService = navigationService;
    }

    async Task StartupAsyncTasks()
    {
        IsBusy = true;
        GetUsernamePC();
        GetSystemInformation();
        GetDiskInformation();
        GetLastChecked();
        SetStateInitialValues();
        await NotificationTask();

        IsBusy = false;
    }

    void GetUsernamePC() => Username = Environment.UserName;

    async void OnWindowsUpdatesAsync() => await Launcher.LaunchUriAsync(new Uri("ms-settings:windowsupdate"));

    void OnNavigateToTweaksPage() => _navigationService.NavigateTo(typeof(TweaksViewModel).FullName!);

    void GetDiskInformation()
    {
        var driveName = Path.GetPathRoot(Environment.SystemDirectory);
        if (driveName == null) return;
        var driveInfo = new DriveInfo(driveName);
        var totalSpaceInBytes = driveInfo.TotalSize;
        var freeSpaceInBytes = driveInfo.TotalFreeSpace;
        var usedSpaceInBytes = totalSpaceInBytes - freeSpaceInBytes;
        var usedSpacePercentage = (double)usedSpaceInBytes / totalSpaceInBytes * 100;
        var freeSpaceInGB = Math.Floor((double)freeSpaceInBytes / (1024 * 1024 * 1024));

        Storage = $"{Math.Round(usedSpacePercentage, 0, MidpointRounding.ToZero)}% full";

        if (usedSpacePercentage < 75)
            Fulldatastorage = $"Your storage device is currently utilizing {Storage} of space, leaving you with {freeSpaceInGB}GB of free space. {LessThan75Perccent}";

        if (usedSpacePercentage >= 75 && usedSpacePercentage < 90)
            Fulldatastorage = $"Your storage device is currently utilizing {Storage} of space, leaving you with {freeSpaceInGB}GB of free space. {MoreThan75Perccent}";

        if (usedSpacePercentage >= 90)
            Fulldatastorage = $"Your storage device is currently utilizing {Storage} of space, leaving you with {freeSpaceInGB}GB of free space. {MoreThan90Perccent}";
    }

    public async Task NotificationTask()
    {
        var restorePointExists = await RestorePointService.CheckIfRestorePointExists(Constants.restorePointServiceName);

        IsNotificationOpen = true;
        CanCloseNotification = true;
        NotificationIconsVisible = true;
        NotificationTitle = "Information about the status of the restore point.";
        NotificationMessage = $"{(restorePointExists ? "Restore point already detected, operation aborted." : $"The restore point has been successfully created at {DateTime.Now}.")}";
    }

    public void TaskBarFunctions(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = (ComboBox)sender;
        var selectedItem = (ComboBoxItem)comboBox.SelectedItem;
        var CustomCommand = RegistryHelper.SetRegistryValue;
        if (selectedItem == null) return;

        var userChoice = selectedItem.Content.ToString();

        switch (userChoice)
        {
            case "Center":
                CustomCommand(Constants.HKEY_CURRENT_USER, Constants.TaskbarPositionPath, Constants.TaskbarPositionValue, 1);
                break;

            case "Left":
                CustomCommand(Constants.HKEY_CURRENT_USER, Constants.TaskbarPositionPath, Constants.TaskbarPositionValue, 0);
                break;

            default:
                break;
        }
    }

    void GetSystemInformation()
    {
        var osVersion = Environment.OSVersion.Version;
        var editionID = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "EditionID", null) as string;

        if (osVersion.Major == 10 && osVersion.Minor == 0)
            Systeminformation = $"You're currently running Windows 10 {editionID} ({osVersion})";
        IsWindows11 = false;

        if (osVersion.Major == 10 && osVersion.Minor == 0 && osVersion.Build >= 22000)
            Systeminformation = $"You're currently running Windows 11 {editionID} ({osVersion})";
        IsWindows11 = true;
    }

    void GetLastChecked()
    {
        var systemPath = Environment.SystemDirectory;
        var systemFile = new FileInfo(Path.Combine(systemPath, "ntoskrnl.exe"));
        var lastUpdate = systemFile.LastWriteTime;

        Lastchecked = $"The last time the system was updated was: {lastUpdate}";
    }

    void SetStateInitialValues()
    {
        var CustomCommand = RegistryHelper.GetToggleSwitchInitialValue;

        var registryKeyPath_UAC = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.uacPath}";
        var registryKeyPath_AplicationPath = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.ApplicationPath}";
        var registryKeyPath_TaskbarAligment = $"{Constants.HKEY_CURRENT_USER}\\{Constants.TaskbarPositionPath}";
        var registryKeyPath_Alt_Tab = $"{Constants.HKEY_CURRENT_USER}\\{Constants.Alt_TabPath}";
        var registryKeyPath_Old_Sound_Mixer = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.Old_Sound_MixerPath}";
        var registryKeyPath_Background_apps = $"{Constants.HKEY_CURRENT_USER}\\{Constants.BackgroundAccessApplicationsPath}";
        var registryKeyPath_Ease_of_Access = $"{Constants.HKEY_CURRENT_USER}\\{Constants.NarratorPath}";
        var registryKeyPath_Account = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.AutoFinishSetupPath}";
        var registryKeyPath_Apps = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.AutoUpdateMapsPath}";
        var registryKeyPath_Personalization = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.RecentlyAddedAppsPath1}";
        var registryKeyPath_Notifications = $"{Constants.HKEY_CURRENT_USER}\\{Constants.NotificationsPath1}";

        UacToggleSwitchValue = CustomCommand(registryKeyPath_UAC, Constants.uacValue, 0);
        StartUp_Time_ToggleSwitchValue = CustomCommand(registryKeyPath_AplicationPath, Constants.startUpTimeValue, 1);
        ComboboxIndex = CustomCommand(registryKeyPath_TaskbarAligment, Constants.TaskbarPositionValue, 0);
        Alt_TabValue = CustomCommand(registryKeyPath_Alt_Tab, Constants.Alt_TabValue, 1);
        Old_Sound_Mixer = CustomCommand(registryKeyPath_Old_Sound_Mixer, Constants.Old_Sound_MixerValue, 1);
        CheckBox_Dialog = CustomCommand(registryKeyPath_AplicationPath, Constants.DialogStatus, 1);
        HeaderViewContent = CustomCommand(registryKeyPath_AplicationPath, Constants.headerViewContentValue, 1);
        Disable_Apps_Background = CustomCommand(registryKeyPath_Background_apps, Constants.GlobalUserDisabledValue, 1);
        Ease_of_Access = CustomCommand(registryKeyPath_Ease_of_Access, Constants.WinEnterLaunchEnabledValue, 0);
        Account = CustomCommand(registryKeyPath_Account, Constants.DisableAutomaticRestartSignOnValue, 1);
        Apps = CustomCommand(registryKeyPath_Apps, Constants.AutoUpdateEnabledValue, 0);
        Personalization = CustomCommand(registryKeyPath_Personalization, Constants.HideRecentlyAddedAppsValue1, 1);
        Notifications = CustomCommand(registryKeyPath_Notifications, Constants.NotificationsValue1, 0);
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
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.uacPath, Constants.uacValue, toggleSwitch.IsOn ? 0 : 1);
                break;

            case "Start_Up_Time":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.ApplicationPath, Constants.startUpTimeValue, toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.verbosePath, Constants.verboseValue, toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.SerializePath, Constants.SerializeValue, toggleSwitch.IsOn ? 0 : 1);
                break;
            case "Backgrounds_Apps":
                customCommand(Constants.HKEY_CURRENT_USER, Constants.BackgroundAccessApplicationsPath, Constants.GlobalUserDisabledValue, toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.SearchPath, Constants.BackgroundAppGlobalToggleValue, toggleSwitch.IsOn ? 0 : 1);
                break;
            case "Ease_of_Access":
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NarratorPath, Constants.WinEnterLaunchEnabledValue, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.StickyKeysPath, Constants.StickyKeysFlagsValue, toggleSwitch.IsOn ? 506 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.ToggleKeysPath, Constants.ToggleKeysFlagsValue, toggleSwitch.IsOn ? 34 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.KeyboardResponsePath, Constants.KeyboardResponseFlagsValue, toggleSwitch.IsOn ? 2 : 0);
                break;
            case "Account":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.AutoFinishSetupPath, Constants.DisableAutomaticRestartSignOnValue, toggleSwitch.IsOn ? 1 : 0);
                break;
            case "Apps":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.AutoUpdateMapsPath, Constants.AutoUpdateEnabledValue, toggleSwitch.IsOn ? 0 : 1);
                removeCommand(Constants.HKEY_LOCAL_MACHINE, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
                removeCommand(Constants.HKEY_CURRENT_USER, @"Software\Microsoft\Windows\CurrentVersion\Run");
                break;
            case "Personalization":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.RecentlyAddedAppsPath1, Constants.HideRecentlyAddedAppsValue1, toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.RecentlyAddedAppsPath2, Constants.HideRecentlyAddedAppsValue2, toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.AlwaysShowIconsPath, Constants.EnableAutoTrayValue, toggleSwitch.IsOn ? 0 : 1);
                break;
            case "Notifications":
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath1, Constants.NotificationsValue1, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath1, Constants.NotificationsValue2, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath1, Constants.NotificationsValue8, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath2, Constants.NotificationsPath3, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath2, Constants.NotificationsPath4, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath3, Constants.NotificationsValue5, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath4, Constants.NotificationsValue6, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath5, Constants.NotificationsValue7, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.NotificationsPath6, Constants.NotificationsValue7, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath1, Constants.TabletModeValue1, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath1, Constants.TabletModeValue2, toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath1, Constants.TabletModeValue3, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath2, Constants.TabletModeValue4, toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath2, Constants.TabletModeValue5, toggleSwitch.IsOn ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath2, Constants.VirtualDesktopsValue1, toggleSwitch.IsOn ? 1 : 0);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.TabletModePath2, Constants.VirtualDesktopsValue2, toggleSwitch.IsOn ? 1 : 0);
                break;
            case "HeaderView":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.ApplicationPath, Constants.headerViewContentValue, toggleSwitch.IsOn ? 1 : 0);
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
                customCommand(Constants.HKEY_CURRENT_USER, Constants.Alt_TabPath, Constants.Alt_TabValue, checkStatus ? 1 : 0);
                break;
            case "Old_Sound_Mixer":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.Old_Sound_MixerPath, Constants.Old_Sound_MixerValue, checkStatus ? 1 : 0);
                break;
            case "Dialog_Visibility":
                customCommand(Constants.HKEY_LOCAL_MACHINE, Constants.ApplicationPath, Constants.DialogStatus, checkStatus ? 1 : 0);
                break;
            default:
                break;
        }
    }
}