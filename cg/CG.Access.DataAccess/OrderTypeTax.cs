//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CG.Access.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderTypeTax
    {
        public long Id { get; set; }
        public long OrderTypeId { get; set; }
        public long TaxId { get; set; }
    
        public virtual OrderType OrderType { get; set; }
        public virtual Tax Tax { get; set; }
    }
}