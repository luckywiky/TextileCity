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

        [UserAuth()]
        public ActionResult Cart()
        {
            if (MyCart.Orders.Count <= 0)
            {
                return View("cartempty");
            }
            else
            {
                TextileCity.Entity.User user = Session["LoginUser"] as TextileCity.Entity.User;
                if (user != null)
                    MyCart.Uid = user.Uid;
                Cart cart = MyCart;
                cart.RefreshDbData();
                ViewData["Cart"] = cart;
                ViewBag.NaviCss.Current = TextileCity.Models.Navigation.Account;
                ViewData["User"] = user;
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
            string message = string.Empty;
            string account = string.Empty;
            string password = string.Empty;
            if (!string.IsNullOrEmpty(form["inputAccount"]))
            {
                account = form["inputAccount"];
                password = form["inputPassword"];
                UserOperation uop = new UserOperation();
                int result = -1;
                TextileCity.Entity.User loginUser = uop.Login(account, password, out result);
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

        [HttpPost]
        public ActionResult Register(FormCollection form)
        {
            bool success = false;
            string message = string.Empty;
            string account = string.Empty;
            string email = string.Empty;
            string password = string.Empty;
            if (!string.IsNullOrEmpty(form["inputAccount"]))
            {
                account = form["inputAccount"];
                email = form["inputEmail"];
                password = form["inputPassword"];
                UserOperation uop = new UserOperation();
                int result = -1;
                TextileCity.Entity.User loginUser = null;
                result = uop.Register(account, password, email);
                if (result > 0)
                {
                    loginUser = uop.Login(account,password,out result);
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
                }
                else
                {
                    switch (result)
                    {
                        case -3:
                            message = "账号格式不正确";
                            
                            break;
                        case -4:
                            message = "邮箱格式不正确";
                            break;
                        case -5:
                            message = "密码格式不正确";
                            break;
                        case -2:
                            message = "不能使用该邮箱";
                            break;
                        case -1:
                            message = "不能使用该用户名";
                            break;
                    }
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
                ViewData["Email"] = email;
                return View();
            }
        }

        [UserAuth()]
        public ActionResult Orders(string type = "latest", int page = 1)
        {
            string[] types = new string[] { "latest", "all", OrderState.MakingUp, OrderState.Delivering, OrderState.Delivered };
            type = type.ToLower();
            if (types.Contains(type))
            {
                try
                {
                    OrderOperation oop = new OrderOperation();
                    List<Order> orders = new List<Order>();
                    TextileCity.Entity.User loginUser = Session["LoginUser"] as TextileCity.Entity.User;
                    switch (type)
                    {
                        case "all":
                            ViewData["Navi"] = 1;
                            if (page > 0)
                            {
                                int count = 0;
                                orders = oop.GetOrders(loginUser.Uid, page, 10, out count);
                                Pager pager = new Pager(page, count, 10);
                                ViewData["PagerItems"] = pager.CreatePager();
                            }
                            else
                            {
                                throw new Exception();
                            }
                            break;
                        case "latest":
                            ViewData["Navi"] = 0;
                            orders = oop.GetMinOrders(loginUser.Uid);
                            break;
                        case OrderState.MakingUp:
                            ViewData["Navi"] = 2;
                            if (page > 0)
                            {
                                int count = 0;
                                orders = oop.GetOrders(loginUser.Uid, type, page, 10, out count);
                                Pager pager = new Pager(page, count, 10);
                               
                                ViewData["PagerItems"] = pager.CreatePager();
                            }
                            else
                            {
                                throw new Exception();
                            }
                            break;
                        case OrderState.Delivering:
                            ViewData["Navi"] = 3;
                            if (page > 0)
                            {
                                int count = 0;
                                orders = oop.GetOrders(loginUser.Uid, type, page, 10, out count);
                                Pager pager = new Pager(page, count, 10);
                                
                                ViewData["PagerItems"] = pager.CreatePager();
                            }
                            else
                            {
                                throw new Exception();
                            }
                            break;
                        case OrderState.Delivered:
                            ViewData["Navi"] = 4;
                            if (page > 0)
                            {
                                int count = 0;
                                orders = oop.GetOrders(loginUser.Uid, type, page, 10, out count);
                                Pager pager = new Pager(page, count, 10);
                                
                                ViewData["PagerItems"] = pager.CreatePager();
                            }
                            else
                            {
                                throw new Exception();
                            }
                            break;
                    }

                    ViewData["Type"] = type;
                    ViewData["Orders"] = orders;
                }
                catch(Exception ex)
                {
                    
                    return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
                }
                ViewBag.NaviCss.Current = TextileCity.Models.Navigation.Account;
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
        }

        [UserAuth()]
        public ActionResult Order(int id)
        {
            TextileCity.Entity.Order dataModel = new Order();
            dataModel = new OrderOperation().GetModel(id);
            TextileCity.Entity.User loginUser = Session["LoginUser"] as TextileCity.Entity.User;
            if (dataModel != null && dataModel.Uid == loginUser.Uid)
            {
                List<OrderItem> items = new OrderItemOperation().GetItems(dataModel.OrderID);
                ViewData["Items"] = items;
                ViewData["DataModel"] = dataModel;
                Dictionary<int, string> craftNames = new Dictionary<int, string>();
                List<Craft> craftsList = new CraftOperation().GetMinList();
                foreach (Craft c in craftsList)
                {
                    craftNames.Add(c.CraftID, c.Name);
                }
                ViewData["CraftNames"] = craftNames;
                ViewBag.NaviCss.Current = TextileCity.Models.Navigation.Account;
                return View();
            }
            else
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);
            }
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
