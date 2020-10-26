using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuocViet.Models;
namespace ShopQuocViet.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        BookModel db = new BookModel();
       
        public ActionResult Index()
        {

            if(Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            else
            {
                var ND = (NguoiDung)Session["TaiKhoan"];
                var GioHang = db.GioHang.Where(KH => KH.MaND == ND.TenDN.ToString()).ToList();
                if (GioHang.Count() == 0)
                {
                    return PartialView("GioTrong");
                }
                else
                {
                    return PartialView(GioHang);
                }
            }
           
        }
        [ChildActionOnly]
        public ActionResult ChiTietSach(string maSach, string soLuong)
        {
            ViewBag.SoLuong = soLuong;
            var CTSach = db.TTSach.Where(s => s.MaSach == maSach).ToList();
            return PartialView(CTSach);
        }
        public ActionResult XoaSP(string maSach)
        {
            if(Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            else
            {
                NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
                var MaND = ND.TenDN;
                var ItemOfCart = db.GioHang.SingleOrDefault(m => m.MaSach == maSach && m.MaND == MaND);
                if (ItemOfCart != null)
                {
                    db.GioHang.Remove(ItemOfCart);
                    db.SaveChanges();
                }
                else
                {
                    return PartialView("GioTrong");
                }
                var GioHang = db.GioHang.Where(KH => KH.MaND == ND.TenDN.ToString()).ToList();
                return PartialView("PartialItem", GioHang);
            }
           
        }
        public ActionResult ThemSP(string maSach)
        {
            if(Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            else
            {
                var Sach = db.Sach.SingleOrDefault(m => m.MaSach == maSach);
                if(Sach == null)
                {
                    
                }
                NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
                var MaND = ND.TenDN;
                var ItemOfCart = db.GioHang.SingleOrDefault(m => m.MaSach == maSach && m.MaND == MaND);
                if (ItemOfCart == null)
                {
                    GioHang gh = new GioHang();
                    gh.MaND = MaND;
                    gh.MaSach = maSach;
                    gh.SoLuong = 1;
                    db.GioHang.Add(gh);
                    db.SaveChanges();
                }
                else
                {
                    var item = db.GioHang.SingleOrDefault(m => (m.MaND == MaND) && (m.MaSach == maSach));
                    item.SoLuong += item.SoLuong;
                    db.SaveChanges();
                }
              
                return PartialView("PartialSachNoiBat", "Home");
            }
        }
        public ActionResult ThemSP1(string maSach)
        {
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            else
            {
                var Sach = db.Sach.SingleOrDefault(m => m.MaSach == maSach);
                if (Sach == null)
                {

                }
                NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
                var MaND = ND.TenDN;
                var ItemOfCart = db.GioHang.SingleOrDefault(m => m.MaSach == maSach && m.MaND == MaND);
                if (ItemOfCart == null)
                {
                    GioHang gh = new GioHang();
                    gh.MaND = MaND;
                    gh.MaSach = maSach;
                    gh.SoLuong = 1;
                    db.GioHang.Add(gh);
                    db.SaveChanges();
                }
                else
                {
                    var item = db.GioHang.SingleOrDefault(m => (m.MaND == MaND) && (m.MaSach == maSach));
                    item.SoLuong += item.SoLuong;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "GioHang");
            }
        }
        public ActionResult ThemSP2(string maSach)
        {
            if (Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            else
            {
               
                var Sach = db.Sach.SingleOrDefault(m => m.MaSach == maSach);
                if (Sach == null)
                {

                }
                NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
                var MaND = ND.TenDN;
                var ItemOfCart = db.GioHang.SingleOrDefault(m => m.MaSach == maSach && m.MaND == MaND);
                if (ItemOfCart == null)
                {
                    GioHang gh = new GioHang();
                    gh.MaND = MaND;
                    gh.MaSach = maSach;
                    gh.SoLuong = 1;
                    db.GioHang.Add(gh);
                    db.SaveChanges();
                }
                else
                {
                    var item = db.GioHang.SingleOrDefault(m => (m.MaND == MaND) && (m.MaSach == maSach));
                    item.SoLuong += item.SoLuong;
                    db.SaveChanges();
                }

                return View("Index", "ChiTietSP");
            }
        }

    }
}