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
    
    public partial class AllergyInfo
    {
        public int AllergyInfo_Id { get; set; }
        public int Allergy_Id_FK { get; set; }
        public int Clients_Id_FK { get; set; }
    
        public virtual Allergy Allergy { get; set; }
        public virtual Clients Clients { get; set; }
    }
}
