using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace IPA1.VolunteerLab
{
    public partial class ViewTask : System.Web.UI.Page
    {
        BusLib.Transaction.Task objTask = new BusLib.Transaction.Task();
        Image sortImage = new Image();
        DataTable dataTable;
        int Task_ID = 0;

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

                txtCDate.Attributes.Add("readonly", "readonly");
                txtACDate.Attributes.Add("readonly", "readonly");
              
                    BindGrid1();
                    BindGrid2();
                    BindGrid3();
                    

                    
            }
        }

        void BindGrid1()
        {
            if (Session["User_ID"] != null)
            {
                objTask.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString()); //dynamic

                objTask.Status1 = "Pending";
                objTask.GetDataSet_GetVTask();
                mvTask.ActiveViewIndex = 0;
                GridView1.DataSource = objTask.Ds;
                GridView1.DataBind();
            }
        }
        void BindGrid2()
        {
             if (Session["User_ID"] != null)
             {
              objTask.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            objTask.Status1 = "In Progress";
            objTask.GetDataSet_GetVTask();
            GridView2.DataSource = objTask.Ds;
            GridView2.DataBind();
             }

        }

        void BindGrid3()
        {
            if (Session["User_ID"] != null)
            {
             objTask.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            objTask.Status1 = "Complete";
            objTask.GetDataSet_GetVTask();
            GridView3.DataSource = objTask.Ds;
            GridView3.DataBind();


            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid1();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                //   Response.Redirect("~/Vol_ViewTaskDetail.aspx?Task_ID=" + e.CommandArgument.ToString() + "");
                Task_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvTask.ActiveViewIndex = 1;
                TaskDetailDisplay();
                txtCDate.Attributes.Add("readonly", "readonly");


            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            BindGrid2();
        }

        protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView3.PageIndex = e.NewPageIndex;
            BindGrid3();
        }

        //Start Task Detail

        void FillddlHour()
        {
            ddlHour.Items.Add(new ListItem("-HH-", ""));
            ddlHour1.Items.Add(new ListItem("-HH-", ""));

            for (int i = 1; i < 13; i++)
            {
                if (i < 10)
                {
                    ddlHour.Items.Add(new ListItem("0" + i.ToString(), "0" + i.ToString()));
                    ddlHour1.Items.Add(new ListItem("0" + i.ToString(), "0" + i.ToString()));
                }
                else
                {
                    ddlHour.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    ddlHour1.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

            }
            ddlHour.SelectedIndex = 0;
            ddlHour1.SelectedIndex = 0;

        }
        void FillddlMinute()
        {
            ddlMinute.Items.Add(new ListItem("-MM-"));
            ddlMinute1.Items.Add(new ListItem("-MM-"));
            for (int i = 0; i < 60; i = i + 5)
            {
                if (i <= 5)
                {
                    ddlMinute.Items.Add(new ListItem(("0" + i).ToString(), ("0" + i).ToString()));
                    ddlMinute1.Items.Add(new ListItem(("0" + i).ToString(), ("0" + i).ToString()));
                }
                else
                {
                    ddlMinute.Items.Add(new ListItem((i).ToString(), (i).ToString()));
                    ddlMinute1.Items.Add(new ListItem((i).ToString(), (i).ToString()));
                }

            }
            ddlMinute.SelectedIndex = 0;
            ddlMinute1.SelectedIndex = 0;
        }
        void FillddlAMPM()
        {
            ddlAMPM.Items.Add(new ListItem("AM", "AM"));
            ddlAMPM.Items.Add(new ListItem("PM", "PM"));
            ddlAMPM.SelectedIndex = 1;

            // Actual CTime
            ddlAMPM1.Items.Add(new ListItem("AM", "AM"));
            ddlAMPM1.Items.Add(new ListItem("PM", "PM"));
            ddlAMPM1.SelectedIndex = 1;
        }

        void TaskDetailDisplay()
        {
            if (Task_ID != 0)
            {

                ddlStatus.Items.Clear();
                ddlStatus.Items.Add(new ListItem("Pending", "Pending"));
                ddlStatus.Items.Add(new ListItem("In Progress", "In Progress"));
                ddlStatus.Items.Add(new ListItem("Complete", "Complete"));

                ddlHour1.Items.Clear();
                ddlMinute1.Items.Clear();
                ddlAMPM1.Items.Clear();

                FillddlHour();
                FillddlMinute();
                FillddlAMPM();

                //clear validation text
                lblcvtxtRemarks.Text = "";
                lblcvACTime.Text = "";
                //lblcvCDate.Text = "";
                lblcvStatus.Text = "";
                lblcvWCP.Text = "";

                pRequestAttachment.Visible = false;
                //end


                objTask.Task_ID1 = Convert.ToInt16(Task_ID.ToString());
                objTask.NFNew1 = false;
                objTask.UpdateNFNew();

                objTask.Task_ID1 = Convert.ToInt16(Task_ID.ToString());
                objTask.NFUpdate1 = false;
                objTask.UpdateNFUpdate();

                //objTask.Task_ID1 = Convert.ToInt16(Task_ID.ToString());
                //objTask.NFNearerTask1 = false;
                //objTask.UpdateNFNearerTask();


                objTask.Task_ID1 = Convert.ToInt16(Task_ID.ToString());
                objTask.GetDataSet_GetVViewTaskDetail();

                if (objTask.Ds.Tables[0].Rows[0]["Request_ID"].ToString() != "" && objTask.Ds.Tables[0].Rows[0]["Request_ID"].ToString() != "0")
                {
                    pRequestAttachment.Visible = true;

                }


                txtTask_ID.Text = objTask.Ds.Tables[0].Rows[0]["Task_ID"].ToString();
                String AssignedBy = objTask.Ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + objTask.Ds.Tables[0].Rows[0]["LastName"].ToString() + " | " + objTask.Ds.Tables[0].Rows[0]["Admin_ID"].ToString();
                txtFrom.Text = AssignedBy;
                txtTask.Text = objTask.Ds.Tables[0].Rows[0]["Subject"].ToString();
                txtDetail.Text = objTask.Ds.Tables[0].Rows[0]["Detail"].ToString();
                txtPriority.Text = objTask.Ds.Tables[0].Rows[0]["Priority"].ToString();
                ddlStatus.Text = objTask.Ds.Tables[0].Rows[0]["Status"].ToString();

                String EntryTime = objTask.Ds.Tables[0].Rows[0]["EntryTime"].ToString();
                String EntryTime1 = EntryTime.Substring(0, 4) + " " + EntryTime.Substring(4, 2);

                txtAssignedOn.Text = objTask.Ds.Tables[0].Rows[0]["EntryDate"].ToString() + " " + EntryTime1;


                //txtAssignedOn.Text = objTask.Ds.Tables[0].Rows[0]["EntryDate"].ToString() +" "+ objTask.Ds.Tables[0].Rows[0]["EntryTime"].ToString();
                txtCDate.Text = objTask.Ds.Tables[0].Rows[0]["CompletionDate"].ToString();

                CalendarExtender_ACDate.StartDate = DateTime.ParseExact(objTask.Ds.Tables[0].Rows[0]["EntryDate"].ToString(), "dd-MM-yyyy", null);

                CalendarExtender_ACDate.EndDate = DateTime.Now;


                if (objTask.Ds.Tables[0].Rows[0]["CompletionTime"].ToString() != "")
                {
                    String CTime = objTask.Ds.Tables[0].Rows[0]["CompletionTime"].ToString();
                    ddlHour.Text = CTime.Substring(0, 2);
                    ddlMinute.Text = CTime.Substring(3, 2);
                    ddlAMPM.Text = CTime.Substring(6, 2);

                }
                if (objTask.Ds.Tables[0].Rows[0]["ActualCompletionTime"].ToString() != "")
                {
                    String ACTime = objTask.Ds.Tables[0].Rows[0]["ActualCompletionTime"].ToString();
                    ddlHour1.Text = ACTime.Substring(0, 2);
                    ddlMinute1.Text = ACTime.Substring(3, 2);
                    ddlAMPM1.Text = ACTime.Substring(6, 2);

                }

                if (objTask.Ds.Tables[0].Rows[0]["WCP"].ToString() != "")
                {
                    txtWCP.Text = objTask.Ds.Tables[0].Rows[0]["WCP"].ToString();
                }
                if (objTask.Ds.Tables[0].Rows[0]["Remarks"].ToString() != "")
                {
                    txtRemarks.Text = objTask.Ds.Tables[0].Rows[0]["Remarks"].ToString();
                }
                if (objTask.Ds.Tables[0].Rows[0]["ActualCompletionDate"].ToString() != "")
                {
                    if (objTask.Ds.Tables[0].Rows[0]["ActualCompletionDate"].ToString() == "01-01-1900")
                    {
                        txtACDate.Text = "";
                    }
                    else
                    {
                        txtACDate.Text = objTask.Ds.Tables[0].Rows[0]["ActualCompletionDate"].ToString();
                    }
                    
                }
                else
                {
                    txtACDate.Text = "";
                }


                if (ddlStatus.SelectedValue == "Pending")
                {
                    ddlStatus.Enabled = true;
                    txtWCP.Enabled = false;
                    txtACDate.Enabled = false;
                    ddlHour1.Enabled = false;
                    ddlMinute1.Enabled = false;
                    ddlAMPM1.Enabled = false;
                    txtRemarks.Enabled = false;

                    btnSubmit.Visible = true;
                    btnReset.Visible = true;
                }
                else if (ddlStatus.SelectedValue == "In Progress")
                {
                    ddlStatus.Enabled = true;
                    txtWCP.Enabled = true;
                    txtACDate.Enabled = false;
                    ddlStatus.Items.Remove("Pending");
                    ddlHour1.Enabled = false;
                    ddlMinute1.Enabled = false;
                    ddlAMPM1.Enabled = false;
                    btnSubmit.Visible = true;
                    btnReset.Visible = true;
                }
                else
                {
                    ddlStatus.Enabled = false;
                    txtWCP.Enabled = false;
                    txtACDate.Enabled = false;
                    txtRemarks.Enabled = false;
                    ddlHour1.Enabled = false;
                    ddlMinute1.Enabled = false;
                    ddlAMPM1.Enabled = false;
                    btnSubmit.Visible = false;
                    btnReset.Visible = false;

                }

            }
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
        void Reset()
        {
            if (txtWCP.Enabled == true)
            {
                txtWCP.Text = "";

            }
            if (txtRemarks.Enabled == true)
            {
                txtRemarks.Text = "";
                

            }
            if (ddlHour1.Enabled == true)
            {
                ddlHour1.SelectedIndex = 0;
                ddlMinute1.SelectedIndex = 0;
                ddlAMPM1.SelectedIndex = 1;
            }
            if (txtACDate.Enabled == true)
            {
                txtACDate.Text = "";

            }
            lblcvACTime.Visible = false;
          //  lblcvCDate.Visible = false;
            lblcvStatus.Visible = false;
            lblcvWCP.Visible = false;
            lblcvACTime.Text = "";
            lblcvtxtRemarks.Text = "";

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objTask.ActualComplitionDate1 = "";

            if (ddlStatus.SelectedValue == "In Progress" || ddlStatus.SelectedValue == "Complete")
            {
                if (txtWCP.Text == "")
                {
                    lblcvWCP.Visible = true;
                    lblcvWCP.Text = "Enter Work Completion Percentage";
                    return;
                }
                else
                {
                    lblcvWCP.Visible = false;
                    if (ddlStatus.SelectedValue == "In Progress")
                    {
                        Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                        if (regx.IsMatch(txtWCP.Text))
                        {
                            if ((Convert.ToDecimal(txtWCP.Text)).CompareTo(new decimal(100.00)) >= 0 || (Convert.ToDecimal(txtWCP.Text)).CompareTo(new decimal(00.00)) <= 0)
                            {
                                lblcvWCP.Visible = true;
                                lblcvWCP.Text = "Enter valid WCP in between 0.00 to 100.00!";
                                return;
                            }
                            else
                            {
                                lblcvWCP.Visible = false;

                            }
                        }
                        else
                        {
                            lblcvWCP.Visible = true;
                            lblcvWCP.Text = "Enter valid WCP having atmost 2 digits after decimal point ";
                            return;
                        }
                    }

                }

            }


            if (ddlStatus.SelectedValue == "Complete")
            {
                if (txtACDate.Text == "")
                {
                    lblACDate.Text = "Required";
                    return;
                }
                else
                {
                    objTask.ActualComplitionDate1 = ConvertDate(txtACDate.Text);
               
                 //   String AssignedOn = txtAssignedOn.Text.Substring(0, 10);
                    //if (Convert.ToDateTime(ConvertDate(txtACDate.Text)) < Convert.ToDateTime(ConvertDate(AssignedOn)))
                    //{
                    //    lblcvCDate.Visible = true;
                    //    lblcvCDate.Text = "Completion Date can not be before assigned date!";
                    //    return;
                    //}
                    //else
                    //{
                    //    lblcvCDate.Visible = false;
                    //    //        objTask.CompletionDate1 = Convert.ToDateTime(String.Format("{0:yyyy-dd-MM}", txtACDate.Text).ToString()) ;
                     //   objTask.ActualComplitionDate1 = ConvertDate(txtACDate.Text);

                  //  }

                }
                if (ddlHour1.SelectedIndex == 0 || ddlMinute1.SelectedIndex == 0)
                {
                    lblcvACTime.Text = "Select actual completion time of task";
                    return;
                }
                else
                {
                    String EntryTime = txtAssignedOn.Text.Substring(11, 7);
                    String CTime = ddlHour1.SelectedItem.Text + ":" + ddlMinute1.SelectedItem.Text + " " + ddlAMPM1.SelectedItem.Text;

                    String AssignedOn = txtAssignedOn.Text.Substring(0, 10);
                    if (Convert.ToDateTime(ConvertDate(txtACDate.Text)).Equals( Convert.ToDateTime(ConvertDate(AssignedOn)) ) )
                    {


                        if (Convert.ToDateTime(CTime) <= Convert.ToDateTime(EntryTime))
                        {
                            lblcvACTime.Text = "Actual Completion time can not be on or before assigned time !";
                            return;
                        }
                    }
                    else
                    {
                        //TimeSpan ts = new TimeSpan(0, 30, 0);
                        //DateTime NewTime = Convert.ToDateTime(EntryTime).Add(ts);
                        //if (Convert.ToDateTime(CTime) >= Convert.ToDateTime(NewTime))
                        //{
                        //    lblcvCTime.Text = "";

                        //}
                        //else
                        //{
                        //    lblcvCTime.Text = "Actual task completion time must be >30 minutes than the assigned time";
                        //    return;
                        //}

                        lblcvACTime.Text = "";
                        objTask.ActualComplitionTime1 = ddlHour1.SelectedItem.Text + ":" + ddlMinute1.SelectedItem.Text + " " + ddlAMPM1.SelectedItem.Text;

                    }

                }

                if (txtRemarks.Text=="")
                {
                    lblcvtxtRemarks.Text = "*";
                    return;
                }
                else
                {
                    lblcvtxtRemarks.Text = "";
                }
            }


            objTask.Task_ID1 = Convert.ToInt16(txtTask_ID.Text);
            objTask.Status1 = ddlStatus.SelectedValue;

            if (txtWCP.Text.Length > 0)
            {
                objTask.WCP1 = Convert.ToDecimal(txtWCP.Text);
            }
            if (txtRemarks.Text.Length > 0)
            {
                objTask.Remarks1 = txtRemarks.Text;
            }
            else
            {
                objTask.Remarks1 = "";

            }


            objTask.VUpdate();

            

            if (ddlStatus.SelectedValue=="In Progress")
            {
                objTask.Task_ID1 = Convert.ToInt16(txtTask_ID.Text);
                objTask.NFInProgress1 = true;
                objTask.UpdateNFInProgress();
            }

            if (ddlStatus.SelectedValue == "Complete")
            {
                objTask.Task_ID1 =  Convert.ToInt16(txtTask_ID.Text);
                objTask.NFComplete1 = true;
                objTask.UpdateNFComplete();

                objTask.Task_ID1  = Convert.ToInt16(txtTask_ID.Text);
                objTask.NFNearerTask1 = false;
                objTask.UpdateNFNearerTask();


            }
            //string message = "Update successfully.";
            //string url = "ViewTask.aspx";
            //string script = "window.onload = function(){ alert('";
            //script += message;
            //script += "');";
            //script += "window.location = '";
            //script += url;
            //script += "'; }";
            //ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);


            //   Response.Redirect("~/Vol_ViewTask.aspx");

            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Task detail updated suceessfully.'); </script>");
            BindGrid1();
            BindGrid2();
            BindGrid3();
            mvTask.ActiveViewIndex = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            BindGrid1();
            BindGrid2();
            BindGrid3();
          //  mvTask.ActiveViewIndex = 0;
            Response.Redirect("~/VolunteerLab/ViewTask.aspx");
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (ddlStatus.SelectedValue=="Complete")
            //{
            //    lblACDate.Visible = true;
            //    txtACDate.Visible = true;
            //}

            if (ddlStatus.SelectedValue == "Pending")
            {
                txtWCP.Text = "";
                txtWCP.Enabled = false;
                txtACDate.Enabled = false;
                ddlHour1.Enabled = false;
                ddlMinute1.Enabled = false;
                ddlAMPM1.Enabled = false;
                txtRemarks.Enabled = false;
                //lblcvCDate.Visible = false;
                lblcvACTime.Visible = false;
                lblcvWCP.Visible = false;
                txtACDate.Text = "";
            }
            else if (ddlStatus.SelectedValue == "In Progress")
            {
                txtWCP.Text = "";
                txtWCP.Enabled = true;
                txtACDate.Enabled = false;
                ddlHour1.Enabled = false;
                ddlMinute1.Enabled = false;
                ddlAMPM1.Enabled = false;
                //lblcvCDate.Visible = false;
                lblcvACTime.Visible = false;
                lblcvACTime.Text = "";
                txtACDate.Text = "";
            }
            else
            {
                txtWCP.Text = "100.00";
                txtACDate.Text = ConvertDate(System.DateTime.Now.ToString());
                txtWCP.Enabled = false;
                txtACDate.Enabled = true;
                txtRemarks.Enabled = true;
              
                ddlHour1.Enabled = true;
                ddlMinute1.Enabled = true;
                ddlAMPM1.Enabled = true;

                ddlHour1.CssClass = "form-grid_dropdown";
                ddlMinute1.CssClass = "form-grid_dropdown";
                ddlAMPM1.CssClass = "form-grid_dropdown";

                txtACDate.Text = "";
            }

        }

        protected void txtACDate_TextChanged(object sender, EventArgs e)
        {

        }


        //End Task Detail


        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            objTask.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());

            objTask.Status1 = "Pending";

            objTask.GetDataSet_GetVTask();

            dataTable = objTask.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in GridView1.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                GridView1.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
        }

        protected void GridView2_Sorting(object sender, GridViewSortEventArgs e)
        {
            objTask.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());

            objTask.Status1 = "In Progress";

            objTask.GetDataSet_GetVTask();

            dataTable = objTask.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                GridView2.DataSource = dataTable;
                GridView2.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in GridView2.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = GridView2.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                GridView2.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }

        }

        protected void GridView3_Sorting(object sender, GridViewSortEventArgs e)
        {
            objTask.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());

            objTask.Status1 = "Complete";

            objTask.GetDataSet_GetVTask();

            dataTable = objTask.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                GridView3.DataSource = dataTable;
                GridView3.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in GridView3.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = GridView3.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                GridView3.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
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

        protected void ddlRecPerPage1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage1.SelectedValue == "All")
            {
                GridView1.AllowPaging = false;
                BindGrid1();
            }

            else
            {
                GridView1.AllowPaging = true;
                GridView1.PageSize = Convert.ToInt16(ddlRecPerPage1.SelectedValue);
                BindGrid1();
            }
        }


        protected void ddlRecPerPage2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage2.SelectedValue == "All")
            {
                GridView2.AllowPaging = false;
                BindGrid2();
            }

            else
            {
                GridView2.AllowPaging = true;
                GridView2.PageSize = Convert.ToInt16(ddlRecPerPage3.SelectedValue);
                BindGrid2();
            }
        }

        protected void ddlRecPerPage3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage3.SelectedValue == "All")
            {
                GridView3.AllowPaging = false;
                BindGrid3();
            }

            else
            {
                GridView3.AllowPaging = true;
                GridView3.PageSize = Convert.ToInt16(ddlRecPerPage3.SelectedValue);
                BindGrid3();
            }
        }

        
        
        protected void lbTasks_Click(object sender, EventArgs e)
        {
            BindGrid1();
            BindGrid2();
            BindGrid3();
            mvTask.ActiveViewIndex = 0;
        }

        protected void lbRequestDetail_Click(object sender, EventArgs e)
        {
            objTask.Task_ID1 = Convert.ToInt16(txtTask_ID.Text);
            objTask.GetDataSet_GetVViewTaskDetail();
            String Request_ID = objTask.Ds.Tables[0].Rows[0]["Request_ID"].ToString();
            if (Request_ID != "")
            {

                Response.Redirect("~/AdminLab/ForwardRequestDetail.aspx?Request_ID=" + Request_ID + "");

            }
        }


    }
}