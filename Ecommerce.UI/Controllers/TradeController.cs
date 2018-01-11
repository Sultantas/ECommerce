using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.UI.Controllers
{
    public class TradeController : Controller
    {
        // GET: Trade
        public ActionResult Payment()
        {
            // Banka İşlemleri 
            // Bankadan veya PAY PALL bir kurumdan servis alınacak
            // BasketTemp okunup Basket ve Basket Detail oluşturulacak
            // Basket deki statu O ödendi yapılacak
            // BasketTepmdeki ilgili kayıtlar silicek
            // BasketID Param Tablosundan otomatik alınacak
            // Kullanıcıya Referans Takip no verilecek.(BasketID)
            // Basketdeki  Odeme tarihi güncellenecek
            return View();
        }
        public ActionResult Invoice()
        {
            // Fatura Programnına Kayıt atılcak. ERP sistemi
            // Basket Tablosundaki statu Kodu S olacak sevk edildi
            // Sevk Tarihi güncellenecek
            return View();
        }
        public ActionResult Shipped()
        {
            // Statu Kodu T yapılacak.
            // Teslim tarihi güncellenecek.
            // Gerekirse Basket de Teslim alan kişi ismi vs gibi bilgiler ilave edilir.
            return View();
        }
        public ActionResult Trace()
        {
            // Son kullanıcya Referans Takip No ile Siparişini takip etme arayüzü yapılacak. 
           
            return View();
        }
    }
}