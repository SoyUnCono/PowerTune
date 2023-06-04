using System.Management;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Win32;

namespace PowerTune.Views.Controls.ViewModels;

public partial class CustomHeaderViewModel : ObservableRecipient
{
    // SystemInformation Strings
    [ObservableProperty] private string? systemInformationLabel;
    [ObservableProperty] private string? nameInformationLabel;
    [ObservableProperty] private string? motherBoardInformationLabel;

    /// <summary>
    /// Main constructor
    /// </summary>
    public CustomHeaderViewModel() => GetSystemInfo();

    /// <summary>
    /// Fill the systemInformationLabel property with system information
    /// </summary>
    private void GetSystemInfo()
    {
        var osVersion = Environment.OSVersion.Version;
        var editionID = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "EditionID", null) as string;

        // Check if the operating system version is Windows 10
        if (osVersion.Major == 10 && osVersion.Minor == 0)
            SystemInformationLabel = $"Operating System: Windows 10 {editionID} ({osVersion})";

        // Check if the operating system version is Windows 11 (build 22000 or higher)
        if (osVersion.Major == 10 && osVersion.Minor == 0 && osVersion.Build >= 22000)
            SystemInformationLabel = $"Operating System: Windows 11 {editionID} ({osVersion})";

        // Fill the nameInformationLabel property with PC name information
        NameInformationLabel = $"PC Name: {Environment.MachineName}";

        // Fill the motherBoardInformationLabel property with motherboard information
        var product = GetMotherboardProduct();
        MotherBoardInformationLabel = $"Motherboard: {product}";
    }

    /// <summary>
    /// Retrieve the motherboard product information
    /// </summary>
    private static string GetMotherboardProduct()
    {
        var query = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
        var motherboard = query.Get().Cast<ManagementObject>().FirstOrDefault();

        // Check if the motherboard is null
        if (motherboard == null)
            return string.Empty; // Return an empty string if the motherboard information is not available

        return motherboard["Product"].ToString()!;
    }
}


