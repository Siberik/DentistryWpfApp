using System.Windows.Controls;


namespace DentistryWpfApp.View.Pages.DentistryPages
{
    /// <summary>
    /// Логика взаимодействия для MainDentistPage.xaml
    /// </summary>
    public partial class MainDentistPage : Page
    {
        
        public MainDentistPage(string name,string lastname,string role,string surname=null)
        {
            InitializeComponent();
            NameTextBlock.Text = $"Пользователь: {lastname} {name} {surname}";
            RoleTextBlock.Text =$"Роль: {role}" ;
           
           
        }
    }

       

        
    }

