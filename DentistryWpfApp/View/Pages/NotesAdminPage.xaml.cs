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

namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для NotesAdminPage.xaml
    /// </summary>
    public partial class NotesAdminPage : Page
    {
        Core db = new Core();

        public NotesAdminPage()
        {
            InitializeComponent();
            LoadButtons();
        }

        private void LoadButtons()
        {
            List<Personal> personals = db.context.Personal.Where(x => x.Role_Id_FK == 1).ToList();
            foreach (var personal in personals)
            {
                Button button = new Button
                {
                    Content = personal.Personal_LastName,
                    Tag = personal.Personal_Id
                };
                button.Click += OnButtonClicked;
                ButtonsStackPanel.Children.Add(button);
            }
        }

        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                int personalId = (int)button.Tag;
                this.NavigationService.Navigate(new NotesDentistPage(personalId));
            }
        }
    }
}
