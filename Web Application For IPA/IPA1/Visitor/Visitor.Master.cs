using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace IPA1.Visitor
{
    public partial class Visitor : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_ID"] != null && (
                    Session["UserType"].ToString() == "Hospital" || Session["UserType"].ToString() == "BloodBank"
                    || Session["UserType"].ToString() == "Donor" || Session["UserType"].ToString() == "PharmaCompany") )
                {
                    Response.Redirect("~/User/Home.aspx");
                }
            }
        }

        
    }
}