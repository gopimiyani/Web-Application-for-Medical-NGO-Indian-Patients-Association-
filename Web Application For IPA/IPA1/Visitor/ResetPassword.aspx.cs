using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace IPA1.Visitor
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();
        BusLib.Transaction.Login objLogin = new BusLib.Transaction.Login();
        String Email = "";
        String RandomNumber = "";
        String PwdUpdate;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    ViewState["Email"] = "";
                    string strReq = "";
                    strReq = Request.RawUrl;
                    strReq = strReq.Substring(strReq.IndexOf('?') + 1);

                    if (!strReq.Equals(""))
                    {
                        strReq = DecryptQueryString(strReq);

                        //Parse the value... this is done is very raw format.. you can add loops or so to get the values out of the query string...
                        string[] arrMsgs = strReq.Split('&');
                        string[] arrIndMsg;

                        arrIndMsg = arrMsgs[0].Split('=');
                        Email = arrIndMsg[1].ToString().Trim();
                        ViewState["Email"] = Email;

                        arrIndMsg = arrMsgs[1].Split('='); //
                        RandomNumber = arrIndMsg[1].ToString().Trim();

                        objRegistration.Email1 = Email;
                        objRegistration.GetResetPwdDetail();

                        if (objRegistration.Ds.Tables[0].Rows.Count > 1)
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Something went wrong, Try again !'); </script>");
                            Response.Redirect("~/Visitor/Login.aspx");
                        }
                        if (objRegistration.Ds.Tables[0].Rows.Count == 1)
                        {
                            PwdUpdate = objRegistration.Ds.Tables[0].Rows[0]["PwdUpdate"].ToString();
                            if (PwdUpdate == "True")
                            {
                                Response.Write("<script language='javascript'>window.alert('You can use this link once only');window.location='ForgotPassword.aspx';</script>");

                            }
                           
                        }
                       
                    }
                    else
                    {
                        Response.Write("<script language='javascript'>window.alert('Access Denied');window.location='ForgotPassword.aspx';</script>");

                    }

                    if (Email != "" && RandomNumber != "")
                    {
                         objRegistration.Email1 = Email;
                            objRegistration.GetResetPwdDetail();
                            if (objRegistration.Ds.Tables[0].Rows.Count > 0)
                            {
                                if (objRegistration.Ds.Tables[0].Rows[0]["RandomNumber"].ToString() != RandomNumber)
                                {

                                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Something went wrong, Try again !'); </script>");
                                    Response.Redirect("~/AdminLab/Login.aspx");
                                }
                            }

                       
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Something went wrong, Try again !'); </script>");
                                Response.Redirect("~/AdminLab/Login.aspx");
                            }
                    }
                }
                else
                {
                    Response.Redirect("~/Visitor/Login.aspx");
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtChangePassword.Text == "" && txtConfirmPassword.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Enter new Password and Confirm Password'); </script>");
                return;

            }

            if (txtChangePassword.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Enter new Password'); </script>");
                return;

            }

            if (txtConfirmPassword.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Enter Confirm Password'); </script>");
                return;
            }

            if (txtChangePassword.Text != "")
            {
                Regex regx = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
                if (!regx.IsMatch(txtChangePassword.Text))
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Password should be min of 8 characters having at least 1 Alphabet and 1 Number'); </script>");
                    return;
                }

            }
            if (txtChangePassword.Text != "" && txtConfirmPassword.Text != "")
            {

                if (txtChangePassword.Text != txtConfirmPassword.Text)
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Password doesn't match, Re-Enter Confirm Password'); </script>");
                    return;
                }

                else
                {
                    
                        objRegistration.Email1 = ViewState["Email"].ToString();

                        String Epwd = objLogin.ENCODE_DECODE(txtChangePassword.Text.Trim(), "E");

                        objRegistration.Pwd1 = Epwd;
                        objRegistration.ResetPassword();
                   
                    Reset();
                    //  Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Your password has been changed successfully'); </script>");
                    string message = "Your password has been changed successfully";
                    string url = "Login.aspx";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "');";
                    script += "window.location = '";
                    script += url;
                    script += "'; }";
                    ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                }
            }
        }

        void Reset()
        {
            txtChangePassword.Text = "";
            txtConfirmPassword.Text = "";

        }

        private string DecryptQueryString(string strQueryString)
        {
            BusLib.Common.EncryptDecryptQueryString objEDQueryString = new BusLib.Common.EncryptDecryptQueryString();
            return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
        }
    }
}