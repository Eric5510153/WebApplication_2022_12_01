using _02View.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02View.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };
            string[] name = { "瑞豐夜市","新崛江商圈","六合夜市","凱旋夜市","花園夜市","大東夜市","武聖夜市"};
            string[] address = { "804高雄市左營區裕誠路南屏路", "高雄市新興區五福二路中山路", "800高雄市新興區六合二路", "80652高雄市前鎮區凱旋四路758號", "704台南市北區海安路三段533號", "701台南市東區林森路一段276號", "700台南市中西區武聖路69巷" };

            List<NightMarket> list = new List<NightMarket>();
            NightMarket nm;
            for (int i = 0; i < id.Length; i++) 
            { 
             nm =new NightMarket();
                nm.Id = id[i];
                nm.Name = name[i];
                nm.Address = address[i];

                list.Add(nm);
            
            }
            
            return View(list);
        }

        public ActionResult IndexRWD()
        {
            string[] id = { "A01", "A02", "A03", "A04", "A05", "A06", "A07" };
            string[] name = { "瑞豐夜市", "新崛江商圈", "六合夜市", "凱旋夜市", "花園夜市", "大東夜市", "武聖夜市" };
            string[] address = { "804高雄市左營區裕誠路南屏路", "高雄市新興區五福二路中山路", "800高雄市新興區六合二路", "80652高雄市前鎮區凱旋四路758號", "704台南市北區海安路三段533號", "701台南市東區林森路一段276號", "700台南市中西區武聖路69巷" };

            List<NightMarket> list = new List<NightMarket>();
            NightMarket nm;
            for (int i = 0; i < id.Length; i++)
            {
                nm = new NightMarket();
                nm.Id = id[i];
                nm.Name = name[i];
                nm.Address = address[i];

                list.Add(nm);

            }

            return View(list);
        }


        public ActionResult Create()
        {
                
            return View();


        }
        [HttpPost]
        public ActionResult Create(NightMarket nightMarket)
        {
            ViewBag.Id=nightMarket.Id;
            ViewBag.Name=nightMarket.Name;
            ViewBag.Address=nightMarket.Address;

            ViewBag.Result="夜市編號:"+nightMarket.Id+"<br>"+
                "夜市名稱:" + nightMarket.Name + "<br>"+
                "夜市地址:" + nightMarket.Address + "<br>";


            return View();


        }

        public ActionResult Display(string id)
        {
            ViewBag.ID = id;

            return View();


        }
        public ActionResult Razor()
        {
            

            return View();


        }

        public ActionResult OLDCreate()
        {

            return View();


        }

    }




}