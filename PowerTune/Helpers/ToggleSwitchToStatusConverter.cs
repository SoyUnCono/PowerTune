using Microsoft.UI.Xaml.Data;

namespace PowerTune.Helpers;
public class ToggleSwitchToStatusConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        var isOn = (bool)value;
        var enabledMessage = "Your User Account Control (UAC) settings is now enabled.";
        var disabledMessage = "Your User Account Control (UAC) settings are set to disabled.";

        return isOn ? disabledMessage : enabledMessage;
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        throw new NotImplementedException();
    }
}
