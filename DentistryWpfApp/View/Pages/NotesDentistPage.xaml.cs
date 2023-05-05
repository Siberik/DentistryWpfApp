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

namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для NotesDentistPAge.xaml
    /// </summary>
    public partial class NotesDentistPage : Page
    {
        int personalID;
        readonly Core db = new Core();
        public NotesDentistPage(int personalId)
        {
            personalID = personalId;
            InitializeComponent();
           var clientsIdList = db.context.Clients.Where(x => x.Personal_Id_FK == personalId).Select(x => x.Clients_Id).ToList();
            var registrations = db.context.Registration
      .Where(r => clientsIdList.Contains((int)r.Clients_Id_FK))
      .ToList();
            registrations=registrations.OrderBy(r => r.Registration_Date) // добавляем сортировку по дате
        .ToList();
            foreach (var registration in registrations)
            {
                Button button = new Button
                {
                    Content = $"Клиент: {registration.Clients.Clients_Name}, Дата: {registration.Registration_Date}",
                    Tag = registration
                };
                button.Click += OnButtonClicked;
                VisitsStackPanel.Children.Add(button);
            }
        }
        private void OnButtonClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Registration registration = button.Tag as Registration;
                if (registration != null)
                {
                    RegistrationDetailsPage detailsPage = new RegistrationDetailsPage(registration);
                    NavigationService.Navigate(detailsPage);
                }
            }
        }

        private void OnFilterButtonClicked(object sender, RoutedEventArgs e)
        {
            string clientName = ClientNameTextBox.Text.Trim();
            DateTime? registrationDate = RegistrationDatePicker.SelectedDate;

            var clientsIdList = db.context.Clients
                .Where(x => x.Personal_Id_FK == personalID && (string.IsNullOrEmpty(clientName) || x.Clients_Name.Contains(clientName)))
                .Select(x => x.Clients_Id)
                .ToList();

            var registrations = db.context.Registration
                .Where(r => clientsIdList.Contains((int)r.Clients_Id_FK) &&
                            (!registrationDate.HasValue || r.Registration_Date == registrationDate.Value))
                .ToList();

            VisitsStackPanel.Children.Clear();
            foreach (var registration in registrations)
            {
                Button button = new Button
                {
                    Content = $"Клиент: {registration.Clients.Clients_Name}, Дата: {registration.Registration_Date}",
                    Tag = registration
                };
                button.Click += OnButtonClicked;
                VisitsStackPanel.Children.Add(button);
            }
        }

        

        private void CreateRegistrationButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CreateRegistratonPage());
        }
    }
}
