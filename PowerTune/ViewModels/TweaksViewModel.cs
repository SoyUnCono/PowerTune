using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PowerTune.Core.Contracts.Services;
using PowerTune.Helpers;
using PowerTune.Strings;
using PowerTune.Views;

namespace PowerTune.ViewModels;

public class AppSettings
{
    public bool IsBoldCheck
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
        set;
    }
    public int SelectedTitleBarSize
    {
        get;
        init;
    }
}

public partial class TweaksViewModel : ObservableRecipient
{
    private readonly string? PowerTunePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PowerTune");
    private readonly IFileService _fileService;

    [ObservableProperty] private bool _isBoldCheck;
    [ObservableProperty] private bool _visualFeedBack;
    [ObservableProperty] private bool _showErrorDialog;
    [ObservableProperty] private bool _hideScrollBar;
    [ObservableProperty] private int _selectedTitleBarSize;

    [ObservableProperty] private string? _selected_String;
    [ObservableProperty] private string? _errorDialogHandlerTitle;
    [ObservableProperty] private string? _errorDialogHandlerDescription;
    [ObservableProperty] private string? _errorDialogHandlerErrorCode;


    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;
    public bool IsNotBusy => !IsBusy;

    public List<int> Titlebar_Size = new()
    {
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        14,
        15,
        16,
        17,
        18,
        19,
        20,
        21,
        22,
        23,
        24,
    };
    private readonly Dictionary<int, (string REGULAR, string BOLD)> stringData = new()
    {
        { 0, (Constants._TITLE_BAR_6, Constants._TITLE_BAR_6_BOLD) },
        { 1, (Constants._TITLE_BAR_7, Constants._TITLE_BAR_7_BOLD) },
        { 2, (Constants._TITLE_BAR_8, Constants._TITLE_BAR_8_BOLD) },
        { 3, (Constants._TITLE_BAR_9, Constants._TITLE_BAR_9_BOLD) },
        { 4, (Constants._TITLE_BAR_10, Constants._TITLE_BAR_10_BOLD) },
        { 5, (Constants._TITLE_BAR_11, Constants._TITLE_BAR_11_BOLD) },
        { 6, (Constants._TITLE_BAR_12, Constants._TITLE_BAR_12_BOLD) },
        { 7, (Constants._TITLE_BAR_13, Constants._TITLE_BAR_13_BOLD) },
        { 8, (Constants._TITLE_BAR_14, Constants._TITLE_BAR_14_BOLD) },
        { 9, (Constants._TITLE_BAR_15, Constants._TITLE_BAR_15_BOLD) },
        { 10, (Constants._TITLE_BAR_16, Constants._TITLE_BAR_16_BOLD) },
        { 11, (Constants._TITLE_BAR_17, Constants._TITLE_BAR_17_BOLD) },
        { 12, (Constants._TITLE_BAR_18, Constants._TITLE_BAR_18_BOLD) },
        { 13, (Constants._TITLE_BAR_19, Constants._TITLE_BAR_19_BOLD) },
        { 14, (Constants._TITLE_BAR_20, Constants._TITLE_BAR_20_BOLD) },
        { 15, (Constants._TITLE_BAR_21, Constants._TITLE_BAR_21_BOLD) },
        { 16, (Constants._TITLE_BAR_22, Constants._TITLE_BAR_22_BOLD) },
        { 17, (Constants._TITLE_BAR_23, Constants._TITLE_BAR_23_BOLD) },
        { 18, (Constants._TITLE_BAR_24, Constants._TITLE_BAR_24_BOLD) },
    };

    public ICommand ImportAllBasicSettingsCommand
    {
        get;
    }

    public TweaksViewModel(IFileService fileService)
    {
        _fileService = fileService;
        _ = LoadSettingsAsync();
        ImportAllBasicSettingsCommand = new RelayCommand(ApplyBasicsOptimizations);
    }

