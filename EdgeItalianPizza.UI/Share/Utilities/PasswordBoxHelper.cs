using System.Windows;
using System.Windows.Controls;

namespace EdgeItalianPizza.UI.Share.Utilities;

internal static class PasswordBoxHelper
{
    internal static readonly DependencyProperty BoundPassword = DependencyProperty.RegisterAttached(
        nameof(BoundPassword), typeof(string), typeof(PasswordBoxHelper), new PropertyMetadata(string.Empty, OnBoundPasswordChanged));

    internal static readonly DependencyProperty BindPassword = DependencyProperty.RegisterAttached(
        nameof(BindPassword), typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(false, OnBindPasswordChanged));

    internal static readonly DependencyProperty UpdatingPassword = DependencyProperty.RegisterAttached(
        nameof(UpdatingPassword), typeof(bool), typeof(PasswordBoxHelper), new PropertyMetadata(false));

    private static void OnBoundPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        PasswordBox box = d as PasswordBox;

        if (d == null || !GetBindPassword(d))
        {
            return;
        }

        box.PasswordChanged -= HandlePasswordChanged;

        string newPassword = (string)e.NewValue;

        if (!GetUpdatingPassword(box))
        {
            box.Password = newPassword;
        }

        box.PasswordChanged += HandlePasswordChanged;
    }

    private static void OnBindPasswordChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
    {
        var box = dp as PasswordBox;

        if (box == null)
        {
            return;
        }

        bool wasBound = (bool)(e.OldValue);
        bool needToBind = (bool)(e.NewValue);

        if (wasBound)
        {
            box.PasswordChanged -= HandlePasswordChanged;
        }

        if (needToBind)
        {
            box.PasswordChanged += HandlePasswordChanged;
        }
    }

    private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
    {
        PasswordBox box = sender as PasswordBox;

        SetUpdatingPassword(box, true);
        SetBoundPassword(box, box.Password);
        SetUpdatingPassword(box, false);
    }

    internal static void SetBindPassword(DependencyObject dp, bool value)
    {
        dp.SetValue(BindPassword, value);
    }

    internal static bool GetBindPassword(DependencyObject dp)
    {
        return (bool)dp.GetValue(BindPassword);
    }

    internal static string GetBoundPassword(DependencyObject dp)
    {
        return (string)dp.GetValue(BoundPassword);
    }

    internal static void SetBoundPassword(DependencyObject dp, string value)
    {
        dp.SetValue(BoundPassword, value);
    }

    private static bool GetUpdatingPassword(DependencyObject dp)
    {
        return (bool)dp.GetValue(UpdatingPassword);
    }

    private static void SetUpdatingPassword(DependencyObject dp, bool value)
    {
        dp.SetValue(UpdatingPassword, value);
    }
}
