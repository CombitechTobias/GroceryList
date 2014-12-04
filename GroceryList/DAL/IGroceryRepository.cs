using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryList.Models;

namespace GroceryList.DAL
{
    public interface IGroceryRepository
    {
        IEnumerable<Grocery> GetGroceries();
        Task<Grocery> GetGroceryById(int id);
        IEnumerable<Grocery> GetGroceriesByName(string name);
        void RemoveGrocery(Grocery grocery);
        void RemoveGrocery(int id);
        void AddGrocery(Grocery grocery);
    }
}
