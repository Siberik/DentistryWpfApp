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
            if(db.context.Clients.Select(x => x.Clients_Id).ToArray().Length>0){
            int count = db.context.Clients.Select(x => x.Clients_Id).Min();
            Console.WriteLine($"Начальное значение:{count}");

            while (count < db.context.Clients.Select(x => x.Clients_Id).Max())
            {
                
               
                Console.WriteLine($"Промежуточное значение:{count}");
                string lastname=db.context.Clients.Where(x=>x.Clients_Id==count).Select(x=>x.Clients_Lastname).FirstOrDefault();
                string name=db.context.Clients.Where(x=>x.Clients_Id==count).Select(x=>x.Clients_Name).FirstOrDefault();
                if (lastname!=null)
                {
                    Button button = new Button
                    {

                        Name = $"Button",
                        Content = $" №{count + 1}. {lastname} {name}",
                    };
                    button.Name += count;
                    Style style = this.FindResource("PatientsButton") as Style;
                    button.Style = style;
                    MainPatientsStackPanel.Children.Add(button);
                    button.Margin = new Thickness(0, 10, 0, 0);
                    button.Click += Button_Click;
                }
                count++;
            }
            }
          






        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var i = button.Name.ToString();
           int id= int.Parse(string.Join("", i.Where(c => char.IsDigit(c))));
            this.NavigationService.Navigate(new ViewingPatientPage(id));
        }

      

        private void AddButtonClick(object sender, RoutedEventArgs e)
        {
            AddPatientWindow win2 = new AddPatientWindow();
            win2.Show();
        }
    }
}
