using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Filters
{
    public class UserAuthAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public override void OnAuthorization(AuthorizationContext actionContext)
        {
            bool authorized = false;
            string url = "/account/login";
            if (actionContext.HttpContext.Session["LoginUser"] != null)
            {
                authorized = true;
            }
            if (!authorized)
            {
                actionContext.Result = new RedirectResult(url);
            }
        }

    }
}