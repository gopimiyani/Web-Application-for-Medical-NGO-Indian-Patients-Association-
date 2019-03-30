using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.AdminLab
{
    public partial class Login : System.Web.UI.Page
    {
        BusLib.Transaction.Login objLogin = new BusLib.Transaction.Login();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();
        BusLib.Master.SuperAdmin objSuperAdmin = new BusLib.Master.SuperAdmin();
        BusLib.Master.IpMast objIpMast = new BusLib.Master.IpMast();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
             {
                if (Request.Cookies["AdminName"] != null && Request.Cookies["AdminPassword"] != null)
                {
                    txtUsername.Text = Request.Cookies["AdminName"].Value;
                    txtPassword.Attributes["Value"] = Request.Cookies["AdminPassword"].Value;
                }
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text=="" &&  txtPassword.Text=="")
            {
        
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Enter UserName and Password'); </script>");
                return;
       
            }

            if (txtUsername.Text == "")
            {
       
        
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Enter UserName'); </script>");
                return;
       
            }
            if(txtPassword.Text=="")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Enter Password'); </script>");
                return;
            }


            String Epwd = objLogin.ENCODE_DECODE(txtPassword.Text.Trim(), "E");
            
            //Super Admin Start//

                    objSuperAdmin.UserName1 = txtUsername.Text;
                    objSuperAdmin.GetSuperAdminLoginDetail();
                    if (objSuperAdmin.Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Epwd == objSuperAdmin.Ds.Tables[0].Rows[0]["Password"].ToString())
                        {
                                Session["User_ID"] = objSuperAdmin.Ds.Tables[0].Rows[0]["SuperAdmin_ID"].ToString();
                                Session["UserType"] = "SuperAdmin";
                                Session["SuperAdminName"] = objSuperAdmin.Ds.Tables[0].Rows[0]["Name"].ToString();
                                if (cbRememberMe.Checked)
                                {
                                    Response.Cookies["AdminName"].Expires = DateTime.Now.AddDays(30);
                                    Response.Cookies["AdminPassword"].Expires = DateTime.Now.AddDays(30);
                                }
                                else
                                {
                                    Response.Cookies["AdminName"].Expires = DateTime.Now.AddDays(-1);
                                    Response.Cookies["AdminPassword"].Expires = DateTime.Now.AddDays(-1);

                                }
                                Response.Cookies["AdminName"].Value = txtUsername.Text.Trim();
                                Response.Cookies["AdminPassword"].Value = txtPassword.Text.Trim();
            
                                Response.Redirect("~/SuperAdmin/Dashboard1.aspx");
                            //}
                            //else
                            //{
                            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Access Denied !'); </script>");
                            //}
                           
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Invalid UserName or Password'); </script>");

                        }
                    }
                
        

            //Super Admin End //


            //Super Admin Static

            //if (txtUsername.Text=="Superadmin" || txtUsername.Text=="superadmin" )
            //{
            //    if (Epwd == "»¾ÇÃÈ(*~")
            //    {
            //        Session["User_ID"] = "101";
            //        Session["UserType"] = "SuperAdmin";
            //        Session["AdminName"] = "Ravindra Shaikh";
            //        Response.Redirect("~/SuperAdmin/Dashboard1.aspx");
                             
            //    }
            //    else
            //    {
            //        Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Invalid Username or Password !'); </script>");
            //    }
            //}

            //End
                    objAdmin.UserName1 = txtUsername.Text;
                    objAdmin.GetAdminLoginDetail();
                    if (objAdmin.Ds.Tables[0].Rows.Count > 0)
                    {
                        if (Epwd == objAdmin.Ds.Tables[0].Rows[0]["Password"].ToString())
                        {
                            
                            objIpMast.GetDataSet("");
                            int f = 0;
                          //  String AdminIP = objAdmin.Ds.Tables[0].Rows[0]["IP"].ToString();
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
                            if (f==1)
                            {
                                Session["User_ID"] = objAdmin.Ds.Tables[0].Rows[0]["Admin_ID"].ToString();
                                Session["UserType"] = "Admin";
                                Session["AdminName"] = objAdmin.Ds.Tables[0].Rows[0]["Name"].ToString();
                                if (cbRememberMe.Checked)
                                {
                                    Response.Cookies["AdminName"].Expires = DateTime.Now.AddDays(30);
                                    Response.Cookies["AdminPassword"].Expires = DateTime.Now.AddDays(30);
                                }
                                else
                                {
                                    Response.Cookies["AdminName"].Expires = DateTime.Now.AddDays(-1);
                                    Response.Cookies["AdminPassword"].Expires = DateTime.Now.AddDays(-1);

                                }
                                Response.Cookies["AdminName"].Value = txtUsername.Text.Trim();
                                Response.Cookies["AdminPassword"].Value = txtPassword.Text.Trim();
            
                                Response.Redirect("~/AdminLab/Dashboard1.aspx");
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