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
        BookModel1 db = new BookModel1();
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
                PhanQuyen(ND.TenDN, ND.MaLoaiTK);
                Session["TaiKhoan"] = ND;
                if(ND.MaLoaiTK == "client")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect("~/Admin/AdminHome/Index");
                }
               
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
            if (db.NguoiDung.SingleOrDefault(m => m.TenDN == tv.TenDN) != null)
            {
                ViewBag.Loi = "Tên đăng nhập đã tồn tại";
                return View();
            }
            if (ModelState.IsValid)
            {
                tv.MaLoaiTK = "client";              
                db.NguoiDung.Add(tv);
                db.SaveChanges();
                Session["TaiKhoan"] = tv;
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        static string key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        public static string EncodePassword(string originalPassword)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(originalPassword);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        public static string Decode(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
        // phân quyền
        public void PhanQuyen(string TaiKhoan, string Quyen)
        {
            FormsAuthentication.Initialize();
            var ticket = new FormsAuthenticationTicket(1,
                                          TaiKhoan,
                                          DateTime.Now, 
                                          DateTime.Now.AddHours(3),
                                          false, 
                                          Quyen,
                                          FormsAuthentication.FormsCookiePath);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
            if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
            Response.Cookies.Add(cookie);
        }
        [HttpGet]
        [Authorize]
        public ActionResult ThongTinCaNhan()
        {
            NguoiDung ND = (NguoiDung)Session["TaiKHoan"];
            if (ND == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            else
            {
                var modelND = db.NguoiDung.Where(m => m.TenDN == ND.TenDN).ToList();
                ViewBag.NgaySinh = modelND[0].NgaySinh.ToString().Split(' ')[0];
                ViewBag.TenDN = modelND[0].TenDN;
                ViewBag.TenND = modelND[0].TenND;
                ViewBag.SDT = modelND[0].SDT;
                ViewBag.Email = modelND[0].Email;
                ViewBag.DC = modelND[0].DiaChi;
                ViewBag.MK = Decode(modelND[0].MatKhau);
                return View("ThongTinCaNhan", modelND);
            }
        }
        [HttpPost]
        public ActionResult CapNhat(FormCollection f)
        {
            db.Configuration.ValidateOnSaveEnabled = false;
            NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
            if (ND == null)
            {
                return RedirectToAction("DangNhap", "TaiKhoan");
            }
            else
            {
                var ThanhVien = db.NguoiDung.SingleOrDefault(m => m.TenDN == ND.TenDN);
                var pass = f["pass"];
                var mk = EncodePassword(pass);
                var tenTV = f["usr"];
                var nS = Convert.ToDateTime(f["birth"]);
                var sdt = f["tel"];
                var email = f["email"];
                var diaChi = f["addr"];
                ThanhVien.MatKhau = mk;
                ThanhVien.TenND = tenTV;
                ThanhVien.NgaySinh = nS;
                ThanhVien.SDT = sdt;
                ThanhVien.Email = email;
                ThanhVien.DiaChi = diaChi;
                db.SaveChanges();
                ND.TenND = tenTV;
            }
            return View("CapNhatThanhCong");
        }

    }
}