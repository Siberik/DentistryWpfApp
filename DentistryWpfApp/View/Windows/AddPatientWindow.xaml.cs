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
using System.Windows.Shapes;

namespace DentistryWpfApp.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddPatientWindow.xaml
    /// </summary>
    public partial class AddPatientWindow : Window
    {
        Core db = new Core();
        public AddPatientWindow()
        {
            InitializeComponent();
            DentistComboBox.ItemsSource = db.context.Personal.ToList();

            DentistComboBox.DisplayMemberPath = "Personal_LastName";


        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            int textComboBox = DentistComboBox.SelectedIndex+1;
            Console.WriteLine(textComboBox);
            var dentistId=db.context.Personal.Where(x=>x.Personal_Id==textComboBox).Select(x=>x.Personal_Id).FirstOrDefault();
            Clients newClient = new Clients()
            {
                
                Clients_Name=NameTextBox.Text,
                Clients_Lastname=LastNameTextBox.Text,
                Clients_Phone=PhoneTextBox.Text,
                Clients_Surname=SurnameTextBox.Text,
                Personal_Id_FK=dentistId,
            };
            db.context.Clients.Add(newClient);
            
            if(db.context.SaveChanges() >0) {
                MessageBox.Show("Новый клиент создан.");
                Close();
            }
            else
            {
                MessageBox.Show("Не вышло создать клиента.");
                
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }

}
