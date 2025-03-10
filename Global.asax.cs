﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PenPortfolio
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        void Session_Start(object sender, EventArgs e)
        {
            //Code that runs when a new session is started
            //if (Session["username"] == null)
            //{
            //    //Redirect to Welcome Page if Session is not null    
            //    Response.Redirect("~/frmLogin.aspx");
            //}

            if (Session["SystemRef"] == null)
            {
                //Redirect to Welcome Page if Session is not null    
                Response.Redirect("~/PortalLogin.aspx");
            }
      

        }
    }
}