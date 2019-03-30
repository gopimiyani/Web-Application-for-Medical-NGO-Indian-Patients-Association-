using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.AdminLab
{
    public partial class Report_RegistrationFilter : System.Web.UI.Page
    {
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        String ToDate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtJoinDateFrom.Attributes.Add("readonly", "readonly");
                txtJoinDateTo.Attributes.Add("readonly", "readonly");
                ddlselecttype.Items.Clear();
                ddlState.Items.Clear();
                ddlCity.Items.Clear();
                FillddlSH();
                FillddlState();
                FillddlCity();
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
        void FillddlCity()
        {
            ddlCity.AppendDataBoundItems = true;
            ddlCity.Items.Add(new ListItem("--Select City--", "--Select City--"));
            ddlCity.SelectedIndex = 0;
            if (ddlState.SelectedIndex!=0)
            {
                objCity.StateID1 = Convert.ToInt16(ddlState.SelectedValue);
                objCity.GetCity();
                if (objCity.Ds.Tables[0].Rows.Count > 0)
                {
                    ddlCity.DataSource = objCity.Ds.Tables[0];
                    ddlCity.DataTextField = "CityName";
                    ddlCity.DataValueField = "City_ID";
                    ddlCity.DataBind();      

                }
                
            }
           


        }

        void FillddlSH()
        {
            objSH.GetDataSet("");
            ddlselecttype.AppendDataBoundItems = true;
            ddlselecttype.Items.Add(new ListItem("--Select User Type--", "--Select User Type--"));
            ddlselecttype.DataSource = objSH.Ds.Tables[0];
            ddlselecttype.DataTextField = "Name";
            ddlselecttype.DataValueField = "StakeHolder_ID";
            ddlselecttype.DataBind();
           

        }

        void FillddlState()
        {
            objState.GetDataSet("");
            ddlState.AppendDataBoundItems = true;
            ddlState.Items.Add(new ListItem("--Select State--", "--Select State--"));
            ddlState.DataSource = objState.Ds.Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "State_ID";
            ddlState.SelectedIndex = 0;
            ddlState.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtJoinDateTo.Text == "")
            {
                ToDate = DateTime.Now.ToString("dd/MM/yyyy");

            }

            else
                ToDate = txtJoinDateTo.Text;
            if (txtJoinDateFrom.Text != "" && ToDate != "")
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
            Response.Redirect("~/AdminLab/ReportGetUserDetail.aspx?UserType=" + ddlselecttype.SelectedItem + "&FromDate=" +txtJoinDateFrom.Text+ "&ToDate="+ToDate+ "&Pincode=" +txtPinCode.Text+ "&State=" +ddlState.SelectedItem.ToString()+ "&City=" +ddlCity.SelectedItem.ToString()+ "");
        }

        protected void cvddlselecttype_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlselecttype.Text == "--Select User Type--")
            {
                cvddlselecttype.ErrorMessage = "Required";

            }

            else
            {
                cvddlselecttype.ErrorMessage = "";
            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    ddlState.Items.Clear();
            ddlCity.Items.Clear();
                FillddlCity();
        }

        protected void cvCity_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlCity.Text == "--Select City--")
            {
                cvCity.ErrorMessage = "Required";

            }

            else
            {
                cvCity.ErrorMessage = "";
            }
        }

        protected void cvState_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlState.Text == "--Select State--")
            {
                cvState.ErrorMessage = "Required";

            }

            else
            {
                cvState.ErrorMessage = "";
            }
        }

       

    }
}
