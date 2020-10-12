using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuocViet.Models;

namespace ShopQuocViet.Controllers
{
    public class DanhMucSPController : Controller
    {
        BookShopModel db = new BookShopModel();
        // GET: DanhMucSP
        public ActionResult Index()
        {
            var listDanhMuc = db.DanhMuc.ToList();
            return View(listDanhMuc);
        }
        public ActionResult PartialChuDe(string id)
        {
            var listChuDe = db.ChuDe.Where(n=>n.MaDM == id).ToList();
            return PartialView(listChuDe);
        }
        public ActionResult PartialSachHot()
        {
            var listSachHot = db.Sach.Take(10).ToList();
            return PartialView(listSachHot);
        }
        public ActionResult PartialSachMoiNhat()
        {
            var listSachNew = db.Sach.Take(10).ToList();
            return PartialView(listSachNew);
        }

    }
}