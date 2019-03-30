using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.SuperAdmin
{
    public partial class SuperAdmin : System.Web.UI.MasterPage
    {
        BusLib.Master.SuperAdmin objSuperAdmin = new BusLib.Master.SuperAdmin();                                             

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_ID"] == null || Session["UserType"].ToString() != "SuperAdmin")
            {
                Response.Redirect("~/AdminLab/Login.aspx");
            }
            else
            {

                lblUsername.Text = Session["SuperAdminName"].ToString();
                //Add 
                objSuperAdmin.SuperAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objSuperAdmin.GetDataset();
                ProfilePic.ImageUrl = "../ProfilePic/" + objSuperAdmin.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                //end

              
 
            }
            
        }

        

        protected void lbLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/AdminLab/Login.aspx");
        }
    }
}