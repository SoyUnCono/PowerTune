using System.Windows.Input;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Navigation;

using PowerTune.Contracts.Services;

namespace PowerTune.ViewModels;

public partial class ShellViewModel : ObservableRecipient
{
    [ObservableProperty]
    private bool isBackEnabled;

    // DependencyInjection
    public ICommand MenuFileExitCommand
    {
        get;
    }
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
    [ObservableProperty][NotifyPropertyChangedFor(nameof(IsNotBusy))] private bool isBusy;
    [ObservableProperty] private bool isVisible = false;
    public bool IsNotBusy => !IsBusy;


    public ShellViewModel(INavigationService navigationService)
    {
        NavigationService = navigationService;
        NavigationService.Navigated += OnNavigated;

        MenuFileExitCommand = new RelayCommand(OnMenuFileExit);
        MenuSettingsCommand = new RelayCommand(OnMenuSettings);
        MenuViewsMainCommand = new RelayCommand(OnMenuViewsMain);

        // Load Tasks After activation
        StartupTask();
    }

    private async void StartupTask()
    {
        IsBusy = true;
        try
        {
            // Add Tasks
        }
        finally
        {
            await Task.Delay(12000);
            IsBusy = false;
        }
    }

    private void OnNavigated(object sender, NavigationEventArgs e) => IsBackEnabled = NavigationService.CanGoBack;

    private void OnMenuFileExit() => Application.Current.Exit();

    private void OnMenuSettings() => NavigationService.NavigateTo(typeof(SettingsViewModel).FullName!);

    private void OnMenuViewsMain() => NavigationService.NavigateTo(typeof(MainViewModel).FullName!);
}
