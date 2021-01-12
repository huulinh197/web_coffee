using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_coffee.Models;

namespace web_coffee.Controllers
{
    
    public class TimkiemController : Controller
    {
        DataDataContext db = new DataDataContext();
        // GET: Timkiem
        public ActionResult KQTimKiem(string TuKhoa)
        {
            var list = db.SanPhams.Where(n => n.TenSP.Contains(TuKhoa));
            return View(list.OrderBy(n => n.TenSP));
        }
    }
}