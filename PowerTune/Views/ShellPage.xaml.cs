using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;

using PowerTune.Contracts.Services;
using PowerTune.Helpers;
using PowerTune.ViewModels;

namespace PowerTune.Views;

public sealed partial class ShellPage : Page
{
    // ViewModel property representing the view model associated with the ShellPage
    public ShellViewModel ViewModel
    {
        get;
    }

    // Constructor for ShellPage, initializes the view model and sets up the UI
    public ShellPage(ShellViewModel viewModel)
    {
        ViewModel = viewModel;
        InitializeComponent();

        // Set up navigation service
        ViewModel.NavigationService.Frame = NavigationFrame;

        // Customize title bar
        App.MainWindow.ExtendsContentIntoTitleBar = true;
        App.MainWindow.SetTitleBar(AppTitleBar);
        App.MainWindow.Activated += MainWindow_Activated;
        AppTitleBarText.Text = "AppDisplayName".GetLocalized();
    }

    // Event handler for the Loaded event, updates the title bar and adds event handlers for settings button
    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        TitleBarHelper.UpdateTitleBar(RequestedTheme);

        ShellMenuBarSettingsButton.AddHandler(UIElement.PointerPressedEvent, new PointerEventHandler(ShellMenuBarSettingsButton_PointerPressed), true);
        ShellMenuBarSettingsButton.AddHandler(UIElement.PointerReleasedEvent, new PointerEventHandler(ShellMenuBarSettingsButton_PointerReleased), true);
    }

    // Event handler for the MainWindow Activated event, updates the app title bar based on activation state
    private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
    {
        var resource = args.WindowActivationState == WindowActivationState.Deactivated ? "WindowCaptionForegroundDisabled" : "WindowCaptionForeground";

        AppTitleBarText.Foreground = (SolidColorBrush)App.Current.Resources[resource];
        App.AppTitlebar = AppTitleBarText as UIElement;
    }

    // Event handler for the Unloaded event, removes event handlers for settings button
    private void OnUnloaded(object sender, RoutedEventArgs e)
    {
        ShellMenuBarSettingsButton.RemoveHandler(UIElement.PointerPressedEvent, (PointerEventHandler)ShellMenuBarSettingsButton_PointerPressed);
        ShellMenuBarSettingsButton.RemoveHandler(UIElement.PointerReleasedEvent, (PointerEventHandler)ShellMenuBarSettingsButton_PointerReleased);
    }

    // Event handler for the PointerEntered event of the settings button, sets the state to PointerOver
    private void ShellMenuBarSettingsButton_PointerEntered(object sender, PointerRoutedEventArgs e) => AnimatedIcon.SetState((UIElement)sender, "PointerOver");

    // Event handler for the PointerPressed event of the settings button, sets the state to Pressed
    private void ShellMenuBarSettingsButton_PointerPressed(object sender, PointerRoutedEventArgs e) => AnimatedIcon.SetState((UIElement)sender, "Pressed");

    // Event handler for the PointerReleased event of the settings button, sets the state to Normal
    private void ShellMenuBarSettingsButton_PointerReleased(object sender, PointerRoutedEventArgs e) => AnimatedIcon.SetState((UIElement)sender, "Normal");

    // Event handler for the PointerExited event of the settings button, sets the state to Normal
    private void ShellMenuBarSettingsButton_PointerExited(object sender, PointerRoutedEventArgs e) => AnimatedIcon.SetState((UIElement)sender, "Normal");

    // Event handler for the Click event of a button, shows an asynchronous custom dialog
    private async void Button_Click(object sender, RoutedEventArgs e) => await Dialog.ShowAsync();

}
