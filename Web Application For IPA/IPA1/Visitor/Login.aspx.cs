using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.Visitor
{
    public partial class Login : System.Web.UI.Page
    {
        BusLib.Transaction.Login objLogin = new BusLib.Transaction.Login();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();
        BusLib.Master.IpMast objIpMast = new BusLib.Master.IpMast();
        // string ip = "192.168.0.100";
        //BusLib.Master.DesignMast objDesign = new BusLib.Master.DesignMast();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                Bind();

                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtUserName.Text = Request.Cookies["UserName"].Value;
                    txtPwd.Attributes["Value"] = Request.Cookies["Password"].Value;
                    ddlUserType.SelectedIndex = Convert.ToInt16(Request.Cookies["UserType"].Value);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (ddlUserType.SelectedIndex == 0)
            {
               // lblrvUserType.Visible = true;
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Please Select User Type'); </script>");
                return;
            }
            if (txtUserName.Text=="" && txtPwd.Text=="")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Please Enter Username and Password'); </script>");
                return;
            }
            if (txtUserName.Text=="")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Please Enter Username'); </script>");
                return;
            }
            if (txtPwd.Text=="")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Please Enter Password'); </script>");
                return;
            }
            
            else
            {
               // lblrvUserType.Visible = false;

                String Epwd = objLogin.ENCODE_DECODE(txtPwd.Text.Trim(), "E");
                objLogin.UserName1 = txtUserName.Text.Trim();
                objLogin.UserType1 = ddlUserType.SelectedItem.Text;
            
                objLogin.GetLoginDetail();
                if (objLogin.Ds.Tables[0].Rows.Count > 0)
                {
                    if (Epwd == objLogin.Ds.Tables[0].Rows[0]["Password"].ToString())
                    {
                        
                        
                        Session["User_ID"] = objLogin.Ds.Tables[0].Rows[0]["User_ID"].ToString();
                        Session["UserType"] = ddlUserType.SelectedItem.Text;

                        if (cbRememberMe.Checked)
                        {
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                            Response.Cookies["UserType"].Expires = DateTime.Now.AddDays(30);
                        }
                        else
                        {
                            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["UserType"].Expires = DateTime.Now.AddDays(-1);
                        }
                        
                        Response.Cookies["UserName"].Value = txtUserName.Text.Trim();
                        Response.Cookies["Password"].Value = txtPwd.Text.Trim();
                        Response.Cookies["UserType"].Value = Convert.ToString( ddlUserType.SelectedIndex);
                        

                        if (objLogin.Ds.Tables[0].Rows[0]["Status"].ToString().Equals("Approved"))
                        {
                            if (Session["UserType"].ToString() == "Volunteer")
                            {
                                Session["VolunteerName"] = objLogin.Ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + objLogin.Ds.Tables[0].Rows[0]["LastName"].ToString();
                                Response.Redirect("~/VolunteerLab/Dashboard.aspx");

                            }
                            else if (Session["UserType"].ToString() == "Donor")
                            {
                                Session["DonorName"] = objLogin.Ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + objLogin.Ds.Tables[0].Rows[0]["LastName"].ToString();
                                Response.Redirect("~/User/Home.aspx");
                            }
                            else if (Session["UserType"].ToString() == "Hospital")
                            {
                                Session["HospitalName"] = objLogin.Ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + objLogin.Ds.Tables[0].Rows[0]["LastName"].ToString();
                                Response.Redirect("~/User/Home.aspx");
                            }
                            else if (Session["UserType"].ToString() == "BloodBank")
                            {
                                Session["BloodBankName"] = objLogin.Ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + objLogin.Ds.Tables[0].Rows[0]["LastName"].ToString();
                                Response.Redirect("~/User/Home.aspx");
                            }
                            else if (Session["UserType"].ToString() == "PharmaCompany")
                            {
                                Session["PharmaCompanyName"] = objLogin.Ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + objLogin.Ds.Tables[0].Rows[0]["LastName"].ToString();
                                Response.Redirect("~/User/Home.aspx");
                            }
                            else if (Session["UserType"].ToString() == "Doctor")
                            {
                                Session["DoctorName"] = objLogin.Ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + objLogin.Ds.Tables[0].Rows[0]["LastName"].ToString();
                                Response.Redirect("~/User/Home.aspx");
                            }
                            //else if (Session["UserType"].ToString() == "NGO")
                            //{
                            //    Session["NGOName"] = objLogin.Ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + objLogin.Ds.Tables[0].Rows[0]["LastName"].ToString();
                            //    Response.Redirect("~/NGOLab/Dashboard.aspx");
                            //}
                            else
                            {
                                Response.Redirect("~/Home.htm");
                            }

                            //if (Session["UserType"].ToString() == "Hospital")
                            //{
                            //    Response.Redirect("~/HospitalProfile.aspx");

                            //}
                            //else
                            //{
                            //    Response.Redirect("~/Home.htm");
                            //}
                        }
                        else
                        {
                            if (objLogin.Ds.Tables[0].Rows[0]["Status"].ToString().Equals("Pending"))
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Access Denied ! Your Registration is not approved yet.'); </script>");
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Access Denied ! Your Registration is rejected.'); </script>");

                            }
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Invalid UserName or Password'); </script>");

                    }
                }
                else
                {

                    //    objLogin.TableName1 = "Admin";
                    //    objLogin.GetAdminLoginDetail();
                    objAdmin.UserName1 = txtUserName.Text;
                    objAdmin.GetAdminLoginDetail();
                    if (objAdmin.Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Epwd == objAdmin.Ds.Tables[0].Rows[0]["Password"].ToString())
                        {

                            objIpMast.GetDataSet("");
                            int f = 0;
                            //            String AdminIP = objAdmin.Ds.Tables[0].Rows[0]["IP"].ToString();
                            HttpRequest Request = base.Request;
                            string AdminIP = Request.UserHostAddress;
                            for (int i = 0; i < objIpMast.Ds.Tables[0].Rows.Count; i++)
                            {
                                if (objIpMast.Ds.Tables[0].Rows[i]["Address"].ToString().Equals(AdminIP))
                                {
                                    f = 1;
                                    break;
                                }
                            }
                            if (f == 1)
                            {
                                Session["User_ID"] = objAdmin.Ds.Tables[0].Rows[0]["Admin_ID"].ToString();
                                Session["UserType"] = ddlUserType.SelectedItem.Text;
                                Session["AdminName"] = objAdmin.Ds.Tables[0].Rows[0]["FirstName"].ToString();
                                Response.Redirect("~/Home.aspx");
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Access Denied !'); </script>");
                            }

                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Invalid UserName or Password'); </script>");

                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Invalid UserName or Password'); </script>");

                    }
                }

               
            }
        }

        private void Bind()
        {

            objSH.GetDataSet("");
            ddlUserType.AppendDataBoundItems = true;

            ddlUserType.Items.Add(new ListItem("--- Select UserType ---", ""));

            objSH.Ds.Tables[0].DefaultView.Sort = "Name";
            ddlUserType.DataSource = objSH.Ds.Tables[0];
            ddlUserType.DataTextField = "Name";
            ddlUserType.DataValueField = "Name";
            ddlUserType.SelectedIndex = 0;  //VALUE
            ddlUserType.DataBind();
            ddlUserType.Items.Remove(new ListItem("Doctor"));
            ddlUserType.Items.Remove(new ListItem("NGO"));
            
         
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Visitor/RegistrationForm.aspx");
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (ddlUserType.SelectedIndex == 0)
            //{
            //    lblrvUserType.Visible = true;
            //    return;
            //}
            //else
            //{
            //    lblrvUserType.Visible = false;
            //}

        }
    }
}