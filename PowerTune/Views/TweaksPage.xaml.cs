using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.Xaml.Interactions.Core;
using PowerTune.ViewModels;

namespace PowerTune.Views;
public sealed partial class TweaksPage : Page
{
    public TweaksViewModel ViewModel
    {
        get;
    }

    public TweaksPage()
    {
        ViewModel = App.GetService<TweaksViewModel>();
        InitializeComponent();
    }

}