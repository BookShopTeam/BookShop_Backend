using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuocViet.Models;
using PagedList;
using System.Web.Security;

namespace ShopQuocViet.Controllers
{
    public class HomeController : Controller
    {
        BookModel1 db = new BookModel1();
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult PartialSachNoiBat()
        {
            var listSachNoiBat = db.TTSach.OrderByDescending(s=>s.DanhGia).Take(8).ToList();
            return PartialView(listSachNoiBat);
        }
        [ChildActionOnly]
        public ActionResult PartialMoiNhat()
        {
            
            var listSachQuanTam = db.TTSach.OrderByDescending(s => s.NgayPhatHanh).Take(8).ToList();
            return PartialView(listSachQuanTam);
        }
        
        public ActionResult DangXuat()
        {
            Session.Clear();//remove session
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
       [HttpPost]
        public ActionResult Search(string key,int? page)
        {
           
            ViewBag.keyword = key;
          
            var listSearch = db.TTSach.SqlQuery("Select *From TTSach WHERE TenSach like N'%" + key + "%' or TacGia like N'%" + key + "%' or NXB like N'%" + key + "%'");
            ViewBag.count = listSearch.ToList().Count;
          // tao bien so trang hien tai
            int PageSize = 8;
            // tao bien so trang hien tai
            int PageNumber = (page ?? 1);
            return View(listSearch.OrderBy(s => s.DanhGia).ToPagedList(PageNumber, PageSize));
        }
        [HttpGet]
        public ActionResult Search1(string key, int? page)
        {

            ViewBag.keyword = key;

            var listSearch = db.TTSach.SqlQuery("Select *From TTSach WHERE TenSach like '%" + key + "%' or TacGia like '%" + key + "%' or NXB like '%" + key + "%'");
            ViewBag.count = listSearch.ToList().Count;
            // tao bien so trang hien tai
            int PageSize = 8;
            // tao bien so trang hien tai
            int PageNumber = (page ?? 1);
            return View("Search",listSearch.OrderBy(s => s.DanhGia).ToPagedList(PageNumber, PageSize));
        }


        [HttpPost]
        public ActionResult LayTuKhoaTimKiem(string key)
        {
            // Gọi về hàm get tìm kiếm
            return RedirectToAction("Search", new { @key = key });
        }


    }
}