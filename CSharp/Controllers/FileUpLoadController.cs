using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharp.Controllers
{
    public class FileUpLoadController : Controller
    {
        // GET: FileUpLoad
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(HttpPostedFileBase photo)
        {
            photo.SaveAs("D:\\WebApplication\\CSharp\\photos\\"+photo.FileName);

            return View();
        }



    }
}