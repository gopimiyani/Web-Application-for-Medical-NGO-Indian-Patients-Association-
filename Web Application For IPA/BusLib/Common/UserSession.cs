using System;
using System.Collections.Generic;
using System.Web;
using System.Linq;
using System.Text;

namespace BusLib
{
    /// <summary>
    /// Summary description for UserSession
    /// </summary>
    public class UserSession
    {
        public UserSession()
        { HttpContext.Current.Session.Timeout = 60; }

        public String LOGINNAME
        {
            get
            {
                if (HttpContext.Current.Session["LOGINNAME"] != null)
                {
                    return HttpContext.Current.Session["LOGINNAME"].ToString();
                }
                else
                {

                    return String.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["LOGINNAME"] = value;
             
            }
        }
        public String PERCPERCUST
        {
            get
            {
                if (HttpContext.Current.Session["PERCPERCUST"] != null)
                {
                    return HttpContext.Current.Session["PERCPERCUST"].ToString();
                }
                else
                {
                    return String.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["PERCPERCUST"] = value;
            }
        }
        public String EMAILID
        {
            get
            {

                if (HttpContext.Current.Session["EMAILID"] != null)
                {
                    return HttpContext.Current.Session["EMAILID"].ToString();
                }
                else
                {

                    return String.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["EMAILID"] = value;
            }
        }
        public String SALESPERSON
        {
            get
            {

                if (HttpContext.Current.Session["SALESPERSON"] != null)
                {
                    return HttpContext.Current.Session["SALESPERSON"].ToString();
                }
                else
                {

                    return String.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["SALESPERSON"] = value;
            }
        }

        public String SALESPERSONEMAIL
        {
            get
            {

                if (HttpContext.Current.Session["SALESPERSONEMAIL"] != null)
                {
                    return HttpContext.Current.Session["SALESPERSONEMAIL"].ToString();
                }
                else
                {

                    return String.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["SALESPERSONEMAIL"] = value;
            }
        }
    }
}
