using DentistryWpfApp.Model;
using DentistryWpfApp.View.Windows;
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
    /// Логика взаимодействия для PersonalPage.xaml
    /// </summary>
    public partial class PersonalPage : Page
    {
        private readonly Core db;
        private int itemsPerPage = 10;

        public PersonalPage()
        {
            InitializeComponent();
            db = new Core(); // Создание экземпляра класса Core (возможно, вы уже это сделали где-то ранее)
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
            IQueryable<Personal> personalQuery = db.context.Personal.OrderBy(x => x.Personal_LastName);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                personalQuery = personalQuery.Where(personal =>
                    personal.Personal_LastName.Contains(searchQuery) ||
                    personal.Personal_Name.Contains(searchQuery) || // Исправлена ошибка в условии
                    personal.Personal_Mail.Contains(searchQuery)); // Исправлена ошибка в условии
            }

            var personals = personalQuery.Skip(firstItemIndex).Take(itemsPerPage).ToList(); // Исправлена ошибка в запросе

            MainPersonalStackPanel.Children.Clear();

            foreach (var personal in personals) // Исправлена ошибка в имени переменной
            {
                Button button = new Button
                {
                    Name = $"Button{personal.Personal_Id}",
                    Content = $"№{personal.Personal_Id}. {personal.Personal_LastName} {personal.Personal_Name}",
                    Style = FindResource("PatientsButton") as Style,
                    Margin = new Thickness(0, 10, 0, 0)
                };

                button.Click += Button_Click;
                MainPersonalStackPanel.Children.Add(button);
            }
        }

        private void AddPageButtons(string searchQuery = "")
        {
            int totalItems = string.IsNullOrEmpty(searchQuery) ? db.context.Personal.Count() : GetMatchingPersonalsCount(searchQuery); // Исправлена ошибка в получении общего количества элементов
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

        private int GetMatchingPersonalsCount(string searchQuery)
        {
            return db.context.Personal
                .Count(personal =>
                    personal.Personal_LastName.Contains(searchQuery) ||
                    personal.Personal_Name.Contains(searchQuery) ||
                    personal.Personal_Mail.Contains(searchQuery));
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
            Personal personal=db.context.Personal.FirstOrDefault(x=>x.Personal_Id==id);
            NavigationService.Navigate(new ViewingPersonalPage(personal));
        }
    }
}
