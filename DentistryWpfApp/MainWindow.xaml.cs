using DentistryWpfApp.Model;
using DentistryWpfApp.Themes;
using DentistryWpfApp.View.Pages;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
        Core db = new Core();
        int idWin;
        string roleNameWin;
        int roleIdWin = 0;
        string nameWin;
        string lastnameWin;
        string surnameWin;

        ThemesCountClass themes = new ThemesCountClass();
        public MainWindow(int roleId, string role, string name, string lastname, string surname)
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
            roleNameWin = role;
            idWin = db.context.Personal.Where(x => x.Personal_Name == nameWin && x.Personal_LastName == lastnameWin).Select(x => x.Personal_Id).First();
            PagesNavigation.Navigate(new HomePage(idWin));
            PersonalNameLabel.Content = $"{lastname} {name}";
            var mail = db.context.Personal.Where(x => x.Personal_Id == idWin).Select(x => x.Personal_Mail).First();
            MailLabel.Content = mail;
            UpdateUserPhoto();
        }

        private void UpdateUserPhoto()
        {
            var photo = db.context.PhotoPersonal.FirstOrDefault(p => p.Personal_Id_FK == idWin)?.PhotoPersonal_Image;

            if (photo != null)
            {
                using (var stream = new MemoryStream(photo))
                {
                    var bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.StreamSource = stream;
                    bitmapImage.EndInit();
                    UserPhotoImage.ImageSource = bitmapImage;
                }
            }
            else
            {
                string defaultImagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\Assets\\Avatars\\", "default.jpeg");
                UserPhotoImage.ImageSource = new BitmapImage(new Uri(defaultImagePath));


            }
        }

        private void UploadUserPhoto(byte[] image)
        {
            var existingPhoto = db.context.PhotoPersonal.FirstOrDefault(p => p.Personal_Id_FK == idWin);

            if (existingPhoto != null)
            {
                existingPhoto.PhotoPersonal_Image = image;
            }
            else
            {
                var newPhoto = new PhotoPersonal
                {
                    Personal_Id_FK = idWin,
                    PhotoPersonal_Image = image
                };
                db.context.PhotoPersonal.Add(newPhoto);
            }

            db.context.SaveChanges();
            UpdateUserPhoto();
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
            PagesNavigation.Navigate(new HomePage(idWin));
        }

        private void rdNotes_Click(object sender, RoutedEventArgs e)
        {
            if (roleIdWin == 1)
            {
                PagesNavigation.Navigate(new NotesDentistPage(idWin));
            }
            else
            {
                PagesNavigation.Navigate(new NotesAdminPage());
            }
        }

        private void UserStackPanelMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            rdNotes.IsChecked = false;
            rdPatients.IsChecked = false;
            rdHome.IsChecked = false;
            PhotoPersonal photo=db.context.PhotoPersonal.FirstOrDefault(x=>x.Personal_Id_FK == idWin);
            PagesNavigation.Navigate(new UserPage(idWin,photo));
        }

        private void rdTheme_Click(object sender, RoutedEventArgs e)
        {
            ThemesCountClass.count++;
            if (ThemesCountClass.count % 2 != 0)
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
                rdTheme.IsChecked = false;
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
            PagesNavigation.Navigate(new PatientsPage());
        }

        private void btnMenu_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdHome_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdNotes_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void rdTheme_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
