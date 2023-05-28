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
    /// Логика взаимодействия для ViewingVisitsPage.xaml
    /// </summary>
    public partial class ViewingVisitsPage : Page
    {
        Core db = new Core();
        Visits currentVisit;
        public ViewingVisitsPage(Visits visits)
        {
            currentVisit = visits;

            currentVisit=db.context.Visits.FirstOrDefault(x=>x.Visits_Date==visits.Visits_Date&&x.Clients_Id_FK==visits.Clients_Id_FK);

            InitializeComponent();
            VisitsComplaintsTextBlock.Text =$"Жалобы пациента: {currentVisit.Visits_Complaints}" ;
            VisitsDateTextBlock.Text= $"Дата приёма: {currentVisit.Visits_Date.ToString()}";
            VisitsDiagnosisTextBlock.Text= $"Поставленный диагноз: {currentVisit.Visits_Diagnosis}";
            VisitsIdTextBlock.Text= $"Идентификатор приёма: {currentVisit.Visits_Id.ToString()}";
            VisitsMucousMembraneTextBlock.Text = $"Состояние полости рта: {currentVisit.Visits_MucousMembrane}";
            VisitsRealDiseaseTextBlock.Text = $"Настоящее заболевание: {currentVisit.Visits_RealDisease}";
            VisitsRentgenTextBlock.Text = $"Данные рентгеновского исследования: {currentVisit.Visits_Rentgen}";
            VisitsTransferredDiseasesTextBlock.Text = $"Перенесённые и сопутствующие заболевания: {currentVisit.Visits_TransferredDiseases}" ;
            VisitsSovetTextBlock.Text = $"Наставления: {currentVisit.Visits_Sovet}";
            VisitsResultTextBlock.Text = $"Эпикриз: {currentVisit.Visits_Result}";
            ClientsIdFKTextBlock.Text = $"Идентификатор клиента: {currentVisit.Clients_Id_FK.ToString()}";

        }
    }
}
