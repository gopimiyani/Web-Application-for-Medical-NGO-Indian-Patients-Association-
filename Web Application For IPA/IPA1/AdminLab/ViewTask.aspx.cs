using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Configuration;

using System.Web.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;

namespace IPA1.AdminLab
{
    public partial class AssignTask : System.Web.UI.Page
    {
        BusLib.Transaction.Task objTask = new BusLib.Transaction.Task();
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();
        DataTable dataTable;
        String Task_ID;
        string CDate = "";

        public int PageSize =5;
        
     //   sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";
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

                CalendarExtender_CDate.StartDate = DateTime.Now;
            }

        }
        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                GridView1.AllowPaging = false;
                BindGrid1();
            }

            else
            {
                GridView1.AllowPaging = true;
                GridView1.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid1();
            }
        }
   
        void BindGrid1()
        {
            if (txtSearch.Text.Trim() != "")
            {
                objTask.GetDataSet_GetATask(txtSearch.Text.Trim());
                GridView1.DataSource = objTask.Ds;
                GridView1.DataBind();
                if (objTask.Ds.Tables[0].Rows.Count == 1 && objTask.Ds.Tables[0].Rows[0]["Task_ID"].ToString() == "")
                {
                    Button btnView = GridView1.Rows[0].FindControl("btnView") as Button;
                    btnView.Visible = false;
                }

            }
            else
            {
                objTask.GetDataSet_GetATask("");
                GridView1.DataSource = objTask.Ds.Tables[0];
                GridView1.DataBind();
                mvTask.ActiveViewIndex = 0;
      
            }
            //sortImage.ImageUrl = "../img/bullet-arrow-up-down-icon.png";
            //int columnIndex = 0;
            //foreach (DataControlFieldHeaderCell headerCell in GridView1.HeaderRow.Cells)
            //{
            //        columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell);
            //        GridView1.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            //}

           
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid1();

        }

        

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin_AssignTask.aspx");
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "View")
            {
                Task_ID = e.CommandArgument.ToString();
                mvTask.ActiveViewIndex = 1;
                FillddlName();
                TaskDetailDisplay("");
                txtCDate.Attributes.Add("readonly", "readonly");
        
               // Response.Redirect("~/Admin_ViewTaskDetail.aspx?Task_ID=" + e.CommandArgument.ToString() + "");
            }

        }

        // Start Task Detail

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


        void FillddlName()
        {
            objTask.GetDataSet_GetVName();
            ddlVName.DataSource = objTask.Ds.Tables[0];
            ddlVName.DataTextField = "Name";
            ddlVName.DataValueField = "User_ID";
            //       ddlVName.SelectedIndex = 0;
            ddlVName.DataBind();

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

        void TaskDetailDisplay(String TaskType)
        {
            
            if (Task_ID != "")
            {

                ddlHour.Items.Clear();
                ddlHour1.Items.Clear();
                ddlMinute.Items.Clear();
                ddlMinute1.Items.Clear();
                ddlAMPM.Items.Clear();
                ddlAMPM1.Items.Clear();

                btnDelete.Visible = true;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;

                //clear validation text

                lblcvCDate.Text = "";
                lblcvCTime.Text = "";
                

                //end

                
                FillddlHour();
                FillddlMinute();
                FillddlAMPM();


                objTask.Task_ID1 = Convert.ToInt16(Task_ID);
                objTask.NFInProgress1 = false;
                objTask.UpdateNFInProgress();


                objTask.Task_ID1 = Convert.ToInt16(Task_ID);
                objTask.NFComplete1 = false;
                objTask.UpdateNFComplete();

                objTask.Task_ID1 = Convert.ToInt16(Task_ID);
                objTask.GetDataSet_GetAViewTaskDetail();

                if (objTask.Ds.Tables[0].Rows[0]["Request_ID"].ToString() != "" && objTask.Ds.Tables[0].Rows[0]["Request_ID"].ToString() != "0")
                {
                    pRequestAttachment.Visible = true;

                }
                txtTask_ID.Text = objTask.Ds.Tables[0].Rows[0]["Task_ID"].ToString();
                ddlStatus.Text = objTask.Ds.Tables[0].Rows[0]["Status"].ToString();
                txtExtendedDays.Text = objTask.Ds.Tables[0].Rows[0]["ExtendedDays"].ToString();
                
                if (ddlStatus.Text == "Pending")
                {
                    txtCDate.Enabled = true;
                    txtDetail.Enabled = true;
                    txtSubjectA.Enabled = true;
                    ddlPriority.Enabled = true;
                   
                    btnDelete.Visible = false;

                    ddlHour.Enabled = true;
                    ddlMinute.Enabled = true;
                    ddlAMPM.Enabled = true;
                }
                else
                {
                    txtCDate.Enabled = false;
                    txtDetail.Enabled = false;
                    txtSubjectA.Enabled = false;
                    ddlPriority.Enabled = false;
                    ddlHour.Enabled = false;
                    ddlMinute.Enabled = false;
                    ddlAMPM.Enabled = false;
                   
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    
                }
                //if (TaskType=="ExtendedTask")
                //{
                    
                //    txtCDate.Enabled = true;
                //    ddlHour.Enabled = true;
                //    ddlMinute.Enabled = true;
                //    ddlAMPM.Enabled = true;
                    
                //    btnUpdate.Visible = true;
                  
                //    btnDelete.Visible = false;

                //}
                //else
                //{

                // //   txtCDate.Enabled = false;
                // //   ddlHour.Enabled = false;
                // //   ddlMinute.Enabled = false;
                // //   ddlAMPM.Enabled = false;
                // ////   btnUpdate.Visible = false;
                // //   btnDelete.Visible = false;

                //}

                ddlVName.SelectedValue = objTask.Ds.Tables[0].Rows[0]["User_ID"].ToString();
                txtSubjectA.Text = objTask.Ds.Tables[0].Rows[0]["Subject"].ToString();
                txtDetail.Text = objTask.Ds.Tables[0].Rows[0]["Detail"].ToString();
                ddlPriority.Text = objTask.Ds.Tables[0].Rows[0]["Priority"].ToString();
                //lblAssignedOn.Text = objTask.Ds.Tables[0].Rows[0]["EntryDateTime"].ToString();

                String EntryTime = objTask.Ds.Tables[0].Rows[0]["EntryTime"].ToString();
                String EntryTime1 = EntryTime.Substring(0, 4) + " " + EntryTime.Substring(4, 2);

                lblAssignedOn.Text = objTask.Ds.Tables[0].Rows[0]["EntryDate"].ToString() + " " + EntryTime1;

                //   lblAssignedOn.Text = objTask.Ds.Tables[0].Rows[0]["EntryDateTimeDisp"].ToString();

                txtCDate.Text = objTask.Ds.Tables[0].Rows[0]["CompletionDate"].ToString();

                CDate = txtCDate.Text;

                if (objTask.Ds.Tables[0].Rows[0]["CompletionTime"].ToString() != "")
                {
                    String CTime = objTask.Ds.Tables[0].Rows[0]["CompletionTime"].ToString();
                    ddlHour.Text = CTime.Substring(0, 2);
                    ddlMinute.Text = CTime.Substring(3, 2);
                    ddlAMPM.Text = CTime.Substring(6, 2);

                }


                txtACDate.Text = objTask.Ds.Tables[0].Rows[0]["ActualCompletionDate"].ToString();
                txtRemarks.Text = objTask.Ds.Tables[0].Rows[0]["Remarks"].ToString();
                txtWCP.Text = objTask.Ds.Tables[0].Rows[0]["WCP"].ToString();

                if (objTask.Ds.Tables[0].Rows[0]["ActualCompletionTime"].ToString() != "")
                {
                    String ACTime = objTask.Ds.Tables[0].Rows[0]["ActualCompletionTime"].ToString();
                    ddlHour1.Text = ACTime.Substring(0, 2);
                    ddlMinute1.Text = ACTime.Substring(3, 2);
                    ddlAMPM1.Text = ACTime.Substring(6, 2);

                }

            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
         //   mvTask.ActiveViewIndex = 0;
            Response.Redirect("~/AdminLab/ViewTask.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                objTask.Task_ID1 = Convert.ToInt16(Task_ID.ToString());
                
                objTask.Delete();
                
                //   Reset();
                Response.Redirect("~/Admin_ViewTask.aspx");
            }
            else
            {

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            
            objTask.Task_ID1 = Convert.ToInt16(txtTask_ID.Text);
            objTask.User_ID1 = Convert.ToInt16(ddlVName.SelectedValue);
            objTask.Subject1 = txtSubjectA.Text;
            objTask.Detail1 = txtDetail.Text;
            objTask.Priority1 = ddlPriority.SelectedValue;
            objTask.Status1 = ddlStatus.SelectedValue;
            objTask.EntryDateTime1 = DateTime.Now;
           
            //start

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


            //end

        objTask.CompletionDate1 = ConvertDate( txtCDate.Text );
        //if (CDate!="")
        //{
        //    int ExtendedDays = Convert.ToInt16(CDate.ToString()) - Convert.ToInt16(txtCDate.Text);
        //    objTask.ExtendedDays1 = ExtendedDays.ToString();
        //    CDate = "";
        //}
        
            
            objTask.CompletionTime1 = ddlHour.SelectedItem.Text + ":" + ddlMinute.SelectedItem.Text + " " + ddlAMPM.SelectedItem.Text;

            if (txtACDate.Text != "")
            {
                objTask.ActualComplitionDate1 = ConvertDate(txtACDate.Text);

            }
            if (txtRemarks.Text != "")
            {
                objTask.Remarks1 = txtRemarks.Text;

            }

            if (txtWCP.Text != "")
            {
                objTask.WCP1 = Convert.ToDecimal(txtWCP.Text);

            }

            if (txtExtendedDays.Text!="")
            {
                objTask.ExtendedDays1 = txtExtendedDays.Text;        
            }

            objTask.AUpdate();

            objTask.Task_ID1 = Convert.ToInt16(txtTask_ID.Text);
            
            objTask.NFUpdate1 = true;
            objTask.UpdateNFUpdate();

            //    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Update  Successfully!!'); </script>");
            //string message = "Update successfully.";
            //string url = "Admin_ViewTask.aspx";
            //string script = "window.onload = function(){ alert('";
            //script += message;
            //script += "');";
            //script += "window.location = '";
            //script += url;
            //script += "'; }";
            //ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

              Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Task Detail Updated Successfully'); </script>");
              BindGrid1();
              BindGrid2();
              mvTask.ActiveViewIndex = 0;
          
        }

        protected void ddlVName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void txtRemarks_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlStatus.Text == "Pending")
            {
                txtCDate.Enabled = true;
                txtDetail.Enabled = true;
                txtSubjectA.Enabled = true;
                ddlPriority.Enabled = true;
              //  ddlPriority.cssClass = "form-grid_dropdown";
            //    btnDelete.Visible = true;
                ddlHour.Enabled = true;
                ddlMinute.Enabled = true;
                ddlAMPM.Enabled = true;
            }
            else
            {
                txtCDate.Enabled = false;
                txtDetail.Enabled = false;
                txtSubjectA.Enabled = false;
                ddlPriority.Enabled = false;
        //        ddlPriority.cssClass = "disable";
                //    btnDelete.Visible = false;
                ddlHour.Enabled = false;
                ddlMinute.Enabled = false;
                ddlAMPM.Enabled = false;
                //ddlHour.cssClass = "disable";
                //ddlMinute.cssClass = "disable";
                //ddlAMPM.cssClass = "disable";
                btnUpdate.Visible = false;
                btnDelete.Visible = false;

            }
        }





        protected void ddlStatus_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindGrid1();

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            objTask.GetDataSet_GetATask("");

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

   /*     protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Label lblTask_ID = (Label)Repeater1.Items[e.Item.ItemIndex].FindControl("lblTask_ID");
            Task_ID = lblTask_ID.Text;
        }*/

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            Response.Redirect("AssignTask.aspx");
        }


        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

            objTask.GetDataSet_GetATask(txtSearch.Text.Trim());
            GridView1.DataSource = objTask.Ds;
            GridView1.DataBind();
            if (objTask.Ds.Tables[0].Rows.Count == 1 && objTask.Ds.Tables[0].Rows[0]["Task_ID"].ToString() == "")
            {
                Button btnView = GridView1.Rows[0].FindControl("btnView") as Button;
                btnView.Visible = false;
            }

        }
        protected void lbTasks_Click(object sender, EventArgs e)
        {
            BindGrid1();
            BindGrid2();
            mvTask.ActiveViewIndex = 0;
        }

        // start extended tasks

        void BindGrid2()
        {
            if (txtSearch1.Text.Trim() != "")
            {
                objTask.GetDataSet_GetExtendedCDateTask(txtSearch1.Text.Trim());
                gvExtendedTask.DataSource = objTask.Ds;
                gvExtendedTask.DataBind();
                if (objTask.Ds.Tables[0].Rows.Count == 1 && objTask.Ds.Tables[0].Rows[0]["Task_ID"].ToString() == "")
                {
                    Button btnView = GridView1.Rows[0].FindControl("btnView") as Button;
                    btnView.Visible = false;
                }

            }
            else
            {
                objTask.GetDataSet_GetExtendedCDateTask("");
                gvExtendedTask.DataSource = objTask.Ds.Tables[0];
                gvExtendedTask.DataBind();
                mvTask.ActiveViewIndex = 0;

            }


        }
        protected void gvExtendedTask_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvExtendedTask.PageIndex = e.NewPageIndex;
            BindGrid2();

        }

        protected void gvExtendedTask_Sorting(object sender, GridViewSortEventArgs e)
        {
            objTask.GetDataSet_GetExtendedCDateTask("");
            dataTable = objTask.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                gvExtendedTask.DataSource = dataTable;
                gvExtendedTask.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvExtendedTask.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvExtendedTask.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvExtendedTask.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
        }

        protected void gvExtendedTask_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Task_ID = e.CommandArgument.ToString();
                mvTask.ActiveViewIndex = 1;
                FillddlName();
                TaskDetailDisplay("ExtendedTask");
                txtCDate.Attributes.Add("readonly", "readonly");
            }
        }

        protected void ddlRecPerPage1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage1.SelectedValue == "All")
            {
                gvExtendedTask.AllowPaging = false;
                BindGrid2();
            }

            else
            {
                gvExtendedTask.AllowPaging = true;
                gvExtendedTask.PageSize = Convert.ToInt16(ddlRecPerPage1.SelectedValue);
                BindGrid2();
            }
        }

        protected void txtSearch1_TextChanged(object sender, EventArgs e)
        {
            objTask.GetDataSet_GetExtendedCDateTask(txtSearch.Text.Trim());
            gvExtendedTask.DataSource = objTask.Ds;
            gvExtendedTask.DataBind();
            if (objTask.Ds.Tables[0].Rows.Count == 1 && objTask.Ds.Tables[0].Rows[0]["Task_ID"].ToString() == "")
            {
                Button btnView = gvExtendedTask.Rows[0].FindControl("btnView") as Button;
                btnView.Visible = false;
            }

        }

        protected void btnView_Click1(object sender, EventArgs e)
        {

        }

        protected void lbRequestDetail_Click(object sender, EventArgs e)
        {
            objTask.Task_ID1 = Convert.ToInt16(txtTask_ID.Text);
            objTask.GetDataSet_GetAViewTaskDetail();
            String Request_ID=objTask.Ds.Tables[0].Rows[0]["Request_ID"].ToString();
            if ( Request_ID != "")
            {

                Response.Redirect("~/AdminLab/ForwardRequestDetail.aspx?Request_ID=" + Request_ID + "");

            }
        }
       

    }
}