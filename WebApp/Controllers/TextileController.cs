using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextileCity.Entity;
using TextileCity.Operation;

namespace WebApp.Controllers
{
    public class TextileController : ApplicationController
    {
        //
        // GET: /Textile/

        public ActionResult Index(string type = "fabric",int id=0)
        {
            type = type.ToLower();
            if (type == "fabric" || type == "accessory")
            {
                try
                {
                    CategoryOperation gop = new CategoryOperation();
                    int parentID = 1;
                    int childID = -1;
                    int currentID = 0;
                    if (id > 0)
                    {
                        Category category = gop.GetModel(id);
                        if (category == null)
                        {
                            return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                        }
                        if (category.ParentID > 0)
                        {
                            parentID = category.ParentID;
                            childID = category.CategoryID;
                            currentID = childID;
                        }
                        else
                        {
                            parentID = category.CategoryID;
                            childID = -1;
                            currentID = parentID;
                        }
                        string strCategoryType = "";
                        switch (category.Type)
                        {
                            case CategoryType.Fabric:
                                strCategoryType = "fabric";
                                ViewBag.NaviCss.Current = TextileCity.Models.Navigation.Fabric;
                                break;
                            case CategoryType.Accessory:
                                strCategoryType = "accessory";
                                ViewBag.NaviCss.Current = TextileCity.Models.Navigation.Accessory;
                                break;
                        }
                        if (type != strCategoryType)
                        {
                            return new RedirectResult(string.Format("/textile/{0}/{1}", strCategoryType, id));
                        }
                    }
                    else
                    {
                        Category category = null;
                        switch (type)
                        {
                            case "fabric":
                                category = gop.FirstFabricParent();
                                ViewBag.NaviCss.Current = TextileCity.Models.Navigation.Fabric;
                                break;
                            case "accessory":
                                category = gop.FirstAccessoryParent();
                                ViewBag.NaviCss.Current = TextileCity.Models.Navigation.Accessory;
                                break;
                        }
                        if (category != null)
                        {
                            parentID = category.CategoryID;
                            childID = -1;
                            currentID = parentID;
                        }
                    }

                    ViewData["CurrentParentID"] = parentID;
                    ViewData["CurrentChildID"] = childID;
                    ViewData["CurrentType"] = type;
                    ViewData["FabricCategories"] = gop.GetFabricCategories();
                    ViewData["AccessoryCategories"] = gop.GetAccessoryCategories();
                    ViewData["CurrentID"] = currentID;
                    return View();
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

        [ActionName("list")]
        public ActionResult MaterialList(int categoryid = 1,int page = 1)
        {
            int count = 0;
            MaterialOperation mop = new MaterialOperation();
            List<Material> mateials = new List<Material>();
            mateials = mop.GetMaterialsMin(categoryid, page, out count);
            Pager pager = new Pager(page, count, Common.TextileConfig.MaterialPageSize);
            ViewData["PagerItems"] = pager.CreatePager();           
            ViewData["Materials"] = mateials;
            ViewData["CategoryID"] = categoryid;
            
            return PartialView("list");
        }
    }
}
