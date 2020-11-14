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
        BookModel1 db = new BookModel1();
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
        public ActionResult PartialSachNoiBat()
        {
            var listSachNoiBat = db.TTSach.OrderByDescending(s => s.DanhGia).Take(16).ToList();
            return PartialView("~/Views/Home/PartialSachNoiBat.cshtml", listSachNoiBat);
        }
        public ActionResult DanhMuc()
        {
            var DanhMuc = db.DanhMuc.ToList();
            return PartialView(DanhMuc);
        }
    }
}