using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Web.Mvc;
using System.Web.Security;
using System.Text;
using ShopQuocViet.Models;

namespace ShopQuocViet.Controllers
{
    public class TaiKhoanController : Controller
    {
        BookModel db = new BookModel();
        // GET: DangNhap
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f, NguoiDung user)
        {
            var sTenDN = f["TenDN"].ToString();
            var sMatKhau = EncodePassword(f["MatKhau"].ToString());

            NguoiDung ND = db.NguoiDung.SingleOrDefault(n => n.TenDN == sTenDN && n.MatKhau == sMatKhau);
            if (ND != null)
            {
                Session["TaiKhoan"] = ND;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.loi = "Sai tên đăng nhập hoặc mật khẩu";
                return PartialView("DangNhap");
            }
            
        }
     
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(FormCollection f,NguoiDung tv)
        {
            tv.MatKhau = EncodePassword(tv.MatKhau);
            tv.ReMatKhau = EncodePassword(tv.ReMatKhau);
            if (ModelState.IsValid)
            {
                tv.MaLoaiTK = "client";              
                db.NguoiDung.Add(tv);
                db.SaveChanges();
                Session["TaiKhoan"] = tv;
                return RedirectToAction("Index", "Home");
            }
                   
            if (db.NguoiDung.SingleOrDefault(m => m.TenDN == tv.TenDN) != null)
            {
                ViewBag.Loi = "Tên đăng nhập đã tồn tại";
            }
            return View();
        }

        public static string EncodePassword(string originalPassword)
        {
           
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(originalPassword);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }
        // phân quyền
        public void PhanQuyen(string TaiKhoan, string Quyen)
        {
            FormsAuthentication.Initialize();
            var ticket = new FormsAuthenticationTicket(1,
                                          TaiKhoan, //user
                                          DateTime.Now, //Thời gian bắt đầu
                                          DateTime.Now.AddHours(3), //Thời gian kết thúc
                                          false, //Ghi nhớ?
                                          Quyen, // "DangKy,QuanLyDonHang,QuanLySanPham"
                                          FormsAuthentication.FormsCookiePath);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
            Response.Cookies.Add(cookie);
        }
    }
}