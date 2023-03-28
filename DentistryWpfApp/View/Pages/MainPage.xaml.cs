using DentistryWpfApp.Model;
using DentistryWpfApp.ViewModel;
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
using System.Xml.Linq;

namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage(string name, string lastname, string role,int roleId, string surname = null)
        {
            InitializeComponent();
            NameTextBlock.Text = $"Пользователь: {lastname} {name} {surname}";
            RoleTextBlock.Text = $"Роль: {role}";
            AppViewModel s = new AppViewModel();
            DataContext = s;
            if (roleId == 1)
            {
                RoleImge.Source = new BitmapImage(new Uri(@"Assets/Images/icon.png", UriKind.Relative));
            }
        }
    }
}
