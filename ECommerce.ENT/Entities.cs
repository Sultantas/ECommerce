using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ENT
{
    public class Entities
    {
        [Table("Categories")]
        public class Categories
        {
            [Key]
            public int CategoryID { get; set; }
            [Required, DisplayName("Kategori Ad")]
            public string CategoryName { get; set; }
        }
        [Table("Brands")]
        public class Brands
        {
            [Key]
            public int BrandID { get; set; }
            [Required, DisplayName("Marka Ad")]
            [StringLength(50)]
            public string BrandName { get; set; }
            public virtual ICollection<Products> Products { get; set; }
        }
        [Table("Colors")]
        public class Colors
        {
            [Key]
            public int ColorID { get; set; }
            [Required, DisplayName("Renk  Ad")]
            [StringLength(50)]
            public string ColorName { get; set; }
        }
        [Table("Sizes")]
        public class Sizes
        {
            [Key]
            public int SizeID { get; set; }
            [Required, DisplayName("Beden")]
            [StringLength(50)]
            public string SizeName { get; set; }
        }
        [Table("Products")]
        public class Products
        {
            [Key]
            public int ProductsID { get; set; }
            [Required, DisplayName("Ürün Ad")]
            [StringLength(50)]
            public string ProductsName { get; set; }
            [StringLength(100)]
            public string ProductDetail { get; set; }
            public int SizeID { get; set; }
            public int ColorID { get; set; }
            public int BrandID { get; set; }
            public int CategoryID { get; set; }
            public decimal UnitPrice { get; set; }
            public int UnitsInStock { get; set; }
            public string ImagePath { get; set; }
            [ForeignKey("BrandID")]
            public virtual Brands Brands { get; set; }
        }
        [Table("ProductCategories")]
        public class ProductCategories
        {
            [Key]
            [Column(Order = 0)]
            public int ProductsID { get; set; }
            [Key]
            [Column(Order = 1)]
            public int CategoryID { get; set; }
            public virtual Categories Categories { get; set; }
            public virtual Products Products { get; set; }
        }
        [Table("ProductColors")]
        public class ProductColors
        {
            [Key]
            [Column(Order = 0)]
            public int ProductsID { get; set; }
            [Key]
            [Column(Order = 1)]
            public int ColorID { get; set; }
            public virtual Products Products { get; set; }
            public virtual Colors Colors { get; set; }
        }
        [Table("ProductSizes")]
        public class ProductSizes
        {
            [Key]
            [Column(Order = 0)]
            public int ProductsID { get; set; }
            [Key]
            [Column(Order = 1)]
            public int SizeID { get; set; }
            public virtual Products Products { get; set; }
            public virtual Sizes Sizes { get; set; }
        }
        [Table("Users")]
        public class Users
        {
            [Key, Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
            [Required]
            public string Role { get; set; }
            [Required]
            public string Address { get; set; }
        }
        [Table("Basket")]
        public class Basket
        {
            public Basket()
            {
                this.BasketDetail = new HashSet<BasketDetail>();
            }
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Key]
            public int BasketID { get; set; }
            public decimal TotalOrder { get; set; }
            public DateTime OrderDate { get; set; }
            public string User { get; set; } //Email userıd olarak işlem görecektir.
            public DateTime? PaymentDate { get; set; } //  ? ile null olabilir yapıldı
            public DateTime? ShipDate { get; set; }
            public DateTime? ShippedDate { get; set; }
            [StringLength(1)]
            //Status boş ise Yeni sipariş:  1>>> S:Sepete Eklendi   2>>> O:Ödendi  3>>> S:Sevk edildi  4>>> T:Teslim edildi
            public string Status { get; set; }

            public virtual ICollection<BasketDetail> BasketDetail { get; set; }
            [ForeignKey("User")]
            public virtual Users Users { get; set; }
        }
        [Table("BasketDetail")]
        public class BasketDetail
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)] //Key artma ve durdurma durumu için >> .None otomatik arttırmayı durduruyor.Identitiy olursa otomatik arttırıyor  .Computed olura manual olarak arttırmaya izin verdirip update ettiriyor.
            [Key]
            [Column(Order = 0)]
            public int BasketID { get; set; }
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Key]
            [Column(Order = 1)]
            public int ProductsID { get; set; } //ProductID olduğu için sıraID ye gerek kalmadı. 1.emir 1 nolu product 1.emir 2 nolu product
            public int Amount { get; set; }
            public decimal UnitPrice { get; set; }
            [ForeignKey("BasketID")]
            public virtual Basket Basket { get; set; }
        }
        [Table("BasketTemp")]
        public class BasketTemp //Geçic basket
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            [Key]
            [Column(Order = 0)]
            public string User { get; set; }
            [Key]
            [Column(Order = 1)]
            public int ProductsID { get; set; }
            public int Amount { get; set; }
            public decimal UnitPrice { get; set; }
            public int Duration { get; set; }  // Süre>> otomatik 3 gün verilir ve sonra admin 3 günden fazla süren siparişleri siler.
            [ForeignKey("User")]
            public virtual Users Users { get; set; }
        }
        [Table("Param")]
        public class Param //Geçici basket
        {
            [Key]
            public string ParamID { get; set; } //BC >:Bascetount
            public string ParamName { get; set; }//Bascetount
            public int Parameter { get; set; } // 3
        }
    }
}
