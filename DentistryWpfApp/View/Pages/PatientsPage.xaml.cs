using DentistryWpfApp.Model;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using DentistryWpfApp.View.Windows;

namespace DentistryWpfApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {



        public PatientsPage()
        {
            Core db = new Core();
            InitializeComponent();

            int itemsPerPage = 10; // количество записей на одной странице
            int totalItems = db.context.Clients.Count(); // общее количество записей
            int totalPages = (int)Math.Ceiling((double)totalItems / itemsPerPage); // общее количество страниц

            for (int i = 1; i <= totalPages; i++)
            {
                Button pageButton = new Button();
                pageButton.Content = i.ToString();
                pageButton.Tag = i; // сохраняем номер страницы в Tag кнопки
                pageButton.Click += PageButton_Click; // подписываемся на событие Click
                pageButton.Margin = new Thickness(0, 0, 10, 0);
                paginationStackPanel.Children.Add(pageButton); // добавляем кнопку на панель
            }

            LoadPage(1); // загружаем записи для первой страницы

            void PageButton_Click(object sender, RoutedEventArgs e)
            {
                Button button = (Button)sender;
                int pageNumber = (int)button.Tag;
                LoadPage(pageNumber); // загружаем записи для выбранной страницы
            }

            void LoadPage(int pageNumber)
            {
                // определяем номер первой записи на странице
                int firstItemIndex = (pageNumber - 1) * itemsPerPage;

                // загружаем записи для текущей страницы
                var clients = db.context.Clients
                    .OrderBy(x => x.Clients_Lastname)
                    .Skip(firstItemIndex)
                    .Take(itemsPerPage)
                    .ToList();

                // очищаем контейнер со списком пациентов
                MainPatientsStackPanel.Children.Clear();

                // отображаем записи на странице
                foreach (var client in clients)
                {
                    Button button = new Button
                    {
                        Name = $"Button{client.Clients_Id}",
                        Content = $" №{client.Clients_Id}. {client.Clients_Lastname} {client.Clients_Name}",
                        Style = this.FindResource("PatientsButton") as Style
                    };
                    button.Margin = new Thickness(0, 10, 0, 0);
                    button.Click += Button_Click;
                   
                    MainPatientsStackPanel.Children.Add(button);
                }
            }

            void Button_Click(object sender, RoutedEventArgs e)
            {
                Button button = sender as Button;
                
                int id = int.Parse(button.Name.Substring(6));
                this.NavigationService.Navigate(new ViewingPatientPage(id));
            }
        }


       

      

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            AddPatientWindow win2 = new AddPatientWindow();
            win2.Show();
        }
    }
}
