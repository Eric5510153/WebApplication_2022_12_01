using MCSDD26.Models;
using MCSDD26.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCSDD26.Controllers
{
    public class HomeController : Controller
    {
        MCSDD26Ccontext db = new MCSDD26Ccontext();

        [HandleError(View = "Error")]
        public ActionResult ExceptionDemo()
        {
            int i = 0;

            int j = 100 / i;

            return View();
        }
        public ActionResult Test()
        {
            throw new NotImplementedException();
        }
        public ActionResult Index()
        {
            var products = db.Products.Where(p => p.Discontinued == false).ToList();

            return View(products);
        }

        public ActionResult Display(string id)
        {

            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            var products = db.Products.Find(id);
            if(products==null)
                return HttpNotFound();
            return View(products);
        }



        public ActionResult MyCart()
        {

            return View();
        
        }

        //-------------------------------------------登入功能-----------------------------------------
        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            string password = BR.getHashPassword(vMLogin.Password);

            var user = db.Members.Where(m => m.Account == vMLogin.Account && m.Password == vMLogin.Password).FirstOrDefault();



            if (user == null)
            {
                ViewBag.ErrMsg = "帳號或密碼錯誤";
                return View(vMLogin);


            }
            Session["member"] = user;
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {

            Session["member"] = null;
            return RedirectToAction("Login");
        }



    }
}
