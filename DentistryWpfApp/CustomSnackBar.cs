using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DentistryWpfApp.View.Controls
{
    public class CustomSnackBar : Control
    {
        static CustomSnackBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomSnackBar), new FrameworkPropertyMetadata(typeof(CustomSnackBar)));
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(CustomSnackBar), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty TextColorProperty =
            DependencyProperty.Register("TextColor", typeof(Brush), typeof(CustomSnackBar), new PropertyMetadata(Brushes.Black));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public Brush TextColor
        {
            get { return (Brush)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }
    }
}
