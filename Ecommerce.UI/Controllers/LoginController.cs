using ECommerce.DL;
using ECommerce.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ECommerce.ENT.Entities;

namespace ECommerce.UI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            ECommerceContext db = new ECommerceContext();
            return View();
        }
       
        [HttpPost]
        public ActionResult Login(LoginModel m)
        {
            ECommerceContext db = new ECommerceContext();
            Users u = db.Users.Find(m.User.Email);
            //if (u.Password==m.User.Password)
            //{
            try
            {
                Session["Kullanici"] = u.Email;
                Session["Rol"] = u.Role;
            }
            catch (Exception)
            {              
            }


            return RedirectToAction("Index", "Home");
            // return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}