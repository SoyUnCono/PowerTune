﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml;
using System.Xml.Linq;
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

    protected override void OnApplyTemplate()
    {
        IsEnabledChanged -= SettingsGroup_IsEnabledChanged;
        _settingsGroup = (Groups)this;
        _descriptionPresenter = (ContentPresenter)_settingsGroup.GetTemplateChild(PartDescriptionPresenter);
        SetEnabledState();
        IsEnabledChanged += SettingsGroup_IsEnabledChanged;
        base.OnApplyTemplate();
    }

    private static void OnDescriptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((Groups)d).Update();
    }

    private void SettingsGroup_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        SetEnabledState();
    }

    private void SetEnabledState()
    {
        VisualStateManager.GoToState(this, IsEnabled ? "Normal" : "Disabled", true);
    }

    private void Update()
    {
        if (_settingsGroup == null)
        {
            return;
        }

        if (_settingsGroup.Description == null)
        {
            _settingsGroup._descriptionPresenter!.Visibility = Visibility.Collapsed;
        }
        else
        {
            _settingsGroup._descriptionPresenter!.Visibility = Visibility.Visible;
        }
    }

    protected override AutomationPeer OnCreateAutomationPeer()
    {
        return new SettingsGroupAutomationPeer(this);
    }
}
