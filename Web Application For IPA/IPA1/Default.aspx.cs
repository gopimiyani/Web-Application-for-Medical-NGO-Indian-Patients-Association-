using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       HttpBrowserCapabilities bc = Request.Browser;
     // Label1.Text =  (Request.ServerVariables["HTTP_X_FORWARDED_FOR"]) ?? (Request.ServerVariables["REMOTE_ADDR"]).Split(',')[0].Trim();
       
        ////Response.Write("<script>alert(ip);</script>");
        //Response.Write("<script>alert(nm);</script>");
    }
}