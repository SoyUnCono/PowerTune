using Microsoft.UI.Windowing;
using Microsoft.UI;
using PowerTune.Helpers;
using Windows.UI.ViewManagement;
using WinRT.Interop;

namespace PowerTune;

public sealed partial class MainWindow : WindowEx
{
    private readonly Microsoft.UI.Dispatching.DispatcherQueue dispatcherQueue;

    private readonly UISettings settings;

    public MainWindow()
    {
        InitializeComponent();

        AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Assets/WindowIcon.gif"));
        Content = null;
        Title = "AppDisplayName".GetLocalized();
        IsAlwaysOnTop = true;

        // Theme change code picked from https://github.com/microsoft/WinUI-Gallery/pull/1239
        dispatcherQueue = Microsoft.UI.Dispatching.DispatcherQueue.GetForCurrentThread();
        settings = new UISettings();
        settings.ColorValuesChanged += Settings_ColorValuesChanged; // cannot use FrameworkElement.ActualThemeChanged event

        // Moves the window to the right side of the screen.
        MoveWindowToTheRight();
    }

    /// <summary>
    /// Moves the window to the right side of the screen.
    /// </summary>
    private void MoveWindowToTheRight()
    {
        // Get the window ID
        // Get the window handle
        var hWnd = WindowNative.GetWindowHandle(this);
        var windowId = Win32Interop.GetWindowIdFromWindow(hWnd);

        // Check if the window ID corresponds to an AppWindow and a valid DisplayArea
        if (AppWindow.GetFromWindowId(windowId) is AppWindow appWindow && DisplayArea.GetFromWindowId(windowId, DisplayAreaFallback.Nearest) is DisplayArea displayArea)
        {
            // Create a new position for the window
            var newPosition = appWindow.Position;

            // Set X position to the right side of the screen
            // Set Y position to the bottom of the screen
            newPosition.X = displayArea.WorkArea.X + displayArea.WorkArea.Width - appWindow.Size.Width;
            newPosition.Y = displayArea.WorkArea.Y + displayArea.WorkArea.Height - appWindow.Size.Height;

            // Move the window to the new position
            appWindow.Move(newPosition);
        }
    }

    /// <summary>
    /// /this handles updating the caption button colours correctly when windows system theme is changed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    // while the app is open
    private void Settings_ColorValuesChanged(UISettings sender, object args)
    {
        // This calls comes off-thread, hence we will need to dispatch it to current app's thread
        dispatcherQueue.TryEnqueue(() =>
        {
            TitleBarHelper.ApplySystemThemeToCaptionButtons();
        });
    }
}
