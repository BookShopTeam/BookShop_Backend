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
        BookModel1 db = new BookModel1();

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
          
            if (Session["TaiKhoan"] == null)
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
                List<ItemCart> lstGioHang = LayGioHang();
                var ND = (NguoiDung)Session["TaiKhoan"];
                if (lstGioHang.Count() == 0)
                {
                    
                }
                else
                {
                    GioHang sGH = new GioHang();
                    foreach(var item in lstGioHang)
                    {
                        sGH.MaND = ND.TenDN;
                        var SachOfGio = db.GioHang.Where(m => m.MaSach == item.MaSach).Where(m => m.MaND == sGH.MaND).ToList();
                        if (SachOfGio.Count() == 0)
                        {
                            sGH.MaSach = item.MaSach;
                            sGH.SoLuong = item.SoLuong;
                            db.GioHang.Add(sGH);
                        }
                        else
                        {
                            SachOfGio[0].SoLuong += item.SoLuong;
                        }
                       
                        db.SaveChanges();
                    }
                    Session["GioHang"] = null;
                }
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

                return PartialView("GHKhachVangLai",lstGioHang);
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
                var gioHang = db.GioHang.Where(m => m.MaND == ND.TenDN).ToList();
                return PartialView("Index", gioHang);
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

                return PartialView("GHKhachVangLai", "GioHang");
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
        [HttpGet]
        public ActionResult CheckItem(string maSach)
        {
            if(Session["TaiKhoan"] == null)
            {
                List<ItemCart> lstGH = LayGioHang();
                var item = lstGH.Where(m => m.MaSach == maSach).ToList();
                if(item != null)
                {
                    return PartialView("CheckItemSession", item);
                }
                else
                {
                    Response.StatusCode = 404;
                    return null;
                }
            }
            else
            {
                NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
                var item = db.GioHang.Where(m => m.MaSach == maSach && m.MaND == ND.TenDN).ToList();
                if (item != null)
                {
                    return PartialView("CheckItem", item);
                }
                else
                {
                    Response.StatusCode = 404;
                    return null;
                }
            }
          
           
        }
        [HttpPost]
        public ActionResult check(string maSach)
        {
            if(Session["TaiKhoan"] == null)
            {
                List<ItemCart> lstGH = LayGioHang();
                var item = lstGH.Where(m => m.MaSach == maSach).ToList();
                if(item != null)
                {
                    item[0].Chon = true;
                    db.SaveChanges();
                    return null;
                }
                else
                {
                    Response.StatusCode = 404;
                    return null;
                }
            }
            else
            {
                NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
                var item = db.GioHang.Where(m => m.MaSach == maSach && m.MaND == ND.TenDN).ToList();
                if (item != null)
                {
                    item[0].Chon = true;
                    db.SaveChanges();
                    return null;
                }
                else
                {
                    Response.StatusCode = 404;
                    return null;
                }

            }

        }
        [HttpPost]
        public ActionResult unCheck(string maSach)
        {
            if (Session["TaiKhoan"] == null)
            {
                List<ItemCart> lstGH = LayGioHang();
                var item = lstGH.Where(m => m.MaSach == maSach).ToList();
                if (item != null)
                {
                    item[0].Chon = true;
                    db.SaveChanges();
                    return null;
                }
                else
                {
                    Response.StatusCode = 404;
                    return null;
                }
            }
            else
            {
                NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
                var item = db.GioHang.Where(m => m.MaSach == maSach && m.MaND == ND.TenDN).ToList();
                if (item != null)
                {
                    item[0].Chon = false;
                    db.SaveChanges();
                    return null;
                }
                else
                {
                    Response.StatusCode = 404;
                    return null;
                }
            }
        }
        [HttpPost]
        public ActionResult upDate(string maSach, int soluong)
        {
            if (Session["TaiKhoan"] != null)
            {
                NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
                var item = db.GioHang.Where(m => m.MaSach == maSach && m.MaND == ND.TenDN).ToList();
                if (item != null)
                {
                    item[0].SoLuong = soluong;
                    db.SaveChanges();
                    return null;
                }
                else
                {
                    Response.StatusCode = 404;
                    return null;
                }
            }
            else
            {
                List<ItemCart> lstGioHang = LayGioHang();
                var item = lstGioHang.Where(m => m.MaSach == maSach).ToList();
                if (item != null)
                {
                    item[0].SoLuong = soluong;
                    db.SaveChanges();
                    return null;
                }
                else
                {
                    Response.StatusCode = 404;
                    return null;
                }

            }
           

        }
        public string SoLuongLoaiSach()
        {
            if (Session["TaiKhoan"] == null)
            {
                List<ItemCart> lstGioHang = LayGioHang();
                var sl = lstGioHang.Count();
                return sl.ToString();
            }
            else
            {
                NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
                var sl = db.GioHang.Where(m=>m.MaND == ND.TenDN).Count();
                return sl.ToString();
            }
        }
        [Authorize]
        public ActionResult DonHang()
        {
            if(Session["TaiKhoan"] == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
            var lstDonHang = db.HoaDon.Where(m => m.MaND == ND.TenDN).ToList();
            return View(lstDonHang);
        }
     
        public ActionResult ChiTietDH(int MaHD)
        {
               
            var lstDonHang = db.ViewChiTietHD.Where(m => m.MaHD == MaHD).ToList();
            return View(lstDonHang);
        }
           
           
        
        public ActionResult TheoDoiDonHang()
        {
            return View("TimKiemDonHang");
        }
        [HttpPost]
        public ActionResult TimKiemDH(FormCollection f)
        {
            try
            {
                var MaHD = Convert.ToInt32(f["search"]);
                var DH = db.HoaDon.Where(m => m.MaHD == MaHD).ToList();
                return View("DonHang", DH);
            }
            catch
            {
                ViewBag.MaDH = f["search"];
                return View("DonHangTrong");
            }          
        }

    }
}