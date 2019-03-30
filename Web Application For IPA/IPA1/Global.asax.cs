using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace IPA1
{
    public class Global : System.Web.HttpApplication
    {
        public static int user_count;
        BusLib.Transaction.Visitor objVisitor = new BusLib.Transaction.Visitor();

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
      //      Application["user_Count"] = user_count; 
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
          //  user_count = Convert.ToInt32(Application["user_Count"]); 
           // Application["user_Count"] = user_count + 1;

          //  Response.Write("<br/> " + HttpContext.Current.Request.ApplicationPath);
            if (Session["User_ID"] == null)
            {
                String UrlMainPath = HttpContext.Current.Request.ApplicationPath;

                if (UrlMainPath == "/AdminLab" || UrlMainPath == "/SuperAdmin")
                {
                    Response.Redirect("~/AdminLab/Login.aspx");
                }

                if (UrlMainPath == "/User" || UrlMainPath == "/VolunteerLab")
                {
                    Response.Redirect("~/Visitor/Login.aspx");
                }
              
                
            }

            

            //if (Session["User_ID"] == null)
            //{
            //    Response.Redirect("~/Visitor/Login.aspx");
            //}

            objVisitor.GetDataSet();
            user_count = Convert.ToInt16(objVisitor.Ds.Tables["Count"].Rows[0]["NoOfVisitors"].ToString());
            objVisitor.NoOfVisitors1 = user_count + 1;
            objVisitor.Update();
            objVisitor.GetDataSet();
            user_count = Convert.ToInt16(objVisitor.Ds.Tables["Count"].Rows[0]["NoOfVisitors"].ToString());
           

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
