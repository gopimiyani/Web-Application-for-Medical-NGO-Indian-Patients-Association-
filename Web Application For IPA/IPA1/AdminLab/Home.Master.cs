using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1
{
    public partial class Home : System.Web.UI.MasterPage
    {
        BusLib.Common.Notification objNotification = new BusLib.Common.Notification();
        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();                                        

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User_ID"] == null || Session["UserType"].ToString() != "Admin")
            {
                Response.Redirect("~/AdminLab/Login.aspx");
            }
            else
            {

                lblUsername.Text = Session["AdminName"].ToString();
                //Add 
                objAdmin.Admin_ID1=Convert.ToInt16(Session["User_ID"].ToString());
                objAdmin.GetDataset();
                ProfilePic.ImageUrl = "../ProfilePic/" + objAdmin.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                //end
 
            }
            if (!IsPostBack)
            {
                if (Session["User_ID"] != null)
                {
                    objNotification.Admin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                }
                                 
                objNotification.GetNotification_Admin();
                String TotalCount = objNotification.Ds.Tables[0].Rows[0]["TotalCnt"].ToString();
                if (TotalCount=="0")
                {
                    lblNotificationNumber1.Text = " no ";
                    lblNotificationNumber.Text = "";
                }
                else
                {
                    lblNotificationNumber.Text = TotalCount;
                    lblNotificationNumber1.Text = TotalCount;
                }
                
            }
        }

        protected void lbNotification_Click(object sender, EventArgs e)
        {

        }

        protected void lbLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/AdminLab/Login.aspx");
        }
    }
}