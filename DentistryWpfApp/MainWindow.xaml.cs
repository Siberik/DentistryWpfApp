using DentistryWpfApp.Themes;
using DentistryWpfApp.View.Pages;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace DentistryWpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string roleNameWin;
        int roleIdWin = 0;
        string nameWin;
        string lastnameWin;
        string surnameWin;

        ThemesCountClass themes = new ThemesCountClass();
        public MainWindow(int roleId,string role,string name,string lastname,string surname)
        {
            InitializeComponent();

            var uri = new Uri(@"Themes/LightTheme.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            roleIdWin = roleId;
            nameWin = name;
            lastnameWin = lastname;
            surnameWin = surname;
            roleNameWin= role;
            PagesNavigation.Navigate(new HomePage(nameWin, lastnameWin, roleNameWin, surnameWin));
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            // PagesNavigation.Navigate(new HomePage());

            PagesNavigation.Navigate(new HomePage(nameWin, lastnameWin,roleNameWin, surnameWin));
        }

      

        private void rdNotes_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/NotesPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdPayment_Click(object sender, RoutedEventArgs e)
        {
            PagesNavigation.Navigate(new System.Uri("Pages/PaymentPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void rdHome_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdTest_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnMenu_Checked(object sender, RoutedEventArgs e)
        {

        }

       

        private void UserStackPanelMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            
        {
            rdNotes.IsChecked = false;
            rdPatients.IsChecked = false;
            rdHome.IsChecked = false;
            PagesNavigation.Navigate(new UserPage());
        }

       
        private void rdTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemesCountClass.count++;
            if (ThemesCountClass.count%2!=0)

            {
                rdTheme.IsChecked = false;
                var uri = new Uri(@"Themes/DarkTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                PagesNavigation.NavigationService.Refresh();
                Console.WriteLine($"Тёмная тема: {ThemesCountClass.count}");
                rdTheme.SetResourceReference(RadioButton.TagProperty, "sun");



            }
            else
            {
                rdTheme.IsChecked=false;
                var uri = new Uri(@"Themes/LightTheme.xaml", UriKind.Relative);
                ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.Clear();
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                PagesNavigation.NavigationService.Refresh();
                Console.WriteLine($"Светлая тема: {ThemesCountClass.count}");
                rdTheme.SetResourceReference(RadioButton.TagProperty, "moon");

            }


        }

      
        private void rdPatientsClick(object sender, RoutedEventArgs e)
        {
            this.PagesNavigation.Navigate(new PatientsPage());
        }
    }
}
