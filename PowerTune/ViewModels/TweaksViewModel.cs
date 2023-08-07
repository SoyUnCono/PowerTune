using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PowerTune.Core.Contracts.Services;
using PowerTune.Helpers;
using PowerTune.Models;
using PowerTune.Strings;

namespace PowerTune.ViewModels;

public partial class TweaksViewModel : ObservableRecipient
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    bool isBusy;

    [ObservableProperty] bool? isBoldCheck = false;
    [ObservableProperty] string? _selected_String;
    readonly IFileService _fileService;

    readonly string? PowerTunePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PowerTune");

    public bool IsNotBusy => !IsBusy;

    [ObservableProperty] int selectedTitleBarSize;

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

    readonly Dictionary<int, (string REGULAR, string BOLD)> stringData = new()
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

    async Task LoadSettingsAsync()
    {
        var settings = await _fileService.Read<AppSettings>($"{PowerTunePath}", "AppSettings.json");

        if (settings == null)
            _ = App.MainWindow.CreateMessageDialog("An error has occurred trying to load settings");

        if (settings != null)
        {
            SelectedTitleBarSize = (int)settings?._SelectedTitleBarSize!;
            IsBoldCheck = (bool)settings?._IsBoldCheck!;
        }
    }


    async void ApplyBasicsOptimizations()
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

        await _fileService.Save($"{PowerTunePath}", "AppSettings.json", new AppSettings { _IsBoldCheck = IsBoldCheck, _SelectedTitleBarSize = SelectedTitleBarSize });

        IsBusy = false;
    }
}