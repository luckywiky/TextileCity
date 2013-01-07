using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextileCity.Entity;

namespace WebApp.Controllers
{
    public class MaterialController : ApplicationController
    {
        //
        // GET: /Material/

        public ActionResult Index(int id=0)
        {

            return View("material");
        }

    }
}
