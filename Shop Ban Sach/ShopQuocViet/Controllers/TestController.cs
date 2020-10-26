using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuocViet.Models;
namespace ShopQuocViet.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(NguoiDung _user)
        {
           
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                return View();
           
        }
    }

}
