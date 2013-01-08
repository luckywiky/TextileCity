using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextileCity.Models;
using TextileCity.Entity;
using TextileCity.Operation;

namespace WebApp.Controllers
{
    public class CartController : ApplicationController
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult AddFabric()
        {
            string strCraft = Request["craft"];
            string strStyle = Request["style"];
            string strCount = Request["count"];
            string strID = Request["materialid"];
            int id = 0;
            int count = 0;
            int carftID = 0;
            int styleID = 0;
            int.TryParse(strCraft,out carftID);
            int.TryParse(strStyle,out styleID);
            int.TryParse(strCount, out count);
            int.TryParse(strID, out id);
            JsonResult json = new JsonResult();
            json.Data = new { flag = 0 };
            if (count > 0 && carftID > 0 && styleID > 0&&id>0)
            {
                DetailItem item = new DetailItem();
                item.Craft = carftID;
                item.Style=styleID;
                item.Type=CategoryType.Fabric;
                item.MaterialID=id;
                Material model = new Material();
                MaterialOperation mop = new MaterialOperation();
                model = mop.GetModel(id);
                Craft craftModel = new Craft();
                CraftOperation craftOperation = new CraftOperation();
                craftModel = craftOperation.GetModel(carftID);
                item.Count = count;
                if (model != null)
                {
                    switch (styleID)
                    {
                        case 1:
                            item.Price = model.Price + craftModel.Price;
                            break;
                        case 2:
                            item.Price = model.PriceHigh+craftModel.Price;
                            break;
                        case 3:
                            item.Price = model.PriceFancy+craftModel.Price;
                            break;
                    }
                    if (item.Price > 0)
                    {
                        MyCart.Add(item);
                        json.Data = new { flag = 1,count=MyCart.Orders.Count,total=MyCart.TotalPrice };
                    }
                }               
            }
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.ContentEncoding = System.Text.Encoding.UTF8;
            return json;
        }


        public JsonResult AddAccessory()
        {
            string strStyle = Request["mstyle"];
            string strCount = Request["count"];
            string strID = Request["materialid"];
            int id = 0;
            int count = 0;
            int carftID = 0;
            int styleID = 0;
            int.TryParse(strStyle, out styleID);
            int.TryParse(strCount, out count);
            int.TryParse(strID, out id);
            JsonResult json = new JsonResult();
            json.Data = new { flag = 0 };
            if (count > 0  && styleID > 0 && id > 0)
            {
                DetailItem item = new DetailItem();
                item.Craft = carftID;
                item.Style = styleID;
                item.Type = CategoryType.Accessory;
                item.MaterialID = id;
                item.Count = count;
                Style model = new Style();
                StyleOperation sop = new StyleOperation();
                model = sop.GetModel(styleID);
                if (model != null)
                {
                    item.Price = model.Price;
                    if (item.Price > 0)
                    {
                        MyCart.Add(item);
                        json.Data = new { flag = 1, count = MyCart.Orders.Count, total = MyCart.TotalPrice };
                    }
                }
            }
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            json.ContentEncoding = System.Text.Encoding.UTF8;
            return json;
        }
    }
}
