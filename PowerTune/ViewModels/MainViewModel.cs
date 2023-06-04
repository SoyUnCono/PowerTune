﻿using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Win32;
using PowerTune.Contracts.Services;
using PowerTune.CustomCommands;
using PowerTune.Services;
using PowerTune.Views;
using Windows.System;

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

    //Dependecy Injection && Commands
    public ICommand OpenWindowsUpdatesCommand
    {
        get;
    }
    public ICommand OnNavigateToTweaksSettingsPageCommand
    {

        get;
    }

    public bool IsNotBusy => !IsBusy;

    // ToggleSwitch
    [ObservableProperty] private bool uacToggleSwitchValue;
    [ObservableProperty] private bool startUp_Time_ToggleSwitchValue;


    public MainViewModel()
    {
        _ = StartupAsyncTasks();

        // Commands
        OpenWindowsUpdatesCommand = new RelayCommand(OnWindowsUpdatesAsync);
        OnNavigateToTweaksSettingsPageCommand = new RelayCommand(OnNavigateToTweaksSettingsPage);

        // Navigation Services
        _navigationService = App.GetService<INavigationService>();


    }

    private async Task StartupAsyncTasks()
    {
        try
        {
            // Startup Tasks and Set IsBusy to True
            IsBusy = true;
            GetUsernamePC();
            GetSystemInformation();
            GetDiskInformation();
            GetLastChecked();
            SetToggleStateInitialValues();
            await NotificationTask();
        }
        finally
        {
            // Set IsBusy to False
            IsBusy = false;
        }
    }

    // Retrieves the username of the current PC user
    private void GetUsernamePC() => Username = Environment.UserName;
    // Opens the Windows Updates settings page asynchronously
    private async void OnWindowsUpdatesAsync() => await Launcher.LaunchUriAsync(new Uri("ms-settings:windowsupdate"));

    private void OnNavigateToTweaksSettingsPage() => _navigationService.NavigateTo(typeof(MainViewModel).FullName!);

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
            Systeminformation = $"You're currently running Windows 10 {editionID} ({osVersion})";

        // Check if the operating system version is Windows 11 (build 22000 or higher)
        if (osVersion.Major == 10 && osVersion.Minor == 0 && osVersion.Build >= 22000)
            Systeminformation = $"You're currently running Windows 11 {editionID} ({osVersion})";
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

    // Method to set the initial values of the toggle switch
    private void SetToggleStateInitialValues()
    {

        // Assign the custom registry command to a variable.
        var CustomCommand = CustomCommands.RegistryCommands.GetToggleSwitchInitialValue;

        // Create the registry key path
        var registryKeyPath_UAC = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.uacPath}";
        var registryKeyPath_StartUp_Time = $"{Constants.HKEY_LOCAL_MACHINE}\\{Constants.startUpTimePath}";

        // Call the custom command with the specified parameters to set the toggle value.
        UacToggleSwitchValue = CustomCommand(registryKeyPath_UAC, Constants.uacValue, 0);
        StartUp_Time_ToggleSwitchValue = CustomCommand(registryKeyPath_StartUp_Time, Constants.startUpTimeValue, 1);

    }

    // Method to set the Windows Registry value based on the ToggleSwitch state
    public void SetWindowsRegistry(object sender, RoutedEventArgs e)
    {
        // Cast the sender object to a ToggleSwitch
        // Retrieve the Tag property of the toggleSwitch control and assign it to toggleSwitchId as a string
        var toggleSwitch = (ToggleSwitch)sender;
        var toggleSwitchId = toggleSwitch.Tag as string;

        // Assign the SetRegistryValue method of the CustomCommands.RegistryCommands object to the CustomCommand variable
        var CustomCommand = CustomCommands.RegistryCommands.SetRegistryValue;

        // Call the custom command to set the registry value based on the ToggleSwitch state
        switch (toggleSwitchId)
        {
            case "UAC":
                CustomCommand(Constants.HKEY_LOCAL_MACHINE, Constants.uacPath, Constants.uacValue, toggleSwitch.IsOn ? 0 : 1);
                break;
            case "Start_Up_Time":
                CustomCommand(Constants.HKEY_LOCAL_MACHINE, Constants.startUpTimePath, Constants.startUpTimeValue, toggleSwitch.IsOn ? 1 : 0);
                CustomCommand(Constants.HKEY_LOCAL_MACHINE, Constants.verbosePath, Constants.verboseValue, toggleSwitch.IsOn ? 1 : 0);
                CustomCommand(Constants.HKEY_LOCAL_MACHINE, Constants.SerializePath, Constants.SerializeValue, toggleSwitch.IsOn ? 0 : 1);
                break;

            // Default Case
            default:
                break;
        }
    }

}
