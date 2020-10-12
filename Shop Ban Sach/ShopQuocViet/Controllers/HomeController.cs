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
        BookShopModel db = new BookShopModel();
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult PartialSachNoiBat()
        {
            var listSachNoiBat = db.Sach.Take(8).ToList();
            return PartialView(listSachNoiBat);
        }
        [ChildActionOnly]
        public ActionResult PartialQuanTam()
        {
            var listSachQuanTam = db.Sach.Take(16).ToList();
            return PartialView(listSachQuanTam);
        }

    }
}