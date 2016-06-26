using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FilmStore.Portal
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //URL store/list/the
            routes.MapRoute(
                name: "List",
                url: "Store/List/{search}",
                defaults: new { Controller = "Store", action = "List", search = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Store", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}
