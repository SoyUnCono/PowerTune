using System.ComponentModel;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using PowerTune.Views.Controls.Peers;

namespace PowerTune.Views.Controls.Models;

/// <summary>
/// Represents a control that can contain multiple settings (or other) controls
/// </summary>
[TemplateVisualState(Name = "Normal", GroupName = "CommonStates")]
[TemplateVisualState(Name = "Disabled", GroupName = "CommonStates")]
[TemplatePart(Name = PartDescriptionPresenter, Type = typeof(ContentPresenter))]
public partial class Groups : ItemsControl
{
    private const string PartDescriptionPresenter = "DescriptionPresenter";
    private ContentPresenter? _descriptionPresenter;
    private Groups? _settingsGroup;

    public Groups() => DefaultStyleKey = typeof(Groups);

    [Localizable(true)]
    public string Header
    {
        get => (string)GetValue(HeaderProperty);
        set => SetValue(HeaderProperty, value);
    }

    public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
        "Header",
        typeof(string),
        typeof(Groups),
        new PropertyMetadata(default(string)));

    [Localizable(true)]
    public object Description
    {
        get => (object)GetValue(DescriptionProperty);
        set => SetValue(DescriptionProperty, value);
    }

    public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register(
        "Description",
        typeof(object),
        typeof(Groups),
        new PropertyMetadata(null, OnDescriptionChanged));

    // Override the OnApplyTemplate method to handle the application of the control's template
    protected override void OnApplyTemplate()
    {
        // Unsubscribe from the IsEnabledChanged event to avoid duplicate event handlers
        IsEnabledChanged -= SettingsGroup_IsEnabledChanged;

        // Get references to the control's template parts
        _settingsGroup = (Groups)this;
        _descriptionPresenter = (ContentPresenter)_settingsGroup.GetTemplateChild(PartDescriptionPresenter);

        // Set the enabled state of the control
        SetEnabledState();

        // Subscribe to the IsEnabledChanged event to handle changes in the control's enabled state
        IsEnabledChanged += SettingsGroup_IsEnabledChanged;

        // Call the base implementation of OnApplyTemplate
        base.OnApplyTemplate();
    }

    // Event handler for the DescriptionProperty changed event
    private static void OnDescriptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => ((Groups)d).Update();

    // Event handler for the IsEnabledChanged event
    private void SettingsGroup_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e) => SetEnabledState();

    // Set the enabled state of the control based on the IsEnabled property
    private void SetEnabledState() => VisualStateManager.GoToState(this, IsEnabled ? "Normal" : "Disabled", true);

    // Update the control based on changes to the Description property
    private void Update()
    {
        // Check if the control and its template parts are available
        if (_settingsGroup == null)
            return;

        // Set the visibility of the description presenter based on the Description property
        if (_settingsGroup.Description == null)
            _settingsGroup._descriptionPresenter!.Visibility = Visibility.Collapsed;
        else
            _settingsGroup._descriptionPresenter!.Visibility = Visibility.Visible;
    }

    // Override the OnCreateAutomationPeer method to provide an automation peer for the control
    protected override AutomationPeer OnCreateAutomationPeer() =>  new SettingsGroupAutomationPeer(this);
}
