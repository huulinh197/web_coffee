using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_coffee.Models;
using System.Data;
using System.Data.SqlClient;

namespace web_coffee.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DataDataContext db = new DataDataContext();
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
       public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult dangnhap(FormCollection f)
        {
            string username = f["TenTk"].ToString();
            string pass = f["MatKhau"].ToString();
            Tai_Khoan tk = db.Tai_Khoans.SingleOrDefault(n => n.TenTK == username && n.MatKhau == pass);
            if(tk != null)
            {
                return RedirectToAction("loi", "Login");
            }
            return View();
        }

    }
}