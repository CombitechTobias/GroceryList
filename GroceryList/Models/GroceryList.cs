using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryList.Models
{
    public class GroceryList
    {
        public int Id { get; set; }

        public virtual ICollection<Grocery> Groceries { get; set; }
    }
}