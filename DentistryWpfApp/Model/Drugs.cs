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
    
    public partial class Drugs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Drugs()
        {
            this.DrugsInfo = new HashSet<DrugsInfo>();
        }
    
        public int Drugs_Id { get; set; }
        public string Drugs_Name { get; set; }
        public string Drugs_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DrugsInfo> DrugsInfo { get; set; }
    }
}