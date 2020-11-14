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
        BookModel1 db = new BookModel1();
        // GET: ChiTietSP
       
        public ActionResult Index(string id)
        {
            string MaKH = "";
            if (Session["TaiKhoan"] != null)
            {
                NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
                MaKH = ND.TenDN;
            }
            ViewBag.MaND = MaKH;
            var CTSach = db.TTSach.Where(n => n.MaSach == id).ToList();
            if(CTSach.Count != 0)
            {
                ViewBag.MaCD = CTSach[0].MaCD;
                ViewBag.MaSach = id;
                var DanhGia = db.DanhGia.Where(m => m.MaSach == id).Where(m => m.MaND == MaKH).ToList();
                if(DanhGia.Count() != 0)
                {
                    ViewBag.SoSao = DanhGia[0].SoSao;
                }
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
        [ChildActionOnly]
        public ActionResult SachCungCD(string maCD)
        {
            var ListSach = db.TTSach.Where(s=> s.MaCD == maCD).ToList();
            return PartialView("~/Views/Home/PartialSachNoiBat.cshtml", ListSach);
        }
        [HttpPost]
        public ActionResult DanhGia(int star, string maSach)
        {
            NguoiDung ND = (NguoiDung)Session["TaiKhoan"];
            var DanhGiaVeSach = db.DanhGia.Where(s=>s.MaSach == maSach).Where(s=>s.MaND == ND.TenDN).ToList();
            if(DanhGiaVeSach.Count !=  0)
            {
                DanhGiaVeSach[0].SoSao = star;
            }
            else
            {
                DanhGia dg = new DanhGia();
                dg.MaND = ND.TenDN;
                dg.MaSach = maSach;
                dg.SoSao = star;
                db.DanhGia.Add(dg);
            }
            db.SaveChanges();
            var sumStar = 0;
            var Star = db.DanhGia.Where(m => m.MaSach == maSach).ToList();
            
            foreach (var item in Star)
            {
                sumStar += Convert.ToInt32(item.SoSao);
            }
            sumStar = Convert.ToInt32(sumStar / Star.Count());
               
            var Sach = db.Sach.Where(m => m.MaSach == maSach).ToList();
            Sach[0].DanhGia = sumStar;
            db.SaveChanges();
            return null;
        }
     
    }
}