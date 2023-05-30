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
    /// Логика взаимодействия для RedactingPersonalPage.xaml
    /// </summary>
    public partial class RedactingPersonalPage : Page
    {
        Personal personalGet;
        Core db= new Core();
        public RedactingPersonalPage(Personal personal)
        {
            personalGet = personal;
            InitializeComponent();
            NameTextBox.Text = personal.Personal_Name;
            LastNameTextBox.Text = personal.Personal_LastName;
            SurnameTextBox.Text =personal.Personal_Surname;
            MailTextBox.Text = personal.Personal_Mail;
        }

        private void SaveButtonClick(object sender, RoutedEventArgs e)
        {
            personalGet.Personal_Mail= MailTextBox.Text;
            personalGet.Personal_Name= NameTextBox.Text;
            personalGet.Personal_Surname= SurnameTextBox.Text;
            personalGet.Personal_LastName= LastNameTextBox.Text;
            db.context.Personal.AddOrUpdate(personalGet);
            if(db.context.SaveChanges()>0)
            {
                MessageBox.Show("Изменения сохранены");
            }
        }
    }
}
