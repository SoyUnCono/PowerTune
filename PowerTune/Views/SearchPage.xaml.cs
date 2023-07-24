using Microsoft.UI.Xaml.Controls;
using PowerTune.ViewModels;

namespace PowerTune.Views;
public sealed partial class SearchPage : Page
{
    public SearchViewModel ViewModel
    {
        get;
    }
    public SearchPage()
    {
        ViewModel = App.GetService<SearchViewModel>();
        this.InitializeComponent();
    }
}
