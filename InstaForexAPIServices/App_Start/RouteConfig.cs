using System.Web.Mvc;
using System.Web.Routing;

namespace InstaForexAPIServices
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {           
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "IFXGame",
                "IFXGame/Doc/Swagger",
                new { controller = "IFXGame", action = "RedirectToSwaggerUi" }
                );

            routes.MapRoute(
            "Help Area",
            "",
            new { controller = "Help", action = "Index" }
            ).DataTokens = new RouteValueDictionary(new { area = "HelpPage" });
        }
    }
}
