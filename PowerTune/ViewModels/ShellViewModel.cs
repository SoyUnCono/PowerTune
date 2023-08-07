using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml.Navigation;

using PowerTune.Contracts.Services;
using PowerTune.Services;
using PowerTune.Views;

namespace PowerTune.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    // NavigationView
    [ObservableProperty]
    private bool isBackEnabled;

    [ObservableProperty]
    private object? selected;

    //Dependency Injection && Commands
    private readonly IRestorePointService _restorePointService = new RestorePointService();
    public INavigationService NavigationService
    {
        get;
    }
    public INavigationViewService NavigationViewService
    {
        get;
    }

    // ProgressBar
    [ObservableProperty][NotifyPropertyChangedFor(nameof(IsNotSplashScreenBusy))] private bool isSplashScreenBusy;
    [ObservableProperty] private bool isVisible = false;
    public bool IsNotSplashScreenBusy => !IsSplashScreenBusy;
   
    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;

        // Load Tasks After activation
        StartupTask();
    }

    // Performs start up tasks asynchronously
    private async void StartupTask()
    {
        // Set IsSplashScreenBusy property to true to indicate that the splash screen is busy
        IsSplashScreenBusy = true;

        try { await _restorePointService.RunRestorePoint(); } // Perform the notification task asynchronously
        finally { IsSplashScreenBusy = false; }
       
    }

    // Updates the value of IsBackEnabled based on whether the NavigationService can go back
    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        IsBackEnabled = NavigationService.CanGoBack;

        if (e.SourcePageType == typeof(SettingsPage))
        {
            Selected = NavigationViewService.SettingsItem;
            return;
        }

        var selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
        if (selectedItem != null)
        {
            Selected = selectedItem;
        }
    }
}
