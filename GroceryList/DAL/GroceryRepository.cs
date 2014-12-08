using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using GroceryList.Models;

namespace GroceryList.DAL
{
    public class GroceryRepository : IGroceryRepository
    {
        private readonly GroceryListContext _context;

        public GroceryRepository(GroceryListContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Grocery>> GetGroceries()
        {
            return  await _context.Groceries.ToListAsync();
        }

        public async Task<Grocery> GetGroceryById(int id)
        {
            return await _context.Groceries.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Grocery>> GetGroceriesByName(string name)
        {
            return await Task.Run<IEnumerable<Grocery>>(() => _context.Groceries.Where(g => g.Name.StartsWith(name)).ToList());
        }

        public void RemoveGrocery(Grocery grocery)
        {
            if (grocery == null) throw new ArgumentException("grocery");

            _context.Groceries.Remove(grocery);
            _context.SaveChanges();
        }

        public void RemoveGrocery(int id)
        {
            var grocery = _context.Groceries.Find(id);
            _context.Groceries.Remove(grocery);
            _context.SaveChanges();
        }

        public void AddGrocery(Grocery grocery)
        {
            if (grocery == null) throw new ArgumentException("grocery");

            _context.Groceries.Add(grocery);
            _context.SaveChanges();
        }

        public void AddGroceryToGroceryList(Grocery grocery)
        {
            if (grocery == null) throw new ArgumentException("grocery");

            _context.GroceryLists.First().Groceries.Add(grocery);
            _context.SaveChanges();
        }

        public void RemoveGroceryFromGroceryList(Grocery grocery)
        {
            if (grocery == null) throw new ArgumentException("grocery");

            _context.GroceryLists.First().Groceries.Remove(grocery);
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Grocery>> GetGroceriesByGroceryListId()
        {
            return await Task.Run<IEnumerable<Grocery>>(() => _context.GroceryLists.First().Groceries.ToList());
        }

        #region IDisposable
        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}