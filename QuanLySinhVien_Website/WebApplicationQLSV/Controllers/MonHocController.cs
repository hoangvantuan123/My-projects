using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationQLSV.Models;

namespace WebApplicationQLSV.Controllers
{
    public class MonHocController : Controller
    {
        // GET: MonHoc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetData()
        {
            using (DBModelQLSV db = new DBModelQLSV())
            {
                List<MonHoc> empList = db.MonHocs.ToList<MonHoc>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

        // Lấy dữ liệu 
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new MonHoc());
            else
            {
                using (DBModelQLSV db = new DBModelQLSV())
                {
                    return View(db.MonHocs.Where(x => x.ID == id).FirstOrDefault<MonHoc>());
                }
            }
         
        }
        // Tạo dữ liệu mới
        [HttpPost]
        public ActionResult AddOrEdit(MonHoc emp)
        {
            using (DBModelQLSV db = new DBModelQLSV())
            {

                if (emp.ID == 0)
                {
                    db.MonHocs.Add(emp);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(emp).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (DBModelQLSV db = new DBModelQLSV())
            {
                MonHoc emp = db.MonHocs.Where(x => x.ID == id).FirstOrDefault<MonHoc>();
                db.MonHocs.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Đã xóa thành công!" }, JsonRequestBehavior.AllowGet);
            }
        }



    }
}