﻿using MCSDD26.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace MCSDD26.Models
{
    public class LoginCheck:ActionFilterAttribute
    {

        void LoginState(HttpContext context)
        {

            if (context.Session["user"] == null)
            {


                context.Response.Redirect("/HomeManager/Login");
                

            }
                         
        }


        public override void OnActionExecuting(ActionExecutingContext filterContex)
        {

            HttpContext context = HttpContext.Current;
            LoginState(context);
        
        }








    }
}