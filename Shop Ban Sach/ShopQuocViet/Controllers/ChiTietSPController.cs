using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuocViet.Models;

namespace ShopQuocViet.Controllers
{
    public class ChiTietSPController : Controller
    {
        BookShopModel db = new BookShopModel();
        // GET: ChiTietSP
        public ActionResult Index(string maSach)
        {
            var CTSach = db.Sach.Where(n => n.MaSach == maSach).ToList();
            return View(CTSach);
        }
    }
}