using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using web_coffee.Models;

namespace web_coffee.Controllers
{
    public class DetailProductController : Controller
    {
        // GET: DetailProduct
        DataDataContext db = new DataDataContext();
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Detail(int? id)
        {
            //kiểm tra tham số truyền vào
            if(id== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //lấy ra sản phẩm tương ứng
            SanPham sp = db.SanPhams.SingleOrDefault(p => p.MaSP == id);
                if(sp==null)
            {
                //thông báo k tìm thấy
                return HttpNotFound();
            }
            return View(sp);
        }
    }
}