using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;


namespace IPA1.AdminLab
{
    public partial class EventDetail : System.Web.UI.Page
    {
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();
        BusLib.Transaction.Event objEvent = new BusLib.Transaction.Event();

        DataTable dataTable;
        String Event_ID;
    
        public int PageSize = 5;

        private string _sortDirection;

        public string SortDireaction
        {
            get
            {
                if (ViewState["SortDireaction"] == null)
                    return string.Empty;
                else
                    return ViewState["SortDireaction"].ToString();
            }
            set
            {
                ViewState["SortDireaction"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                
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


        void BindGrid()
        {
            if (txtSearch.Text.Trim() != "")
            {
                objEvent.GetDataset(txtSearch.Text.Trim());
                gvEvent.DataSource = objEvent.Ds;
                gvEvent.DataBind();
                if (objEvent.Ds.Tables[0].Rows.Count == 1 && objEvent.Ds.Tables[0].Rows[0]["Event_ID"].ToString() == "")
                {
                    Button btnView = gvEvent.Rows[0].FindControl("btnView") as Button;
                    btnView.Visible = false;
                }

            }
            else
            {
                objEvent.GetDataset("");
                gvEvent.DataSource = objEvent.Ds.Tables[0];
                gvEvent.DataBind();
                mvEvent.ActiveViewIndex = 0;

            }
            //gvEvent.AllowPaging = false;
            //for (int i = 0; i < objEvent.Ds.Tables[0].Rows.Count; i++)
            //{
            //    DateTime.
            //    if (objEvent.Ds.Tables[0].Rows[i]["EventDate"].ToString() == "False")
            //    {
            //        Label lblNew = (Label)gvEvent.Rows[i].FindControl("lblNew");
            //        lblNew.Visible = true;

            //    }
            //}

        }
        protected void btnRegisterEvent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/EventForm.aspx");
        }


        
        protected void gvEvent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEvent.PageIndex = e.NewPageIndex;
            BindGrid();

            if (ViewState["SortExpression"] != null)
            {
                objEvent.GetDataset(txtSearch.Text.Trim());
                dataTable = objEvent.Ds.Tables[0];
                if (dataTable != null)
                {
                    if (SortDireaction == "ASC")
                    {
                        sortImage.ImageUrl = "../img/icon_up_sort_arrow.png";
                    }
                    else
                    {
                        sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";
                    }

                    dataTable.DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + SortDireaction;
                    gvEvent.DataSource = dataTable;
                    gvEvent.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvEvent.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvEvent.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvEvent.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
        
        }

        protected void gvEvent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Event_ID = e.CommandArgument.ToString();
                mvEvent.ActiveViewIndex = 1;
                EventDetailDisplay();
                txtEventDate.Attributes.Add("readonly", "readonly");
                CalendarExtender_EventDate.StartDate = DateTime.Now;
            }

        }

        void EventDetailDisplay()
        {
            if (Event_ID!="")
            {
                lblcvStartTime.Text = "";
                lblcvEndTime.Text = "";

                FillddlHour();
                FillddlMinute();
                FillddlAMPM();

                objEvent.Event_ID1 = Convert.ToInt16(Event_ID);
                objEvent.GetDataset("");

                txtEvent_ID.Text = objEvent.Ds.Tables[0].Rows[0]["Event_ID"].ToString();
                txtEntryDate.Text = objEvent.Ds.Tables[0].Rows[0]["EntryDate"].ToString(); 
                txtEventName.Text = objEvent.Ds.Tables[0].Rows[0]["EventName"].ToString();
                txtEventDescription.Text = objEvent.Ds.Tables[0].Rows[0]["EventDescription"].ToString();
                txtEventDate.Text = objEvent.Ds.Tables[0].Rows[0]["EventDate"].ToString(); 
                
              
                if (objEvent.Ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    String CTime = objEvent.Ds.Tables[0].Rows[0]["StartTime"].ToString();
                    ddlHour.Text = CTime.Substring(0, 2);
                    ddlMinute.Text = CTime.Substring(3, 2);
                    ddlAMPM.Text = CTime.Substring(6, 2);

                }

                if (objEvent.Ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    String CTime = objEvent.Ds.Tables[0].Rows[0]["EndTime"].ToString();
                    ddlHour1.Text = CTime.Substring(0, 2);
                    ddlMinute1.Text = CTime.Substring(3, 2);
                    ddlAMPM1.Text = CTime.Substring(6, 2);

                }


                txtEventLocation.Text = objEvent.Ds.Tables[0].Rows[0]["Location"].ToString();

                DateTime EventDate = DateTime.ParseExact(txtEventDate.Text, "dd-MM-yyyy", null);
                DateTime TodayDate = DateTime.Now;

                if (objEvent.Ds.Tables[0].Rows[0]["EventType"].ToString() == "Upcoming Event")
                {
                    txtEventName.Enabled = true;
                    txtEventDescription.Enabled = true;
                    txtEventDate.Enabled = true;
                    ddlHour.Enabled = true;
                    ddlMinute.Enabled = true;
                    ddlAMPM.Enabled = true;

                    ddlHour1.Enabled = true;
                    ddlMinute1.Enabled = true;
                    ddlAMPM1.Enabled = true;

                    txtEventLocation.Enabled = true;
                    btnDelete.Visible = true;

                    CalendarExtender_EventDate.StartDate = TodayDate;
                }
                else
                {
                    txtEventName.Enabled = false;
                    txtEventDescription.Enabled = false;
                    txtEventDate.Enabled = false;

                    ddlHour.Enabled = false;
                    ddlMinute.Enabled = false;
                    ddlAMPM.Enabled = false;

                    ddlHour1.Enabled = false;
                    ddlMinute1.Enabled = false;
                    ddlAMPM1.Enabled = false;

                    txtEventLocation.Enabled = false;
                    btnDelete.Visible = false;

                }
            }
        }
        protected void gvEvent_Sorting(object sender, GridViewSortEventArgs e)
        {
            objEvent.GetDataset("");

            dataTable = objEvent.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;
                gvEvent.DataSource = dataTable;
                gvEvent.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvEvent.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvEvent.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvEvent.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
        }
        protected void SetSortDirection(string sortDirection)
        {
            if (sortDirection == "ASC")
            {
                _sortDirection = "DESC";
                sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";

            }
            else
            {
                _sortDirection = "ASC";
                sortImage.ImageUrl = "../img/icon_up_sort_arrow.png";
            }
        }

        


        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvEvent.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvEvent.AllowPaging = true;
                gvEvent.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }

