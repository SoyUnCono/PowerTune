﻿using Microsoft.UI.Xaml.Data;

namespace PowerTune.Converters;

public class ToggleSwitchToStatusConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var isOn = (bool)value;
        const string enabledMessage = "Your User Account Control (UAC) settings is now enabled.";
        const string disabledMessage = "Your User Account Control (UAC) settings are set to disabled.";

        return isOn ? disabledMessage : enabledMessage;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}