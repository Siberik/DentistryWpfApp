using DentistryWpfApp.Model.Controllers;
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

namespace DentistryWpfApp.View.Pages.DentistryPages
{
    /// <summary>
    /// Логика взаимодействия для MainDentistPage.xaml
    /// </summary>
    public partial class MainDentistPage : Page
    {
        
        public MainDentistPage(string name,string lastname,string role,string surname=null)
        {
            InitializeComponent();
            NameTextBlock.Text = $"Пользователь: {lastname} {name} {surname}";
            RoleTextBlock.Text =$"Роль: {role}" ;
        }

       

        private void ClientsButtonClick(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
