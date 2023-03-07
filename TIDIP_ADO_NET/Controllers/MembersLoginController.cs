using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TIDIP_ADO_NET.Models;
using TIDIP_ADO_NET.viewModels;

namespace TIDIP_ADO_NET.Controllers
{
    public class MembersLoginController : Controller
    {
        TIDIPEntities db = new TIDIPEntities();
        // GET: MembersLogin
        public ActionResult Index()
        {
            return View();

        }
        public ActionResult MBLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MBLogin(MBLogin mBLogin)
        {
            //注意是否有做雜湊 (Hash)
            var mb=db.Members.Where(m=>m.MbAccount== mBLogin.Account && m.MbPassword == mBLogin.Password).FirstOrDefault();

            if (mb == null)
            {
                ViewBag.ErrMsg = "帳號或密碼錯誤";
                return View(mBLogin);
            }

            Session["mb"] = mb;
            return RedirectToAction("Index");

        }

    }
}