using DentistryClassLibrary;
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
    /// Логика взаимодействия для AddPersonal.xaml
    /// </summary>
    public partial class AddPersonalPage : Window
    {
        Core db = new Core();
        public AddPersonalPage()
        {
           

            InitializeComponent();

            RoleComboBox.ItemsSource = db.context.Role.ToList();

            RoleComboBox.DisplayMemberPath = "Role_Name";
        }

       

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            // Проверка на пустоту полей
            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(NameTextBox.Text) ||
                string.IsNullOrWhiteSpace(SurnameTextBox.Text) ||
                RoleComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }
          var password=  MailClass.GetRandomPassword(10);
            Personal personal = new Personal()
            {
                Personal_LastName = LastNameTextBox.Text,
                Personal_Mail = NameTextBox.Text,
                Personal_Login = MailTextBox.Text,
                Personal_Name = NameTextBox.Text,
                Personal_Password = password,
                Personal_Surname = SurnameTextBox.Text,
                Role_Id_FK = RoleComboBox.SelectedIndex + 1,
            };
            db.context.Personal.Add(personal);
            if (db.context.SaveChanges() > 0)
            {
                MessageBox.Show("Добавление сделано. Пароль успешно выслан на почту.");
                MailClass.SendMailNewUser(personal.Personal_Mail, personal.Personal_Login, password);
                Close();
            }
            else
            {
                MessageBox.Show("Что-то не так.");
            }
        }


        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState=WindowState.Minimized;
        }

        private void border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
