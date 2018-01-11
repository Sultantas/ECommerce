using ECommerce.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.UI
{
    public class AllProducts: ShopModel
    {
        public class Filtre
        {
            public int Category_ID { get; set; }
            public string Category_Name { get; set; }
            //public int Category_ID { get; set; }
            //public string Category_Name { get; set; }
        }
    }
}