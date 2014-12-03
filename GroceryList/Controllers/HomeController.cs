using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using GroceryList.Services;

namespace GroceryList.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFoodAdministrationService _foodAdministrationService;

        public HomeController(IFoodAdministrationService foodAdministrationService)
        {
            _foodAdministrationService = foodAdministrationService;
        }

        public async Task<ActionResult> GetGroceries(string filter)
        {
            var groceries = await _foodAdministrationService.GetFoodStuffs(filter);
            return Json(groceries.ToList(), JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetGrocery(int id)
        {
            var grocery = await _foodAdministrationService.GetFoodStuffById(id);
            return Json(grocery, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}