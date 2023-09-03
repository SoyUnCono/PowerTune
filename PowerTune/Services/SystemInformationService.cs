using System.Management;
using System.Security.Principal;
using Microsoft.Extensions.Hosting;
using PowerTune.Contracts.Services;

namespace PowerTune.Services;

public class SystemInformationService : ISystemInformationService
{
    public bool IsWindows11()
    {
        var osVersion = Environment.OSVersion.Version;

        return osVersion is { Major: 10, Minor: 0, Build: >= 22000 };
    }

    public bool IsDesktop()
    {
        var batteryQuery = new SelectQuery("Win32_Battery");
        var batterySearcher = new ManagementObjectSearcher(batteryQuery);
        var batteryDevices = batterySearcher.Get();

        return (batteryDevices.Count <= 0);
    }

    public bool IsRunAsAdmin()
    {
        var identity = WindowsIdentity.GetCurrent();
        var principal = new WindowsPrincipal(identity);

        return principal.IsInRole(WindowsBuiltInRole.Administrator);
    }

    public string GetMotherBoardInformationLabel()
    {
        var query = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
        var motherboard = query.Get().Cast<ManagementObject>().FirstOrDefault();

        return motherboard == null ? "Motherboard information not available" : $"Motherboard: {motherboard["Product"].ToString()!}";
    }

    public string GetComputerName()
    {
        return $"Computer Name:  {Environment.MachineName}";
    }
}