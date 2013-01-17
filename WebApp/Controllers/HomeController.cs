using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : ApplicationController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.NaviCss.Current = TextileCity.Models.Navigation.Index;
            return View();
        }

    }
}
