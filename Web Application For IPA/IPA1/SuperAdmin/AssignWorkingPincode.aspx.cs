using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.SuperAdmin
{
    public partial class AssignWorkingPincode : System.Web.UI.Page
    {
        BusLib.Master.PincodeMast objPincode = new BusLib.Master.PincodeMast();
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblSelectPincode.Visible = false;
                FillddlAdminName();

                FillddlState();
                FillddlCity();
            }
        }

        void FillddlAdminName()
        {
            objAdmin.GetDataSet_GetAdminDetail();
            ddlAdminName.AppendDataBoundItems = true;
            ddlAdminName.Items.Add(new ListItem("--Select Name | ID--", ""));
            ddlAdminName.DataSource = objAdmin.Ds.Tables[0];
            ddlAdminName.DataTextField = "FirstName";
            ddlAdminName.DataValueField = "Admin_ID";
            ddlAdminName.SelectedIndex = 0;
            ddlAdminName.DataBind();

        }

        void FillddlState()
        {
            objState.GetDataSet("");
            ddlState.AppendDataBoundItems = true;
            ddlState.Items.Add(new ListItem("--Select State--", ""));

            ddlState.DataSource = objState.Ds.Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "State_ID";
            ddlState.SelectedIndex = 0;
            ddlState.DataBind();
            //if (objState.Ds.Tables[0].Rows.Count > 0)
            //{
            //    ddlState.SelectedIndex = 0;

            //}

        }

        void FillddlCity()
        {
            ddlCity.AppendDataBoundItems = true;
            ddlCity.Items.Add(new ListItem("--Select City--", ""));

            if (ddlState.SelectedIndex != 0)
            {
                objCity.StateID1 = Convert.ToInt16(ddlState.SelectedValue);

                objCity.GetCity();

                ddlCity.DataSource = objCity.Ds.Tables[0];
                ddlCity.DataTextField = "CityName";
                ddlCity.DataValueField = "City_ID";
                ddlCity.DataBind();
                ddlCity.SelectedIndex = 0;

            }

            //if (objCity.Ds.Tables[0].Rows.Count > 0)
            //{

            // }


        }

        void FillcblPincode()
        {
            //if (ddlCity.SelectedIndex != 0 && ddlState.SelectedIndex != 0)
            //{
            cblPincode.Items.Clear();
            if (ddlCity.SelectedIndex != 0 && ddlState.SelectedIndex != 0)
            {
                objPincode.State_ID1 = Convert.ToInt16(ddlState.SelectedValue);
                objPincode.City_ID1 = Convert.ToInt16(ddlCity.SelectedValue);

                objPincode.GetDataSet_GetPincode();

                for (int i = 0; i < objPincode.Ds.Tables[0].Rows.Count; i++)
                {
                    cblPincode.Items.Add(new ListItem(objPincode.Ds.Tables[0].Rows[i]["PinCode"].ToString(), objPincode.Ds.Tables[0].Rows[i]["PinCode"].ToString()));

                }

            }
        }


        protected void btnAssign_Click(object sender, EventArgs e)
        {

            if (ddlAdminName.SelectedIndex == 0)
            {
                lblcvAdminName.Text = "Choose Admin Name";
                return;
            }
            else
            {
                lblcvAdminName.Text = "";
            }

            if (ddlState.SelectedIndex == 0)
            {
                lblcvState.Text = "please choose state ";
                return;
            }
            else
            {
                lblcvState.Text = "";
            }

            if (ddlCity.SelectedIndex == 0)
            {
                lblcvCity.Text = "please choose City ";
                return;
            }
            else
            {
                lblcvCity.Text = "";
            }
            string WorkingPincode = "";
            for (int i = 0; i < cblPincode.Items.Count; i++)
            {
                if (cblPincode.Items[i].Selected)
                {

                    WorkingPincode += cblPincode.Items[i].Text + ",";
                }

            }
            //ddlAdminName.Text = objPincode.Ds.Tables[0].Rows[0]["FirstName"].ToString();
            //cblPincode.Text = objPincode.Ds.Tables[0].Rows[0]["WorkingPincode"].ToString();

            objAdmin.Admin_ID1 = Convert.ToInt16(ddlAdminName.SelectedValue);
            objAdmin.WorkingPinCode1 = WorkingPincode;

            objAdmin.UpdateWorkingPincode();
            Reset();

            string message = " Inserted successfully.";
            string url = "AssignWorkingPincode.aspx";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }

        protected void ddlAdminName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAdminName.SelectedIndex == 0)
            {
                lblcvAdminName.Text = "choose Admin Name";
                return;
            }
            else
            {
                lblcvAdminName.Text = "";
            }

            if (ddlAdminName.SelectedIndex == 0)
            {

                ddlState.SelectedIndex = 0;
                ddlCity.SelectedIndex = 0;
            }

            else
            {
                if (ddlAdminName.SelectedIndex != 0)
                {
                    objAdmin.Admin_ID1 = Convert.ToInt16(ddlAdminName.SelectedValue);
                    objAdmin.GetDataset_GetCityState();
                    ddlState.Items.Clear();
                    FillddlState();
                    ddlState.SelectedValue = objAdmin.Ds.Tables[0].Rows[0]["State_ID"].ToString();

                    ddlCity.Items.Clear();
                    FillddlCity();


                    ddlCity.SelectedValue = objAdmin.Ds.Tables[0].Rows[0]["City_ID"].ToString();
                }

            }

        }


        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlState.SelectedIndex == 0)
            {
                lblcvState.Text = "please choose state ";
                return;
            }
            else
            {
                lblcvState.Text = "";
            }

            ddlCity.Items.Clear();
            FillddlCity();


        }

        protected void btnGetPinCodeList_Click(object sender, EventArgs e)
        {

            if (ddlAdminName.SelectedIndex == 0)
            {
                lblcvAdminName.Text = "choose Admin Name";
                return;
            }
            else
            {
                lblcvAdminName.Text = "";
            }


            if (ddlState.SelectedIndex == 0)
            {
                lblcvState.Text = "please choose state ";
                return;
            }
            else
            {
                lblcvState.Text = "";
            }



            if (ddlCity.SelectedIndex == 0)
            {
                lblcvCity.Text = "please choose City ";
                return;
            }
            else
            {
                lblcvCity.Text = "";
            }

            cblPincode.Items.Clear();
            lblSelectPincode.Visible = true;
            FillcblPincode();

        }


        void Reset()
        {
            cblPincode.ClearSelection();
            ddlAdminName.ClearSelection();
            ddlCity.ClearSelection();
            ddlState.ClearSelection();

        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCity.SelectedIndex == 0)
            {
                lblcvCity.Text = "please choose City ";
                return;
            }
            else
            {
                lblcvCity.Text = "";
            }
        }
    }

}