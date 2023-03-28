using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace DentistryWpfApp.View.Pages.DentistryPages
{
    /// <summary>
    /// Логика взаимодействия для MainDentistPage.xaml
    /// </summary>
    public partial class MainDentistPage : Page
    {
        
        public MainDentistPage(string name,string lastname,string role,int roleId,string surname=null)
        {
            InitializeComponent();
            NameTextBlock.Text = $"Пользователь: {lastname} {name} {surname}";
            RoleTextBlock.Text =$"Роль: {role}" ;
           if(roleId == 1)
            {
                RoleImage.Source = new BitmapImage(new Uri(@"/Assets/Images/icon.png", UriKind.Relative));
            }
            if (roleId == 2)
            {
                RoleImage.Source = new BitmapImage(new Uri(@"/Assets/Images/key-icon.png", UriKind.Relative));
            }

        }
    }

       

        
    }

