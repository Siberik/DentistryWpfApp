using DentistryWpfApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для RegistrationDetailsPage.xaml
    /// </summary>
    public partial class RegistrationDetailsPage : Page
    {
        Core db = new Core();
        int regId = 0;
        public RegistrationDetailsPage(Registration registration)
        {
            regId = registration.Registration_Id;
           
            
           
             var date = registration.Registration_Date.ToString();
            string clientName = db.context.Clients.Where(x => x.Clients_Id == registration.Clients_Id_FK).Select(x=>x.Clients_Name).First().ToString();
            string clientLastName = db.context.Clients.Where(x => x.Clients_Id == registration.Clients_Id_FK).Select(x=>x.Clients_Lastname).First().ToString();
            string clientSurName = db.context.Clients.Where(x => x.Clients_Id == registration.Clients_Id_FK).Select(x=>x.Clients_Surname).First().ToString();
            
           

          
            InitializeComponent();
            DateTextBlock.Text=$"{date}";
            Line.Text = $"{clientLastName} {clientName} {clientSurName}";
            
        }

       

        private void ClientsNameTextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.NavigationService.Navigate(new ViewingPatientPage(regId));
        }
    }
}
