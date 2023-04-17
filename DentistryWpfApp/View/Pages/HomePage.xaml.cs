using DentistryWpfApp.Model;
using DentistryWpfApp.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        Core db= new Core();
        public HomePage(int id)
        {
            int roleId = db.context.Personal.Where(x => x.Personal_Id == id).Select(x => x.Role_Id_FK).First();
          
            
            string lastname=db.context.Personal.Where(x=>x.Personal_Id==id).Select(x=>x.Personal_LastName).First();
            string name=db.context.Personal.Where(x=>x.Personal_Id==id).Select(x=>x.Personal_Name).First();
            string surname=db.context.Personal.Where(x=>x.Personal_Id==id).Select(x=>x.Personal_Surname).First();
            string role=db.context.Role.Where(x=> x.Role_Id==roleId).Select(x=>x.Role_Name).First();

              string timeNow;
              
            
            
            if(DateTime.Now.Hour>=0&& DateTime.Now.Hour<4)
            {
                timeNow = "Доброй ночи";
            }
            else if(DateTime.Now.Hour >= 5 && DateTime.Now.Hour < 12)
            {
                timeNow = "Доброго утра";
            }
            else if(DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 18)
            {
                timeNow = "Доброго дня";
            }
            else
            {
                timeNow = "Доброго вечера";
            }
            InitializeComponent();

          
           
            
            NameTextBlock.Text = $"{timeNow}, {lastname} {name} {surname}!";
            RoleTextBlock.Text = $"Ваша должность: {role}";
            
        }
    }
}
