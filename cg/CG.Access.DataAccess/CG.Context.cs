﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CGEntities : DbContext
    {
        public CGEntities()
            : base("name=CGEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuItemCategory> MenuItemCategories { get; set; }
        public DbSet<MenuItemShift> MenuItemShifts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatus> OrderStatus { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        public DbSet<OrderTypeTax> OrderTypeTaxes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<ShiftType> ShiftTypes { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<TableMeal> TableMeals { get; set; }
        public DbSet<TableMealOrder> TableMealOrders { get; set; }
        public DbSet<TableStatus> TableStatus1 { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}
