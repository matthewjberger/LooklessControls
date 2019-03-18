namespace LooklessControls
{
    using System.Windows;
    using System.Windows.Controls;

    // Template parts are specified in attributes here
    [TemplatePart(Name = PART_CustomContentPresenter, Type = typeof(ContentPresenter))]
    [TemplatePart(Name = PART_Title, Type = typeof(string))]
    public class LooklessControl : Control
    {
        public const string PART_CustomContentPresenter = "PART_CustomContentPresenter";
        public const string PART_Title = "PART_Title";

        static LooklessControl()
        {
            // This is necessary when subclassing a
            // FrameworkElement or FrameworkElement derived type
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(LooklessControl),
                new FrameworkPropertyMetadata(typeof(LooklessControl)));
        }

        public override void OnApplyTemplate()
        {
            // This must always be called first
            base.OnApplyTemplate();

            // Getting the template parts can be done like this
            var contentPresenter = GetTemplateChild(PART_CustomContentPresenter) as ContentPresenter;

            // Which can be used to modify template parts when the template is applied
            // such as for setting the entire control's datacontext
            // to the same datacontext used by the custom content
            DataContext = contentPresenter?.DataContext;
        }

        // Any customizable pieces of the control
        // need to be specified here as dependencies properties.
        //
        // In Visual Studio 2017+, typing 'propdp' and pressing TAB will
        // autocomplete a snippet for creating a dependency property.

        public object CustomContent
        {
            get => GetValue(CustomContentProperty);
            set => SetValue(CustomContentProperty, value);
        }

        public static readonly DependencyProperty CustomContentProperty =
            DependencyProperty.Register("CustomContent", typeof(object), typeof(LooklessControl));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(LooklessControl), new PropertyMetadata("Default Text"));
    }
}