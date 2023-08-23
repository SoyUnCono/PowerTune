using Microsoft.UI.Text;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;

namespace PowerTune.Services;

public static class ContentDialogService
{
    private static XamlRoot? _xamlRoot;

    public static void Initialize(XamlRoot xamlRoot) => _xamlRoot = xamlRoot;

    public static async Task<ContentDialogResult> ShowDialogAsync(string title, string description, string errorCode)
    {
        ContentDialog dialog = new()
        {
            XamlRoot = _xamlRoot,
            Name = "ErrorDialog",
            CloseButtonText = "ok",
            Title = new StackPanel
            {
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Top,
                Orientation = Orientation.Horizontal,
                Children =
                {
                    new Image
                    {
                        Width = 66,
                        Height = 66,
                        Margin = new Thickness(8, 0, 0, 0),
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Center,
                        Source = new BitmapImage(
                            new Uri("ms-appx:///Assets/NavigationViewIcons/icons8-broken-robot-66.png"))
                    },
                    new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        Children =
                        {
                            new TextBlock
                            {
                                VerticalAlignment = VerticalAlignment.Center,
                                FontSize = 22,
                                FontWeight = FontWeights.Bold,
                                Text = title
                            },
                            new TextBlock
                            {
                                VerticalAlignment = VerticalAlignment.Bottom,
                                FontSize = 12,
                                FontWeight = FontWeights.Normal,
                                Text = errorCode
                            }
                        }
                    }
                }
            },
            Content = new StackPanel
            {
                Orientation = Orientation.Vertical,
                Children =
                {
                    new TextBlock
                    {
                        Margin = new Thickness(0, 0, 0, 8),
                        VerticalAlignment = VerticalAlignment.Top,
                        Text = description,
                        TextWrapping = TextWrapping.Wrap
                    }
                }
            }
        };

        return await dialog.ShowAsync();
    }
}