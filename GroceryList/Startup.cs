using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GroceryList.Startup))]
namespace GroceryList
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
