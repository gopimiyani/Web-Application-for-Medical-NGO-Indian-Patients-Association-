using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.Visitor
{
    public partial class GetInvolved1 : System.Web.UI.Page
    {
        BusLib.Common.Dashboard objDashboard = new BusLib.Common.Dashboard();
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 objDashboard.GetDashboardIcons_Admin();

                //Get Involved start
               
                lblVolunteers.Text = objDashboard.Ds.Tables[0].Rows[0]["Volunteers"].ToString();
                lblHospitals.Text = objDashboard.Ds.Tables[0].Rows[0]["Hospitals"].ToString();
                lblBloodBanks.Text = objDashboard.Ds.Tables[0].Rows[0]["BloodBanks"].ToString();
                lblPharmaCompanies.Text = objDashboard.Ds.Tables[0].Rows[0]["PharmaCompanies"].ToString();
                lblDoctors.Text = objDashboard.Ds.Tables[0].Rows[0]["Doctors"].ToString();
                lblDonors.Text = objDashboard.Ds.Tables[0].Rows[0]["Donors"].ToString();
              
                //Get Involved end
            }
        }
    }
}