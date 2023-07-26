using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PowerTune.Helpers;
using PowerTune.Strings;

namespace PowerTune.ViewModels;

public partial class TweaksViewModel : ObservableRecipient
{
    // Bool's
    // A flag indicating if the view model is busy.
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotBusy))]
    private bool isBusy;

    // Public bool's
    // A flag indicating if the view model is not busy (the inverse of 'isBusy').
    public bool IsNotBusy => !IsBusy;

    // Dependency Injections && Commands
    // Command to import all basic settings.
    public ICommand ImportAllBasicSettingsCommand
    {
        get;
    }

    public TweaksViewModel()
    {
        // Initialize the command to import all basic settings using a RelayCommand.
        ImportAllBasicSettingsCommand = new RelayCommand(ApplyBasicsOptimizations);
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
        if (osVersion.Build >= 22000)
            RegistryHelper.ImportRegistryFromString(Constants.RawBasicsOptimizationsW11);

        // Add a small delay to simulate processing time (remove this if unnecessary).
        await Task.Delay(1000);

        // Set 'isBusy' to false after optimizations have been applied.
        IsBusy = false; 
    }
}
