using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextileCity.Entity;
using TextileCity.Operation;

namespace WebApp.Controllers
{
    public class MaterialController : ApplicationController
    {
        //
        // GET: /Material/

        public ActionResult Index(int id=0)
        {
            if (id > 0)
            {
                try
                {
                    MaterialOperation mop = new MaterialOperation();
                    Material material = mop.GetModel(id);
                    if (material != null)
                    {
                        ViewData["DataModel"] = material;
                        CategoryOperation cop = new CategoryOperation();
                        Category category = cop.GetModel(material.CategoryID);
                        if (category != null)
                        {
                            ViewData["CategoryName"] = category.Name;
                        }
                        ViewBag.Title = material.Name;
                        string categoryUrl = "fabric";
                        switch (material.CategoryType)
                        {
                            case CategoryType.Fabric:
                                categoryUrl = "fabric";
                                ViewBag.NaviCss.Current = TextileCity.Models.Navigation.Fabric;
                                List<Craft> crafts = new List<Craft>();
                                CraftOperation craftOper = new CraftOperation();
                                crafts = craftOper.GetMinList();
                                ViewData["Crafts"] = crafts;
                                break;
                            case CategoryType.Accessory:
                                categoryUrl = "accessory";
                                ViewBag.NaviCss.Current = TextileCity.Models.Navigation.Accessory;
                                StyleOperation styleOper = new StyleOperation();
                                List<Style> styles = styleOper.GetStyles(material.MaterialID);
                                if(styles.Count>0)
                                    ViewData["Styles"] = styles;
                                break;
                        }
                        ViewData["CategoryTypeUrl"] = categoryUrl;
                        string[] images = material.Images.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        List<string> imageList = new List<string>();
                        if (images != null && images.Length > 0)
                        {
                            foreach (string image in images)
                            {
                                imageList.Add(image);
                            }
                            ViewData["Images"] = imageList;
                        }
                        
                        return View("material");
                    }
                    else
                    {
                        return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                    }
                }
                catch
                {
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                }
            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
        }

    }
}
