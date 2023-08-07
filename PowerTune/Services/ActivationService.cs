using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PowerTune.Activation;
using PowerTune.Contracts.Services;
using PowerTune.Views;

namespace PowerTune.Services;

public class ActivationService : IActivationService {
    readonly ActivationHandler<LaunchActivatedEventArgs> _defaultHandler;
    readonly IEnumerable<IActivationHandler> _activationHandlers;
    readonly IThemeSelectorService _themeSelectorService;
    UIElement? _shell;

    public ActivationService(ActivationHandler<LaunchActivatedEventArgs> defaultHandler, IEnumerable<IActivationHandler> activationHandlers, IThemeSelectorService themeSelectorService) {
        _defaultHandler = defaultHandler;
        _activationHandlers = activationHandlers;
        _themeSelectorService = themeSelectorService;
    }

    public async Task ActivateAsync(object activationArgs) {
        // Execute tasks before activation.
        await InitializeAsync();

        // Set the MainWindow Content.
        if (App.MainWindow.Content == null) {
            _shell = App.GetService<ShellPage>();
            App.MainWindow.Content = _shell ?? new Frame();
        }

        // Handle activation via ActivationHandlers.
        await HandleActivationAsync(activationArgs);

        // Activate the MainWindow.
        App.MainWindow.Activate();

        // Execute tasks after activation.
        await StartupAsync();
    }

    async Task HandleActivationAsync(object activationArgs) {
        var activationHandler = _activationHandlers.FirstOrDefault(h => h.CanHandle(activationArgs));

        if (activationHandler != null) {
            await activationHandler.HandleAsync(activationArgs);
        }

        if (_defaultHandler.CanHandle(activationArgs)) {
            await _defaultHandler.HandleAsync(activationArgs);
        }
    }

    async Task InitializeAsync() {
        await _themeSelectorService.InitializeAsync().ConfigureAwait(false);
        await Task.CompletedTask;
    }

    async Task StartupAsync() {
        await _themeSelectorService.SetRequestedThemeAsync();
        await Task.CompletedTask;
    }
}
