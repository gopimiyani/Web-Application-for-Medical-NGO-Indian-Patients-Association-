using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.SuperAdmin
{
    public partial class Dashboard1 : System.Web.UI.Page
    {
        int Admin_ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
    //        BusLib.Transaction.Request objRequest = new BusLib.Transaction.Request();
            BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();
            BusLib.Common.Dashboard objDashboard = new BusLib.Common.Dashboard();
            
            BusLib.Transaction.Visitor objVisitor = new BusLib.Transaction.Visitor();

            //if (Session["User_ID"] != null)
            //{
            //    Admin_ID = Convert.ToInt16(Session["User_ID"].ToString()); 
            //}
            if (!IsPostBack)
            {

          
                //objDashboard.Admin_ID1 = Admin_ID;
                objDashboard.GetDashboardIcons_Admin();

                //Stackholders
                lblVolunteers.Text = objDashboard.Ds.Tables[0].Rows[0]["Volunteers"].ToString();
                lblHospitals.Text = objDashboard.Ds.Tables[0].Rows[0]["Hospitals"].ToString();
                lblBloodBanks.Text = objDashboard.Ds.Tables[0].Rows[0]["BloodBanks"].ToString();
                lblPharmaCompanies.Text = objDashboard.Ds.Tables[0].Rows[0]["PharmaCompanies"].ToString();
                lblDoctors.Text = objDashboard.Ds.Tables[0].Rows[0]["Doctors"].ToString();
                lblDonors.Text = objDashboard.Ds.Tables[0].Rows[0]["Donors"].ToString();
                //end

                //Others

                lblUniqueVisitor.Text = objDashboard.Ds.Tables[0].Rows[0]["NoOfVisitors"].ToString();
                //end


            }
        }
    }
}