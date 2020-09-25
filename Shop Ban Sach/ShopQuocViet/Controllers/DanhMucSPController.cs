using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuocViet.Models;

namespace ShopQuocViet.Controllers
{
    public class DanhMucSPController : Controller
    {
        BookShopEntities1 db = new BookShopEntities1();
        // GET: DanhMucSP
        public ActionResult Index()
        {
            var listDanhMuc = from DM in db.DanhMuc
                              select DM;
            return View(listDanhMuc.ToList());
        }
        public ActionResult PartialChuDe(string id)
        {

            var listChuDe = from CD in db.ChuDe
                            where CD.MaDM == id
                            select CD;
            return PartialView(listChuDe.ToList());
        }

    }
}