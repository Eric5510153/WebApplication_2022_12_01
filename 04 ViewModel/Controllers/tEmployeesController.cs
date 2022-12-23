using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _04ViewModel.Models;
using _04ViewModel.ViewModels;

namespace _04ViewModel.Controllers
{
    public class tEmployeesController : Controller
    {
        //第一件事要做的是建立dbContext
        dbEmployeeEntities db = new dbEmployeeEntities();

        //讀出tEmployee資料表,並建立成List
        public ActionResult Index(int deptId=1)
        {
            


            EmpDept emp = new EmpDept()
            {
                department = db.tDepartment.ToList(),
                employee = db.tEmployee.Where(e => e.fDepId == deptId).ToList()
            };

            ViewBag.deptName = db.tDepartment.Find(deptId).fDepName;
            ViewBag.deptId = deptId;
            return View(emp);
        }


       

        public ActionResult Create()
        {
           ViewBag.Dept= db.tDepartment.ToList();
        return View();
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tEmployee employee)
        {
            var emp = db.tEmployee.Find(employee.fEmpId);

            if (emp != null)
            {
                ViewBag.PKCheck = "員工代號重複!!";

            }

            else if (ModelState.IsValid)
            {

                db.tEmployee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index", new { deptId = employee.fDepId });
            }
            else
            {

                ViewBag.Msg = "請檢查資料填寫是否正確";
            }
                ViewBag.Dept = db.tDepartment.ToList();
                return View(employee);
            
        }

        //public ActionResult IndexOld()
        //{

        //    return View(db.tEmployee.ToList());

        //}

    






        
           public ActionResult Edit(string id)
        {
            var emp = db.tEmployee.Find(id);
            ViewBag.Dept = db.tDepartment.ToList();
            return View(emp);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(tEmployee employee)
        {

            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified; //修改狀態
                db.SaveChanges(); //存回資料庫
                return RedirectToAction("Index", new { deptId = employee.fDepId });
            }


            ViewBag.Msg = "請檢查資料填寫是否正確";
            ViewBag.Dept = db.tDepartment.ToList();
            return View(employee);

        }


        

        public ActionResult Delete(string id)
        {
           /*tEmployee tEmployee = db.tEmployee.Find(id);
            db.tEmployee.Remove(tEmployee);
            db.SaveChanges();
            return RedirectToAction("Index");
           */
              
            var emp = db.tEmployee.Find(id);
            db.tEmployee.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index", new { deptId = emp.fDepId });
             

            }




    }
}