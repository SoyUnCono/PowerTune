using Microsoft.UI.Xaml.Controls;
using PowerTune.ViewModels;

namespace PowerTune.Views;

public sealed partial class MainPage : Page {
    public MainViewModel ViewModel {
        get;
    }

    public MainPage() {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }

    // Loads the page and displays a warning dialog if CheckBox_Dialog is not checked
    async void Page_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e) {
        // Checks if the CheckBox_Dialog property is false
        // Displays the warning dialog asynchronously
        if (!ViewModel.CheckBox_Dialog)
            await SplashWarningDialog.ShowAsync();
    }
}