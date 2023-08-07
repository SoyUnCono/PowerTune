using Microsoft.Windows.ApplicationModel.Resources;

namespace PowerTune.Extensions;

public static class ResourceExtensions {
    static readonly ResourceLoader _resourceLoader = new();

    public static string GetLocalized(this string resourceKey) => _resourceLoader.GetString(resourceKey);
}
