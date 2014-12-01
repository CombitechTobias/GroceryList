using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Services
{
    public interface ILogger
    {
        void LogEvent(string message);
    }
}
