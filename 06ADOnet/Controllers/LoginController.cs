using _06ADOnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.ComponentModel;

namespace _06ADOnet.Controllers
{
    public class LoginController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Login
        GetData gd = new GetData();
        
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            //string sql = "select * from Employees where LastName='"+ vMLogin.Account+ "' and FirstName='"+ vMLogin.Password+ "'";
            string sql = "select * from Employees where LastName=@id and FirstName=@pw";
            List<SqlParameter>list=new List<SqlParameter>
            {
               new SqlParameter("id", vMLogin.Account),
               new SqlParameter("pw", vMLogin.Password)
            };
            //SqlConnection conn=new SqlConnection(ConfigurationManager.ConnectionStrings["NorthwindConnection"].ConnectionString);

            //SqlCommand cmd = new SqlCommand(sql,conn);
            //SqlDataReader rd;



            var rd = gd.LoginQuery(sql,list);
            if (rd.HasRows || rd==null)
            {
                Session["emp"] = rd;
                rd.Close();
                return RedirectToAction("Index", "Customers");
            }
            ViewBag.ErrMsg = "Account or password Error ";
            rd.Close();
            //conn.Close();
            return View();
            //Session["emp"] = gd.LoginQuery(sql);

            /*
            conn.Open();
            rd=cmd.ExecuteReader();
            if (rd.Read())
            {
                Session["emp"] = rd[0];
                conn.Close();
                return RedirectToAction("Index", "Customers");
            }
            */

            
            
           



            
        }
       /* [HttpPost]
        public ActionResult Login(VMLogin vMLogin)
        {
            var emp = db.Employees.Where(e => e.LastName == vMLogin.Account && e.FirstName == vMLogin.Password).FirstOrDefault();

            if (emp == null)
            {
                ViewBag.ErrMsg = "Account or password Error ";
                return View();
            }

            //若帳號密碼打對,則登入成功,跳轉至後台管理首頁

            Session["emp"] = emp;
            return RedirectToAction("Index","Customers");
        }
       */
        public ActionResult Logout()
        {

            Session["emp"] = null;
            return RedirectToAction("Login");
        }




    }
}