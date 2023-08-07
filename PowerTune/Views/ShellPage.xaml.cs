using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using PowerTune.Extensions;
using PowerTune.Helpers;
using PowerTune.ViewModels;

namespace PowerTune.Views;

public sealed partial class ShellPage : Page {
    // ViewModel property representing the view model associated with the ShellPage
    public ShellViewModel ViewModel {
        get;
    }

    // Constructor for ShellPage, initializes the view model and sets up the UI
    public ShellPage(ShellViewModel viewModel) {
        ViewModel = viewModel;
        InitializeComponent();

        // Set up navigation service
        ViewModel.NavigationService.Frame = NavigationFrame;
        ViewModel.NavigationViewService.Initialize(NavigationViewControl);

        // Customize title bar
        App.MainWindow.ExtendsContentIntoTitleBar = true;
        App.MainWindow.SetTitleBar(AppTitleBar);
        App.MainWindow.Activated += MainWindow_Activated;
        AppTitleBarText.Text = "AppDisplayName".GetLocalized();
    }

    // Event handler for the MainWindow Activated event, updates the app title bar based on activation state
    void MainWindow_Activated(object sender, WindowActivatedEventArgs args) {
        var resource = args.WindowActivationState == WindowActivationState.Deactivated ? "WindowCaptionForegroundDisabled" : "WindowCaptionForeground";

        AppTitleBarText.Foreground = (SolidColorBrush)App.Current.Resources[resource];
        App.AppTitlebar = AppTitleBarText as UIElement;
    }

    void NavigationViewControl_DisplayModeChanged(NavigationView sender, NavigationViewDisplayModeChangedEventArgs args) {
        AppTitleBar.Margin = new Thickness() {
            Left = sender.CompactPaneLength * (sender.DisplayMode == NavigationViewDisplayMode.Minimal ? 2 : 1),
            Top = AppTitleBar.Margin.Top,
            Right = AppTitleBar.Margin.Right,
            Bottom = AppTitleBar.Margin.Bottom
        };
    }

    void OnLoaded(object sender, RoutedEventArgs e) => TitleBarHelper.UpdateTitleBar(RequestedTheme);
}