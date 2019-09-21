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
    
    public partial class Inventory_Supplier_Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory_Supplier_Order()
        {
            this.Order_Line = new HashSet<Order_Line>();
            this.Received_Supplier_Order = new HashSet<Received_Supplier_Order>();
            this.Return_Line = new HashSet<Return_Line>();
            this.Return_Supplier_Order = new HashSet<Return_Supplier_Order>();
        }
    
        public int InvSuppOrder_ID { get; set; }
        public Nullable<int> InvSupplier_ID { get; set; }
        public Nullable<int> SuppOrder_Status_ID { get; set; }
        public Nullable<System.DateTime> Order_Date { get; set; }
    
        public virtual Inventory_Supplier Inventory_Supplier { get; set; }
        public virtual Order_Status Order_Status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Line> Order_Line { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Received_Supplier_Order> Received_Supplier_Order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Return_Line> Return_Line { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Return_Supplier_Order> Return_Supplier_Order { get; set; }
    }
}
