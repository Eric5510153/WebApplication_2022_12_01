using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01controller.Controllers
{
    public class _02_SimpleBindController : Controller
    {
        // GET: SimplebIND
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        //接收表單所送過來的資料
        [HttpPost]
        public ActionResult Create(string pID, string pName, int price)

        {
            ViewBag.pID = pID;
            ViewBag.pName = pName;
            ViewBag.price = price;

            return View();
        }
    
}
}