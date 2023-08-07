using Microsoft.UI.Xaml.Data;

namespace PowerTune.Converters;
public class DoubleToStringConverter : IValueConverter {
    public object Convert(object value, Type targetType, object parameter, string language) {
        if (value is double doubleValue) {
            return doubleValue.ToString();
        }

        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language) {
        throw new NotImplementedException();
    }
}