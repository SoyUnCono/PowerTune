namespace PowerTune.Strings;

public static class Constants
{
    public const string RestorePointServiceName = "PowerTune_RestorePoint";

    public static string PowerTunePath =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PowerTune");
}