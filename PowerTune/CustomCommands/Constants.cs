
using CommunityToolkit.WinUI.UI.Controls;

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
    public const string uacPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
    public const string ApplicationPath = "Software\\RegisteredApplications\\PowerTune";
    public const string verbosePath = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System";
    public const string SerializePath = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Serialize";
    public const string TaskbarPositionPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced";
    public const string Alt_TabPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Explorer";
    public const string Old_Sound_MixerPath = "Software\\Microsoft\\Windows NT\\CurrentVersion\\MTCUVC";
    /// <summary>
    /// Value Strings
    /// </summary>
    public const string uacValue = "EnableLUA";
    public const string startUpTimeValue = "EnableBoostStartUp";
    public const string DialogStatus = "EnableDialog";
    public const string verboseValue = "VerboseStatus";
    public const string SerializeValue = "StartupDelayInMSec";
    public const string TaskbarPositionValue = "TaskbarAl";
    public const string Alt_TabValue = "AltTabSettings";
    public const string Old_Sound_MixerValue = "EnableMtcUvc";

    /// <summary>
    /// Important Constants
    /// </summary>s
    public const string restorePointServiceName = "PowerTune_RestorePoint";
}
