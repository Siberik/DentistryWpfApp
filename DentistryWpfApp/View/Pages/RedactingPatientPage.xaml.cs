using DentistryWpfApp.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Логика взаимодействия для RedactingPatientPage.xaml
    /// </summary>
    public partial class RedactingPatientPage : Page
    {
        string gender;
        private int idget = 0;
        Core db = new Core();
        public RedactingPatientPage(int id)
        {
            idget=id;
            InitializeComponent();
            NameTextBox.Text = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Name).FirstOrDefault();
            LastNameTextBox.Text = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Lastname).FirstOrDefault();
            SurnameTextBox.Text = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Surname).FirstOrDefault();
            PhoneTextBox.Text = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Phone).FirstOrDefault();
            ClientDateTextBox.SelectedDate = (DateTime)db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Date).FirstOrDefault();
            AdressTextBox.Text = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Сlients_Adress).FirstOrDefault();
            ProfTextBox.Text = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Prof).FirstOrDefault();
            


            string phone = PhoneTextBox.Text;
            PhoneTextBox.Text =phone;
        }




        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            Clients s = new Clients()
            {
                Clients_Id = idget,
                Clients_Name = NameTextBox.Text,
                Clients_Surname = SurnameTextBox.Text,
                Clients_Lastname = LastNameTextBox.Text,
                Clients_Phone = PhoneTextBox.Text,
                Personal_Id_FK = db.context.Clients.Where(x => x.Clients_Id == idget).Select(x => x.Personal_Id_FK).FirstOrDefault(),
                Clients_Date = ClientDateTextBox.SelectedDate,
                Сlients_Adress = AdressTextBox.Text,
                Clients_Prof = ProfTextBox.Text,
                Clients_Gender = gender,
                
            };



            db.context.Clients.AddOrUpdate(s);
            if (db.context.SaveChanges()>0)
            {
                MessageBox.Show("Сохранено.");
                this.NavigationService.Navigate(new ViewingPatientPage(idget));
            }
            else
            {
                MessageBox.Show("Проверьте правильность введённых данных");
            }
            
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            string selectedGender = radioButton.Content.ToString();
            gender = selectedGender;

        }
    }
}
