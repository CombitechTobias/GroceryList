using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryList.Models
{
    public class Grocery
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    //public class Recipe
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }

    //    public virtual ICollection<Grocery> Groceries { get; set; } 
    //}

    //public class RecipieIngredient
    //{
    //    public int Id { get; set; }
    //    public int RecipieId { get; set; }
    //    public int GroceryId { get; set; }
    //}

    //public class GroceryList
    //{
    //    public int Id { get; set; }

    //    public virtual ICollection<Grocery> Groceries { get; set; }
    //}

    //public class GroceryHistory
    //{
    //    public int Id { get; set; }
    //}
}