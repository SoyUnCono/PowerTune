// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using PowerTune.Views.Controls.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace PowerTune.Views.Controls;
public sealed partial class CustomHeader : UserControl {
    /// <summary>
    /// HeaderImageProperty 
    /// </summary>
    public static readonly DependencyProperty HeaderImageProperty =
        DependencyProperty.Register(nameof(HeaderImage), typeof(string), typeof(CustomHeader), new PropertyMetadata(null));
    /// <summary>
    /// HeaderTitleProperty
    /// </summary>
    public static readonly DependencyProperty HeaderTitleProperty =
        DependencyProperty.Register(nameof(HeaderTitle), typeof(string), typeof(CustomHeader), new PropertyMetadata(null));
    /// <summary>
    /// HeaderRightContentProperty
    /// </summary>
    public static readonly DependencyProperty HeaderRightContentProperty =
        DependencyProperty.Register(nameof(HeaderRightContent), typeof(object), typeof(CustomHeader), new PropertyMetadata(DependencyProperty.UnsetValue));

    /// <summary>
    /// SubHeaderTitleProperty
    /// </summary>
    public static readonly DependencyProperty SubHeaderTitleProperty =
        DependencyProperty.Register(nameof(SubHeaderTitle), typeof(string), typeof(CustomHeader), new PropertyMetadata(DependencyProperty.UnsetValue));

    public static readonly DependencyProperty IsRightContentVisibleProperty =
    DependencyProperty.RegisterAttached(
        "IsRightContentVisible",
        typeof(bool),
        typeof(CustomHeader),
        new PropertyMetadata(true));
    public CustomHeader() {
        InitializeComponent();
        ViewModel = App.GetService<CustomHeaderViewModel>();
    }

    public static bool GetIsRightContentVisible(DependencyObject obj) {
        return (bool)obj.GetValue(IsRightContentVisibleProperty);
    }

    public static void SetIsRightContentVisible(DependencyObject obj, bool value) {
        obj.SetValue(IsRightContentVisibleProperty, value);
    }

    public string HeaderImage {
        get => (string)GetValue(HeaderImageProperty);
        set => SetValue(HeaderImageProperty, value);
    }

    public string HeaderTitle {
        get => (string)(GetValue(HeaderTitleProperty));
        set => SetValue(HeaderTitleProperty, value);
    }
    public string SubHeaderTitle {
        get => (string)(GetValue(SubHeaderTitleProperty));
        set => SetValue(SubHeaderTitleProperty, value);
    }

    public object HeaderRightContent {
        get => GetValue(HeaderRightContentProperty);
        set => SetValue(HeaderRightContentProperty, value);
    }

    public CustomHeaderViewModel ViewModel {
        get;
    }
}