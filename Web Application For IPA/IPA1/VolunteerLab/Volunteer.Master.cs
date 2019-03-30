using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.VolunteerLab
{
    public partial class Volunteer : System.Web.UI.MasterPage
    {
        BusLib.Common.Notification objNotification = new BusLib.Common.Notification();
        BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();
        BusLib.Common.Alert objAlert = new BusLib.Common.Alert();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["User_ID"] == null || Session["UserType"].ToString() != "Volunteer")
            {
                Response.Redirect("~/Visitor/Login.aspx");
            }
            else
            {

                lblUsername.Text = Session["VolunteerName"].ToString();
                objRegistration.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objRegistration.GetDataSet_Select();
                ProfilePic.ImageUrl = "../ProfilePic/" + objRegistration.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();


            }
            if (!IsPostBack)
            {
                objNotification.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objNotification.GetNotification_Volunteer();
                String TotalCount = objNotification.Ds.Tables[0].Rows[0]["TotalCnt"].ToString();
                lblNotificationNumber.Text = TotalCount;
                lblNotificationNumber1.Text = TotalCount;

                objAlert.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objAlert.GetAlert_Volunteer();
                TotalCount = objAlert.Ds.Tables[0].Rows[0]["TotalCnt"].ToString();
                lblAlertNumber.Text = TotalCount;
                lblAlertNumber1.Text = TotalCount;
                
            }
        }

        protected void lbLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Visitor/Login.aspx");
        }
    }
}