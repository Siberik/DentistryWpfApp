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
    
    public partial class Allergy
    {
        public Allergy()
        {
            this.AllergyInfo = new HashSet<AllergyInfo>();
        }
    
        public int Allergy_Id { get; set; }
        public string Allergy_Name { get; set; }
        public string Allergy_Description { get; set; }
    
        public virtual ICollection<AllergyInfo> AllergyInfo { get; set; }
    }
}
