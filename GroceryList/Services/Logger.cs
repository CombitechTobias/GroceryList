using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace GroceryList.Services
{
    public class Logger : ILogger
    {
        public void LogEvent(string message)
        {
            Debug.WriteLine(message);
        }
    }
}