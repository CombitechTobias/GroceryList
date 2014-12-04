using System;
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

        public  IEnumerable<Grocery> GetGroceries()
        {
            return  _context.Groceries;
        }

        public async Task<Grocery> GetGroceryById(int id)
        {
            return await _context.Groceries.FirstOrDefaultAsync(g => g.Id == id);
        }

        public IEnumerable<Grocery> GetGroceriesByName(string name)
        {
            return _context.Groceries.Where(g => g.Name.StartsWith(name));
        }

        public void RemoveGrocery(Grocery grocery)
        {
            _context.Groceries.Remove(grocery);
        }

        public void RemoveGrocery(int id)
        {
            var grocery = _context.Groceries.Find(id);
            _context.Groceries.Remove(grocery);
        }

        public void AddGrocery(Grocery grocery)
        {
            throw new NotImplementedException();
        }
    }
}