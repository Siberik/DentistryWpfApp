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
using DentistryClassLibrary;
using System.Data.Entity.Migrations;
using System.Configuration;

namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ResetPasswordPage.xaml
    /// </summary>
    public partial class ResetPasswordPage : Page
    {
        Core db = new Core();
        public ResetPasswordPage()
        {
            InitializeComponent();
            
        }
        
       

        private void SendEmailButton(object sender, RoutedEventArgs e)
        {

            if(LoginTextBox.Text!=String.Empty)
            {
                if (db.context.Personal.Where(x => x.Personal_Login == LoginTextBox.Text).FirstOrDefault() != null)
                {
                    string password = MailClass.GetRandomPassword(16);
                    string email=db.context.Personal.Where(x => x.Personal_Login == LoginTextBox.Text).Select(x=>x.Personal_Mail).First();
                    if (MailClass.SendMail(email, password))
                    {
                        MessageBox.Show("Ваш пароль успешно выслан на почту");
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели неверный логин");
                    }
                    
                }
            }
        }
    }
}
