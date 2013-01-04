using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextileCity.Entity;
using TextileCity.Operation;

namespace WebApp.Controllers
{
    public class TextileController : Controller
    {
        //
        // GET: /Textile/

        public ActionResult Index()
        {
            ViewData["CurrentParentID"] = 1;
            ViewData["CurrentChildID"] = -1;
            ViewData["CurrentType"] = "fabric";
            ViewData["FabricCategories"] = new CategoryOperation().GetFabricCategories();
            ViewData["AccessoryCategories"] = new CategoryOperation().GetAccessoryCategories();
            return View();
        }

    }
}
