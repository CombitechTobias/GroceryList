using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryList.Models
{
    public class GroceryType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Grocery
    {
        public GroceryType GroceryType { get; set; }
        public int Amount { get; set; }
    }

    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Grocery> Groceries { get; set; } 
    }

    public class GroceryList
    {
        public int Id { get; set; }
        public ICollection<Grocery> Groceries { get; set; }
    }

    public class GroceryListHistory
    {
        public int Id { get; set; }

    }
}