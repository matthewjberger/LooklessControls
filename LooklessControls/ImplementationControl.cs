namespace LooklessControls
{
    using System.Windows;
    using System.Windows.Controls;

    public class ImplementationControl : Control
    {
        static ImplementationControl()
        {
            // This is necessary when subclassing a
            // FrameworkElement or FrameworkElement derived type
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(ImplementationControl),
                new FrameworkPropertyMetadata(typeof(ImplementationControl)));
        }
    }
}