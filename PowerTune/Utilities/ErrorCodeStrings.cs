namespace PowerTune.Utilities;

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
        },
        {
            "ErrorCode-SaveSettings",
            ("Error Save Settings",
                "An error occurred while loading the application settings. Please try again later or contact support for assistance.",
                "Error Code - [ _LOAD-SETTINGS_FILE_OPEN_BY_ANOTHER_PROGRAM ]")
        },
        {
            "ErrorCode-DefaultError",
            ("Unexpected Error",
                "An unexpected error occurred while applying the settings. Please contact your system administrator or our support service for assistance.",
                "Error Code - [ _INSUFFICIENT_PERMISSIONS_LEVEL ]"
            )
        },
        {
            "ErrorCode-StringValueNull", (
                "Error-Applying-TitleBarSize",
                "Failed to apply title bar size. The selected string is missing or empty.Please ensure that a valid title bar size is selected before applying.",
                "Error Code - [ _STRING_VALUE_NULL ]")
        },
        {
            "ErrorCode-RegeditValueNull", (
                "Error-TryingToGetSystemValue",
                "Failed to get SystemInformation, Please ensure that you have the necessary permissions and try again.",
                "Error Code - [ _REGISTRY_KEY_EMPTY ]")
        },
    };
}