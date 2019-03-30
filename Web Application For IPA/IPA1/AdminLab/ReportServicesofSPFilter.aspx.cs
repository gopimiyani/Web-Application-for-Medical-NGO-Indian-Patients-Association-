using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.AdminLab
{
    public partial class ReportServicesofSP : System.Web.UI.Page
    {
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        //  BusLib.Transaction.Report objReport = new BusLib.Transaction.Report();
        BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();
        String PStatus;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlselecttype.Items.Clear();
                ddlState.Items.Clear();
                ddlCity.Items.Clear();
                FillddlState();
                FillddlCity();
                FillddlSH();

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
            if (ddlState.SelectedIndex != 0)
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
            ddlselecttype.Items.Remove(new ListItem("Volunteer", "1"));
            ddlselecttype.Items.Remove(new ListItem("Donor", "2"));
            ddlselecttype.Items.Remove(new ListItem("Doctor", "6"));
           
            ddlselecttype.Items.Remove(new ListItem("NGO", "8"));
            ddlselecttype.Items.Remove(new ListItem("Media", "9"));



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



        void FillddlSHName()
        {

            ddlName.Items.Clear();
            ddlName.AppendDataBoundItems = true;
            ddlName.Items.Add(new ListItem("------- Select Name -------", ""));

            if (ddlselecttype.SelectedIndex != 0)
            {
                objRegistration.GetDataSet_FillSHName(ddlselecttype.SelectedItem.ToString());

                if (objRegistration.Ds.Tables.Count != 0)
                {
                    if (objRegistration.Ds.Tables[0].Rows.Count > 0)
                    {
                        ddlName.DataSource = objRegistration.Ds.Tables[0];
                        ddlName.DataTextField = "Name";
                        ddlName.DataValueField = "User_ID";
                        ddlName.DataBind();
                    }
                }

            }

            else
            {
                ddlName.SelectedIndex = 0;

            }
        }




        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (Convert.ToDateTime(ConvertDate(txtJoinDateTo.Text)).CompareTo(Convert.ToDateTime(ConvertDate(txtJoinDateFrom.Text))) >= 0)
            //{
            //    lblcvJoinDateTo.Visible = false;
            //}
            //else
            //{

            //    lblcvJoinDateTo.Visible = true;
            //    return;
            //}
            
            //if (ddlPStatus.SelectedItem.ToString() == "UnPaid")
            //{
            //    PStatus = "0";
            //}
            //if(ddlPStatus.SelectedItem.ToString() == "Paid")
            //{
            //    PStatus = "1";
            //}

            //if (ddlPStatus.SelectedItem.ToString() == "--Select Status--")
            //{
            //    PStatus = "0";
            //}

            if (ddlselecttype.SelectedItem.ToString() == "--Select User Type--")
            {
                cvddlselecttype.Text = "*";
                return;
            }

            else
            {
                cvddlselecttype.Text = "";
            }

            Response.Redirect("~/AdminLab/ReportServicesofSPDetail.aspx?UserType=" + ddlselecttype.SelectedItem.Text +  "&Pincode=" + txtPinCode.Text + "&State=" + ddlState.SelectedItem.ToString() + "&City=" + ddlCity.SelectedItem.ToString() + "&User_ID=" + ddlName.SelectedValue + "&PStatus=" + ddlPStatus.SelectedValue + "");
        }

       

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.Items.Clear();
            FillddlCity();
        }

        protected void ddlselecttype_SelectedIndexChanged(object sender, EventArgs e)
        {

            FillddlSHName();
            if (ddlselecttype.SelectedValue != "")
            {
                cvddlselecttype.Text = "";
            }

        }


        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
        //    if (ddlName.SelectedIndex == 0)
        //    {
        //        lblcvName.Text = "Please choose User Name";
        //        return;
        //    }
        //    else
        //    {
        //        lblcvName.Text = "";

        //    }
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



    }
}
