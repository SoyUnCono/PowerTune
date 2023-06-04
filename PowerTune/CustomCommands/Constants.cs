
namespace PowerTune.CustomCommands;
public class Constants
{
    /// <summary>
    /// Root Keys
    /// </summary>
    public const string HKEY_LOCAL_MACHINE = "HKEY_LOCAL_MACHINE";
    public const string HKEY_CURRENT_USER = "HKEY_CURRENT_USER";

    /// <summary>
    /// Path Strings
    /// </summary>
    public const string uacPath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
    public const string startUpTimePath = "SOFTWARE\\RegisteredApplications\\PowerTune";
    public const string verbosePath = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
    public const string SerializePath = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Serialize";

    /// <summary>
    /// Value Strings
    /// </summary>
    public const string uacValue = "EnableLUA";
    public const string startUpTimeValue = "EnableBoostStartUp";
    public const string verboseValue = "VerboseStatus";
    public const string SerializeValue = "StartupDelayInMSec";

    /// <summary>
    /// Important Constants
    /// </summary>s
    public const string restorePointServiceName = "PowerTune_RestorePoint";
}
