using MCSDD26.Models;
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


    }
}
