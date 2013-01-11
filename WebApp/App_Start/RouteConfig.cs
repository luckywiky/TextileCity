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
             name: "List",
             url: "List/{categoryid}",
             defaults: new { controller = "Textile", action = "list" },
             constraints: new { categoryid = @"\d+" }         
            );
            routes.MapRoute(
               name: "Material",
               url: "Material/{id}",
               defaults: new { controller = "Material", action = "Index" },
              constraints: new { id = @"\d+" }
              );
            routes.MapRoute(
              name: "Orders",
              url: "Account/Orders/{type}",
              defaults: new { controller = "Account", action = "Orders", type = UrlParameter.Optional }
             );
            routes.MapRoute(
              name: "OrdersRoot",
              url: "Account/Orders",
              defaults: new { controller = "Account", action = "Orders", type = "latest" }
             );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}