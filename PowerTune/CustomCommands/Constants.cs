
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

    /// <summary>
    /// Value Strings
    /// </summary>
    public const string uacValue = "EnableLUA";

    /// <summary>
    /// Important Constants
    /// </summary>s
    public const string restorePointServiceName = "PowerTune_RestorePoint";
}
