//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DentistryWpfApp.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Registration
    {
        public int Registration_Id { get; set; }
        public System.DateTime Registration_Date { get; set; }
        public string Registration_Description { get; set; }
        public int Clients_Id_FK { get; set; }
        public int Visits_Id_FK { get; set; }
    
        public virtual Clients Clients { get; set; }
        public virtual Visits Visits { get; set; }
    }
}