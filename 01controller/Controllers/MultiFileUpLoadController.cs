using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _01controller.Controllers
{
    public class MultiFileUpLoadController : Controller
    {
        // GET: MultiFileUpLoad
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase[] photos)
        {
            int index = 0;
            string subName = "";
            if (photos != null)
            {
                foreach (var photo in photos)
                {

                    if (photo.ContentLength > 0)
                    {
                        index = photo.FileName.IndexOf(".");  //抓字串.的索引位置
                        subName = photo.FileName.Substring(index + 1, 3);  //抓副檔名
                        subName = subName.ToLower();
                        if (subName == "jpg" || subName == "png")
                        {
                            photo.SaveAs(Server.MapPath("~/photos/" + photo.FileName));
                            ViewBag.Message = "上傳成功";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "格是錯誤!!";
                    }

                }

            }
            else
            {
                ViewBag.Message = "您的檔案為空";
            }

            return View();


        }


        public string ShowPhotos()
        {
            string show = "";
            DirectoryInfo d = new DirectoryInfo(Server.MapPath("~/photos/"));
            FileInfo[] files = d.GetFiles();
            foreach (FileInfo item in files)
            {
                show += "<img src='../photos/" + item.Name + "'/>";
            }
            show += "<hr><a href='/MultiFileUpLoad/Create'>點我回上一頁</a>";
            return show;
        }
















    }
}