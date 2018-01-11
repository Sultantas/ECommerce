using ECommerce.DL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECommerce.ENT.Entities;
using ECommerce.ENT;

namespace ECommerce.REP
{
    public class Repositories
    {
        public class ProductRepository : RepositoryBase<Products> { }

        public class CategoryRepository : RepositoryBase<Categories> { }
        public class BrandsRepository : RepositoryBase<Brands> { }

        public class ColorRepository : RepositoryBase<Colors> { }
        public class SizesRepository : RepositoryBase<Sizes> { }
        public class ProductCategoriesRepository : RepositoryBase<ProductCategories> { }
        public class ProductColorsRepository : RepositoryBase<ProductColors> { }
        public class ProductSizesRepository : RepositoryBase<ProductSizes> { }

        public class UsersRepository : RepositoryBase<Users>
        {
            public override Users Single(object id)
            {
                return _db.Set<Users>().Find(id.ToString());
            }
        }
        public class BasketRepository : RepositoryBase<Basket> { }
        public class BasketDetailRepository : RepositoryBase<BasketDetail> { }
        public class BasketTempRepository : RepositoryBase<BasketTemp> { }
        public class ParamRepository : RepositoryBase<Param>
        {
            public override Param Single(object id)
            {
                return _db.Set<Param>().Find(id.ToString());
            }
        }

        public class RepositoryBase<T> : IRepository<T> where T : class
        {
            public static ECommerceContext _db = DBSingleTone.GetInstance();

            public void Delete(T entity)
            {
                _db.Entry(entity).State = EntityState.Deleted;
                _db.SaveChanges();
            }

            public List<T> GetAll()
            {
                return _db.Set<T>().ToList();
            }

            public void Insert(T entity)
            {
                _db.Entry(entity).State = EntityState.Added;
                _db.SaveChanges();
            }

            public virtual T Single(object id)
            {
                return _db.Set<T>().Find(Convert.ToInt32(id));
            }

            public void Update(T entity)
            {
                _db.Entry(entity).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }

        public interface IRepository<T>
        {
            void Delete(T entity);
            void Insert(T entity);
            void Update(T entity);
            List<T> GetAll();
            T Single(object id);
        }
    }
}
