using _06ADOnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _06ADOnet.Controllers
{
    public class LoginController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Login
        public ActionResult Login()
        {
            

            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtAccount,string txtPassword)
        {
            var emp = db.Employees.Where(e => e.LastName == txtAccount && e.FirstName == txtPassword).FirstOrDefault();

            if (emp == null)
            {
                ViewBag.ErrMsg = "帳號或密碼有誤";
                return View();
            }

            //若帳號密碼打對,則登入成功,跳轉至後台管理首頁

            Session["emp"] = emp;
            return RedirectToAction("Index","Customers");
        }
    }
}