using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_coffee.Models;

namespace web_coffee.Controllers
{
    public class HomeController : Controller
    {
        DataDataContext db = new DataDataContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category()
        {
            var listsp = from p in db.Danh_Mucs select p;
            return View(listsp);
        }
        public ActionResult Product()
        {
            var sp = from p in db.SanPhams select p;
            //var sp = from p in db.SanPhams
            //         join c in db.Danh_Mucs on p.MaDM equals c.MaDM
            //         select new
            //         {
            //             p.Gia,
            //             p.Anh,
            //             p.TenSP,
            //             p.Danh_Muc.TenDM,

            //         };
                     
            return PartialView(sp);
           
        }
            
    }
}