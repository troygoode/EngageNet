using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace RPX.Web.MVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "RPX.Signout", // Route name
                "RPXAuthentication/SignOut", // URL with parameters
                new {controller = "RPXAuthentication", action = "SignOut"} // Parameter defaults
                );

            routes.MapRoute(
                "RPX.HandleResponse", // Route name
                "RPXAuthentication/HandleResponse", // URL with parameters
                new {controller = "RPXAuthentication", action = "HandleResponse"} // Parameter defaults
                );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = ""} // Parameter defaults
                );
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}