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
using System.Data.SqlClient;

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
                    string login=LoginTextBox.Text;
                    Console.WriteLine(login);
                    string password = MailClass.GetRandomPassword(16);
                    Console.WriteLine(password);
                    string email=db.context.Personal.Where(x => x.Personal_Login == LoginTextBox.Text).Select(x=>x.Personal_Mail).First();
                    Console.WriteLine(email);
                    if (MailClass.SendMail(email,login, password))
                    {
                        MessageBox.Show("Ваш пароль успешно выслан на почту");
                        this.NavigationService.Navigate(new AutoPage());
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели неверный логин");
                    }
                    
                }
                
            }
           else if (EmailTextBox.Text != String.Empty)
            {
                if (db.context.Personal.Where(x => x.Personal_Mail == EmailTextBox.Text).FirstOrDefault() != null)
                {
                    string login =db.context.Personal.Where(x => x.Personal_Mail == EmailTextBox.Text).Select(x=>x.Personal_Login).First();
                    Console.WriteLine(login);
                    string password = MailClass.GetRandomPassword(16);
                    Console.WriteLine(password);
                    string email = EmailTextBox.Text;
                    Console.WriteLine(email);
                    if (MailClass.SendMail(email,login, password))
                    {
                        Personal s = new Personal()
                        {
                            Personal_Id=db.context.Personal.Where(x => x.Personal_Mail == EmailTextBox.Text).Select(x=>x.Personal_Id).First(),
                            Personal_Password=password,
                            Personal_Login=login,   
                            Personal_Mail=email,

                        };
                        db.context.Personal.AddOrUpdate(s);
                        db.context.SaveChanges();
                        MessageBox.Show("Ваш пароль успешно выслан на почту");
                        this.NavigationService.Navigate(new AutoPage());
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели неверную почту");
                    }

                }
            }
            else
            {
                MessageBox.Show("Неверно введены данные");
            }
        }
       
    }
}
