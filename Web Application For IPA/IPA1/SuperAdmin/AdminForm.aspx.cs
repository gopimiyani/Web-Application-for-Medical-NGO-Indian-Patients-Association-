using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.SuperAdmin
{
    public partial class AdminForm : System.Web.UI.Page
    {
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        BusLib.Transaction.Login objLogin = new BusLib.Transaction.Login();

        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();


        bool Mflag = true;
        bool Pflag = true;
      
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
            if (Mflag && Pflag)
            {
               // objAdmin.Admin_ID1 = 101;

                objAdmin.FirstName1 = txtFirstName.Text.Trim();
                objAdmin.LastName1 = txtLastName.Text.Trim();
                objAdmin.Address1 = txtAddress.Text.Trim();
                objAdmin.City1 = ddlCity.SelectedItem.ToString().Trim();
                objAdmin.State1 = ddlState.SelectedItem.ToString().Trim();
                objAdmin.PinCode1 = Convert.ToInt32(txtPinCode.Text);
                objAdmin.MobileNo1 = Convert.ToInt64(txtMobileNo.Text);

                objAdmin.UserName1 = txtUserName.Text.Trim();

                objAdmin.GetDataSet_GetUserName();
                if (objAdmin.Ds.Tables[0].Rows.Count > 0)
                {
                    lblcvUserName.Text = "UserName already exist";
                    return;
                }
                else
                {
                    lblcvUserName.Text = "";
                    objAdmin.UserName1 = txtUserName.Text.Trim();

                }

                objAdmin.Email1 = txtEmail.Text.Trim();
                objAdmin.GetDataSet_GetEmail();
                if (objAdmin.Ds.Tables[0].Rows.Count > 0)
                {
                    lblcvEmail.Text = "Email already exist";
                    return;
                }
                else
                {
                    lblcvEmail.Text = "";
                    objAdmin.Email1 = txtEmail.Text.Trim();

                }

                objAdmin.IP1 = txtIpaddress.Text.Trim();

               
                if (fuProfilePic.HasFile)
                {
                    string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg" };
                    string ext = System.IO.Path.GetExtension(fuProfilePic.PostedFile.FileName);
                    bool isvalidFile = false;
                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (ext == "." + validFileTypes[i])
                        {
                            isvalidFile = true;
                            objAdmin.ProfilePic1 = fuProfilePic.FileName.Trim();
                            //      fuProfilePic.SaveAs(Server.MapPath("~../ProfilePic/" + fuProfilePic.FileName));
                            fuProfilePic.SaveAs(Server.MapPath("~//ProfilePic//") + fuProfilePic.FileName);

                            break;
                        }
                    }
                    if (!isvalidFile)
                    {
                        lblProfilePicture.ForeColor = System.Drawing.Color.Red;
                        lblProfilePicture.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                        return;
                    }


                }

                objAdmin.Pwd1 = objLogin.ENCODE_DECODE(txtPassword.Text.Trim(), "E");
                objAdmin.Insert();

                string message = "Admin Created Successfully";
                string url = "AdminDetail.aspx";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                Reset();
            }
        }
         
            void Reset()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtEmail.Text = "";
            txtPinCode.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtIpaddress.Text = "";
            lblcvEmail.Text = "";
            lblcvUserName.Text = "";
         

        }

            protected void cvMobileNo_ServerValidate(object source, ServerValidateEventArgs args)
            {
                if (args.Value.Length == 10)
                {

                    args.IsValid = true;
                    Mflag = true;
                }
                else
                {

                    args.IsValid = false;
                    Mflag = false;
                }
            }

            protected void cvPincode_ServerValidate(object source, ServerValidateEventArgs args)
            {
                if (args.Value.Length == 6)
                {

                    args.IsValid = true;
                    Mflag = true;
                }
                else
                {

                    args.IsValid = false;
                    Mflag = false;
                }
            }

            protected void btnReset_Click(object sender, EventArgs e)
            {
                Reset();
            }

            protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
            {
                FillddlCity();
            }

            protected void btnCancel_Click(object sender, EventArgs e)
            {
                Response.Redirect("~/SuperAdmin/AdminDetail.aspx");
            }

            protected void txtUserName_TextChanged(object sender, EventArgs e)
            {
                objAdmin.UserName1 = txtUserName.Text;
                objAdmin.GetDataSet_GetUserName();
                if (objAdmin.Ds.Tables[0].Rows.Count > 0)
                {
                    lblcvUserName.Visible = true;
                    lblcvUserName.Text = "UserName already exist";
                    return;
                }
                else
                {
                    lblcvUserName.Text = "";
                }

            }

            protected void txtEmail_TextChanged(object sender, EventArgs e)
            {
                objAdmin.Email1 = txtEmail.Text.Trim();
                objAdmin.GetDataSet_GetEmail();
                if (objAdmin.Ds.Tables[0].Rows.Count > 0)
                {
                    lblcvEmail.Text = "Email already exist";
                    return;
                }
                else
                {
                    lblcvEmail.Text = "";
                    
                }
            }



        }
    }
