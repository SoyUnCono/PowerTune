﻿using Microsoft.Windows.ApplicationModel.Resources;

namespace PowerTune.Extensions;

public static class ResourceExtensions
{
    private static readonly ResourceLoader ResourceLoader = new();

    public static string GetLocalized(this string resourceKey) => ResourceLoader.GetString(resourceKey);
}