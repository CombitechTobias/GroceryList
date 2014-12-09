using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryList.Models;

namespace GroceryList.DAL
{
    public interface IGroceryRepository : IDisposable
    {
        Task<IEnumerable<Grocery>> GetGroceriesAsync();
        Task<Grocery> GetGroceryByIdAsync(int id);
        Task<IEnumerable<Grocery>> GetGroceriesByNameAsync(string name);
        void RemoveGroceryAsync(Grocery grocery);
        void RemoveGroceryAsync(int id);
        void AddGroceryAsync(Grocery grocery);

        void AddGroceryToGroceryListAsync(Grocery grocery);
        void RemoveGroceryFromGroceryListAsync(Grocery grocery);
        Task<IEnumerable<Grocery>> GetGroceriesByGroceryListIdAsync();

        Task<IEnumerable<Recipe>> GetRecipiesAsync();
        void AddGroceriesByRecipeIdAsync(int id);
    }
}
