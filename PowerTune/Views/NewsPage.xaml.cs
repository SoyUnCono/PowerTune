using Microsoft.UI.Xaml.Controls;
using PowerTune.ViewModels;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PowerTune.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class NewsPage : Page
{
    public NewsViewModel ViewModel
    {
        get;
    }

    public NewsPage()
    {
        ViewModel = App.GetService<NewsViewModel>();
        this.InitializeComponent();
    }
}
