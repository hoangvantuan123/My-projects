using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationQLSV.Models;


namespace WebApplicationQLSV.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (DBModelQLSV db = new DBModelQLSV())
            {
                List<SinhVien> empList = db.SinhViens.ToList <SinhVien>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

        // Lấy dữ liệu 
        [HttpGet]
        public ActionResult AddOrEdit( int id = 0) {
            if (id == 0)
                return View(new SinhVien());
            else
            {
                using (DBModelQLSV db = new DBModelQLSV())
                {
                    return View(db.SinhViens.Where(x => x.ID == id).FirstOrDefault<SinhVien>());
                }
            }
            //return View(new Employee());  
        }
        // Tạo dữ liệu mới
        [HttpPost]
        public ActionResult AddOrEdit(SinhVien emp)
        {
            using (DBModelQLSV db = new DBModelQLSV())
            {

                if (emp.ID == 0)
                {
                    db.SinhViens.Add(emp);
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
                SinhVien emp = db.SinhViens.Where(x => x.ID == id).FirstOrDefault<SinhVien>();
                db.SinhViens.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Đã xóa thành công!" }, JsonRequestBehavior.AllowGet);
            }
        }



    }
}