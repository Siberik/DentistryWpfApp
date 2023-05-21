using DentistryWpfApp.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DentistryWpfApp.View.Pages
{
    public partial class ViewingPatientPage : Page
    {
        private int idget = 0;
        Core db = new Core();
        private bool appointmentsVisible = false;

        public ViewingPatientPage(int id)
        {
            idget = id;
            string name = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Name).FirstOrDefault();
            string surname = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Surname).FirstOrDefault();
            string lastname = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Lastname).FirstOrDefault();
            string phone = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Phone).FirstOrDefault();
            var date = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Date).FirstOrDefault();
            string adress = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Adress).FirstOrDefault();
            string prof = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Prof).FirstOrDefault();
            string gender = db.context.Clients.Where(x => x.Clients_Id == id).Select(x => x.Clients_Gender).FirstOrDefault();
            InitializeComponent();
            IdTextBlock.Text = $"Id клиента: {id}";
            LastNameTextBlock.Text = $"Фамилия: {lastname}";
            NameTextBlock.Text = $"Имя: {name}";
            SurnameTextBlock.Text = $"Отчество: {surname}";
            PhoneTextBlock.Text = $"Телефон: {phone}";
            ClientsDateTextBlock.Text = $"Дата рождения: {date}";
            AdressTextBlock.Text = $"Адрес: {adress}";
            ProfTextBlock.Text = $"Профессия: {prof}";
            GenderTextBlock.Text = $"Пол: {gender}";
        }

        private void RedactButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RedactingPatientPage(idget));
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Clients clientsDelete = db.context.Clients.FirstOrDefault(x => x.Clients_Id == idget);

            if (clientsDelete != null)
            {
                db.context.Clients.Remove(clientsDelete);

                var registrations = db.context.Registration.Where(r => r.Clients_Id_FK == idget).ToList();
                db.context.Registration.RemoveRange(registrations);

                if (db.context.SaveChanges() > 0)
                {
                    MessageBox.Show("Удаление сделано.");
                }
                else
                {
                    MessageBox.Show("Удаление сделано. Привязанных к клиенту приёмов не обнаружено.");
                }
            }
        }

        private void ViewAppointmentsButtonClick(object sender, RoutedEventArgs e)
        {
            if (appointmentsVisible)
            {
                // Если список уже видим, скрываем его
                AppointmentsPanel.Visibility = Visibility.Collapsed;
                appointmentsVisible = false;
            }
            else
            {
                // Очищаем панель с кнопками при каждом нажатии
                AppointmentsPanel.Children.Clear();

                // Получаем даты приёмов из базы данных для данного клиента
                var appointments = db.context.Registration
                    .Where(r => r.Clients_Id_FK == idget)
                    .Select(r => r.Registration_Date)
                    .ToList();

                // Создаем кнопку для каждой даты приёма и добавляем их на панель
                foreach (var appointmentDate in appointments)
                {
                    Button button = new Button
                    {
                        Content = appointmentDate.ToShortDateString(),
                        Style = FindResource("AppointmentButtonStyle") as Style
                    };
                    // Создаем экземпляр объекта Visits
                    Visits visits = new Visits
                    {
                        Visits_Date = appointmentDate,
                        Clients_Id_FK = idget
                    };
                    // Привязываем обработчик события клика на кнопку
                    button.Click += (s, args) =>
                    {
                        // Переходим на страницу ViewingVisitsPage и передаем объект Visits
                        NavigationService.Navigate(new ViewingVisitsPage(visits));
                    };
                    AppointmentsPanel.Children.Add(button);
                }

                // Показываем панель с кнопками
                AppointmentsPanel.Visibility = Visibility.Visible;
                appointmentsVisible = true;
            }
        }

    }
}
