using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.ENT;
using static ECommerce.REP.Repositories;
using static ECommerce.ENT.Entities;

namespace ECommerce.BL
{
    public class BusinessManagers
    {
        public class CategoriesManager : CategoryRepository
        {
        }
        public class ProductsManager : ProductRepository
        {
        }
        public class BrandsManager : BrandsRepository
        {
        }
        public class ColorManager : ColorRepository
        {
        }
        public class SizeManager : SizesRepository
        {
        }
        public class ProductCategoriesManager : ProductCategoriesRepository
        {
        }
        public class ProductColorsManager : ProductColorsRepository
        {
        }
        public class ProductSizesManager : ProductSizesRepository
        {
        }


        public class UsersManager : UsersRepository
        {
        }
        public class BasketManager : BasketRepository
        {
        }
        public class BasketDetailManager : BasketDetailRepository
        {
        }
        public class BasketTempManager : BasketTempRepository
        {
            //public List<BasketTemp> baskettlist { get; set; }
            public BasketTemp AddToTempBasket(int id, string kullanici)
            {
                UsersManager usm = new UsersManager();

                ProductsManager pm = new ProductsManager();
                ParamManager paramManager = new ParamManager();
                Param param = paramManager.Single("DU");
                Products product = pm.Single(id);
                BasketTemp basketTemp = new BasketTemp();
                BasketTempRepository btm = new BasketTempRepository();
                basketTemp.Amount = 1;
                basketTemp.Duration = param.Parameter;
                basketTemp.ProductsID = product.ProductsID;
                basketTemp.UnitPrice = 100;
                basketTemp.User = kullanici;
                basketTemp.Users = usm.Single(kullanici);
                btm.Insert(basketTemp);
                //baskettlist.Add(basketTemp);
                return basketTemp;
            }


        }
        public class ParamManager : ParamRepository
        {
            //1.yol single() dan hariç bir metot yaparak gün çekilir.
            //2.yol ise repository e gelerek single() metodunu virtual yapmak



        }
    }
}
