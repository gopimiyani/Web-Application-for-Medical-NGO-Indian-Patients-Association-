using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using System.Net.Mail;

namespace IPA1.AdminLab
{
    public partial class ForwardRequest : System.Web.UI.Page
    {
    BusLib.Transaction.Request objRequest = new BusLib.Transaction.Request();
        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();
        BusLib.Common.Registration objReg = new BusLib.Common.Registration();

        int Request_ID = 0;
        int User_ID = 0;
        int User_ID1 = 0;
        Image sortImage = new Image();

        DataTable dataTable;

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
                if (Request.QueryString.Count==0)
                {
                    Response.Redirect("~/AdminLab/ViewRequest.aspx");   
                }
                mvForwardRequest.ActiveViewIndex = 0;
           //     objReg.PinCode1 = Convert.ToInt32(txtVSearch.Text);

                objReg.GetDataSet_Search_Volunteer();
                gvUser.DataSource = objReg.Ds;
                gvUser.DataBind();

            }
        }

        protected void SetSortDirection(string sortDirection)
        {
            if (sortDirection == "ASC")
            {
                _sortDirection = "DESC";
                //       sortImage.ImageUrl = "../img/view_sort_ascending.png";
                sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";
            }
            else
            {
                _sortDirection = "ASC";
                //      sortImage.ImageUrl = "../img/view_sort_descending.png";
                sortImage.ImageUrl = "../img/icon_up_sort_arrow.png";
            }
        }

        protected void lbPatientRequests_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/ViewRequest.aspx");
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtVSearch.Text!="")
            {
                objReg.PinCode1 = Convert.ToInt32(txtVSearch.Text);

            }
            objReg.GetDataSet_Search_Volunteer();
            gvUser.DataSource = objReg.Ds;
            gvUser.DataBind();
            if (objReg.Ds.Tables[0].Rows.Count == 1 && objReg.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
            {
                Button btnView = gvUser.Rows[0].FindControl("btnView") as Button;
                btnView.Visible = false;
            }

            if (ViewState["SortExpression"] != null)
            {
                objReg.GetDataSet_Search();
                dataTable = objReg.Ds.Tables[0];
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
                    gvUser.DataSource = dataTable;
                    gvUser.DataBind();
                    if (objReg.Ds.Tables[0].Rows.Count == 1 && objReg.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                    {
                        Button btnView = gvUser.Rows[0].FindControl("btnView") as Button;
                        btnView.Visible = false;
                    }
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvUser.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvUser.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvUser.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }



        }

        protected void gvUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUser.PageIndex = e.NewPageIndex;
            if (ViewState["SortExpression"] != null)
            {
                if (txtVSearch.Text != "")
                {
                    objReg.PinCode1 = Convert.ToInt16(txtVSearch.Text);

                }
                objReg.GetDataSet_Search_Volunteer();
                dataTable = objReg.Ds.Tables[0];
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
                    gvUser.DataSource = dataTable;
                    gvUser.DataBind();
                    if (objReg.Ds.Tables[0].Rows.Count == 1 && objReg.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                    {
                        Button btnView = gvUser.Rows[0].FindControl("btnView") as Button;
                        btnView.Visible = false;
                    }
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvUser.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvUser.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvUser.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

        }
        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (txtVSearch.Text != "")
            {
                objReg.PinCode1 = Convert.ToInt16(txtVSearch.Text);
               
            }
            objReg.GetDataSet_Search_Volunteer();
            dataTable = objReg.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;

                gvUser.DataSource = dataTable;
                gvUser.DataBind();
                if (objReg.Ds.Tables[0].Rows.Count == 1 && objReg.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                {
                    Button btnView = gvUser.Rows[0].FindControl("btnView") as Button;
                    btnView.Visible = false;
                }
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvUser.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvUser.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvUser.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
        }

        

        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                // Response.Redirect("~/Search.aspx?Admin_ID=" + e.CommandArgument.ToString() + "");
                User_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvForwardRequest.ActiveViewIndex = 1;
                UserDetailDisplay();

            }
            if (e.CommandName == "Forward")
            {
                Response.Redirect("~/AdminLab/AssignTask.aspx?User_ID=" + e.CommandArgument.ToString() + " &Request_ID=" + Request.QueryString["RequestNo"].ToString()+ "");
            }

        }
        void UserDetailDisplay()
        {
            if (User_ID != 0)
            {
                objReg.User_ID1 = Convert.ToInt16(User_ID.ToString());
                objReg.GetDataset_GetVolnteerDetail();
                txtVUserID.Text = objReg.Ds.Tables[0].Rows[0]["User_ID"].ToString();
                User_ID1 = Convert.ToInt16(txtVUserID.Text);

                txtFirstName.Text = objReg.Ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + objReg.Ds.Tables[0].Rows[0]["LastName"].ToString();

                // txtUserName.Text = objUserRegister.Ds.Tables[0].Rows[0]["UserName"].ToString();
                txtVEmail.Text = objReg.Ds.Tables[0].Rows[0]["Email"].ToString();
                // txtPassword.Text = objUserRegister.Ds.Tables[0].Rows[0]["Password"].ToString();
                //txtConfirmPassword.Text = objUserRegister.Ds.Tables[0].Rows[0]["ConfirmPassword"].ToString();
                txtVAddress.Text = objReg.Ds.Tables[0].Rows[0]["Address"].ToString() + ", " + objReg.Ds.Tables[0].Rows[0]["City"].ToString() + "- " + objReg.Ds.Tables[0].Rows[0]["PinCode"].ToString() + ", " + objReg.Ds.Tables[0].Rows[0]["State"].ToString();

                txtVMobileNo.Text = objReg.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                //ImgProfilePic.ImageUrl = "../ProfilePic/" + objUserRegister.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                //        TextBox txtUserType = objUserRegister.Ds.Tables[0].Rows[0]["StackHolder"] as TextBox;
                //   MvRegister.ActiveViewIndex = Convert.ToInt16(ddlUserType.SelectedValue);


            }

        }

        protected void btnForward_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/AssignTask.aspx?User_ID="+ txtVUserID.Text +" &Request_ID="+ Request.QueryString["RequestNo"].ToString()+"");

        }

        protected void btnCancel1_Click(object sender, EventArgs e)
        {
            mvForwardRequest.ActiveViewIndex = 0;
        }

        protected void lbSaveAsPDF_Click(object sender, EventArgs e)
        {

        }

        protected void lbExportToExcel_Click(object sender, EventArgs e)
        {

        }

        protected void lbExportToWord_Click(object sender, EventArgs e)
        {

        }

        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
             if (ddlRecPerPage.SelectedValue == "All")
            {
                gvUser.AllowPaging = false;
                if (txtVSearch.Text != "")
                {
                    objReg.PinCode1 = Convert.ToInt32(txtVSearch.Text);

                }
                objReg.GetDataSet_Search_Volunteer();
                gvUser.DataSource = objReg.Ds;
                gvUser.DataBind();
                if (objReg.Ds.Tables[0].Rows.Count == 1 && objReg.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                {
                    Button btnView = gvUser.Rows[0].FindControl("btnView") as Button;
                    btnView.Visible = false;
                }
            }

            else
            {
                gvUser.AllowPaging = true;
                gvUser.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                if (txtVSearch.Text != "")
                {
                    objReg.PinCode1 = Convert.ToInt32(txtVSearch.Text);

                }
                objReg.GetDataSet_Search_Volunteer();
                gvUser.DataSource = objReg.Ds;
                gvUser.DataBind();
                if (objReg.Ds.Tables[0].Rows.Count == 1 && objReg.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                {
                    Button btnView = gvUser.Rows[0].FindControl("btnView") as Button;
                    btnView.Visible = false;
                }
            }

            if (ViewState["SortExpression"] != null)
            {
                if (txtVSearch.Text!="")
            {
                objReg.PinCode1 = Convert.ToInt32(txtVSearch.Text);

            }
            objReg.GetDataSet_Search_Volunteer();
           

                dataTable = objReg.Ds.Tables[0];
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
                    gvUser.DataSource = dataTable;
                    gvUser.DataBind();
                    if (objReg.Ds.Tables[0].Rows.Count == 1 && objReg.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                    {
                        Button btnView = gvUser.Rows[0].FindControl("btnView") as Button;
                        btnView.Visible = false;
                    }
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvUser.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvUser.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvUser.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
        }
      

        protected void lbExportToWord1_Click(object sender, EventArgs e)
        {

        }

        protected void lbExportToExcel1_Click(object sender, EventArgs e)
        {

        }

        protected void lbSaveAsPDF1_Click(object sender, EventArgs e)
        {

        }

        protected void txtVSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
