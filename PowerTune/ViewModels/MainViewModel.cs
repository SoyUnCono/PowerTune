﻿using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using PowerTune.Contracts.Services;
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

    public MainViewModel()
    {
        // Startup Tasks
        GetUsernamePC();
        GetSystemInformation();
        GetDiskInformation();
        GetLastChecked();

        // Navigation Services
        _navigationService = App.GetService<INavigationService>();
    }

    // Retrieves the username of the current PC user
    private void GetUsernamePC() => Username = Environment.UserName;
    // Opens the Windows Updates settings page asynchronously
    public async Task OpenWindowsUpdatesAsync() => await Launcher.LaunchUriAsync(new Uri("ms-settings:windowsupdate"));

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
            Fulldatastorage = $"Your storage device is currently utilizing {Storage} of space, leaving you with {freeSpaceInGB} of free space. {LessThan75Perccent}";
        if (usedSpacePercentage >= 75 && usedSpacePercentage < 90)
            Fulldatastorage = $"Your storage device is currently utilizing {Storage} of space, leaving you with {freeSpaceInGB} of free space. {MoreThan75Perccent}";
        if (usedSpacePercentage >= 90)
            Fulldatastorage = $"Your storage device is currently utilizing {Storage} of space, leaving you with {freeSpaceInGB} of free space. {MoreThan90Perccent}";
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
}
