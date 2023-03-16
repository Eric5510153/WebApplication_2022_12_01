using MCSDD26.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MCSDD26.Controllers
{   
    [LoginCheck(id =1)]
    public class MemberOrderController : Controller
    {
        MCSDD26Ccontext db = new MCSDD26Ccontext();
        // GET: MemberOrder
        
        public ActionResult Order()
        {
            ViewBag.ShipID = new SelectList(db.Shippers, "ShipID", "ShipVia");
            ViewBag.PayTypeID = new SelectList(db.PayTypes, "PayTypeID", "PayTypeName");
            ViewBag.OrderDate = DateTime.Today.ToShortDateString(); //現在時間
            int endNum = db.Employees.Count();
            

            Random r = new Random();

            ViewBag.Employee = db.Employees.OrderBy(m => m.EmployeeID).Skip(r.Next(endNum)).Take(1).FirstOrDefault();


            return View();
        }


        
        [HttpPost]
        public ActionResult Order(Orders orders,string cartData)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Orders.Add(orders);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

           List<SqlParameter> list = new List<SqlParameter>
            {

                  new SqlParameter("ShipName",orders.ShipName),
                  new SqlParameter("ShipAddress",orders.ShipAddress),
                  new SqlParameter("ShipID",orders.ShipID),
                  new SqlParameter("PayTypeID",orders.PayTypeID),
                  new SqlParameter("MemberID", ((Members)Session["member"]).MemberID ),
                  new SqlParameter("EmployeeID",orders.EmployeeID),
                  new SqlParameter("cart",cartData)
           



            };
            setData sd = new setData();
            sd.executeSqlBySP("addOrders", list);
            TempData["cartFlag"] = "OK";

            return RedirectToAction("MyOrderList");
        }
        public ActionResult MyOrderList()
        {

            var memID = ((Members)Session["member"]).MemberID;
            var orders = db.Orders.Where(m => m.MemberID == memID).ToList();

            return View(orders);
        }



    }
}