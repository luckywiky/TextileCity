using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TextileCity.Entity;
using TextileCity.Models;
using TextileCity.Operation;
using WebApp.Filters;

namespace WebApp.Controllers
{
    public class AccountController : ApplicationController
    {
        //
        // GET: /Account/
        [UserAuth()]
        public ActionResult Me()
        {
            ViewBag.NaviCss.Current = TextileCity.Models.Navigation.Account;
            return View();
        }

        //[UserAuth()]
        public ActionResult Cart()
        {
            if (MyCart.Orders.Count <= 0)
            {
                return View("cartempty");
            }
            else
            {
                TextileCity.Entity.User user = Session["LoginUser"] as TextileCity.Entity.User;
                if(user!=null)
                    MyCart.Uid = user.Uid;
                Cart cart = MyCart;
                cart.RefreshDbData();
                ViewData["Cart"] = cart;
                ViewBag.NaviCss.Current = TextileCity.Models.Navigation.Account;
                return View();
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["LoginUser"] != null)
            {
                return new RedirectResult("/account/me");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            bool success = false;
            string message=string.Empty;
            string account = string.Empty;
            string password = string.Empty;
            if (!string.IsNullOrEmpty(form["inputAccount"]))
            {
                account = form["inputAccount"];
                password = form["inputPassword"];
                UserOperation uop = new UserOperation();
                int result =-1;
                TextileCity.Entity.User loginUser = uop.Login(account,password,out result);
                switch (result)
                {
                    case -3:
                        message = "账号格式不正确";
                        break;
                    case -2:
                        message = "密码格式不正确";
                        break;
                    case -1:
                        message = "账号或者密码不正确";
                        break;
                    case 0:
                        message = "该账号已被封禁，请联系管理员";
                        break;
                    case 1:
                        if (loginUser != null)
                        {
                            Session.Timeout = 60;
                            Session["LoginUser"] = loginUser;                          
                            success = true;                          
                        }
                        else
                        {
                            message = "未知错误";
                        }
                        break;
                }
            }
            else
            {
                message = "账号不能为空！";
            }
            if (success)
            {
                return new RedirectResult("/account/me");
            }
            else
            {
                ViewData["Message"] = message;
                ViewData["Account"] = account;
                return View();
            }
        }

        public ActionResult Logout()
        {
            if (Session["LoginUser"] != null)
            {
                Session.Remove("LoginUser");
            }
            if (Session["Cart"] != null)
            {
                Session.Remove("Cart");
            }
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View("register");
        }

        public ActionResult LoginWidget()
        {
            
            if (Session != null && Session["Cart"] != null)
            {
                Cart cart = Session["Cart"] as Cart;
                ViewBag.ItemsCount = cart.Orders.Count;
            }
            else
            {
                ViewBag.ItemsCount = 0;
            }
            if (Session["LoginUser"] == null)
            {
                return PartialView("loginWidget");
            }
            else
            {
                TextileCity.Entity.User loginUser = Session["LoginUser"] as TextileCity.Entity.User;
                ViewData["UserName"] = loginUser.Name;
                return PartialView("loginedWidget");
            }
        }
    }
}
