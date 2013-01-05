using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApp
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
             name: "MaterialType",
             url: "textile/{type}/{id}",
             defaults: new { controller = "Textile", action = "Index",type = UrlParameter.Optional,id=UrlParameter.Optional }
             
            );
            routes.MapRoute(
             name: "FabricList",
             url: "fabric/{id}",
             defaults: new { controller = "Textile", action = "list" },
             constraints: new { id = @"\d+" }         
            );
            routes.MapRoute(
             name: "AccessoryList",
             url: "accessory/{id}",
             defaults: new { controller = "Textile", action = "list" },
             constraints: new { id = @"\d+" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}