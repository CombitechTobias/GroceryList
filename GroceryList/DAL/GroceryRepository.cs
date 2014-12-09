using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GroceryList.Models;
using WebGrease.Css.Extensions;

namespace GroceryList.DAL
{
    public class GroceryRepository : IGroceryRepository
    {
        private readonly GroceryListContext _context;

        public GroceryRepository(GroceryListContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grocery>> GetGroceriesAsync()
        {
            return  await _context.Groceries.ToListAsync();
        }

        public async Task<Grocery> GetGroceryByIdAsync(int id)
        {
            return await _context.Groceries.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Grocery>> GetGroceriesByNameAsync(string name)
        {
            return await Task.Run<IEnumerable<Grocery>>(() => _context.Groceries.Where(g => g.Name.StartsWith(name)).ToList());
        }

        public async void RemoveGroceryAsync(Grocery grocery)
        {
            if (grocery == null) throw new ArgumentException("grocery");

            _context.Groceries.Remove(grocery);
            await _context.SaveChangesAsync();
        }

        public async void RemoveGroceryAsync(int id)
        {
            var grocery = await _context.Groceries.FindAsync(id);
            _context.Groceries.Remove(grocery);
            await _context.SaveChangesAsync();
        }

        public async void AddGroceryAsync(Grocery grocery)
        {
            if (grocery == null) throw new ArgumentException("grocery");

            _context.Groceries.Add(grocery);
            await _context.SaveChangesAsync();
        }

        public void AddGroceryToGroceryListAsync(Grocery grocery)
        {
            if (grocery == null) throw new ArgumentException("grocery");

            _context.GroceryLists.First().Groceries.Add(grocery);
            _context.SaveChanges();
        }

        public void RemoveGroceryFromGroceryListAsync(Grocery grocery)
        {
            if (grocery == null) throw new ArgumentException("grocery");

            _context.GroceryLists.First().Groceries.Remove(grocery);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Grocery>> GetGroceriesByGroceryListIdAsync()
        {
            return await Task.Run<IEnumerable<Grocery>>(() => _context.GroceryLists.First().Groceries.ToList());
        }

        public async Task<IEnumerable<Recipe>> GetRecipiesAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async void AddGroceriesByRecipeIdAsync(int id)
        {
            var recipe = await _context.Recipes.FirstOrDefaultAsync(r => r.Id == id);
            if (recipe == null) return;

            recipe.Groceries.ForEach(async (g) =>
            {
                var groceryList = await _context.GroceryLists.FirstAsync();
                groceryList.Groceries.Add(g);
            });
        }

        #region IDisposable
        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}