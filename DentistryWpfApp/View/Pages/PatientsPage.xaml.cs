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
       
      

        public PatientsPage()
        {

            Core db = new Core();
            var patientIdList = db.context.Clients.Select(x => x.Clients_Id).ToList();
            InitializeComponent();
            
         
            for (int i = 0; i < patientIdList.Count(); i++)
            {
                TextBlock newTextBlock = new TextBlock
                {
                    Text = "Хорошего дня!"
                };
            }

        }

        
    }
}
