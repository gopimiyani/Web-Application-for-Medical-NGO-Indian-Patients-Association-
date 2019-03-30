using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.AdminLab
{
    public partial class ReportEvent : System.Web.UI.Page
    {
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        BusLib.Transaction.Task objTask = new BusLib.Transaction.Task();
        String ToDate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                txtJoinDateFrom.Attributes.Add("readonly", "readonly");
                txtJoinDateTo.Attributes.Add("readonly", "readonly");
               

            }
        }

       

        private string ConvertDate(string Date)
        {
            string Rdate = "";
            if (Date != "")
            {

                Rdate = Date.Substring(6, 4) + "-" + Date.Substring(3, 2) + "-" + Date.Substring(0, 2);
            }
            return Rdate;
        }
        



       
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtJoinDateTo.Text == "")
            {
                ToDate = DateTime.Now.ToString("dd/MM/yyyy");

            }

            else
                ToDate = txtJoinDateTo.Text;
            if (txtJoinDateFrom.Text != "" && txtJoinDateTo.Text != "")
            {
                if (Convert.ToDateTime(ConvertDate(ToDate)).CompareTo(Convert.ToDateTime(ConvertDate(txtJoinDateFrom.Text))) >= 0)
                {

                    lblcvJoinDateTo.Text = "";
                }
                else
                {

                    lblcvJoinDateTo.Text = "JoinDate(From) can't be greater than JoinDate(To)!";
                    return;


                }
            }
            Response.Redirect("~/AdminLab/ReportGetEventDetail.aspx?FromDate=" + txtJoinDateFrom.Text + "&ToDate=" + ToDate + "&Location=" + txtLocation.Text + "");
        }



        



    }
}
