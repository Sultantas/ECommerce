using ECommerce.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.REP
{
  public  class DBSingleTone
    {
        private static ECommerceContext _db;

        public static ECommerceContext GetInstance()
        {
            if (_db == null) { _db = new ECommerceContext(); }
            return _db;
        }
    }
}
