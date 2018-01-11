using ECommerce.DL;
using ECommerce.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static ECommerce.BL.BusinessManagers;
using static ECommerce.ENT.Entities;

namespace ECommerce.UI.Controllers
{
    public class ShopController : Controller
    {
        static List<Int32> BrandsFilter = null;
        public List<string> marka = null;
        public ActionResult Shop(ShopModel m)
        {
            m.clist = (List<Categories>)Session["Categories"];
            m.plist = (List<Products>)Session["Products"];
            m.blist = (List<Brands>)Session["Brands"];
            m.colorlist = (List<Colors>)Session["Colors"];
            m.sizelist = (List<Sizes>)Session["Sizes"];
            //m.pclist = (List<ProductCategories>)Session["ProductCategories"];
            //m.ProductCount = m.plist.Count();

            return View(m);
        }
        public ActionResult Products(int id, ShopModel m)
        {
            ProductsManager pm = new ProductsManager();
            ProductCategoriesManager pcm = new ProductCategoriesManager();

            m.pclist = pcm.GetAll().Where(x => x.CategoryID == id).ToList();

            foreach (var item in m.pclist)
            {
                m.plist.Add(pm.Single(item.ProductsID));
            }

            Session["Products"] = m.plist;
            //m.ProductCount = m.plist.Count();
            return RedirectToAction("Shop", "Shop", m);
        }
        public ActionResult Brands(int id, ShopModel m) //Sadece ProductsManager ile yapıldı
        {
            if (BrandsFilter == null)
            {
                BrandsFilter = new List<int>();
            }
            //if (m.BrandsFilter == null)
            //{
            //    m.BrandsFilter = new List<Brands>();
            //}

            ProductsManager pm = new ProductsManager();
            BrandsManager bm = new BrandsManager();

            BrandsFilter.Add(id);
            //m.marka.Add(bm.Single(id).BrandName);
            //m.BrandsFilter.Add(bm.Single(id));
            //m.BrandsFilter = bm.GetAll().Where(x => x.BrandID == id).ToList();
            //Session["BrandsFilter"] = BrandsFilter;
            //foreach (var item in m.BrandsFilter)
            //{
            //    m.BrandsFilter.Add(bm.Single(id));
            //}
            m.plist = pm.GetAll().Where(x => BrandsFilter.Contains(x.BrandID)).ToList();
            Session["Products"] = m.plist;
            return RedirectToAction("Shop", "Shop", m);
        }

        public ActionResult Colors(int id, ShopModel m) //ProductColorsManager dahil edildi
        {
            ProductsManager pm = new ProductsManager();
            ProductColorsManager pcolm = new ProductColorsManager();

            m.pcollist = pcolm.GetAll().Where(x => x.ColorID == id).ToList();

            foreach (var item in m.pcollist)
            {
                m.plist.Add(pm.Single(item.ProductsID));
            }
            Session["Products"] = m.plist;
            return RedirectToAction("Shop", "Shop", m);
        }
        public ActionResult Sizes(int id, ShopModel m)   //ProductSizesManager dahil edildi
        {
            ProductsManager pm = new ProductsManager();

            //var size = db.ProductSizes.Where(p => p.SizeID ==id);
            //var histories = db.Products.Take(5).OrderByDescending(p => p.ProductsID in size);
            //SizeManager sm = new SizeManager();

            ProductSizesManager pszm = new ProductSizesManager();
            m.pszlist = pszm.GetAll().Where(x => x.SizeID == id).ToList();

            foreach (var item in m.pszlist)
            {
                m.plist.Add(pm.Single(item.ProductsID));
            }
            Session["Products"] = m.plist;
            return RedirectToAction("Shop", "Shop", m);
        }
        public ActionResult Lh(ShopModel m)
        {
            ProductsManager pm = new ProductsManager();
            m.plist = pm.GetAll().OrderBy(x => x.UnitPrice).ToList();
            Session["Products"] = m.plist;
            return RedirectToAction("Shop", "Shop", m);
        }
        public ActionResult Hl(ShopModel m)
        {
            ProductsManager pm = new ProductsManager();
            m.plist = pm.GetAll().OrderByDescending(x => x.UnitPrice).ToList();
            Session["Products"] = m.plist;
            return RedirectToAction("Shop", "Shop", m);
        }
    }
}