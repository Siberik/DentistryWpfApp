using DentistryWpfApp.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using DentistryWpfApp.View.Windows;

namespace DentistryWpfApp.View.Pages
{
    public partial class PatientsPage : Page
    {
        private readonly Core db;
        private int itemsPerPage = 10;

        public PatientsPage()
        {
            db = new Core();
            InitializeComponent();
            LoadPage(1);
            AddPageButtons();
        }

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            AddPatientWindow win2 = new AddPatientWindow();
            win2.Show();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchQuery = SearchTextBox.Text.Trim();
            LoadPage(1, searchQuery);
            ClearPagination();
            AddPageButtons(searchQuery);
        }

        private void LoadPage(int pageNumber, string searchQuery = "")
        {
            int firstItemIndex = (pageNumber - 1) * itemsPerPage;
            IQueryable<Clients> clientsQuery = db.context.Clients.OrderBy(x => x.Clients_Lastname);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                clientsQuery = clientsQuery.Where(client =>
                    client.Clients_Lastname.Contains(searchQuery) ||
                    client.Clients_Name.Contains(searchQuery) ||
                    client.Clients_Phone.Contains(searchQuery));
            }

            var clients = clientsQuery.Skip(firstItemIndex).Take(itemsPerPage).ToList();

            MainPatientsStackPanel.Children.Clear();

            foreach (var client in clients)
            {
                Button button = new Button
                {
                    Name = $"Button{client.Clients_Id}",
                    Content = $" №{client.Clients_Id}. {client.Clients_Lastname} {client.Clients_Name}",
                    Style = FindResource("PatientsButton") as Style,
                    Margin = new Thickness(0, 10, 0, 0)
                };

                button.Click += Button_Click;
                MainPatientsStackPanel.Children.Add(button);
            }
        }

        private void AddPageButtons(string searchQuery = "")
        {
            int totalItems = string.IsNullOrEmpty(searchQuery) ? db.context.Clients.Count() : GetMatchingClientsCount(searchQuery);
            int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage);

            for (int i = 1; i <= totalPages; i++)
            {
                Button pageButton = new Button
                {
                    Content = i.ToString(),
                    Tag = i,
                    Margin = new Thickness(0, 0, 10, 0)
                };

                pageButton.Click += PageButton_Click;
                paginationStackPanel.Children.Add(pageButton);
            }
        }

        private int GetMatchingClientsCount(string searchQuery)
        {
            return db.context.Clients
                .Count(client =>
                    client.Clients_Lastname.Contains(searchQuery) ||
                    client.Clients_Name.Contains(searchQuery) ||
                    client.Clients_Phone.Contains(searchQuery));
        }

        private void ClearPagination()
        {
            paginationStackPanel.Children.Clear();
        }

        private void PageButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int pageNumber = (int)button.Tag;
            LoadPage(pageNumber, SearchTextBox.Text.Trim());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int id = int.Parse(button.Name.Substring(6));
            NavigationService.Navigate(new ViewingPatientPage(id));
        }
    }
}
