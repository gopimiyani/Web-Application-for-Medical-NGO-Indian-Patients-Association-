using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.SuperAdmin
{
    public partial class ReportTask : System.Web.UI.Page
    {
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        BusLib.Transaction.Task objTask = new BusLib.Transaction.Task();
        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();
        String ToDate = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtJoinDateFrom.Attributes.Add("readonly", "readonly");
                txtJoinDateTo.Attributes.Add("readonly", "readonly");
                //ddlState.Items.Clear();
                //ddlCity.Items.Clear();
                FillddlAdminName();
                //FillddlName();

                // FillddlSH();
                //FillddlState();
                //FillddlCity();

            }
        }

        void FillddlAdminName()
        {
            objAdmin.GetDataSet_GetAName();
            ddlAName.Items.Add(new ListItem("--Select Name | ID--", ""));
            ddlAName.DataSource = objAdmin.Ds.Tables[0];
            ddlAName.DataTextField = "FirstName";
            ddlAName.DataValueField = "Admin_ID";
            ddlAName.SelectedIndex = 0;
            ddlAName.DataBind();

        }


        //void FillddlName()
        //{
        //    objTask.GetDataSet_GetVName();
        //    ddlVName.Items.Add(new ListItem("--Select Name | ID--", ""));
        //    ddlVName.DataSource = objTask.Ds.Tables[0];
        //    ddlVName.DataTextField = "Name";
        //    ddlVName.DataValueField = "User_ID";
        //    ddlVName.SelectedIndex = 0;
        //    ddlVName.DataBind();

        //}

        private string ConvertDate(string Date)
        {
            string Rdate = "";
            if (Date != "")
            {

                Rdate = Date.Substring(6, 4) + "-" + Date.Substring(3, 2) + "-" + Date.Substring(0, 2);
            }
            return Rdate;
        }
        //void FillddlCity()
        //{
        //    ddlCity.AppendDataBoundItems = true;
        //    ddlCity.Items.Add(new ListItem("--Select City--", "--Select City--"));
        //    ddlCity.SelectedIndex = 0;
        //    if (ddlState.SelectedIndex != 0)
        //    {
        //        objCity.StateID1 = Convert.ToInt16(ddlState.SelectedValue);
        //        objCity.GetCity();
        //        if (objCity.Ds.Tables[0].Rows.Count > 0)
        //        {
        //            ddlCity.DataSource = objCity.Ds.Tables[0];
        //            ddlCity.DataTextField = "CityName";
        //            ddlCity.DataValueField = "City_ID";
        //            ddlCity.DataBind();

        //        }

        //    }



        //}



        //void FillddlState()
        //{
        //    objState.GetDataSet("");
        //    ddlState.AppendDataBoundItems = true;
        //    ddlState.Items.Add(new ListItem("--Select State--", "--Select State--"));
        //    ddlState.DataSource = objState.Ds.Tables[0];
        //    ddlState.DataTextField = "StateName";
        //    ddlState.DataValueField = "State_ID";
        //    ddlState.SelectedIndex = 0;
        //    ddlState.DataBind();
        //}

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
                    lblcvJoinDateTo.Visible = false;
                }
                else
                {

                    lblcvJoinDateTo.Visible = true;
                    return;
                }
            }

           
           
            Response.Redirect("~/SuperAdmin/ReportTaskDetail.aspx?WorkingAdmin_ID=" + ddlAName.SelectedValue + "&FromDate=" + txtJoinDateFrom.Text + "&ToDate=" + ToDate + "&Status=" + ddlStatus.SelectedItem.ToString() + "");
        }



        //protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //    ddlState.Items.Clear();
        //    ddlCity.Items.Clear();
        //    FillddlCity();
        //}

        //protected void cvCity_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    if (ddlCity.Text == "--Select City--")
        //    {
        //        cvCity.ErrorMessage = "Required";

        //    }

        //    else
        //    {
        //        cvCity.ErrorMessage = "";
        //    }
        //}

        //protected void cvState_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    if (ddlState.Text == "--Select State--")
        //    {
        //        cvState.ErrorMessage = "Required";

        //    }

        //    else
        //    {
        //        cvState.ErrorMessage = "";
        //    }
        //}

        protected void ddlVName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



    }
}
