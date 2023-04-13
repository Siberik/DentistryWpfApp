using DentistryWpfApp.Model;
using JetBrains.Annotations;
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
    /// Логика взаимодействия для ViewingPatientPage.xaml
    /// </summary>
    public partial class ViewingPatientPage : Page
    {
        private int idget = 0;
        Core db= new Core();
        public ViewingPatientPage(int id)
        {
            idget = id;
            string name= db.context.Clients.Where(x=>x.Clients_Id==id).Select(x=>x.Clients_Name).FirstOrDefault();
            string surname= db.context.Clients.Where(x=>x.Clients_Id==id).Select(x=>x.Clients_Surname).FirstOrDefault();
            string lastname= db.context.Clients.Where(x=>x.Clients_Id==id).Select(x=>x.Clients_Lastname).FirstOrDefault();
            InitializeComponent();
            IdTextBlock.Text = $"Id клиента: {id}";
            LastNameTextBlock.Text =$"Фамилия: {lastname}";
            NameTextBlock.Text =$"Имя : {name}";
            SurnameTextBlock.Text = $"Отчество: {surname}";

            
        }

       

        private void RedactButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RedactingPatientPage(idget));
        }
    }
}
