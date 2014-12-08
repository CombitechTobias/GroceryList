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

        //public async Task<ActionResult> Index()
        //{
        //    return View(await _groceryRepository.GetGroceries());
        //}

        public async Task<ActionResult> GetAvailableGroceries()
        {
            var groceries = await _groceryRepository.GetGroceries();
            return Json(
                groceries.Except(await _groceryRepository.GetGroceriesByGroceryListId()).Select(g => new {g.Id, g.Name}), 
                JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetGroceriesByGroceryListId()
        {
            var groceries = await _groceryRepository.GetGroceriesByGroceryListId();
            return Json(groceries.Select(g => new {g.Id, g.Name}), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> AddGroceryToGroceryList(int id)
        {
            var grocery = await _groceryRepository.GetGroceryById(id);
            if (grocery == null) return Json(JsonRequestBehavior.DenyGet);
            
            _groceryRepository.AddGroceryToGroceryList(grocery);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> RemoveGroceryFromGroceryList(int id)
        {
            var grocery = await _groceryRepository.GetGroceryById(id);
            if (grocery == null) return Json(JsonRequestBehavior.DenyGet);
            
            _groceryRepository.RemoveGroceryFromGroceryList(grocery);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Grocery grocery)
        {
            _groceryRepository.AddGrocery(grocery);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            return View(await _groceryRepository.GetGroceryById(id));
        }

        [HttpPost]
        public ActionResult Edit(Grocery grocery)
        {
            //todo: Edit grocery
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
           throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Delete(Grocery grocery)
        {
            _groceryRepository.RemoveGrocery(grocery);
            return RedirectToAction("Index");
        }
    }
}