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
    
    public partial class Order
    {
        public Order()
        {
            this.OrderItems = new HashSet<OrderItem>();
        }
    
        public long Id { get; set; }
        public long OrderTypeId { get; set; }
        public long OrderStatusId { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public long CreatedBy { get; set; }
        public System.DateTime UpdatedDateTime { get; set; }
        public long UpdatedBy { get; set; }
        public long TableMealId { get; set; }
    
        public virtual User User { get; set; }
        public virtual OrderStatu OrderStatu { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual User User1 { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual TableMeal TableMeal { get; set; }
    }
}
