namespace PowerTune.Models;

public class LocalSettingsOptions
{
    public string? ApplicationDataFolder
    {
        get;
        set;
    }

    public string? LocalSettingsFile
    {
        get;
        set;
    }
    public bool SecurityFileDownloads
    {
        get;
        init;
    }

    public bool IsBoldCheck
    {
        get;
        init;
    }

    public bool DefaultDpi
    {
        get;
        init;
    }

    public bool EnhancedSearchIndexing
    {
        get;
        init;
    }

    public bool VisualFeedBack
    {
        get;
        init;
    }

    public bool HideScrollBar
    {
        get;
        init;
    }

    public int SelectedTitleBarSize
    {
        get;
        init;
    }

    public bool ShowDisplayVersion
    {
        get;
        init;
    }
}