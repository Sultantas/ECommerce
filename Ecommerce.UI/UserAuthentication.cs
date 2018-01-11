using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI
{
    public class UserAuthentication : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (HttpContext.Current.Session["Kullanici"] == null)
            {
                filterContext.Result = new RedirectResult("/Login/Login");
            }
        }
    }
}