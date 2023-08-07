using System.Reflection;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml;
using PowerTune.Contracts.Services;
using PowerTune.Extensions;
using PowerTune.Helpers;
using Windows.ApplicationModel;

namespace PowerTune.ViewModels;

public partial class SettingsViewModel : ObservableRecipient {
    readonly IThemeSelectorService _themeSelectorService;

    [ObservableProperty]
    ElementTheme _elementTheme;

    [ObservableProperty]
    string _versionDescription;

    public ICommand SwitchThemeCommand {
        get;
    }

    public SettingsViewModel(IThemeSelectorService themeSelectorService) {
        _themeSelectorService = themeSelectorService;
        _elementTheme = _themeSelectorService.Theme;
        _versionDescription = GetVersionDescription();

        SwitchThemeCommand = new RelayCommand<ElementTheme>(
            async (param) => {
                if (ElementTheme != param) {
                    ElementTheme = param;
                    await _themeSelectorService.SetThemeAsync(param);
                }
            });
    }

    static string GetVersionDescription() {
        Version version;

        if (RuntimeHelper.IsMSIX) {
            var packageVersion = Package.Current.Id.Version;
            version = new(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);
        }
        else { version = Assembly.GetExecutingAssembly().GetName().Version!; }

        return $"{"AppDisplayName".GetLocalized()} - {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
    }
}