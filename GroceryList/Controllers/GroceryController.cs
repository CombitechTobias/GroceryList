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

        public ActionResult Index()
        {
            return View(_groceryRepository.GetGroceries().ToList());
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