using DentistryWpfApp.Model;
using DentistryWpfApp.View.Pages.AdminPages;
using DentistryWpfApp.View.Pages.DentistryPages;
using DentistryWpfApp.View.Pages.ManagersPages;
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
    /// Логика взаимодействия для AutorizationPage.xaml
    /// </summary>
    public partial class AutorizationPage : Page
    {
        public AutorizationPage()
        {
            InitializeComponent();
        }

        
    Core db= new Core();
        private void AuthorizeButtonClick(object sender, RoutedEventArgs e)
        {
            string role = "";
            string name = "";
            string lastname = "";
            string surname = "";
            if (db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text && x.Personal_Password == UserPasswordBox.Password).FirstOrDefault() != null)
            {
               if (db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text && x.Personal_Password == UserPasswordBox.Password && x.Role_Id_FK==1).FirstOrDefault() != null)
            {
                    role=db.context.Role.Where(x=>x.Role_Id==1).Select(x=>x.Role_Name).FirstOrDefault(); 
                   name=db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text).Select(x=>x.Personal_Name).FirstOrDefault();
                    lastname = db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text).Select(x => x.Personal_LastName).FirstOrDefault();
                    surname = db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text).Select(x => x.Personal_Surname).FirstOrDefault();
                    this.NavigationService.Navigate(new MainDentistPage(name,lastname, role, surname));
            }
            if (db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text && x.Personal_Password == UserPasswordBox.Password && x.Role_Id_FK == 2).FirstOrDefault() != null)
            {
                this.NavigationService.Navigate(new MainAdminPage());
            }
            if (db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text && x.Personal_Password == UserPasswordBox.Password && x.Role_Id_FK == 3).FirstOrDefault() != null)
            {
                this.NavigationService.Navigate(new MainManagerPage());
            }
            }  
            else
            {
                MessageBox.Show("Введены неверные данные!");
            }
        }

       
        
    }
}
