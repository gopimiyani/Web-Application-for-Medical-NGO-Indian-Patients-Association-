using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
using System.Net.Mail;

using System.IO;

namespace IPA1.AdminLab
{
    public partial class AssignTask1 : System.Web.UI.Page
    {
        BusLib.Transaction.Task objTask = new BusLib.Transaction.Task();
        BusLib.Transaction.Request objRequest = new BusLib.Transaction.Request();
        BusLib.Common.Registration objReg = new BusLib.Common.Registration();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillddlName();
                FillddlHour();
                FillddlMinute();
                FillddlAMPM();
                txtCDate.Attributes.Add("readonly", "readonly");
                CalendarExtender.StartDate = DateTime.Now;
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["User_ID"].ToString() != "" && Request.QueryString["Request_ID"].ToString() != "")
                    {
                        int Request_ID = Convert.ToInt16(Request.QueryString["Request_ID"]);
                        int User_ID = Convert.ToInt16(Request.QueryString["User_ID"]);

                        objRequest.Request_ID1 = Convert.ToInt16(Request_ID.ToString());
                        objRequest.User_ID1 = Convert.ToInt16(User_ID.ToString());
                        objRequest.GetDataSet_GetViewRequestDetail();

                        txtSubject.Text = "Authenticate The Given Patient Request" + " | " + objRequest.Ds.Tables[0].Rows[0]["Request_ID"].ToString();
                        txtSubject.Enabled = false;
                        string str = "";

                        str += "Kindly refer the attachment for the details of the request.";
                        //str += "Requset Detail: ";
                        //str += "Patient Name: " + objRequest.Ds.Tables[0].Rows[0]["Name"].ToString();
                        //str += "Subject: " + objRequest.Ds.Tables[0].Rows[0]["Subject"].ToString();
                        //str += "Request Detail: " + objRequest.Ds.Tables[0].Rows[0]["Description"].ToString();
                        //str += "Address: " + objRequest.Ds.Tables[0].Rows[0]["Address"].ToString();
                        //str += "City: " + objRequest.Ds.Tables[0].Rows[0]["City"].ToString();
                        //str += "PinCode:" + objRequest.Ds.Tables[0].Rows[0]["PinCode"].ToString();
                        //str += "Mobile No :" + objRequest.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                        //str += "Email :" + objRequest.Ds.Tables[0].Rows[0]["Email"].ToString();
              
                        
                        txtDetail.Text = str;
                        ddlVName.SelectedValue = User_ID.ToString();
                        ddlVName.Enabled = false;
                        //str.Subject = "Task: " + txtSubject.Text;

                        pRequestAttachment.Visible = true;
                        //     hl1.NavigateUrl ;

                    }
                    else
                    {
        //                Response.Redirect("~/AdminLab/Login.aspx");        
                    }
        
                }
                else
                {

                }
            }

        }
        void FillddlName()
        {
            objTask.GetDataSet_GetVName();
            ddlVName.Items.Add(new ListItem("--Select Name | ID--", ""));
            ddlVName.DataSource = objTask.Ds.Tables[0];
            ddlVName.DataTextField = "Name";
            ddlVName.DataValueField = "User_ID";
            ddlVName.SelectedIndex = 0;
            ddlVName.DataBind();

        }
        void FillddlHour()
        {
            ddlHour.Items.Add(new ListItem("-HH-", ""));

            for (int i = 1; i < 13; i++)
            {
                if (i < 10)
                {
                    ddlHour.Items.Add(new ListItem("0" + i.ToString(), "0" + i.ToString()));
                }
                else
                {
                    ddlHour.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

            }
            ddlHour.SelectedIndex = 0;

        }
        void FillddlMinute()
        {
            ddlMinute.Items.Add(new ListItem("-MM-"));
            for (int i = 0; i < 60; i = i + 5)
            {
                if (i <= 5)
                {
                    ddlMinute.Items.Add(new ListItem(("0" + i).ToString(), ("0" + i).ToString()));
                }
                else
                {
                    ddlMinute.Items.Add(new ListItem((i).ToString(), (i).ToString()));
                }

            }
            ddlMinute.SelectedIndex = 0;
        }
        void FillddlAMPM()
        {
            ddlAMPM.Items.Add(new ListItem("AM", "AM"));
            ddlAMPM.Items.Add(new ListItem("PM", "PM"));
            ddlAMPM.SelectedIndex = 1;
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
        //private string ConvertTime(string Time)
        //{
        //    string Rtime = "";
        //    if (Time != "")
        //    {


        //        Rtime = Time.Substring(6, 4) + "-" + Time.Substring(3, 2) + "-" + Time.Substring(0, 2);
        //    }
        //    return Rtime;
        //}
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (ddlVName.SelectedIndex == 0)
            {
                lblrfvVName.Visible = true;
                return;
            }
            else
            {
                lblrfvVName.Visible = false;

            }
            if (ddlPriority.SelectedIndex == 0)
            {
                lblrfvPriority.Visible = true;
                return;
            }
            else
            {
                lblrfvPriority.Visible = false;
            }

            if (ddlHour.SelectedIndex == 0 || ddlMinute.SelectedIndex == 0)
            {
                lblcvCTime.Text = "Select task completion time";
                return;
            }
            else
            {
                lblcvCTime.Text = "";
            }


            String TodayDate = DateTime.Now.ToString("yyyy-MM-dd");
            String TodayTime = DateTime.Now.ToShortTimeString();
            if (Convert.ToDateTime(ConvertDate(txtCDate.Text)).CompareTo(Convert.ToDateTime(TodayDate)) >= 0)
            {
                lblcvCDate.Visible = false;
                if (Convert.ToDateTime(ConvertDate(txtCDate.Text)).Equals(Convert.ToDateTime(TodayDate)))
                {
                    String CTime = ddlHour.SelectedItem.Text + ":" + ddlMinute.SelectedItem.Text + " " + ddlAMPM.SelectedItem.Text;
                    TimeSpan ts = new TimeSpan(1, 0, 0);
                    DateTime NewTime = Convert.ToDateTime(TodayTime).Add(ts);
                    if (Convert.ToDateTime(CTime) >= NewTime)
                    {
                        lblcvCTime.Text = "";

                    }
                    else
                    {
                        lblcvCTime.Text = "Task completion time must be >1 hour than the current time";
                        return;

                    }
                }
                else
                {
                    lblcvCTime.Text = "";

                }

            }
            else
            {
                lblcvCDate.Visible = true;
                return;
            }


            objTask.Admin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            objTask.User_ID1 = Convert.ToInt16(ddlVName.SelectedValue);
            objTask.Subject1 = txtSubject.Text;
            objTask.Detail1 = txtDetail.Text;
            objTask.Priority1 = ddlPriority.SelectedValue;
            objTask.Status1 = "Pending";
            objTask.WCP1 = Convert.ToDecimal(0.00);


            //  String TodayDateTime=DateTime.Now.ToString();
            //    String EntryDatetime = TodayDateTime.Substring(3, 2) + "-" + TodayDateTime.Substring(0, 2) + "-" + TodayDateTime.Substring(6, TodayDateTime.Length-6);
            String AssignedDate = DateTime.Now.ToString("dd-MM-yyyy");
            String AssignedTime = DateTime.Now.ToShortTimeString();
            String AssignedDateTime = AssignedDate + " " + AssignedTime;

            objTask.EntryDateTime1 = DateTime.Now;
            //objTask.CompletionDate1 = Convert.ToDateTime(Request.Form[txtCDate.Text.]);
            //objTask.CompletionDate1 = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", txtCDate.Text).ToString());

            String CDate1 = ConvertDate(txtCDate.Text);
            objTask.CompletionDate1 = CDate1;
            String CTime1 = ddlHour.SelectedItem.Text + ":" + ddlMinute.SelectedItem.Text + " " + ddlAMPM.SelectedItem.Text;
            objTask.CompletionTime1 = CTime1;
           
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["User_ID"].ToString() != "" && Request.QueryString["Request_ID"].ToString() != "")
                {
                    int Request_ID = Convert.ToInt16(Request.QueryString["Request_ID"]);
                    objTask.Request_ID1 = Request_ID;

                    objRequest.Request_ID1 = Request_ID;
                    objRequest.IsForward1 = true;
                    objRequest.UpdateIsForward();
                }
            }
            objTask.Insert();

            objTask.NFNew1 = true;
            objTask.UpdateNFNew();

            objReg.User_ID1 = Convert.ToInt16(ddlVName.SelectedValue);
            objReg.GetDataSet_Select();

            String mailto = objReg.Ds.Tables[0].Rows[0]["Email"].ToString();
            String smsto = objReg.Ds.Tables[0].Rows[0]["MobileNo"].ToString();

