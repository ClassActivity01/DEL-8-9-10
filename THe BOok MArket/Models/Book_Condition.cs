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
    
    public partial class Book_Condition
    {
        public int Condition_ID { get; set; }
        public int Book_ID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> Price { get; set; }
    
        public virtual Book Book { get; set; }
        public virtual Condition Condition { get; set; }
    }
}