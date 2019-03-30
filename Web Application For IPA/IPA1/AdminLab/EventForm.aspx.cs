using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.AdminLab
{
    public partial class EventForm : System.Web.UI.Page
    {
        BusLib.Transaction.Event objEvent = new BusLib.Transaction.Event();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEventDate.Attributes.Add("readonly", "readonly");
                CalendarExtender.StartDate = DateTime.Now;
                FillddlHour();
                FillddlMinute();
                FillddlAMPM();
            }
        }

        void FillddlHour()
        {
            ddlHour.Items.Add(new System.Web.UI.WebControls.ListItem("-HH-", ""));
            ddlHour1.Items.Add(new System.Web.UI.WebControls.ListItem("-HH-", ""));

            for (int i = 1; i < 13; i++)
            {
                if (i < 10)
                {
                    ddlHour.Items.Add(new System.Web.UI.WebControls.ListItem("0" + i.ToString(), "0" + i.ToString()));
                    ddlHour1.Items.Add(new System.Web.UI.WebControls.ListItem("0" + i.ToString(), "0" + i.ToString()));
                }
                else
                {
                    ddlHour.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));
                    ddlHour1.Items.Add(new System.Web.UI.WebControls.ListItem(i.ToString(), i.ToString()));
                }

            }
            ddlHour.SelectedIndex = 0;
            ddlHour1.SelectedIndex = 0;

        }
        void FillddlMinute()
        {
            ddlMinute.Items.Add(new System.Web.UI.WebControls.ListItem("-MM-"));
            ddlMinute1.Items.Add(new System.Web.UI.WebControls.ListItem("-MM-"));
            for (int i = 0; i < 60; i = i + 5)
            {
                if (i <= 5)
                {
                    ddlMinute.Items.Add(new System.Web.UI.WebControls.ListItem(("0" + i).ToString(), ("0" + i).ToString()));
                    ddlMinute1.Items.Add(new System.Web.UI.WebControls.ListItem(("0" + i).ToString(), ("0" + i).ToString()));
                }
                else
                {
                    ddlMinute.Items.Add(new System.Web.UI.WebControls.ListItem((i).ToString(), (i).ToString()));
                    ddlMinute1.Items.Add(new System.Web.UI.WebControls.ListItem((i).ToString(), (i).ToString()));
                }

            }
            ddlMinute.SelectedIndex = 0;
            ddlMinute1.SelectedIndex = 0;
        }
        void FillddlAMPM()
        {
            ddlAMPM.Items.Add(new System.Web.UI.WebControls.ListItem("AM", "AM"));
            ddlAMPM.Items.Add(new System.Web.UI.WebControls.ListItem("PM", "PM"));
            ddlAMPM.SelectedIndex = 1;

            // Actual CTime
            ddlAMPM1.Items.Add(new System.Web.UI.WebControls.ListItem("AM", "AM"));
            ddlAMPM1.Items.Add(new System.Web.UI.WebControls.ListItem("PM", "PM"));
            ddlAMPM1.SelectedIndex = 1;
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (ddlHour.SelectedIndex == 0 || ddlMinute.SelectedIndex == 0)
            {
                lblcvStartTime.Text = "Select event start time";
                return;
            }
            else
            {
                lblcvStartTime.Text = "";
            }


            if (ddlHour1.SelectedIndex == 0 || ddlMinute1.SelectedIndex == 0)
            {
                lblcvEndTime.Text = "Select event end time";
                return;
            }
            else
            {
                lblcvEndTime.Text = "";
            }

        
            String StartTime = ddlHour.SelectedItem.Text + ":" + ddlMinute.SelectedItem.Text + " " + ddlAMPM.SelectedItem.Text;
            String EndTime = ddlHour1.SelectedItem.Text + ":" + ddlMinute1.SelectedItem.Text + " " + ddlAMPM1.SelectedItem.Text;

            TimeSpan ts = new TimeSpan(1, 0, 0);
            DateTime NewTime = Convert.ToDateTime(StartTime).Add(ts);
            if (Convert.ToDateTime(EndTime) >= NewTime)
            {
                lblcvEndTime.Text = "";

            }
            else
            {
                lblcvEndTime.Text = "Event end time must be >=1 hour than the start time";
                return;

            }


            if (Session["User_ID"]!=null)
            {
                objEvent.Admin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            }
            
            objEvent.EventName1 = txtEventName.Text.Trim();

            objEvent.EventDescription1 = txtEventDescription.Text.Trim();
            objEvent.EventDate1 = ConvertDate(txtEventDate.Text);

            String StartTime1 = ddlHour.SelectedItem.Text + ":" + ddlMinute.SelectedItem.Text + " " + ddlAMPM.SelectedItem.Text;
            String EndTime1 = ddlHour1.SelectedItem.Text + ":" + ddlMinute1.SelectedItem.Text + " " + ddlAMPM1.SelectedItem.Text;

            objEvent.StartTime1 = StartTime1;
            objEvent.EndTime1 = EndTime1;
      
            objEvent.Location1 = txtEventLocation.Text.Trim();
            objEvent.EntryDate1 = DateTime.Now.ToString("yyyy-MM-dd");
            objEvent.Insert();
            Reset();
            Response.Write("<script language='javascript'>window.alert('Event Registered Successfully');window.location='EventDetail.aspx';</script>");
        }

        void Reset()
        {
            txtEventName.Text = "";
            txtEventDescription.Text = "";
            txtEventDate.Text = "";
            ddlHour.SelectedIndex = 0;
            ddlMinute.SelectedIndex = 0;
            ddlAMPM.SelectedIndex = 1;
            ddlHour1.SelectedIndex = 0;
            ddlMinute1.SelectedIndex = 0;
            ddlAMPM1.SelectedIndex = 1;
            txtEventLocation.Text = "";

            lblcvStartTime.Text = "";
            lblcvEndTime.Text = "";

            
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/EventDetail.aspx");
        }

       
    }
}