//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CG.Access.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Terminal
    {
        public Terminal()
        {
            this.Transactions = new HashSet<Transaction>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
        public long RestaurantId { get; set; }
    
        public virtual Restaurant Restaurant { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
