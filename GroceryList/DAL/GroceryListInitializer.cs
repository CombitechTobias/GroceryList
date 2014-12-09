using System;
using System.Collections.Generic;
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
            var g1 = new Grocery {Id = 1, Name = "Mjölk"};
            var g2 = new Grocery {Id = 2, Name = "Mjöl"};
            var g3 = new Grocery {Id = 3, Name = "Havregryn"};
            var g4 = new Grocery {Id = 4, Name = "Kycklingfilé"};
            var g5 = new Grocery {Id = 5, Name = "Nötfärs"};
            var g6 = new Grocery {Id = 6, Name = "Blandfärs"};
            var g7 = new Grocery {Id = 7, Name = "Pasta"};
            var g8 = new Grocery {Id = 8, Name = "Ris"};
            var groceries = new List<Grocery> {g1, g2, g3, g4, g5, g6, g7, g8};

            groceries.ForEach(g => context.Groceries.Add(g));
            context.SaveChanges();

            var groceryList = new Models.GroceryList() {Id = 1};

            context.GroceryLists.Add(groceryList);
            context.SaveChanges();

            var recipies = new List<Recipe>
            {
                new Recipe {Id = 1, Name = "Spaghetti & köttfärssås", Groceries = new List<Grocery> {g5, g7}},
                new Recipe {Id = 2, Name = "Kycklingtallrik", Groceries = new List<Grocery> {g4, g8}}
            };

            recipies.ForEach(r => context.Recipes.Add(r));
            context.SaveChanges();
        }
    }
}