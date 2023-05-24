using Microsoft.UI.Xaml.Automation.Peers;
using PowerTune.Views.Controls.Models;

namespace PowerTune.Views.Controls.Peers;

public class SettingsGroupAutomationPeer : FrameworkElementAutomationPeer
{
    public SettingsGroupAutomationPeer(Groups owner)
        : base(owner)
    {
    }

    protected override string GetNameCore()
    {
        var selectedSettingsGroup = (Groups)Owner;
        return selectedSettingsGroup.Header;
    }
}
