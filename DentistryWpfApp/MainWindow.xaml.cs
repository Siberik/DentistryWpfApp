using DentistryWpfApp.View.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DentistryWpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if(MainFrame.CanGoBack) {
                UIGridRow.Height = new GridLength(50, GridUnitType.Pixel); 
            }
            MainFrame.Navigate(new AutorizationPage());
        }
        [ValueConversion(typeof(bool), typeof(GridLength))]
        public class BoolToGridRowHeightConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return ((bool)value == true) ? new GridLength(1, GridUnitType.Star) : new GridLength(0);
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {    // Don't need any convert back
                return null;
            }
        }
    }
}
