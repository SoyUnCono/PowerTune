﻿using Microsoft.UI.Xaml.Data;

namespace PowerTune.Helpers;
public class BooleanToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var boolValue = (bool)value;
        var parameterString = parameter as string;

        if (!string.IsNullOrEmpty(parameterString))
        {
            var values = parameterString.Split(',');

            if (boolValue)
                return values[0];

            if (values.Length > 1)
                return values[1];
        }

        return boolValue.ToString();
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}