using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ECommerce.ENT.Entities;

namespace ECommerce.UI.Models
{
    public class ShopModel
    {
        public List<Categories> clist { get; set; }
        public List<Products> plist { get; set; }
        public List<Brands> blist { get; set; }
        public List<Colors> colorlist { get; set; }
        public List<Sizes> sizelist { get; set; }
        public List<ProductCategories> pclist { get; set; }
        public List<ProductColors> pcollist { get; set; }
        public List<ProductSizes> pszlist { get; set; }


        public List<Basket> basketlist { get; set; }
        public List<BasketDetail> basketdlist { get; set; }
        public List<BasketTemp> baskettlist { get; set; }
        public List<Param> paramlist { get; set; }
        //public List<Brands> BrandsFilter { get; set; }

        public int Category_ID { get; set; }
        public string Category_Name { get; set; }
        //public int ProductCount { get; set; } //Bu ürün sayısı kullanılacak ise 
        public ShopModel()
        {
            plist = new List<Products>();
            baskettlist = new List<BasketTemp>();
            //BrandsFilter = new List<Brands>();
            //pclist = new List<ProductCategories>();
        }
    }
}