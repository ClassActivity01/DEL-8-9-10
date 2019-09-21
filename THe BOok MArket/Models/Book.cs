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
    
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            this.Book_Condition = new HashSet<Book_Condition>();
            this.Book_Request_Line = new HashSet<Book_Request_Line>();
            this.Purchase_Line = new HashSet<Purchase_Line>();
        }
    
        public int Book_ID { get; set; }
        public string Book_Title { get; set; }
        public string Book_Author { get; set; }
        public string ISBN { get; set; }
        public Nullable<int> Book_Edition { get; set; }
        public Nullable<int> BookStatus_ID { get; set; }
    
        public virtual Book_Status Book_Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book_Condition> Book_Condition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book_Request_Line> Book_Request_Line { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Purchase_Line> Purchase_Line { get; set; }
    }
}
