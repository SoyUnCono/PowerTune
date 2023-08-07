using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.WinUI.UI.Triggers;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Win32;
using PowerTune.Contracts.Services;
using PowerTune.Core.Contracts.Services;
using PowerTune.Helpers;
using PowerTune.Models;
using PowerTune.Strings;
using PowerTune.Views;
using Windows.Media.Core;

namespace PowerTune.ViewModels;

public partial class TweaksViewModel : ObservableRecipient
{
    // Bool's
    // A flag indicating if the view model is busy.
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;

    [ObservableProperty] private bool? isBoldCheck = false;
    [ObservableProperty] private string? _selected_String;
    private readonly IFileService _fileService;

    private readonly string? PowerTunePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PowerTune");

    // Public bool's
    // A flag indicating if the view model is not busy (the inverse of 'isBusy').
    public bool IsNotBusy => !IsBusy;

    [ObservableProperty] private int selectedTitleBarSize;

    // Public List
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

    // Dependency Injections && Commands
    // Command to import all basic settings.
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
            App.MainWindow.CreateMessageDialog("An error has occurred trying to load settings");

        if (settings != null)
        {
            SelectedTitleBarSize = (int)settings?._SelectedTitleBarSize!;
            IsBoldCheck = (bool)settings?._IsBoldCheck!;
        }

    }


    // Method: ApplyBasicsOptimizations
    // Apply basic optimizations to the operating system.
    // The method sets 'isBusy' to true while applying optimizations, and after completion, it sets 'isBusy' to false.
    private async void ApplyBasicsOptimizations()
    {
        IsBusy = true;

        // Get the version of the operating system
        var osVersion = Environment.OSVersion.Version;

        // Check if the operating system version is Windows 10
        // Import basic optimizations from the specified raw content using the RegistryHelper.
        if (osVersion.Major == 10 && osVersion.Minor == 0)
            RegistryHelper.ImportRegistryFromString(Constants.RawBasicsOptimizationsW10);

        // Check if the operating system version is Windows 11 (build 22000 or higher)
        // Import basic optimizations from the specified raw content using the RegistryHelper.
        if (osVersion.Major >= 10 && osVersion.Build >= 22000)
            RegistryHelper.ImportRegistryFromString(Constants.RawBasicsOptimizationsW11);

        // Add a small delay to simulate processing time (remove this if unnecessary).
        await Task.Delay(1000);

        // Set 'isBusy' to false after optimizations have been applied.
        IsBusy = false;
    }

    // Method: ApplyTitleBarSize
    // This method is used to apply the selected title bar size to the Windows Registry.
    // The parameter '_Selected_String' is not needed as the value will be determined inside the method.
    public async void ApplyTitleBarSizeAsync()
    {
        IsBusy = true;

        // Verifies that the selected value is present in the 'stringData' dictionary.
        if (stringData.TryGetValue(SelectedTitleBarSize, out var stringPair))
        {

            // Verifies if the CheckBox is NOT checked and selects the regular string.
            if (IsBoldCheck == false)
                Selected_String = stringPair.REGULAR;

            // Verifies if the CheckBox is checked and selects the bold string.
            if (IsBoldCheck == true)
                Selected_String = stringPair.BOLD;

        }

        // If '_Selected_String' is null or empty, display an error message.
        // Display an error message indicating that an error has occurred.
        if (string.IsNullOrEmpty(Selected_String))
            return;


        // Import the selected string (either regular or bold) to the Windows Registry using 'RegistryHelper'.
        RegistryHelper.ImportRegistryFromString(Selected_String);


        await _fileService.Save($"{PowerTunePath}", "AppSettings.json", new AppSettings { _IsBoldCheck = IsBoldCheck, _SelectedTitleBarSize = SelectedTitleBarSize });

        IsBusy = false;
    }


}
