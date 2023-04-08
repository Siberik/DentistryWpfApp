using DentistryWpfApp.Model;
using JetBrains.Annotations;
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
    /// Логика взаимодействия для PatientsPage.xaml
    /// </summary>
    public partial class PatientsPage : Page
    {
        public int id;
       Core db = new Core();
        public PatientsPage()
        {
            InitializeComponent();
            var patientsList= db.context.Clients;
            for (int i = 0; i < patientsList.Select(x=>x.Clients_Id).ToArray().Count(); i++)
            {
                
                var textblock = new TextBlock();
                textblock.Text = $" {patientsList.Where(x => x.Clients_Id == i).ToString()} {patientsList.Where(x => x.Clients_Id == i).Select(x => x.Clients_Name)} ";
                textblock.MouseDown += Label_MouseDown;
            }

        }
        private void Label_MouseDown(object sender, RoutedEventArgs e) 
        {
           
        }
    }
}
