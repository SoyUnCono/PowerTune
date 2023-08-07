using Microsoft.UI.Xaml.Data;

namespace PowerTune.Converters;

public class BoolToIntConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        // Convert bool to int
        if (value is bool boolValue)
            return boolValue ? 1 : 0;

        return 0; // Default value if the conversion fails
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        // Convert int to bool
        if (value is int intValue)
            return intValue != 0;

        return false; // Default value if the conversion fails
    }
}