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
    public class ConfigSession
    {
        public ConfigSession()
        { HttpContext.Current.Session.Timeout = 60; }

        public String HOME_MSG
        {
            get
            {
                if (HttpContext.Current.Session["HOME_MSG"] != null)
                {
                    return HttpContext.Current.Session["HOME_MSG"].ToString();
                }
                else
                {

                    return String.Empty;
                }
            }
            set
            {
                HttpContext.Current.Session["HOME_MSG"] = value;

            }
        }

    }
}
