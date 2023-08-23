namespace PowerTune.Strings;

public static class ErrorCodeStrings
{
    public static readonly Dictionary<string, (string title, string description, string errorCode)> ErrorHandler = new()
    {
        {
            "ErrorCode-LoadSettings",
            ("Error Loading Settings",
                "Failed to load settings. The AppSettings.json file is missing or corrupted.Please make sure that the configuration file is present and correctly formatted.",
                "Error Code - [ _FAILED_TO_LOAD_SETTINGS_NULL ] ")
        },
        {
            "ErrorCode-EnablingRestorePointService",
            ("Error Enabling System Restore",
                "An error occurred while enabling System Restore for the specified drive. Please ensure that you have the necessary permissions and try again.",
                "Error Code - [ _SYSTEM_RESTORE_POINT_SERVICES_NULL_OR_DISABLED ]"
            )
        },
        {
            "ErrorCode-CreatingRestorePointService",
            ("Error Creating Restore Point",
                "An error occurred while creating a restore point. Please ensure that you have the necessary permissions and try again.",
                "Error Code - [ _INSUFFICIENT_PERMISSIONS_LEVEL ]"
            )
        },
        {
            "ErrorCode-CheckingRestorePointService",
            ("Error Checking Restore Point",
                "An error occurred while checking for the existence of a restore point. Please ensure that you have the necessary permissions and try again.",
                "Error Code - [ _INSUFFICIENT_PERMISSIONS_LEVEL ]"
            )
        }
    };
}