using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.AdminLab
{
    public partial class PatientRequestForm : System.Web.UI.Page
    {
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        bool PFlg = true;
        bool MFlg = true;
        BusLib.Transaction.Request objRequest = new BusLib.Transaction.Request();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillddlState();
                FillddlCity();
            }
        }
        void FillddlState()
        {
            objState.GetDataSet("");
            ddlState.DataSource = objState.Ds.Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "State_ID";
            ddlState.SelectedIndex = 6;
            ddlState.DataBind();
        }

        void FillddlCity()
        {
            objCity.StateID1 = Convert.ToInt16(ddlState.SelectedValue);
            objCity.GetCity();
            ddlCity.DataSource = objCity.Ds.Tables[0];
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "City_ID";
            ddlCity.DataBind();
            if (objCity.Ds.Tables[0].Rows.Count > 0)
            {
                ddlCity.SelectedIndex = 0;

            }



        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (PFlg && MFlg)
            {
                if (Session["User_ID"] != null)
                {
                    int UserID = Convert.ToInt16(Session["User_ID"].ToString());
                    if (Session["UserType"].ToString() == "Admin")
                    {
                        objRequest.Admin_ID1 = UserID;
                    }
                    else
                    {
                        objRequest.User_ID1 = UserID;
                    }

                }


                //    objRequest.Admin_ID1 = 101;
                objRequest.Date1 = DateTime.Now;
                objRequest.Name1 = txtName.Text;
                objRequest.Subject1 = txtSubject.Text;
                objRequest.Description1 = txtDescr.Text;

                objRequest.Address1 = txtAddress.Text;
                objRequest.Email1 = txtEmail.Text;

                objRequest.City1 = ddlCity.SelectedItem.ToString();
                objRequest.State1 = ddlState.SelectedItem.ToString();
                objRequest.PinCode1 = Convert.ToInt32(txtPinCode.Text);
                objRequest.MobileNo1 = Convert.ToInt64(txtMobileNo.Text);
                objRequest.Status1 = "Pending";
                objRequest.NotificationFlag1 = false;
                objRequest.IdProof11 = "";
                objRequest.IdProof21 = "";
                objRequest.IdProof31 = "";
                objRequest.Insert();

                Reset();
                string message = "Request sent successfully";
                string url = "ViewRequest.aspx";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);


                //Reset();
            }

        }

        void Reset()
        {
            txtName.Text = "";
            txtSubject.Text = "";
            txtDescr.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            FillddlState();
            FillddlCity();
            ddlState.Text = "8";
            ddlCity.Text = "2";
            txtPinCode.Text = "";
            txtMobileNo.Text = "";


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void cvPinCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 6)
            {

                args.IsValid = true;
                PFlg = true;

            }
            else
            {

                args.IsValid = false;
                PFlg = false;

            }
        }

        protected void cvMobileNo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 10)
            {

                args.IsValid = true;
                MFlg = true;
            }
            else
            {

                args.IsValid = false;
                MFlg = false;
            }

        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/ViewRequest.aspx");
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillddlCity();
        }

       


    }
}