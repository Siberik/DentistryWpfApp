using DentistryWpfApp.Model;
using DentistryWpfApp.View.Pages.DentistryPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;

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
            int roleId = 0;
            if (db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text && x.Personal_Password == UserPasswordBox.Password).FirstOrDefault() != null)
            {
             
                    role=db.context.Role.Where(x=>x.Role_Id==1).Select(x=>x.Role_Name).FirstOrDefault(); 
                   name=db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text).Select(x=>x.Personal_Name).FirstOrDefault();
                    lastname = db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text).Select(x => x.Personal_LastName).FirstOrDefault();
                    surname = db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text).Select(x => x.Personal_Surname).FirstOrDefault();
                    roleId = db.context.Personal.Where(x => x.Personal_Login == UserLoginTextBox.Text && x.Personal_Password == UserPasswordBox.Password).Select(x=>x.Role_Id_FK).FirstOrDefault();
                    this.NavigationService.Navigate(new MainDentistPage(name,lastname, role,roleId, surname));
            
            
            }  
            else
            {
                MessageBox.Show("Введены неверные данные!");
            }

           
        }

        

     
    }
}
