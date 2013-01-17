using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class NewsController : ApplicationController
    {
        //
        // GET: /News/

        public ActionResult Index(int page=1)
        {
            ViewBag.NaviCss.Current = TextileCity.Models.Navigation.News;
            return View();
        }


        public ActionResult Details(int id)
        {
            ViewBag.NaviCss.Current = TextileCity.Models.Navigation.News;
            return View();
        }
    }
}
