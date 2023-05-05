using DentistryClassLibrary;
using DentistryWpfApp.View.Windows;
using System;
using System.Collections.Generic;
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

namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateRegistratonPage.xaml
    /// </summary>
    public partial class CreateRegistratonPage : Page
    {
        public CreateRegistratonPage()
        {
            InitializeComponent();
        }



        private void CreateRegButtonClick(object sender, RoutedEventArgs e)
        {
            if (!InputClass.HourChecking(HourTextBox.Text))
            {
                MessageBox.Show("Неправильно введено время.");
            }
            
        }
    }
}
