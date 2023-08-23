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
        }
    };
}