            if (ViewState["SortExpression"] != null)
            {
                objEvent.GetDataset(txtSearch.Text.Trim());
                dataTable = objEvent.Ds.Tables[0];
                if (dataTable != null)
                {
                    if (SortDireaction == "ASC")
                    {
                        sortImage.ImageUrl = "../img/icon_up_sort_arrow.png";
                    }
                    else
                    {
                        sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";
                    }

                    dataTable.DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + SortDireaction;
                    gvEvent.DataSource = dataTable;
                    gvEvent.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvEvent.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvEvent.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvEvent.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
        
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            objEvent.GetDataset(txtSearch.Text.Trim());
            gvEvent.DataSource = objEvent.Ds;
            gvEvent.DataBind();
            if (objEvent.Ds.Tables[0].Rows.Count == 1 && objEvent.Ds.Tables[0].Rows[0]["Event_ID"].ToString() == "")
            {
                Button btnView = gvEvent.Rows[0].FindControl("btnView") as Button;
                btnView.Visible = false;
            }
        }
        
       
        //Start Event Detail

        void Reset()
        {
            txtEvent_ID.Text = "";
            txtEntryDate.Text = "";
            txtEventName.Text = "";
            txtEventDescription.Text = "";
            txtEventDate.Text = "";
            

            txtEventLocation.Text = "";
           
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

            
            objEvent.Event_ID1 = Convert.ToInt16(txtEvent_ID.Text);
            objEvent.EventName1 = txtEventName.Text.Trim();
            objEvent.EventDescription1 = txtEventDescription.Text.Trim();
            objEvent.EventDate1 = ConvertDate(txtEventDate.Text);

            String StartTime1 = ddlHour.SelectedItem.Text + ":" + ddlMinute.SelectedItem.Text + " " + ddlAMPM.SelectedItem.Text;
            String EndTime1 = ddlHour1.SelectedItem.Text + ":" + ddlMinute1.SelectedItem.Text + " " + ddlAMPM1.SelectedItem.Text;

            objEvent.StartTime1 = StartTime1;
            objEvent.EndTime1 = EndTime1;


            objEvent.Location1 = txtEventLocation.Text.Trim();
            objEvent.Update();

            Response.Write("<script language='javascript'>window.alert('Event Detail Updated Sucessfully');window.location='EventDetail.aspx';</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            objEvent.Event_ID1 = Convert.ToInt16(txtEvent_ID.Text);
            objEvent.Delete();

            Response.Write("<script language='javascript'>window.alert('Event Detail Deleted Sucessfully');window.location='EventDetail.aspx';</script>");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvEvent.ActiveViewIndex = 0;
            BindGrid();
        }


     
        protected void lbEvents_Click(object sender, EventArgs e)
        {
            mvEvent.ActiveViewIndex = 0;
            BindGrid();
        }

        

        

        //End Event Detail

    }
}