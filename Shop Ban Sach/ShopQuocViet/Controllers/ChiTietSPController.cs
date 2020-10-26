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
        BookModel db = new BookModel();
        // GET: ChiTietSP
        public ActionResult Index(string id)
        {
            var CTSach = db.TTSach.Where(n => n.MaSach == id).ToList();
            if(CTSach.Count != 0)
            {
                ViewBag.MaCD = CTSach[0].MaCD;
                return View(CTSach);
            }
            else
            {
                return RedirectToAction("ThongBao");
            }
           
        }
        public ActionResult AnhKem()
        {
            var CTSach = db.ANH.SqlQuery("SELECT *from Anh WHERE MaSach is null").ToList();
            return PartialView(CTSach);
        }
        public ActionResult ThongBao()
        {
            return PartialView();
        }
        public ActionResult SachCungCD(string maCD)
        {
            maCD = ViewBag.MaCD;
            var ListSach = db.TTSach.Where(s=> s.MaCD == maCD).ToList();
            return PartialView("~/Views/Home/PartialSachNoiBat.cshtml", ListSach);
        }

    }
}