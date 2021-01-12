using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_coffee.Models;
using System.Data;
using System.Data.SqlClient;

namespace web_coffee.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        DataDataContext db = new DataDataContext();
        //SanPham sp = new SanPham();

        public ActionResult Index()
        {
            var model = db.SanPhams.ToList();
            return View(model);

        }
        [HttpGet]
        public ActionResult Create()
        {
            //load dropdownlist
            //ViewBag.MaDM = new SelectList(db.Danh_Mucs.OrderBy(n => n.TenDM), "MaDM", "TenDM");

            return View();
        }
        [HttpPost]
        public ActionResult Create(SanPham sp, HttpPostedFileBase Anh)
        {
            string filename = Path.GetFileName(Anh.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/images"), filename);
            Anh.SaveAs(path);
            sp.Anh = filename;
            db.SanPhams.InsertOnSubmit(sp);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Chinhsua(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }

            return View(sp);
        }
        [HttpPost]
        public ActionResult Chinhsua(SanPham model)
        {


            //db.Entry(model). = System.Data.Entity.EntityState.Modified;
            db.SubmitChanges();
            return RedirectToAction("Index");

        }


        public ActionResult Xoa(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            else
            {
                db.SanPhams.DeleteOnSubmit(sp);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View(sp);

        }


    }

    
}