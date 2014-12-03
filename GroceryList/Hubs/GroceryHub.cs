using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace GroceryList.Hubs
{
    public class GroceryHub : Hub
    {
        public void Send(string grocery)
        {
            //todo: Spara ner den nya matvaran i databas(?)
            Clients.All.broadcastGrocery(grocery);
        }
    }
}