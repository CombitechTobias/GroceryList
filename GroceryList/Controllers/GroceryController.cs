using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GroceryList.DAL;
using GroceryList.Models;

namespace GroceryList.Controllers
{
    public class GroceryController : Controller
    {
        private readonly IGroceryRepository _groceryRepository;
        public GroceryController(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }

        public async Task<ActionResult> GetAvailableGroceriesAsync()
        {
            var groceries = await _groceryRepository.GetGroceriesAsync();
            return Json(
                groceries.Except(await _groceryRepository.GetGroceriesByGroceryListIdAsync()).Select(g => new {g.Id, g.Name}), 
                JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetGroceriesByGroceryListIdAsync()
        {
            var groceries = await _groceryRepository.GetGroceriesByGroceryListIdAsync();
            return Json(groceries.Select(g => new {g.Id, g.Name}), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> AddGroceryToGroceryListAsync(int id)
        {
            var grocery = await _groceryRepository.GetGroceryByIdAsync(id);
            if (grocery == null) return Json(JsonRequestBehavior.DenyGet);
            
            _groceryRepository.AddGroceryToGroceryListAsync(grocery);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> RemoveGroceryFromGroceryListAsync(int id)
        {
            var grocery = await _groceryRepository.GetGroceryByIdAsync(id);
            if (grocery == null) return Json(JsonRequestBehavior.DenyGet);
            
            _groceryRepository.RemoveGroceryFromGroceryListAsync(grocery);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetRecipiesAsync()
        {
            var recipies = await _groceryRepository.GetRecipiesAsync();
            return Json(
                recipies.Select(r => new {r.Id, r.Name}),
                JsonRequestBehavior.AllowGet);
        }
    }
}