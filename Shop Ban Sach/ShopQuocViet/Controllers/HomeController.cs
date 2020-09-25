using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuocViet.Models;

namespace ShopQuocViet.Controllers
{
    public class HomeController : Controller
    {
        BookShopEntities1 db = new BookShopEntities1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialSachNoiBat()
        {
            var listSachNoiBat = db.Sach.Take(8).ToList();
            return PartialView(listSachNoiBat);
        }
        public ActionResult PartialQuanTam()
        {
            var listSachQuanTam = db.Sach.Take(16).ToList();
            return PartialView(listSachQuanTam);
        }

    }
}