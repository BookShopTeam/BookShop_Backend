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
        public ActionResult XemDM()
        {
            var ListDM = db.DanhMuc.ToList();
            return View(ListDM);
        }
        public ActionResult XemChuDe()
        {
            var ListCD = db.ChuDe.OrderBy(m=>m.MaDM).ToList();
            return View(ListCD);
        }
        public ActionResult XemDonHang()
        {
            var ListHD = db.HoaDon.OrderBy(m => m.MaHD).ToList();
            return View(ListHD);
        }
        public ActionResult ChiTietHD(string MaHD)
        {
            ViewBag.MaHD = MaHD;
            var ListCTDH = db.CTHoaDon.SqlQuery("Select *from CTHoaDon where MaHD = '"+MaHD+"'").ToList();
            if (ListCTDH != null)
            {
                return View(ListCTDH);
            }
            else
                return null;
        }
        public ActionResult ThanhVien()
        {
            var ListTV = db.NguoiDung.Where(m=>m.MaLoaiTK == "client").ToList();
            return View(ListTV);
        }
        public ActionResult Admin()
        {
            var ListTV = db.NguoiDung.Where(m => m.MaLoaiTK == "admin").ToList();
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