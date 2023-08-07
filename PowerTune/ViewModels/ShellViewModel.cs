using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Xaml.Navigation;
using PowerTune.Contracts.Services;
using PowerTune.Services;
using PowerTune.Views;

namespace PowerTune.ViewModels;

public partial class ShellViewModel : ObservableRecipient {
    [ObservableProperty]
    bool isBackEnabled;

    [ObservableProperty]
    object? selected;

    readonly IRestorePointService _restorePointService = new RestorePointService();
    public INavigationService NavigationService {
        get;
    }
    public INavigationViewService NavigationViewService {
        get;
    }

    [ObservableProperty][NotifyPropertyChangedFor(nameof(IsNotSplashScreenBusy))] bool isSplashScreenBusy;
    [ObservableProperty] bool isVisible = false;
    public bool IsNotSplashScreenBusy => !IsSplashScreenBusy;

    public ShellViewModel(INavigationService navigationService, INavigationViewService navigationViewService) {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;
        NavigationViewService = navigationViewService;

        StartupTask();
    }

    async void StartupTask() {
        IsSplashScreenBusy = true;

        try { await _restorePointService.RunRestorePoint(); } // Perform the notification task asynchronously
        finally { IsSplashScreenBusy = false; }
    }

    void OnNavigated(object sender, NavigationEventArgs e) {
        IsBackEnabled = NavigationService.CanGoBack;

        if (e.SourcePageType == typeof(SettingsPage)) {
            Selected = NavigationViewService.SettingsItem;
            return;
        }

        var selectedItem = NavigationViewService.GetSelectedItem(e.SourcePageType);
        if (selectedItem != null) Selected = selectedItem;
    }
}