//            Send Email

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

                msg1.To.Add(mailto);   //Dynamic
                string Body = "";
                Body = "<b><big>" + "Task Detail" + "</big></b><br/><br/>";

                Body += "<table cellspacing='5px' cellpadding='3px'><tr><td>";
                Body += "Assigned By" + "</td><td>" + Session["AdminName"].ToString() + "</td></tr>";
                Body += "<tr><td>" + "Assigned On" + "</td><td>" + AssignedDateTime + "</td></tr>";
                Body += "<tr><td>" + "Task Detail" + "</td><td>" + txtDetail.Text + "</td></tr>";
                Body += "<tr><td>" + "Priority" + "</td><td>" + ddlPriority.SelectedItem.Text + "</td></tr>";
                Body += "<tr><td>" + "Completion Date" + "</td><td>" + txtCDate.Text + "</td></tr>";
                Body += "<tr><td>" + "Completion Time" + "</td><td>" + CTime1 + "</td></tr>";
                Body += "</table>";
                msg1.Subject = "Task: " + txtSubject.Text;
                msg1.IsBodyHtml = true;
                msg1.Body = Body;
                smtpClient.Timeout = 1000000;
              //  smtpClient.Send(msg1);
            }

          
           // Send SMS


            //WebClient client = new WebClient();

            //String msg = "A new task is assigned from IPA\r\nTask: " + txtSubject.Text;
            ////msg+=    "\r\nCompletion Date:" + txtCDate.Text;
            //msg += "\r\nFor more details: Refer mail or login to the system";
            //string baseurl = "http://smsidea.co.in/sendsms.aspx?mobile=9574017480&pass=prabhu&senderid=WEBSMS&to=" + smsto + "&msg=" + msg + "";
            //Stream data = client.OpenRead(baseurl);
            //StreamReader reader = new StreamReader(data);
            //string s = reader.ReadToEnd();


            Reset();

            //string message = "Task is successfully assigned to  + ddlVName.SelectedItem.Text";
            //string url = "ViewTask.aspx";
            //string script = "window.onload = function(){ alert('";
            //script += message;
            //script += "');";
            //script += "window.location = '";
            //script += url;
            //script += "'; }";
            //ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

     
            //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert (Task is successfully assigned. ); </script>");

            //Response.Redirect("~/AdminLab/ViewTask.aspx");
            Response.Write("<script language='javascript'>window.alert('Task is Successfully Assigned');window.location='ViewTask.aspx';</script>");


        }
        void Reset()
        {
            txtSubject.Text = "";
            txtDetail.Text = "";
            txtCDate.Text = "";
            ddlVName.ClearSelection();
            // ddlStatus.ClearSelection();
            ddlPriority.ClearSelection();
            ddlVName.SelectedIndex = 0;
            lblcvCDate.Visible = false;
            lblcvCTime.Text = "";
            lblrfvPriority.Visible = false;
            lblrfvVName.Visible = false;
            ddlHour.SelectedIndex = 0;
            ddlMinute.SelectedIndex = 0;
            ddlAMPM.SelectedIndex = 1;
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["User_ID"] != "" && Request.QueryString[1] != "")
                {
                    Response.Redirect("~/AdminLab/ForwardRequest.aspx?RequestNo=" + Request.QueryString[1].ToString() + "");
                }
            }
            else
            {
                Response.Redirect("~/AdminLab/ViewTask.aspx");
            }


        }


        protected void ddlVName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlVName.SelectedIndex == 0)
            {
                lblrfvVName.Visible = true;

            }
            else
            {
                lblrfvVName.Visible = false;
            }
        }

        protected void ddlPriority_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPriority.SelectedIndex == 0)
            {
                lblrfvPriority.Visible = true;
            }
            else
            {
                lblrfvPriority.Visible = false;
            }

        }

        protected void ibRequestDetail_Click(object sender, ImageClickEventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["Request_ID"].ToString() != "")
                {
                    Response.Redirect("~/AdminLab/ForwardRequestDetail.aspx?Request_ID=" + Request.QueryString["Request_ID"].ToString() + "");
                }
            }

            
        }

        protected void lbRequestDetail_Click(object sender, EventArgs e)
        {
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["Request_ID"].ToString() != "" && Request.QueryString["Request_ID"].ToString() != "")
                {
                    Response.Redirect("~/AdminLab/ForwardRequestDetail.aspx?Request_ID=" + Request.QueryString["Request_ID"].ToString() + "");
                }
            }
        }

 
    }
}