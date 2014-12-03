using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryList.Services
{
    public interface IFoodAdministrationService
    {
        Task<IEnumerable<FoodStuff>> GetFoodStuffs(string filter);
        Task<FoodStuff> GetFoodStuffById(int id);
    }
}
