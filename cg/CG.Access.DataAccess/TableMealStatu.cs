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
    
    public partial class TableMealStatu
    {
        public TableMealStatu()
        {
            this.TableMeals = new HashSet<TableMeal>();
        }
    
        public long Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<TableMeal> TableMeals { get; set; }
    }
}
