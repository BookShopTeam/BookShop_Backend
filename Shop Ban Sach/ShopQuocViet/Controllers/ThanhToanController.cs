using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuocViet.Models;
using ShopQuocViet.Controllers;
namespace ShopQuocViet.Controllers
{
    public class ThanhToanController : Controller
    {
        BookModel1 db = new BookModel1();
        // GET: ThanhToan
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
        public List<ChiTietDHSession> LayDonHang()
        {
            List<ChiTietDHSession> lstDH = Session["DonHang"] as List<ChiTietDHSession>;
            if (lstDH == null)
            {
                //Nếu session bằng  null thì khởi tạo gio hàng
                lstDH = new List<ChiTietDHSession>();
                // Gán lại giỏ hàng cho session
                Session["DonHang"] = lstDH;
            }
            // nếu giỏ hàng khác null ( đã có sản phẩm trong giỏ ) thì trả về  list
            return lstDH;
        }

        public ActionResult Index()
        {
            if(Session["TaiKhoan"] ==  null)
            {
                List<ItemCart> lstGH = LayGioHang();
                var sp = lstGH.Where(m => m.Chon == true);
                ViewBag.SLSP = sp.Count();
                var sum = 0;
                foreach(var item in sp)
                {
                    var sach = db.Sach.Where(m => m.MaSach == item.MaSach).ToList();
                    sum = sum + Convert.ToInt32(sach[0].GiaBan * item.SoLuong);
                }
                ViewBag.sum = sum;
                return View();
            }
            else
            {
                NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
                var sp = db.ChiTietDH.Where(m => m.MaND == ND.TenDN).ToList();
                ViewBag.SLSP = sp.Count();
                var sum = 0;
                foreach(var item in sp)
                {
                    sum = sum +  Convert.ToInt32(item.GiaBan*item.SoLuong);
                }
                ViewBag.sum = sum; 
                return View();
            }
        }
        public ActionResult SanPham()
        {
            if (Session["TaiKhoan"] == null)
            {
                List<ItemCart> lstGioHang = LayGioHang();
                var dh = lstGioHang.Where(m => m.Chon == true).ToList();
                if(dh != null)
                {
                    List<ChiTietDHSession> listDH = LayDonHang();
                    foreach(var item in dh)
                    {
                        ChiTietDHSession ct = new ChiTietDHSession();
                        var tenSach = db.Sach.SingleOrDefault(m => m.MaSach == item.MaSach).TenSach;
                        var giaBan = db.Sach.SingleOrDefault(m => m.MaSach == item.MaSach).GiaBan;
                        ct.maSach = item.MaSach;
                        ct.tenSach = tenSach;
                        ct.soLuong = item.SoLuong;
                        ct.giaBan = giaBan;
                        listDH.Add(ct);
                        db.SaveChanges();
                    }
                    return PartialView("SanPhamSession", listDH);
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
                var sp = db.ChiTietDH.Where(m => m.MaND == ND.TenDN).ToList();
                if(sp.Count != 0)
                {
                    return PartialView("SanPham", sp);
                }
                else
                {
                    Response.StatusCode = 404;
                    return null;
                }
               
            }
           
        }
       
        [HttpPost]
        public ActionResult DatHang(FormCollection f)
        {
            var tenKH = f["deliveryname"];
            var SDT = f["deliveryphone"];
            var email = f["deliveryemail"];
            var diaChi = f["deliveryaddress"];
            var ghiChu = f["deliveryNote"];
            var HTTT = "Thanh toán sau khi nhận hàng";
            var TrangThaiVC = "Đang vận chuyển";
            var ThanhToan = false;
            var sum = 0;
            if (Session["TaiKhoan"] == null)
            {
                List<ChiTietDHSession> ListSP = LayDonHang();
                foreach (var item in ListSP)
                {
                    sum = sum + Convert.ToInt32(item.giaBan * item.soLuong);
                }
                HoaDon hd = new HoaDon();
                hd.MaND = "VangLai";
                hd.TenKH = tenKH;
                hd.SDT = SDT;
                hd.Email = email;
                hd.DiaChi = diaChi;
                hd.HTTT = HTTT;
                hd.TrangThaiVC = TrangThaiVC;
                hd.ThanhToan = ThanhToan;
                hd.Ghichu = ghiChu;
                hd.Ngay = DateTime.Today;
                hd.TongTien = sum;
                db.HoaDon.Add(hd);
                db.SaveChanges();
                //cap nhat chi tiet hoa don

                foreach (var item in ListSP)
                {
                    CTHoaDon ct = new CTHoaDon();
                    ct.MaHD = hd.MaHD;
                    ct.MaSach = item.maSach;
                    ct.SoLuong = item.soLuong;
                    ct.DonGia = item.giaBan;
                    db.CTHoaDon.Add(ct);
                    db.SaveChanges();
                }
                // xoa san pham trong gio hang
                List<ItemCart> lstGH = LayGioHang();
                var SPGHCheck = lstGH.Where(m => m.Chon == true).ToList();
                foreach (var item in SPGHCheck)
                {
                    lstGH.Remove(item);
                    db.SaveChanges();
                }
            }
            else
            {
                NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
                var ListSP = db.ChiTietDH.Where(m => m.MaND == ND.TenDN).ToList();
                foreach (var item in ListSP)
                {
                    sum = sum + Convert.ToInt32(item.GiaBan * item.SoLuong);
                }
                HoaDon hd = new HoaDon();
                hd.MaND = ND.TenDN;
                hd.TenKH = tenKH;
                hd.SDT = SDT;
                hd.Email = email;
                hd.DiaChi = diaChi;
                hd.HTTT = HTTT;
                hd.TrangThaiVC = TrangThaiVC;
                hd.ThanhToan = ThanhToan;
                hd.Ghichu = ghiChu;
                hd.Ngay = DateTime.Today;
                hd.TongTien = sum;
                db.HoaDon.Add(hd);
                db.SaveChanges();
                //cap nhat chi tiet hoa don

                foreach (var item in ListSP)
                {
                    CTHoaDon ct = new CTHoaDon();
                    ct.MaHD = hd.MaHD;
                    ct.MaSach = item.MaSach;
                    ct.SoLuong = item.SoLuong;
                    ct.DonGia = item.GiaBan;
                    db.CTHoaDon.Add(ct);
                    db.SaveChanges();
                }
                // xoa san pham trong gio hang
                var SPGHCheck = db.GioHang.Where(m => m.MaND == ND.TenDN).Where(m => m.Chon == true).ToList();
                foreach (var item in SPGHCheck)
                {
                    db.GioHang.Remove(item);
                    db.SaveChanges();
                }
            }           
            return View();
        }
        public ActionResult Tinh()
        {
            var tinh = db.Tinh.OrderBy(x => x.TenTinh).ToList();
            return Json(tinh);
        }
        public JsonResult GetAllDistrictId(string maTinh)
        {
            var data = db.Huyen.Where(x=>x.MaTinh == maTinh).OrderBy(x => x.TenHuyen).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllWardId(string maHuyen)
        {
            var data = db.Xa.Where(x => x.MaHuyen == maHuyen).OrderBy(x => x.TenXa).ToList();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}