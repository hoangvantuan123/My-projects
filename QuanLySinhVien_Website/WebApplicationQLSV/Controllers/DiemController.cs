using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationQLSV.Models;

namespace WebApplicationQLSV.Controllers
{
    public class DiemController : Controller
    {
        // GET: Diem
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (DBModelQLSV db = new DBModelQLSV())
            {
                List<Diem> empList = db.Diems.ToList<Diem>();
                return Json(new { data = empList }, JsonRequestBehavior.AllowGet);
            }
        }

        // Lấy dữ liệu 
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Diem());
            else
            {
                using (DBModelQLSV db = new DBModelQLSV())
                {
                    return View(db.Diems.Where(x => x.ID == id).FirstOrDefault<Diem>());
                }
            }
            //return View(new MonHoc());  
        }
        // Tạo dữ liệu mới
        [HttpPost]
        public ActionResult AddOrEdit(Diem emp)
        {
            using (DBModelQLSV db = new DBModelQLSV())
            {

                if (emp.ID == 0)
                {
                    db.Diems.Add(emp);
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
                Diem emp = db.Diems.Where(x => x.ID == id).FirstOrDefault<Diem>();
                db.Diems.Remove(emp);
                db.SaveChanges();
                return Json(new { success = true, message = "Đã xóa thành công!" }, JsonRequestBehavior.AllowGet);
            }
        }



    }
}