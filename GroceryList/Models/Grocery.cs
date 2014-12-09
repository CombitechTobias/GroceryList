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

        public virtual ICollection<GroceryList> GroceryLists { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; } 
    }
}