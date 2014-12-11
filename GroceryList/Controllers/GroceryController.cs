using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GroceryList.DAL;
using GroceryList.Hubs;
using GroceryList.Models;
using Microsoft.AspNet.SignalR;

namespace GroceryList.Controllers
{
    public class GroceryController : Controller
    {
        private readonly IGroceryRepository _groceryRepository;
        public GroceryController(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }

        public async Task<ActionResult> GetAvailableGroceries()
        {
            var groceries = await _groceryRepository.GetGroceriesAsync();
            return Json(
                groceries.Except(await _groceryRepository.GetGroceriesByGroceryListIdAsync()).Select(g => new {g.Id, g.Name}), 
                JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetGroceriesByGroceryListId()
        {
            var groceries = await _groceryRepository.GetGroceriesByGroceryListIdAsync();
            return Json(groceries.Select(g => new {g.Id, g.Name}), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> AddGroceryToGroceryList(int id)
        {
            var grocery = await _groceryRepository.GetGroceryByIdAsync(id);
            if (grocery == null) return Json(JsonRequestBehavior.DenyGet);
            
            _groceryRepository.AddGroceryToGroceryListAsync(grocery);
            await Task.Run(() => NotifyClientsOnUpdateAsync());

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> RemoveGroceryFromGroceryList(int id)
        {
            var grocery = await _groceryRepository.GetGroceryByIdAsync(id);
            if (grocery == null) return Json(JsonRequestBehavior.DenyGet);
            
            _groceryRepository.RemoveGroceryFromGroceryListAsync(grocery);
            await Task.Run(() => NotifyClientsOnUpdateAsync());

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetRecipes()
        {
            var recipies = await _groceryRepository.GetRecipesAsync();
            return Json(
                recipies.Select(r => new {r.Id, r.Name}),
                JsonRequestBehavior.AllowGet);
        }

        private async void NotifyClientsOnUpdateAsync()
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<GroceriesHub>();

            var groceriesInGroceryList = await _groceryRepository.GetGroceriesByGroceryListIdAsync();
            await hubContext.Clients.All.updateGroceriesInGroceryList(groceriesInGroceryList.Select(g => new { g.Id, g.Name }));

            var allGroceries = await _groceryRepository.GetGroceriesAsync();
            var availableGroceries =
                allGroceries.Except(groceriesInGroceryList).Select(g => new {g.Id, g.Name});
            await hubContext.Clients.All.updateAvailableGroceries(availableGroceries.Select(g => new { g.Id, g.Name }));

        }
    }
}