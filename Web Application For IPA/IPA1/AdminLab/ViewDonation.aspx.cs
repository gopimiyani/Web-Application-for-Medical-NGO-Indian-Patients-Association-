using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
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
    public partial class ViewDonation : System.Web.UI.Page
    {
        BusLib.Transaction.Donation objDonation = new BusLib.Transaction.Donation();
        int Donation_ID = 0;
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();

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
                BindGrid();
                sortImage.ImageUrl = "../img/bullet-arrow-up-down-icon.png";

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
        void BindGrid()
        {
            objDonation.GetDataSet();
            GridView1.DataSource = objDonation.Ds;
            GridView1.DataBind();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvDonation.ActiveViewIndex = 0;
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            objDonation.GetDataSet();

            dataTable = objDonation.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;

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



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {

                Donation_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvDonation.ActiveViewIndex = 1;
                ViewDonationDetail();
                txtChequeDate.Attributes.Add("readonly", "readonly");


            }
        }

        void ViewDonationDetail()
        {
            objDonation.Donation_ID1 = Convert.ToInt16(Donation_ID.ToString());
            objDonation.GetDataSet_GetDonationDetail(); 
            txtAmount.Text = objDonation.Ds.Tables[0].Rows[0]["Amount"].ToString();
            txtType.Text = objDonation.Ds.Tables[0].Rows[0]["Type"].ToString();
            if (txtType.Text=="By Pay")
            {
                txtChequeDate.Text = "";
                txtChequeNo.Text = "";
            }
            else
            {
                txtChequeDate.Text = objDonation.Ds.Tables[0].Rows[0]["ChequeDate"].ToString();
                txtChequeNo.Text = objDonation.Ds.Tables[0].Rows[0]["ChequeNo"].ToString();
            
            }
            
          

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid();


            if (ViewState["SortExpression"] != null)
            {
                objDonation.GetDataSet();
                dataTable = objDonation.Ds.Tables[0];
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
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in GridView1.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    GridView1.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
        }


        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                GridView1.AllowPaging = false;
                BindGrid();
            }

            else
            {
                GridView1.AllowPaging = true;
                GridView1.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }

            if (ViewState["SortExpression"] != null)
            {
                objDonation.GetDataSet();
                dataTable = objDonation.Ds.Tables[0];
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
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in GridView1.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    GridView1.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

        }

        protected void lbDonation_Click(object sender, EventArgs e)
        {
            mvDonation.ActiveViewIndex = 0;
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/DonationForm.aspx");
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

       
        protected void lbSaveAsPDF_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridView1.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objDonation.GetDataSet();
                GridView1.DataSource = objDonation.Ds;
                GridView1.DataBind();

                if (objDonation.Ds.Tables[0].Rows.Count == 1 && objDonation.Ds.Tables[0].Rows[0]["Donation_ID"].ToString() == "")
                {
                    Button btnEdit = GridView1.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = GridView1.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objDonation.GetDataSet();
                GridView1.DataSource = objDonation.Ds;
                GridView1.DataBind();


            }

            if (ViewState["SortExpression"] != null)
            {
                objDonation.GetDataSet();
                dataTable = objDonation.Ds.Tables[0];
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
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in GridView1.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                //    GridView1.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

           // GridView1.HeaderRow.Cells[2].Visible = false;
            GridView1.HeaderRow.Cells[4].Visible = false;
            GridView1.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];
               // row.Cells[2].Visible = false;
                row.Cells[4].Visible = false;
            }

            Label lblTitle = new Label();
            lblTitle.Text = "Donation Detail <br /><br />";
            lblTitle.Font.Bold = true;
            lblTitle.Font.Underline = true;
            lblTitle.RenderControl(hw);

            GridView1.RenderControl(hw);


            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();

        }

        protected void lbExportToExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition",
             "attachment;filename=Export.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridView1.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objDonation.GetDataSet();
                GridView1.DataSource = objDonation.Ds;
                GridView1.DataBind();
                if (objDonation.Ds.Tables[0].Rows.Count == 1 && objDonation.Ds.Tables[0].Rows[0]["Donation_ID"].ToString() == "")
                {
                    Button btnEdit = GridView1.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = GridView1.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objDonation.GetDataSet();
                GridView1.DataSource = objDonation.Ds;
                GridView1.DataBind();

            }

            if (ViewState["SortExpression"] != null)
            {
                objDonation.GetDataSet();
                dataTable = objDonation.Ds.Tables[0];
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
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in GridView1.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                  //  GridView1.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

          //  GridView1.HeaderRow.Cells[2].Visible = false;
            GridView1.HeaderRow.Cells[4].Visible = false;
            GridView1.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];
              //  row.Cells[2].Visible = false;
                row.Cells[4].Visible = false;
            }

            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write("<b><u><big>Donation Detail</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

       

        protected void lbExportToWord_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Export.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            GridView1.AllowPaging = false;
            //objState.GetDataSet("");
            //gvState.DataSource = objState.Ds;
            //gvState.DataBind();



            if (txtSearch.Text.Trim() != "")
            {
                objDonation.GetDataSet();
                GridView1.DataSource = objDonation.Ds;
                GridView1.DataBind();

                if (objDonation.Ds.Tables[0].Rows.Count == 1 && objDonation.Ds.Tables[0].Rows[0]["Donation_ID"].ToString() == "")
                {
                    Button btnEdit = GridView1.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = GridView1.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objDonation.GetDataSet();
                GridView1.DataSource = objDonation.Ds;
                GridView1.DataBind();
            }

            if (ViewState["SortExpression"] != null)
            {
                objDonation.GetDataSet();
                dataTable = objDonation.Ds.Tables[0];
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
                    GridView1.DataSource = dataTable;
                    GridView1.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in GridView1.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = GridView1.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                //    GridView1.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

          //  GridView1.HeaderRow.Cells[2].Visible = false;
            GridView1.HeaderRow.Cells[4].Visible = false;
            GridView1.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];
           //     row.Cells[2].Visible = false;
                row.Cells[4].Visible = false;
            }

            GridView1.RenderControl(hw);
            Response.Output.Write("<b><u><big>Donation Detail</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }


     
    }
}