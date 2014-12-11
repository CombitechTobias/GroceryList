using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GroceryList.DAL;
using GroceryList.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.SignalR;

namespace GroceryList.Hubs
{
    public class GroceriesHub : Hub
    {
        private readonly IGroceryRepository _groceryRepository;

        public GroceriesHub(IGroceryRepository groceryRepository)
        {
            _groceryRepository = groceryRepository;
        }

        public void BroadcastGroceries()
        {
            Clients.All.updateGroceries(_groceryRepository.GetGroceriesByGroceryListIdAsync().Result);
        }

        public  void Hello()
        {
            Clients.All.sayHello("hello from outer space!");
        }
    }
}