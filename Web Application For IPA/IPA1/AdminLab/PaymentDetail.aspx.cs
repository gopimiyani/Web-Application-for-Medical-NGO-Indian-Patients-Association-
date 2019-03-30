using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace IPA1.AdminLab
{
    public partial class ViewPaymentDetail : System.Web.UI.Page
    {
        BusLib.Utility.Payment objPayment = new BusLib.Utility.Payment();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();
        Image sortImage = new Image();
        DataTable dataTable;
        int Payment_ID = 0;
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FillddlSHType();
                BindGrid();
            }
        }

       
        void BindGrid()
        {
            objPayment.StackHolder1 = ddlType.SelectedItem.ToString();
            objPayment.GetDataSet();
            gvPaymentDetail.DataSource = objPayment.Ds;
            gvPaymentDetail.DataBind();

        }

        void FillddlSHType()
        {
            objSH.GetDataSet("");
            ddlType.DataSource = objSH.Ds.Tables[0];
            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "StakeHolder_ID";
            ddlType.DataBind();
            ddlType.Items.Remove(new ListItem("Volunteer", "1"));
            ddlType.Items.Remove(new ListItem("Donor", "2"));
            ddlType.Items.Remove(new ListItem("Doctor", "6"));
            ddlType.Items.Remove(new ListItem("NGO", "8"));

        }

        void FillddlSHselecttype()
        {
            objSH.GetDataSet("");
            ddlselecttype.DataSource = objSH.Ds.Tables[0];
            ddlselecttype.DataTextField = "Name";
            ddlselecttype.DataValueField = "StakeHolder_ID";
            ddlselecttype.DataBind();
            ddlselecttype.Items.Remove(new ListItem("Volunteer", "1"));
            ddlselecttype.Items.Remove(new ListItem("Donor", "2"));
            ddlselecttype.Items.Remove(new ListItem("Doctor", "6"));
            ddlselecttype.Items.Remove(new ListItem("NGO", "8"));

        }

        void FillddlSHName()
        {
                objRegistration.GetDataSet_FillSHName(ddlselecttype.SelectedItem.ToString());

                if (objRegistration.Ds.Tables.Count != 0)
                {
                    if (objRegistration.Ds.Tables[0].Rows.Count > 0)
                    {
                        ddlName.DataSource = objRegistration.Ds.Tables[0];
                        ddlName.DataTextField = "Name";
                        ddlName.DataValueField = "User_ID";
                        ddlName.DataBind();
                    }
                }
        }

        //void FillddlSHName()
        //{
        //    objRegistration.GetDataSet_FillSHName(ddlType.SelectedItem.ToString());
        //    ddlName.DataSource = objRegistration.Ds.Tables[0];
        //    ddlName.DataTextField = "Name";
        //    ddlName.DataValueField = "User_ID";
        //    ddlName.DataBind();

        //}

        void BindBillNo()
        {
            objPayment.User_ID1 = Convert.ToInt16(ddlName.SelectedValue);
            objPayment.StackHolder1 = ddlType.SelectedItem.ToString();
            objPayment.GetBillNo();
            ddlBillNo.DataSource = objPayment.Ds.Tables[0];
            ddlBillNo.DataTextField = "BillNo";
            ddlBillNo.DataValueField = "BillNo";
            ddlBillNo.DataBind();
        }



        void BindAmount()
        {
            objPayment.User_ID1 = Convert.ToInt16(ddlName.SelectedValue);
            objPayment.StackHolder1 = ddlselecttype.SelectedItem.ToString();
            objPayment.BillNo1 = Convert.ToInt16(ddlBillNo.SelectedValue);
            objPayment.GetAmount();
            txtAmount.Text = objPayment.Ds.Tables[0].Rows[0]["FinalAmount"].ToString();

        }
       
        
        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/PaymentForm.aspx");
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        void Reset()
        {
            txtAmount.Text = "";
            ddlBillNo.ClearSelection();
            ddlName.ClearSelection();
            ddlselecttype.ClearSelection();
            txtChequeNo.Text = "";
            txtPaymentID.Text = "";
        }
        protected void btnCancle_Click(object sender, EventArgs e)
        {
            mvPayment.ActiveViewIndex = 0;
        }

        protected void btnView_Click(object sender, EventArgs e)
        {

        }

        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvPaymentDetail.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvPaymentDetail.AllowPaging = true;
                gvPaymentDetail.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }

            if (ViewState["SortExpression"] != null)
            {
                objPayment.GetDataSet();
                dataTable = objPayment.Ds.Tables[0];
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
                    gvPaymentDetail.DataSource = dataTable;
                    gvPaymentDetail.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvPaymentDetail.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvPaymentDetail.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvPaymentDetail.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
        }

        protected void gvPaymentDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPaymentDetail.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvPaymentDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {

                Payment_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvPayment.ActiveViewIndex = 1;
                FillddlSHselecttype();
               
                ViewPaymentSHDetail();
            }
        }


    

        void ViewPaymentSHDetail()
        {
            objPayment.Payment_ID1 = Convert.ToInt16(Payment_ID.ToString());
            //  objPayment.StackHolder1 = ddlType.SelectedItem.ToString();
            objPayment.GetDataSet_GetPaymentDetail();
            txtAmount.Text = objPayment.Ds.Tables[0].Rows[0]["Amount"].ToString();
            txtChequeNo.Text = objPayment.Ds.Tables[0].Rows[0]["ChequeNo"].ToString();
            txtChequeDate.Text = objPayment.Ds.Tables[0].Rows[0]["ChequeDate"].ToString();
            txtPaymentID.Text = objPayment.Ds.Tables[0].Rows[0]["Payment_ID"].ToString();
            ddlselecttype.SelectedItem.Text = objPayment.Ds.Tables[0].Rows[0]["StackHolder"].ToString();

            FillddlSHName();
            ddlName.SelectedValue = objPayment.Ds.Tables[0].Rows[0]["User_ID"].ToString();

            BindBillNo();
            ddlBillNo.SelectedItem.Text = objPayment.Ds.Tables[0].Rows[0]["BillNo"].ToString();

        }


        


        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindBillNo();
            BindAmount();
        }


        protected void ddlselecttype_SelectedIndexChanged1(object sender, EventArgs e)
        {
            FillddlSHName();
            BindBillNo();
            BindAmount();
        }

        protected void ddlBillNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvPaymentDetail_Sorting(object sender, GridViewSortEventArgs e)
        {
            objPayment.StackHolder1 = ddlType.SelectedItem.ToString();
            objPayment.GetDataSet();

            dataTable = objPayment.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                gvPaymentDetail.DataSource = dataTable;
                gvPaymentDetail.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvPaymentDetail.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvPaymentDetail.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvPaymentDetail.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
        }



        protected void lblPayment_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/PaymentDetail.aspx");
        }

    }
}