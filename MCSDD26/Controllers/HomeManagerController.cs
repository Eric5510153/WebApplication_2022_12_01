using MCSDD26.Models;
using MCSDD26.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MCSDD26.Controllers 
{

    public class HomeManagerController : Controller
    {   
       MCSDD26Ccontext db = new MCSDD26Ccontext();
        // GET: HomeManager
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            string password = BR.getHashPassword(vMLogin.Password);
            var user =db.Employees.Where(m=>m.Account==vMLogin.Account && m.Password == vMLogin.Password).FirstOrDefault();

           

            if (user == null)
            {
                ViewBag.ErrMsg="帳號或密碼錯誤"; 
                return View(vMLogin);

             
            }
            Session["user"] = user;
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        { 
        
          Session["user"] = null;
            return RedirectToAction("Login");
        }


        //public ActionResult Logout()
        //{

        //    Session["user"] = null;
        //    return RedirectToAction("Home");
        //}



    }

}