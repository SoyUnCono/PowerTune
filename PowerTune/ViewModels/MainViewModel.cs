using Windows.UI;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.Win32;
using PowerTune.Contracts.Services;
using PowerTune.Services;
using Windows.System;
using Windows.UI.ViewManagement;
using PowerTune.Strings;
using PowerTune.Helpers;

namespace PowerTune.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    // Const String
    private readonly INavigationService _navigationService;

    // Message Strings
    private const string LessThan75Perccent = "You can still store data, but monitor usage to avoid running out of space. Review and delete unnecessary files regularly.";
    private const string MoreThan75Perccent = "Memory usage exceeded 75%. Delete unnecessary files or apps to free up memory. Consider resetting device if issues persist.";
    private const string MoreThan90Perccent = "Memory usage exceeded 90%. Reset device to free up space and resolve memory issues. Back up critical data before resetting.";

    // About System Strings
    [ObservableProperty] private string? username;
    [ObservableProperty] private string? tip;
    [ObservableProperty] private string? systeminformation;
    [ObservableProperty] private string? storage;
    [ObservableProperty] private string? lastchecked;
    [ObservableProperty] private string? fulldatastorage;
    [ObservableProperty] private int index;
    [ObservableProperty][NotifyPropertyChangedFor(nameof(IsNotBusy))] private bool isBusy;

    // Notifications && Checks
    [ObservableProperty] private string? notificationTitle;
    [ObservableProperty] private string? notificationMessage;
    [ObservableProperty] private string? notificationsIconSource;
    [ObservableProperty] private string? isRunAsAdmin;
    [ObservableProperty] private bool isNotificationOpen = false;
    [ObservableProperty] private bool canCloseNotification = false;
    [ObservableProperty] private bool notificationIconsVisible = false;
    [ObservableProperty][NotifyPropertyChangedFor(nameof(IsNotWindows11))] private bool isWindows11;

    //Dependency Injection && Commands
    public ICommand OpenWindowsUpdatesCommand
    {
        get;
    }
    public ICommand NavigateToTweaksPageCommand
    {
        get;
    }

    // Public bool's
    public bool IsNotBusy => !IsBusy;
    public bool IsNotWindows11 => !IsWindows11;
    public bool DontShowHeader => !HeaderViewContent;

    // ToggleSwitch && Checkboxes Initials Values
    [ObservableProperty] private bool uacToggleSwitchValue;
    [ObservableProperty] private bool startUp_Time_ToggleSwitchValue;
    [ObservableProperty] private bool alt_TabValue;
    [ObservableProperty] private bool comboboxIndex;
    [ObservableProperty] private bool old_Sound_Mixer;
    [ObservableProperty] private bool checkBox_Dialog;
    [ObservableProperty] private bool disable_Apps_Background;
    [ObservableProperty] private bool ease_of_Access;
    [ObservableProperty] private bool account;
    [ObservableProperty] private bool apps;
    [ObservableProperty] private bool personalization;
    [ObservableProperty] private bool notifications;
    [ObservableProperty][NotifyPropertyChangedFor(nameof(DontShowHeader))] private bool headerViewContent;

    public MainViewModel(INavigationService navigationService)
    {
        _ = StartupAsyncTasks();

        // Commands
        OpenWindowsUpdatesCommand = new RelayCommand(OnWindowsUpdatesAsync);
        NavigateToTweaksPageCommand = new RelayCommand(OnNavigateToTweaksPage);

        // Navigation Services
        _navigationService = App.GetService<INavigationService>();
        _navigationService = navigationService;

    }

    private async Task StartupAsyncTasks()
    {
        try
        {
            // Start up Tasks and Set IsBusy to True
            IsBusy = true;
            GetUsernamePC();
            GetSystemInformation();
            GetDiskInformation();
            GetLastChecked();
            SetStateInitialValues();
            await NotificationTask();
        } finally
        {
            // Set IsBusy to False
            IsBusy = false;
        }
    }

    /// <summary>
    /// Retrieves the username of the current PC user
    /// </summary>
    private void GetUsernamePC() => Username = Environment.UserName;
    /// <summary>
    /// Opens the Windows Updates settings page asynchronously
    /// </summary>
    private async void OnWindowsUpdatesAsync() => await Launcher.LaunchUriAsync(new Uri("ms-settings:windowsupdate"));

    private void OnNavigateToTweaksPage() => _navigationService.NavigateTo(typeof(TweaksViewModel).FullName!);

    /// <summary>
    /// Retrieves disk information including total space, free space, and used space percentage
    /// </summary>
    private void GetDiskInformation()
    {
        // Get the drive name of the system directory
        var driveName = Path.GetPathRoot(Environment.SystemDirectory);
        if (driveName == null) { return; }

        // Create a DriveInfo object for the specified drive
        // Retrieve the total space, free space, and used space on the drive
        // Convert free space to gigabytes
        var driveInfo = new DriveInfo(driveName);
        var totalSpaceInBytes = driveInfo.TotalSize;
        var freeSpaceInBytes = driveInfo.TotalFreeSpace;
        var usedSpaceInBytes = totalSpaceInBytes - freeSpaceInBytes;
        var usedSpacePercentage = (double)usedSpaceInBytes / totalSpaceInBytes * 100;
        var freeSpaceInGB = Math.Floor((double)freeSpaceInBytes / (1024 * 1024 * 1024));

        // Set the Storage property to represent the used space percentage
        Storage = $"{Math.Round(usedSpacePercentage, 0, MidpointRounding.ToZero)}% full";

        // Determine the appropriate message based on the used space percentage
        if (usedSpacePercentage < 75)
            Fulldatastorage = $"Your storage device is currently utilizing {Storage} of space, leaving you with {freeSpaceInGB}GB of free space. {LessThan75Perccent}";
        if (usedSpacePercentage >= 75 && usedSpacePercentage < 90)
            Fulldatastorage = $"Your storage device is currently utilizing {Storage} of space, leaving you with {freeSpaceInGB}GB of free space. {MoreThan75Perccent}";
        if (usedSpacePercentage >= 90)
            Fulldatastorage = $"Your storage device is currently utilizing {Storage} of space, leaving you with {freeSpaceInGB}GB of free space. {MoreThan90Perccent}";
    }

    /// <summary>
    /// Asynchronous method that handles the notification task.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task NotificationTask()
    {
        // Verifies if a restore point with the specified name exists
        var restorePointExists = await RestorePointService.CheckIfRestorePointExists(Constants.restorePointServiceName);

        // Checks the conditions to display the appropriate notification message
        IsNotificationOpen = true;
        CanCloseNotification = true;
        NotificationIconsVisible = true;
        NotificationTitle = "Information about the status of the restore point.";
        NotificationMessage = $"{(restorePointExists ? "Restore point already detected, operation aborted." : $"The restore point has been successfully created at {DateTime.Now}.")}";
    }

    /// <summary>
    /// Method to handle the selection changed event of the ComboBox
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void TaskBarFunctions(object sender, SelectionChangedEventArgs e)
    {
        // Get the ComboBox and selected item
        // Assign the SetRegistryValue method of the CustomCommands.RegistryCommands object to the CustomCommand variable
        var comboBox = (ComboBox)sender;
        var selectedItem = (ComboBoxItem)comboBox.SelectedItem;

        var CustomCommand = RegistryHelper.SetRegistryValue;

        // Check if an item is selected
        if (selectedItem == null)
            return;

        // Get the user's choice from the selected item
        var userChoice = selectedItem.Content.ToString();

        // Apply logic based on the user's choice
        switch (userChoice)
        {
            case "Center":
                // Logic for center alignment
                // Call a custom command with the appropriate parameters for center alignment
                CustomCommand(Constants.HKEY_CURRENT_USER, Constants.TaskbarPositionPath, Constants.TaskbarPositionValue, 1);
                break;

            case "Left":
                // Logic for left alignment
                // Call a custom command with the appropriate parameters for left alignment
                CustomCommand(Constants.HKEY_CURRENT_USER, Constants.TaskbarPositionPath, Constants.TaskbarPositionValue, 0);
                break;

            default:
                // Default case (optional)
                // Handle any additional cases or provide a default behavior
                break;
        }
    }

    /// <summary>
    /// Retrieves the system information including the operating system version and edition ID
    /// </summary>
    private void GetSystemInformation()
    {
        // Get the version of the operating system
        // Get the EditionID from the registry
        var osVersion = Environment.OSVersion.Version;
        var editionID = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "EditionID", null) as string;

        // Check if the operating system version is Windows 10
        if (osVersion.Major == 10 && osVersion.Minor == 0)
            Systeminformation = $"You're currently running Windows 10 {editionID} ({osVersion})"; IsWindows11 = false;

        // Check if the operating system version is Windows 11 (build 22000 or higher)
        if (osVersion.Major == 10 && osVersion.Minor == 0 && osVersion.Build >= 22000)
            Systeminformation = $"You're currently running Windows 11 {editionID} ({osVersion})"; IsWindows11 = true;
    }

    /// <summary>
    /// Retrieves the last time the system was updated and stores it in the Lastchecked variable
    /// </summary>
    private void GetLastChecked()
    {
        // Get the system directory path
        // Combine the system directory path with the file name "ntoskrnl.exe" to get the full file path
        // Get the last write time of the system file
        var systemPath = Environment.SystemDirectory;
        var systemFile = new FileInfo(Path.Combine(systemPath, "ntoskrnl.exe"));
        var lastUpdate = systemFile.LastWriteTime;

        // Create a string that represents the last time the system was updated
        Lastchecked = $"The last time the system was updated was: {lastUpdate}";
    }

    /// <summary>
    /// Method to set the initial values
    /// </summary>
    private void SetStateInitialValues()
    {
        // Assign the custom registry command to a variable.
        var CustomCommand = RegistryHelper.GetToggleSwitchInitialValue;

        // Create the registry key path
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


        // Call the custom command with the specified parameters to set the toggle value.
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

    /// <summary>
    /// Method to set the Windows Registry value based on the ToggleSwitch state
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void SetWindowsRegistryToggle(object sender, RoutedEventArgs e)
    {
        // Cast the sender object to a ToggleSwitch
        // Retrieve the Tag property of the toggleSwitch control and assign it to toggleSwitchId as a string
        var toggleSwitch = (ToggleSwitch)sender;
        var toggleSwitchId = toggleSwitch.Tag as string;

        // Assign the SetRegistryValue method of the CustomCommands.RegistryCommands object to the CustomCommand variable
        var customCommand = RegistryHelper.SetRegistryValue;
        var removeCommand = RegistryHelper.RemoveRegistryKey;

        // Call the custom command to set the registry value based on the ToggleSwitch state
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

    /// <summary>
    /// Method to set the Windows Registry value based on the CheckBox status
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void SetWindowsRegistryCheckBox(object sender, RoutedEventArgs e)
    {
        // Cast the sender object to a CheckBox
        // Retrieve the Tag property of the checkBox control and assign it to checkBoxId as a string
        var checkBox = (CheckBox)sender;
        var checkBoxId = checkBox.Tag as string;

        //Get the checked status of the checkBox
        var checkStatus = (bool)checkBox.IsChecked!;

        // Assign the SetRegistryValue method of the CustomCommands.RegistryCommands object to the CustomCommand variable
        var customCommand = RegistryHelper.SetRegistryValue;

        // Call the custom command to set the registry value based on the CheckBox status
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
