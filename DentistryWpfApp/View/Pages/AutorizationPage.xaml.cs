using DentistryWpfApp.Model;
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
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

       
    Core db= new Core();
        private void AuthorizeButtonClick(object sender, RoutedEventArgs e)
        {
            if (db.context.Personal.Where(x => x.Personal_login == AuthorizationTextBox.Text && x.Personal_Password == AuthPasswordBox.Password).FirstOrDefault() != null)
            {
                this.NavigationService.Navigate(new TestPage());
            }
            else
            {
                MessageBox.Show("Введены неверные данные!");
            }
        }
    }
}
