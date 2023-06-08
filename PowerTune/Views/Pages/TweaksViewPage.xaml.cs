using Microsoft.UI.Xaml.Controls;

using PowerTune.ViewModels;

namespace PowerTune.Views;

public sealed partial class TweaksViewPage : Page
{
    public TweaksViewViewModel ViewModel
    {
        get;
    }

    public TweaksViewPage()
    {
        ViewModel = App.GetService<TweaksViewViewModel>();
        InitializeComponent();
    }
}
