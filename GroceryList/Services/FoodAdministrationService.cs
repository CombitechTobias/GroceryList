using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace GroceryList.Services
{

    public class FoodStuff
    {
        public int Number { get; set; }
        public string Name { get; set; }
    }

    public class FoodAdministrationService : IFoodAdministrationService
    {
        private const string Uri = "http://matapi.se/";

        public async Task<IEnumerable<FoodStuff>> GetFoodStuffs(string filter)
        {
            if (string.IsNullOrEmpty(filter)) return null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Uri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(string.Format("/foodstuff?query={0}", filter));
                return response.IsSuccessStatusCode ? response.Content.ReadAsAsync<IEnumerable<FoodStuff>>().Result : null;
            }
        }

        public async Task<FoodStuff> GetFoodStuffById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Uri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(string.Format("/foodstuff/{0}", id));
                return response.IsSuccessStatusCode ? response.Content.ReadAsAsync<FoodStuff>().Result : null;
            }
        }

    }
}