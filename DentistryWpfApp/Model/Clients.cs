//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DentistryWpfApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clients
    {
        public Clients()
        {
            this.AllergyInfo = new HashSet<AllergyInfo>();
            this.DentalFormula = new HashSet<DentalFormula>();
            this.DiagnosisHistory = new HashSet<DiagnosisHistory>();
            this.DrugsInfo = new HashSet<DrugsInfo>();
            this.PhotoPersonal = new HashSet<PhotoPersonal>();
            this.Registration = new HashSet<Registration>();
            this.ServicesHistory = new HashSet<ServicesHistory>();
            this.Studies = new HashSet<Studies>();
        }
    
        public int Clients_Id { get; set; }
        public string Clients_Name { get; set; }
        public string Clients_Surname { get; set; }
        public string Clients_Lastname { get; set; }
        public string Clients_Phone { get; set; }
        public Nullable<System.DateTime> Clients_Date { get; set; }
        public string Clients_Prof { get; set; }
        public string Clients_Adress { get; set; }
        public string Clients_Gender { get; set; }
        public int Personal_Id_FK { get; set; }
    
        public virtual ICollection<AllergyInfo> AllergyInfo { get; set; }
        public virtual Personal Personal { get; set; }
        public virtual ICollection<DentalFormula> DentalFormula { get; set; }
        public virtual ICollection<DiagnosisHistory> DiagnosisHistory { get; set; }
        public virtual ICollection<DrugsInfo> DrugsInfo { get; set; }
        public virtual ICollection<PhotoPersonal> PhotoPersonal { get; set; }
        public virtual ICollection<Registration> Registration { get; set; }
        public virtual ICollection<ServicesHistory> ServicesHistory { get; set; }
        public virtual ICollection<Studies> Studies { get; set; }
    }
}
