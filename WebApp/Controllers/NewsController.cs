using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextileCity.Entity;
using TextileCity.Operation;

namespace WebApp.Controllers
{
    public class NewsController : ApplicationController
    {
        //
        // GET: /News/

        public ActionResult Index(int page=1)
        {
            ViewBag.NaviCss.Current = TextileCity.Models.Navigation.News;
            int count = 0;
            if (page > 0)
            {
                NewsOperation nop = new NewsOperation();
                List<News> news = new List<News>();
                news = nop.GetMinList(page, out count);
                Pager pager =new Pager(page,count,NewsOperation.NewsListSize);
                ViewData["News"] = news;
                if (count > NewsOperation.NewsListSize)
                {
                    if (page > 1)
                    {
                        ViewData["Prev"] = page - 1;
                    }
                    if (page < pager.Count)
                    {
                        ViewData["Next"] = page + 1;
                    }
                }
            }
            return View();
        }

        
        public ActionResult Details(int id)
        {
            News dataModel = new NewsOperation().GetModel(id);
            if (dataModel != null)
            {
                ViewData["DataModel"] = dataModel;
            }
           
            return PartialView();
        }
    }
}
