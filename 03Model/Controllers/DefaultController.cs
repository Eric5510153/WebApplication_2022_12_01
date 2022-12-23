using _03Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _03Model.Controllers
{
    public class DefaultController : Controller
    {
        dbSutdentEntities db = new dbSutdentEntities();
        public ActionResult Index()
        {
            
            var studens = db.tStudent.ToList();


            return View(studens);
        }
        public ActionResult Create()
        {
        



        return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tStudent student)
        {

            var id = student.fStuId;
           var result= db.tStudent.Find(id);
            if(result !=null)
            {
                ViewBag.ErrMsg = "學號重複";
                return View(student);
            }

            if (ModelState.IsValid)
            {
              db.tStudent.Add(student); //把表單新增至模型
              db.SaveChanges(); //資料寫入資料庫

                return RedirectToAction("Index");
            }

          return View(student);
        }

        public ActionResult Delete(string id)
        {
            var student =db.tStudent.Find(id);
            db.tStudent.Remove(student);
            db.SaveChanges();

            return RedirectToAction("Index");

           
        }












    }
}