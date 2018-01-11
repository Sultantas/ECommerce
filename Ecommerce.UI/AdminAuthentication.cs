using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI
{
    public class AdminAuthentication : ActionFilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            try
            {
                if (HttpContext.Current.Session["Rol"].ToString() != "Admin")
                {
                    filterContext.Result = new RedirectResult("/Login/Login");
                }
            }
            catch (Exception)
            {
                if (HttpContext.Current.Session["Rol"] == null)
                {
                    filterContext.Result = new RedirectResult("/Login/Login");
                }
            }
        }
    }
}