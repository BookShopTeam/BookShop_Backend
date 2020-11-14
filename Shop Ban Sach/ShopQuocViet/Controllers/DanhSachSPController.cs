using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuocViet.Models;
using PagedList;
namespace ShopQuocViet.Controllers
{
    public class DanhSachSPController : Controller
    {
        // GET: DanhSachSP
        BookModel1 db = new BookModel1();
        public ActionResult Index(string maCD,int? page)
        {
            var sach = db.ChuDe.SingleOrDefault(s=>s.MaCD == maCD);
            if(sach == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var SachChuDe = db.TTSach.Where(Sach => Sach.MaCD == maCD);
                ViewBag.TenCD = SachChuDe.ToList()[0].TenCD;
                var TenDM = db.ViewTenDM.SingleOrDefault(DM => DM.MaCD == maCD);

                ViewBag.TenDM = TenDM.TenDM;
                // tao bien so trang hien tai
                int PageSize = 8;
                // tao bien so trang hien tai
                int PageNumber = (page ?? 1);
                ViewBag.MaCD = maCD;
                return View(SachChuDe.OrderBy(s => s.DanhGia).ToPagedList(PageNumber, PageSize));
            }
          
        }
       
    }
}