using System.Windows;
using System.Windows.Controls;

namespace DentistryWpfApp
{
    public partial class SnackBarControl : UserControl
    {
        public SnackBarControl()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(SnackBarControl), new PropertyMetadata(""));

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Visibility = Visibility.Collapsed;
        }
    }
}
