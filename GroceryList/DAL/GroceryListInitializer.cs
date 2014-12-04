using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GroceryList.Models;

namespace GroceryList.DAL
{
    public class GroceryListInitializer : DropCreateDatabaseIfModelChanges<GroceryListContext>
    {
        protected override void Seed(GroceryListContext context)
        {
            var groceries = new List<Grocery>
            {
                new Grocery { Id=1, Name="Mjölk" },
                new Grocery { Id=2, Name="Mjöl" },
                new Grocery { Id=3, Name="Havregryn" },
                new Grocery { Id=4, Name="Kycklingfilé" },
                new Grocery { Id=5, Name="Nötfärs" },
                new Grocery { Id=6, Name="Blandfärs" },
                new Grocery { Id=7, Name="Pasta" },
                new Grocery { Id=8, Name="Ris" }
            };

            groceries.ForEach(g => context.Groceries.Add(g));
            context.SaveChanges();

            //var recipies = new List<Recipe>
            //{
            //    new Recipe { Id=1, Name="Kycklingtallrik", },
            //}
        }
    }
}