    private async Task LoadSettingsAsync()
    {
        var settings = await _fileService.Read<AppSettings>($"{PowerTunePath}", "AppSettings.json");

        if (settings == null)
            HandleErrorDialog("Error", "An error occurred while attempting to load settings", "Error code [ 0x0ffff ]",true);

        if (settings != null)
        {
            SelectedTitleBarSize = settings.SelectedTitleBarSize;
            IsBoldCheck = settings.IsBoldCheck;
            VisualFeedBack = settings.VisualFeedBack;
            HideScrollBar = settings.HideScrollBar;
        }
    }


    private async Task SaveSettings()
    {
        await _fileService.Save($"{PowerTunePath}", "AppSettings.json", new AppSettings
        {
            HideScrollBar = HideScrollBar,
            IsBoldCheck = IsBoldCheck,
            SelectedTitleBarSize = SelectedTitleBarSize,
            VisualFeedBack = VisualFeedBack,
        });
    }

    private async void ApplyBasicsOptimizations()
    {
        IsBusy = true;

        var osVersion = Environment.OSVersion.Version;

        if (osVersion.Major == 10 && osVersion.Minor == 0)
            RegistryHelper.ImportRegistryFromString(Constants.RawBasicsOptimizationsW10);

        if (osVersion.Major >= 10 && osVersion.Build >= 22000)
            RegistryHelper.ImportRegistryFromString(Constants.RawBasicsOptimizationsW11);

        await Task.Delay(1000);

        IsBusy = false;
    }

    public async void ApplyTitleBarSizeAsync()
    {
        IsBusy = true;

        if (stringData.TryGetValue(SelectedTitleBarSize, out var stringPair))
        {
            if (IsBoldCheck == false)
                Selected_String = stringPair.REGULAR;

            if (IsBoldCheck == true)
                Selected_String = stringPair.BOLD;
        }

        if (string.IsNullOrEmpty(Selected_String)) return;

        RegistryHelper.ImportRegistryFromString(Selected_String);

        await SaveSettings();

        IsBusy = false;
    }

    //public async Task ApplyCheckBoxValue(object sender, RoutedEventArgs e)
    //{
    //    var checkBox = (CheckBox)sender;
    //    var checkBoxId = checkBox.Tag as string;
    //    var checkStatus = (bool)checkBox.IsChecked!;
    //    var customCommand = RegistryHelper.SetRegistryValue;

    //    switch (checkBoxId)
    //    {

    //    }
    //}

    private void HandleErrorDialog(string title, string description,string errorCode, bool showDialog)
    {
        ErrorDialogHandlerTitle = title;
        ErrorDialogHandlerDescription = description;
        ErrorDialogHandlerErrorCode = errorCode;
        ShowErrorDialog = showDialog;
    }

    public async Task ApplyToggleSwitchValue(object sender, RoutedEventArgs e)
    {
        var toggleSwitch = (ToggleSwitch)sender;
        var toggleSwitchId = toggleSwitch.Tag.ToString();

        var customCommand = RegistryHelper.SetRegistryValue;

        var check = (bool)toggleSwitch.IsOn!;

        switch (toggleSwitchId)
        {
            case "HideScrollBar":
                customCommand(Constants.HKEY_CURRENT_USER, Constants.ShowAlwaysScrollBarPath, Constants.ShowAlwaysScrollBarValue, check ? 1 : 0);
                HideScrollBar = check;
                await SaveSettings();
                break;

            case "VisualFeedBack":
                customCommand(Constants.HKEY_CURRENT_USER, Constants.VisualFeedBackPath, Constants.VisualFeedBackvalue1, check ? 0 : 1);
                customCommand(Constants.HKEY_CURRENT_USER, Constants.VisualFeedBackPath, Constants.VisualFeedBackvalue1, check ? 0 : 1f);
                VisualFeedBack = check;
                await SaveSettings();
                break;

            default:
                break;

        }

    }
}