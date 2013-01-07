using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextileCity.Models;

namespace WebApp.Controllers
{
    public abstract class ApplicationController : Controller
    {

        public ApplicationController()
        {
            NaviCss naviCss = new NaviCss();
            ViewBag.NaviCss = naviCss;
        }
    }
}
