//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nedeljni_II_Bojana_Backo
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblClinicManager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblClinicManager()
        {
            this.tblClinicDoctors = new HashSet<tblClinicDoctor>();
        }
    
        public int ManagerID { get; set; }
        public int FloorNumber { get; set; }
        public int MaxNumberOfDoctors { get; set; }
        public int MinNumberOfRooms { get; set; }
        public int OmissionNumber { get; set; }
        public int UserID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblClinicDoctor> tblClinicDoctors { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}
