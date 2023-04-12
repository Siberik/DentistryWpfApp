﻿using DentistryWpfApp.Model;
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
            for (int i = 0; i < patientIdList.Count; i++)
            {
            string Lastname= db.context.Clients.Where(x=>x.Clients_Id==i+1).Select(x => x.Clients_Lastname).FirstOrDefault();
            string Firstname = db.context.Clients.Where(x => x.Clients_Id == i + 1).Select(x => x.Clients_Name).FirstOrDefault();
                string count = (i + 1).ToString();
                Button button = new Button
                {
                   
                    
                    Content = $" №{i + 1}. {Lastname} {Firstname}",
                }; 

                Style style = this.FindResource("PatientsButton") as Style;
                button.Style = style;
                MainPatientsStackPanel.Children.Add(button);
                button.Margin= new Thickness(0, 10, 0, 0);
                button.Click += Button_Click;
                
            }
            
            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            var i = button.Content.ToString();
           int id= int.Parse(string.Join("", i.Where(c => char.IsDigit(c))));
            this.NavigationService.Navigate(new ViewingPatientPage(id));
        }

      

    }
}
