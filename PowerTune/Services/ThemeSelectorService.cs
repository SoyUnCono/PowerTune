using Microsoft.UI.Xaml;
using PowerTune.Contracts.Services;
using PowerTune.Helpers;

namespace PowerTune.Services;

public class ThemeSelectorService : IThemeSelectorService {
    const string SettingsKey = "AppBackgroundRequestedTheme";

    public ElementTheme Theme { get; set; } = ElementTheme.Dark;

    readonly ILocalSettingsService _localSettingsService;

    public ThemeSelectorService(ILocalSettingsService localSettingsService) {
        _localSettingsService = localSettingsService;
    }

    public async Task InitializeAsync() {
        Theme = await LoadThemeFromSettingsAsync();
        await Task.CompletedTask;
    }

    public async Task SetThemeAsync(ElementTheme theme) {
        Theme = theme;

        await SetRequestedThemeAsync();
        await SaveThemeInSettingsAsync(Theme);
    }

    public async Task SetRequestedThemeAsync() {
        if (App.MainWindow.Content is FrameworkElement rootElement) {
            rootElement.RequestedTheme = Theme;

            TitleBarHelper.UpdateTitleBar(Theme);
        }

        await Task.CompletedTask;
    }

    async Task<ElementTheme> LoadThemeFromSettingsAsync() {
        var themeName = await _localSettingsService.ReadSettingAsync<string>(SettingsKey);

        if (Enum.TryParse(themeName, out ElementTheme cacheTheme)) {
            return cacheTheme;
        }

        return ElementTheme.Default;
    }

    async Task SaveThemeInSettingsAsync(ElementTheme theme) {
        await _localSettingsService.SaveSettingAsync(SettingsKey, theme.ToString());
    }
}
