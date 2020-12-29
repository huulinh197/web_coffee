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
            return View(db.SanPhams);
        }
        [HttpGet]
        public ActionResult Create()
        {


            return View();
        }
    }
}