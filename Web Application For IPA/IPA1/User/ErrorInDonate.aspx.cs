using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.User
{
    public partial class ErrorInDonate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].ToString() != "Donor")
                {
                    Response.Redirect("~/Visitor/Login.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Visitor/Login.aspx");
            }
        }
    }
}