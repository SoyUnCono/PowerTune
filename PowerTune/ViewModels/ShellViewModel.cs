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

    // Notifications && Checks
    [ObservableProperty] private string? notificationTitle;
    [ObservableProperty] private string? notificationMessage;
    [ObservableProperty] private string? notificationsIconSource;
    [ObservableProperty] private string? isRunAsAdmin;
    [ObservableProperty] private bool isNotificationOpen = false;
    [ObservableProperty] private bool canCloseNotification = false;
    [ObservableProperty] private bool notificationIconsVisible = false;

    // ProgressBar
    [ObservableProperty][NotifyPropertyChangedFor(nameof(IsNotSplashScreenBusy))] private bool isSplashScreenBusy;
    [ObservableProperty] private bool isVisible = false;
    public bool IsNotSplashScreenBusy => !IsSplashScreenBusy;
    private const string restorePointServiceName = "PowerTune_RestorePoint";


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

        try { await NotificationTask(); } // Perform the notification task asynchronously
        finally
        {
            // Delay the execution for 4000 milliseconds (4 seconds)
            // Set IsSplashScreenBusy property to false to indicate that the splash screen is no longer busy
            await Task.Delay(4000);
            IsSplashScreenBusy = false;
        }
    }

    public async Task NotificationTask()
    {
        // Create an instance of the RestorePointService
        IRestorePointService _restorePointService = new RestorePointService();

        // Run the restore point operation asynchronously
        var _RunRestorePoint = _restorePointService.RunRestorePoint();
        // Check if a restore point with the specified name exists asynchronously
        var _RestorePointExists = await RestorePointService.CheckIfRestorePointExists(restorePointServiceName);

        // Check the conditions to display the appropriate notification message
        if (_RestorePointExists || !_RestorePointExists)
        {
            IsNotificationOpen = true;
            CanCloseNotification = true;
            NotificationIconsVisible = true;
            NotificationTitle = "Information about the status of the restore point.";
            NotificationMessage = $"{(await _RunRestorePoint ? $"The restore point has been successfully created at {DateTime.Now}." : "Restore point already detected, operation aborted.")}";
        }
    }

    // Updates the value of IsBackEnabled based on whether the NavigationService can go back
    private void OnNavigated(object sender, NavigationEventArgs e) => IsBackEnabled = NavigationService.CanGoBack;

    // Navigates to the SettingsViewModel by using the NavigationService and passing the full name of the SettingsViewModel type
    private void OnMenuSettings() => NavigationService.NavigateTo(typeof(SettingsViewModel).FullName!);

    // Navigates to the MainViewModel by using the NavigationService and passing the full name of the MainViewModel type
    private void OnMenuViewsMain() => NavigationService.NavigateTo(typeof(MainViewModel).FullName!);

}
