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

        public List<ItemCart> LayGioHang()
        {
            List<ItemCart> lstGioHang = Session["GioHang"] as List<ItemCart>;
            if (lstGioHang == null)
            {
                //Nếu session bằng  null thì khởi tạo gio hàng
                lstGioHang = new List<ItemCart>();
                // Gán lại giỏ hàng cho session
                Session["GioHang"] = lstGioHang;
            }
            // nếu giỏ hàng khác null ( đã có sản phẩm trong giỏ ) thì trả về  list
            return lstGioHang;
        }

        public ActionResult Index()
        {

            if(Session["TaiKhoan"] == null)
            {
                List<ItemCart> lstGioHang = LayGioHang();
                if (lstGioHang.Count() == 0)
                {
                    return PartialView("GioTrong");
                }
                return PartialView("GHKhachVangLai",lstGioHang);
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
            var Sach = db.Sach.SingleOrDefault(m => m.MaSach == maSach);
            if (Sach == null)
            {
                //Trả về trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;
            }
            if (Session["TaiKhoan"] == null)
            {
                List<ItemCart> lstGioHang = LayGioHang();
                var ItemOfCartKH =lstGioHang.SingleOrDefault(m => m.MaSach == maSach);
                if (ItemOfCartKH != null)
                {
                    lstGioHang.Remove(ItemOfCartKH);
                }
                else
                {
                    return PartialView("GioTrong");
                }
                return PartialView("PartialItemKH",lstGioHang);
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
            var Sach = db.Sach.SingleOrDefault(m => m.MaSach == maSach);
            if (Sach == null)
            {
                //Trả về trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;
            }
            if (Session["TaiKhoan"] == null)
            {
                List<ItemCart> lstGioHang = LayGioHang();
                var ItemOfCartKH = lstGioHang.SingleOrDefault(m => m.MaSach == maSach);
                if(ItemOfCartKH ==  null)
                {
                    ItemCart gh = new ItemCart();
                    gh.MaSach = maSach;
                    gh.SoLuong = 1;
                    lstGioHang.Add(gh);
                }
                else
                {
                    ItemOfCartKH.SoLuong += ItemOfCartKH.SoLuong;
                }
              
                return PartialView("PartialSachNoiBat", "Home");
            }
            else
            {
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
                   
                    ItemOfCart.SoLuong += ItemOfCart.SoLuong;
                    db.SaveChanges();
                }
              
                return PartialView("PartialSachNoiBat", "Home");
            }
        }
        public ActionResult ThemSP1(string maSach)
        {
            var Sach = db.Sach.SingleOrDefault(m => m.MaSach == maSach);
            if (Sach == null)
            {
                //Trả về trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;
            }
            if (Session["TaiKhoan"] == null)
            {
                List<ItemCart> lstGioHang = LayGioHang();
                var ItemOfCartKH = lstGioHang.SingleOrDefault(m => m.MaSach == maSach);
                if (ItemOfCartKH == null)
                {
                    ItemCart gh = new ItemCart();
                    gh.MaSach = maSach;
                    gh.SoLuong = 1;
                    lstGioHang.Add(gh);
                }
                else
                {
                    ItemOfCartKH.SoLuong += ItemOfCartKH.SoLuong;
                }

                return PartialView("Index", "GioHang");
            }
            else
            {
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

                    ItemOfCart.SoLuong += ItemOfCart.SoLuong;
                    db.SaveChanges();
                }

                return RedirectToAction("Index", "GioHang");
            }
        }
        public ActionResult ThemSP2(string maSach)
        {
            var Sach = db.Sach.SingleOrDefault(m => m.MaSach == maSach);
            if (Sach == null)
            {
                //Trả về trang đường dẫn không hợp lệ
                Response.StatusCode = 404;
                return null;
            }
            if (Session["TaiKhoan"] == null)
            {
                List<ItemCart> lstGioHang = LayGioHang();
                var ItemOfCartKH = lstGioHang.SingleOrDefault(m => m.MaSach == maSach);
                if (ItemOfCartKH == null)
                {
                    ItemCart gh = new ItemCart();
                    gh.MaSach = maSach;
                    gh.SoLuong = 1;
                    lstGioHang.Add(gh);
                }
                else
                {
                    ItemOfCartKH.SoLuong += ItemOfCartKH.SoLuong;
                }

                return PartialView("Index", "GioHang");
            }
            else
            {
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

                    ItemOfCart.SoLuong += ItemOfCart.SoLuong;
                    db.SaveChanges();
                }

                return View("Index", "ChiTietSP");
            }
        }

    }
}