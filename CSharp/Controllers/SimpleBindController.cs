using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class SimpleBindController : Controller
    {
        // GET: SimpleBind
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        //接收表單所送過來的資料
        public ActionResult Create(string pID , string pName , int price)

        {
            return View();
        }
    }
}