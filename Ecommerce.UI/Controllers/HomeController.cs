using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ECommerce.BL.BusinessManagers;
using static ECommerce.ENT.Entities;

namespace ECommerce.UI.Controllers
{
    public class HomeController : Controller
    {
        public List<BasketTemp> baskettlist { get; set; }
        // GET: Home
        public ActionResult Index()
        {
           

         CategoriesManager cm = new CategoriesManager();
            ProductsManager pm = new ProductsManager();
            BrandsManager bm = new BrandsManager();
            ColorManager colm = new ColorManager();
            SizeManager sm = new SizeManager();
            ProductCategoriesManager pcm = new ProductCategoriesManager();
            ProductColorsManager pcolm = new ProductColorsManager();
            ProductSizesManager pszm = new ProductSizesManager();

            BasketManager basm = new BasketManager();
            BasketDetailManager bdm = new BasketDetailManager();
            BasketTempManager btm = new BasketTempManager();
            ParamManager parm = new ParamManager();

            Session["Categories"] = cm.GetAll();
            Session["Products"] = pm.GetAll();
            Session["Brands"] = bm.GetAll();
            Session["Colors"] = colm.GetAll();
            Session["Sizes"] = sm.GetAll();
            Session["ProductCategories"] = pcm.GetAll();
            Session["ProductColorsManager"] = pcolm.GetAll();
            Session["ProductSizesManager"] = pszm.GetAll();

            Session["Basket"] = basm.GetAll();
            Session["BasketDetail"] = bdm.GetAll();
            Session["BasketTemp"] = btm.GetAll();
            Session["Param"] = parm.GetAll();

            baskettlist= btm.GetAll(); ;

            ViewBag.Login = "Login";
            ViewBag.Logout = "Logout";
            return View();
        }
    }
}