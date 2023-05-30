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
using System.Xml.Linq;

namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для ViewingPersonalPage.xaml
    /// </summary>
    public partial class ViewingPersonalPage : Page
    {
        Personal personalGet;
        Core db = new Core();
        public ViewingPersonalPage(Personal personal)
        {
            personalGet = personal;
            InitializeComponent();
            IdTextBlock.Text = $"Id работника: {personal.Personal_Id}";
            LastNameTextBlock.Text = $"Фамилия: {personal.Personal_LastName}";
            NameTextBlock.Text = $"Имя: {personal.Personal_Name}";
            SurnameTextBlock.Text = $"Отчество: {personal.Personal_Surname}";
            MailTextBlock.Text = $"Почта: {personal.Personal_Mail}";
          
        }
        private void RedactButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RedactingPersonalPage(personalGet));
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
           
                var personalToRemove = db.context.Personal.Find(personalGet.Personal_Id);
                if (personalToRemove != null)
                {
                    db.context.Personal.Remove(personalToRemove);
                    db.context.SaveChanges();
                    MessageBox.Show("Удаление завершено");
               }
            
        }

    }
}
