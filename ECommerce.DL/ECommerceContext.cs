namespace ECommerce.DL
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using static ECommerce.ENT.Entities;

    public class ECommerceContext : DbContext
    {

        public ECommerceContext()
            : base("Baglanti")
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }

        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<BasketDetail> BasketDetail { get; set; }
        public virtual DbSet<BasketTemp> BasketTemp { get; set; }
        public virtual DbSet<Param> Param { get; set; }

        public virtual DbSet<ProductCategories> ProductCategories { get; set; }
        public virtual DbSet<ProductColors> ProductColors { get; set; }
        public virtual DbSet<ProductSizes> ProductSizes { get; set; }

       

    }


}