using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextileCity.Entity;
using TextileCity.Operation;

namespace WebApp.Controllers
{
    public class CraftController : Controller
    {
        //
        // GET: /Craft/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult AjaxModel(int id)
        {
            JsonResult json = new JsonResult();          
            if (id > 0)
            {
                Craft model = new Craft();
                CraftOperation cop = new CraftOperation();
                model = cop.GetModel(id);
                if (model != null)
                {
                    json.Data = model;
                    json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                    json.ContentEncoding = System.Text.Encoding.UTF8;                    
                }
            }
            return json;
        }

    }
}
