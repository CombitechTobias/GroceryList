using System.Collections.Generic;

namespace GroceryList.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Grocery> Groceries { get; set; }
    }
}