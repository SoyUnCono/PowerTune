using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;
using PowerTune.Contracts.Services;
using Windows.System;

namespace PowerTune.ViewModels;

public partial class MainViewModel : ObservableRecipient
{
    // Const String
    private readonly INavigationService _navigationService;

    // Message Strings
    private const string LessThan75Perccent = "This means that you can still store a significant amount of data, but it is important to keep track of your storage usage in order to avoid running out of space in the future. Remember to regularly review your files and delete any that are no longer necessary to keep your storage space optimized and running smoothly.";
    private const string MoreThan75Perccent = "It looks like your device's memory usage has exceeded 75%. While this still leaves some room for data storage, it's important to take action to prevent any potential issues down the road. Consider deleting unnecessary files or applications that are taking up space on your device to free up some memory.\r\n\r\nIf you continue to experience performance issues, you may need to consider more drastic measures, such as resetting your device to its factory settings. While this can be a time-consuming process, it can also help ensure that your device is running optimally and prevent any further storage-related problems. Remember to back up any important data before taking this step, as resetting your device will erase all of its data.";
    private const string MoreThan90Perccent = "It appears that your device's memory usage has exceeded 90%. This is a critical situation and it's imperative that you take immediate action to prevent any potential problems.\r\n\r\nAt this point, it's highly recommended that you reset your device to its factory settings. This will help free up space and ensure that your device is running optimally. While resetting your device may seem like a drastic measure, it's often the most effective solution when dealing with memory issues.\r\n\r\nBefore resetting your device, be sure to back up any important data to ensure that you don't lose any critical files. Once you have reset your device, remember to only reinstall the applications and files that are necessary, as this will help prevent any future storage-related problems.\r\n\r\nIn the future, it's a good idea to regularly review your files and delete any that are no longer necessary. This will help keep your device's memory usage in check and prevent any potential issues from arising.";

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
