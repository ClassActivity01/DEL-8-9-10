//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace THe_BOok_MArket.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Employees = new HashSet<Employee>();
        }
    
        public int User_ID { get; set; }
        public Nullable<int> UserRole_ID { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public Nullable<System.Guid> GUID { get; set; }
        public Nullable<bool> IsUserVerified { get; set; }
        public string ResetCode { get; set; }
        public string PassConfirm { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual User_Role User_Role { get; set; }
    }
}
