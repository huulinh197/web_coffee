using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_coffee.Models;

namespace web_coffee.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        DataDataContext db = new DataDataContext();

        public ActionResult Index()
        {
            var model = db.SanPhams.ToList();
            return View(db.SanPhams);
        }
        [HttpGet]
        public ActionResult Create()
        {
            //load dropdownlist
            ViewBag.MaDM = new SelectList(db.Danh_Mucs.OrderBy(n => n.TenDM), "MaDM", "TenDM");
            return View();
        }
    }
}