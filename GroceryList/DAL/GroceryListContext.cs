using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using GroceryList.Models;

namespace GroceryList.DAL
{
    public class GroceryListContext : DbContext
    {
        public GroceryListContext() : base("GroceryListContext")
        {
        }

        public DbSet<Grocery> Groceries { get; set; }
        public DbSet<Models.GroceryList> GroceryLists { get; set; }
        public DbSet<Recipe> Recipes { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}