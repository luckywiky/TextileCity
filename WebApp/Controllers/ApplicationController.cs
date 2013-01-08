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
        public Cart MyCart
        {
            get
            {
                if (Session["Cart"] != null)
                {
                    return Session["Cart"] as Cart;
                }
                else
                {
                    Cart myCart = new Cart();
                    if (Session["LoginUser"] != null)
                    {
                        TextileCity.Entity.User loginUser = Session["LoginUser"] as TextileCity.Entity.User;
                        myCart.Uid = loginUser.Uid;
                    }
                    Session["Cart"] = myCart;
                    return myCart;
                }
            }
            set
            {
                Session["Cart"] = value;
            }
        }
        public ApplicationController()
        {
            
            NaviCss naviCss = new NaviCss();
            ViewBag.NaviCss = naviCss;
        }
    }
}
