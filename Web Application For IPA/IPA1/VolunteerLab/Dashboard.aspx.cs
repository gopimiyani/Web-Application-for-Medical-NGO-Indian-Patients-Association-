using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.VolunteerLab
{
    public partial class Dashboard : System.Web.UI.Page
    {
        BusLib.Common.Dashboard objDashboard = new BusLib.Common.Dashboard();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["User_ID"]!=null)
                {
                    objDashboard.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
               
                }
                objDashboard.GetDashboardIcons_Volunteer();

                //Tasks

                lblPendingTasks.Text = objDashboard.Ds.Tables[0].Rows[0]["PendingTasks"].ToString();
                lblInProgressedTasks.Text = objDashboard.Ds.Tables[0].Rows[0]["InProgressedTasks"].ToString();
                lblCompletedTasks.Text = objDashboard.Ds.Tables[0].Rows[0]["CompletedTasks"].ToString();

                //end

            }
        }

    }
}
