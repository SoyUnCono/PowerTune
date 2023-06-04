using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Navigation;

using PowerTune.Contracts.Services;
using PowerTune.Services;

namespace PowerTune.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    // NavigationView
    [ObservableProperty]
    private bool isBackEnabled;

    //Dependecy Injection && Commands
    private readonly IRestorePointService _restorePointService = new RestorePointService();
    public ICommand MenuSettingsCommand
    {
        get;
    } 
    public ICommand MenuViewsMainCommand
    {
        get;
    }
    public INavigationService NavigationService
    {
        get;
    }

    // ProgressBar
    [ObservableProperty][NotifyPropertyChangedFor(nameof(IsNotSplashScreenBusy))] private bool isSplashScreenBusy;
    [ObservableProperty] private bool isVisible = false;
    public bool IsNotSplashScreenBusy => !IsSplashScreenBusy;
   
    public ShellViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;

        MenuSettingsCommand = new RelayCommand(OnMenuSettings);
        MenuViewsMainCommand = new RelayCommand(OnMenuViewsMain);

        // Load Tasks After activation
        StartupTask();
    }

    // Performs startup tasks asynchronously
    private async void StartupTask()
    {
        // Set IsSplashScreenBusy property to true to indicate that the splash screen is busy
        IsSplashScreenBusy = true;

        try { await _restorePointService.RunRestorePoint(); } // Perform the notification task asynchronously
        finally
        {
            // Delay the execution for 4000 milliseconds (4 seconds)
            // Set IsSplashScreenBusy property to false to indicate that the splash screen is no longer busy
            await Task.Delay(4000);
            IsSplashScreenBusy = false;
        }
    }
   

    // Updates the value of IsBackEnabled based on whether the NavigationService can go back
    private void OnNavigated(object sender, NavigationEventArgs e) => IsBackEnabled = NavigationService.CanGoBack;

    // Navigates to the SettingsViewModel by using the NavigationService and passing the full name of the SettingsViewModel type
    private void OnMenuSettings() => NavigationService.NavigateTo(typeof(SettingsViewModel).FullName!);

    // Navigates to the MainViewModel by using the NavigationService and passing the full name of the MainViewModel type
    private void OnMenuViewsMain() => NavigationService.NavigateTo(typeof(MainViewModel).FullName!);

}
