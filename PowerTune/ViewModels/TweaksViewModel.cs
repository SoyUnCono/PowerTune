using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using PowerTune.CustomCommands;

namespace PowerTune.ViewModels;
public partial class TweaksViewModel : ObservableRecipient
{
    // Dependecy Injections & Command's
    public ICommand OptimizeSystemSettingsCommand
    {
        get;
    }
    public ICommand ApplyDefaultValuesCommand
    {
        get;
    }

    // Bool's
    [ObservableProperty][NotifyPropertyChangedFor(nameof(IsNotBusy))] private bool isBusy;

    // Public bool's
    public bool IsNotBusy => !IsBusy;


    public TweaksViewModel()
    {
        OptimizeSystemSettingsCommand = new RelayCommand(OptimizeSystemSettings);
        ApplyDefaultValuesCommand = new RelayCommand(ApplyDefaultValues);
    }

    public async void OptimizeSystemSettings()
    {
        IsBusy = true;
        var registry = RegistryCommands.SetRegistryValue;

        // Disable power throttling
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.PowerThrottlingPath, Constants.PowerThrottlingValue, 1);

        // Network throttling & system responsiveness
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.SystemProfilePath, Constants.NetworkThrottlingIndexValue, unchecked((int)0xFFFFFFFF));
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.SystemProfilePath, Constants.SystemResponsivenessValue, 0);

        // Games scheduling
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingAffinityValue, 0);
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingBackgroundOnlyValue, "False");
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingClockRateValue, 10000);
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingGPUPriorityValue, 8);
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingPriorityValue, 6);
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingSchedulingCategoryValue, "High");
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingSFIOValue, "High");

        // Disable sleep
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.SleepSettingsPath, Constants.SleepSettingsValue, 0);

        // Disable hibernate
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.HibernateSettingsPath, Constants.HibernateSettingsValue, 0);

        // Disable automatic maintenance
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.AutomaticMaintenancePath, Constants.AutomaticMaintenanceValue, 1);

        // Disable menu show delay
        registry(Constants.HKEY_CURRENT_USER, Constants.MenuShowDelayPath, Constants.MenuShowDelayValue, "0");

        // Restore the classic context menu 4 w11
        registry(Constants.HKEY_CURRENT_USER, Constants.ClassicContextMenuPath, Constants.ClassicContextMenuValue, "");

        // Disable background apps global 4 w11
        registry(Constants.HKEY_CURRENT_USER, Constants.BackgroundAppsPath, Constants.BackgroundAppsValue, 1);

        // Disable windows widgets 4 w11
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.DisableWindowsWidgetsPath, Constants.DisableWindowsWidgetsValue, 0);
        await Task.Delay(1000);
        IsBusy = false;
    }

    public async void ApplyDefaultValues()
    {
        IsBusy = true;

        var registry = RegistryCommands.SetRegistryValue;

        // Disable power throttling
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.PowerThrottlingPath, Constants.PowerThrottlingValue, 0); 

        // Network throttling & system responsiveness
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.SystemProfilePath, Constants.NetworkThrottlingIndexValue, 0); 
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.SystemProfilePath, Constants.SystemResponsivenessValue, unchecked((int)0x00000001));

        // Games scheduling
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingAffinityValue, 1); 
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingBackgroundOnlyValue, "True"); 
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingClockRateValue, 0); 
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingGPUPriorityValue, 0); 
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingPriorityValue, 0); 
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingSchedulingCategoryValue, "Normal");
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.GamesSchedulingPath, Constants.GamesSchedulingSFIOValue, "Normal"); 

        // Disable sleep
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.SleepSettingsPath, Constants.SleepSettingsValue, 1); 

        // Disable hibernate
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.HibernateSettingsPath, Constants.HibernateSettingsValue, 1); 

        // Disable automatic maintenance
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.AutomaticMaintenancePath, Constants.AutomaticMaintenanceValue, 0); 

        // Disable menu show delay
        registry(Constants.HKEY_CURRENT_USER, Constants.MenuShowDelayPath, Constants.MenuShowDelayValue, "400"); 

        // Restore the classic context menu 4 w11
        registry(Constants.HKEY_CURRENT_USER, Constants.ClassicContextMenuPath, Constants.ClassicContextMenuValue, "valor_original"); 
        // Disable background apps global 4 w11
        registry(Constants.HKEY_CURRENT_USER, Constants.BackgroundAppsPath, Constants.BackgroundAppsValue, 0); 

        // Disable windows widgets 4 w11
        registry(Constants.HKEY_LOCAL_MACHINE, Constants.DisableWindowsWidgetsPath, Constants.DisableWindowsWidgetsValue, 1); 

        await Task.Delay(1000);
        IsBusy = false;
    }
}
