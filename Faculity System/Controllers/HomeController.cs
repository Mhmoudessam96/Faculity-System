using Faculity_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Faculity_System.Controllers
{
    public class HomeController : Controller
    {
        FaculityEntities db = new FaculityEntities();
        public ActionResult Index()
        {
            List<Department> Departments = db.Departments.ToList();
            return View(Departments);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Students(int id)
        {
           List<Student> StudentsList= db.Students.Where(x => x.DPTId == id).ToList();
            return View(StudentsList);
        }

        public ActionResult Delete(int id)
        {
            var Data = db.Students.Where(a => a.Id == id).FirstOrDefault();
            return View(Data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            try
            {

                var OldData = db.Students.Include("Department").Where(a => a.Id == id).FirstOrDefault();

                db.Students.Remove(OldData);
                db.SaveChanges();
                return RedirectToAction("Students");
            }
            catch (Exception ex)
            {

               
                return View();
            }
        }
    }
}