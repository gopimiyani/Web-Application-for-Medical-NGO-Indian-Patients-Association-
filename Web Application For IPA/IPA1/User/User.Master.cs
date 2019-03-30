using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_ID"] == null)
                {
                    Response.Redirect("~/Visitor/Login.aspx");
                }
                //if (Session["User_ID"] != null && ( Session["UserType"].ToString() !="Volunteer" ||
                //    Session["UserType"].ToString() != "Hospital" 
                //    || Session["UserType"].ToString() != "BloodBank" 
                //    || Session["UserType"].ToString() != "Donor" 
                //    || Session["UserType"].ToString() != "PharmaCompany") )
                //{
                //    Response.Redirect("~/Visitor/Login.aspx");
                //}

                if (Session["User_ID"] != null && (Session["UserType"].ToString() == "Admin" 
                    ||Session["UserType"].ToString() == "Volunteer") )
              
                {
                    Response.Redirect("~/Visitor/Login.aspx");
                }
                else
                {

                    objRegistration.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                    objRegistration.GetDataSet_Select();
                    ProfilePic.ImageUrl = "/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                    lblUsername.Text = objRegistration.Ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + objRegistration.Ds.Tables[0].Rows[0]["LastName"].ToString(); ;
               //     Response.Redirect("~/User/Home.aspx");

                }
            }
        }

        protected void lbLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Visitor/Login.aspx");
        }
    }
}