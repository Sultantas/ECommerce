using ECommerce.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ECommerce.BL.BusinessManagers; //static olarak eklemesinin sebebi proje boyunca-sayfalar arasında kullandırmak için.
using static ECommerce.ENT.Entities;

namespace ECommerce.UI.Controllers
{
    [UserAuthentication]
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Add(int id, ShopModel m)
        {
            BasketTempManager btm = new BasketTempManager();
            m.baskettlist.Add(btm.AddToTempBasket(id, Session["Kullanici"].ToString()));
            Session["BasketTemp"] = m.baskettlist;
            return RedirectToAction("Display", "Cart");
        }

        public ActionResult Display()
        {
            return View();
        }
    }
}