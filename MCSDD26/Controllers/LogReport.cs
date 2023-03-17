using MCSDD26.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MCSDD26.Controllers
{
    public class LogReport : ActionFilterAttribute
    {
        



        void LogValues(RouteData routeData, HttpContext context)


        {



            var logtTimeStamp = DateTime.Now;
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var parameter = routeData.Values["id"] == null ? "N/A" : routeData.Values["id"];

            var user = "Guest";
            if (context.Session["user"] != null)
            {

                user = ((Employees)context.Session["user"]).EmployeeID + ((Employees)context.Session["user"]).EmployeeName;

            }
            else if (context.Session["member"] != null)
            {
                user = ((Members)context.Session["member"]).MemberID + ((Members)context.Session["member"]).MemberName;
            }

            StreamWriter sw = new StreamWriter(context.Server.MapPath("\\ValueLog.csv"), true, Encoding.Default);
            sw.WriteLine(logtTimeStamp + "," + controllerName + "," + actionName + "," + parameter + "," + user);
            sw.Close();

        }


        void RequestLog(HttpContext context)
        { 
        
        
        }


        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (flag)
            {
                HttpContext context = HttpContext.Current;
                LogValues(filterContext.RouteData, context);
            
            
            
            }
        }
  
    }
}