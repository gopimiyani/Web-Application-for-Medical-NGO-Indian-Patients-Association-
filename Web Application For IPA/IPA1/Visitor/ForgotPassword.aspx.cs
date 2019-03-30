using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
using System.IO;
using System.Net.Mail;

namespace IPA1.Visitor
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        BusLib.Transaction.Login objLogin = new BusLib.Transaction.Login();
        BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();
 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Enter Email-Id'); </script>");
                return;

            }
            else
            {
                String mailto = "", RandomNo = "", Username="";

                objRegistration.Email1 = txtEmail.Text;
                objRegistration.GetDataSet_ForgotPassword();
                if (objRegistration.Ds.Tables[0].Rows.Count > 0)
                {

                    mailto = objRegistration.Ds.Tables[0].Rows[0]["Email"].ToString();
                    Username = objRegistration.Ds.Tables[0].Rows[0]["Username"].ToString();
                    objRegistration.Email1 = txtEmail.Text;
                    objRegistration.SetRandomNo();

                    RandomNo = objRegistration.Ds.Tables[0].Rows[0]["RandomNo"].ToString();
                   
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert (' Not a valid Email-ID'); </script>");
                    return;
                }




                string strURL = "http://localhost:10399/Visitor/ResetPassword.aspx?";
                string strURLWithData = strURL + EncryptQueryString(string.Format("Email={0}&Rand={1}", mailto, RandomNo));

                //Send Email
                var fromAddress = new MailAddress("IPANGO992015@gmail.com");
                var fromPassword = "IPANGO2015";

                using (System.Net.Mail.MailMessage msg1 = new System.Net.Mail.MailMessage())
                {
                    System.Net.Mail.SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;


                    smtpClient.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
                    msg1.From = new MailAddress("IPANGO992015@gmail.com");

                    // send mail...

                    msg1.To.Add(mailto);   //Dynamic
                    string Body = "";
                    Body += "Your Username: " + Username;
                    Body += "<br/><br/><b><big>" + "To Reset Your Password Click On the Below Link" + "</big></b><br/><br/>";
              
                    Body += "<a href=" + strURLWithData + ">Reset Password</a> ";
                    msg1.Subject = "Reset Your Password";
                    msg1.IsBodyHtml = true;
                    msg1.Body = Body;
                    smtpClient.Timeout = 1000000;
                //    smtpClient.Send(msg1);
                }



                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert (' Reset password link has been sent to you in your Email'); </script>");
                txtEmail.Text = "";

            }

        }


        public string EncryptQueryString(string strQueryString)
        {

            BusLib.Common.EncryptDecryptQueryString objEDQueryString = new BusLib.Common.EncryptDecryptQueryString();
            return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
        }
    }
}