﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<MenuItemCategory> MenuItemCategories { get; set; }
        public virtual DbSet<MenuItemShift> MenuItemShifts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<OrderStatu> OrderStatus { get; set; }
        public virtual DbSet<OrderType> OrderTypes { get; set; }
        public virtual DbSet<OrderTypeTax> OrderTypeTaxes { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<ShiftType> ShiftTypes { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<TableMeal> TableMeals { get; set; }
        public virtual DbSet<TableMealStatu> TableMealStatus { get; set; }
        public virtual DbSet<Tax> Taxes { get; set; }
        public virtual DbSet<Terminal> Terminals { get; set; }
        public virtual DbSet<TestTable> TestTables { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }
    }
}
