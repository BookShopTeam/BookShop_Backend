using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuocViet.Models;
using System.Web.Security;
namespace ShopQuocViet.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminHomeController : Controller
    {
        BookModel1 db = new BookModel1();
        // GET: Admin/Home
        public ActionResult Index()
        {
            var donHang = db.HoaDon.Take(4).ToList();
            ViewBag.SLCD = db.ChuDe.Count();
            ViewBag.SLSP = db.Sach.Count();
            ViewBag.SLTV = db.NguoiDung.Count();
            ViewBag.SLDH = db.HoaDon.Count();
            return View(donHang);
        }
        public ActionResult XemSP()
        {
            var ListSach = db.TTSach.ToList();
            return View(ListSach);
        }
        public ActionResult ThanhVien()
        {
            var ListTV = db.NguoiDung.Where(m=>m.MaLoaiTK == "client").ToList();
            return View(ListTV);
        }
        public ActionResult DangXuat()
        {
            FormsAuthentication.SignOut();
            Session["TaiKhoan"] = null;
            return Redirect("~/Home/Index");
        }
    }
}