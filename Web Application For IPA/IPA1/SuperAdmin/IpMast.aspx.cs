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

namespace IPA1.SuperAdmin
{
    public partial class IpMast : System.Web.UI.Page
    {
        BusLib.Master.IpMast objIp = new BusLib.Master.IpMast();
        //sort start
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


        //sort end


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }

        }
        void BindGrid()
        {

            if (txtSearch.Text.Trim() != "")
            {
                objIp.GetDataSet(txtSearch.Text.Trim());
                gvIp.DataSource = objIp.Ds;
                gvIp.DataBind();
                if (objIp.Ds.Tables[0].Rows.Count == 1 && objIp.Ds.Tables[0].Rows[0]["Ip_ID"].ToString() == "")
                {
                    Button btnEdit = gvIp.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvIp.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }
            else
            {
                objIp.GetDataSet("");
                gvIp.DataSource = objIp.Ds;
                gvIp.DataBind();

            }
         
         
        }




        protected void btnInsert_Click(object sender, EventArgs e)
        {
            TextBox txtIpId = gvIp.FooterRow.FindControl("txtIIpId") as TextBox;
            TextBox txtIpaddress = gvIp.FooterRow.FindControl("txtIIpaddress") as TextBox;
            objIp.Address1 = txtIpaddress.Text;
            objIp.Insert();
            BindGrid();

        }

        protected void gvIp_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvIp.PageIndex = e.NewPageIndex;
            BindGrid();

            if (ViewState["SortExpression"] != null)
            {
                objIp.GetDataSet(txtSearch.Text.Trim());
                dataTable = objIp.Ds.Tables[0];
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
                    gvIp.DataSource = dataTable;
                    gvIp.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvIp.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvIp.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvIp.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

        }

        protected void gvIp_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = gvIp.Rows[e.RowIndex];
            TextBox txtIpId = row.FindControl("txtIpId") as TextBox;
            TextBox txtIpaddress = row.FindControl("txtIpaddress") as TextBox;
            objIp.ID1 = Convert.ToInt16(txtIpId.Text);
            objIp.Address1 = txtIpaddress.Text;
            objIp.Update();
            BindGrid();
            gvIp.EditIndex = -1;
            BindGrid();

        }

        protected void gvIp_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvIp.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvIp_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(gvIp.DataKeys[e.RowIndex].Value);
            objIp.ID1 = id;
            objIp.Delete();
            BindGrid();
        }

        protected void gvIp_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvIp.EditIndex = -1;
            BindGrid();
        }

        protected void gvIp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvIp.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvIp.AllowPaging = true;
                gvIp.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }

            if (ViewState["SortExpression"] != null)
            {
                objIp.GetDataSet(txtSearch.Text.Trim());
                dataTable = objIp.Ds.Tables[0];
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
                    gvIp.DataSource = dataTable;
                    gvIp.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvIp.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvIp.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvIp.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }


        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

            objIp.GetDataSet(txtSearch.Text.Trim());
            gvIp.DataSource = objIp.Ds;
            gvIp.DataBind();

            if (ViewState["SortExpression"] != null)
            {
                objIp.GetDataSet(txtSearch.Text.Trim());
                dataTable = objIp.Ds.Tables[0];
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
                    gvIp.DataSource = dataTable;
                    gvIp.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvIp.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvIp.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvIp.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }




            if (objIp.Ds.Tables[0].Rows.Count == 1 && objIp.Ds.Tables[0].Rows[0]["Ip_ID"].ToString() == "")
            {
                Button btnEdit = gvIp.Rows[0].FindControl("btnEdit") as Button;
                Button btnDelete = gvIp.Rows[0].FindControl("btnDelete") as Button;

                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }

        }

        protected void gvIp_Sorting(object sender, GridViewSortEventArgs e)
        {
            objIp.GetDataSet(txtSearch.Text.Trim());
            dataTable = objIp.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;
                gvIp.DataSource = dataTable;
                gvIp.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvIp.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvIp.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvIp.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
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

            gvIp.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objIp.GetDataSet(txtSearch.Text.Trim());
                gvIp.DataSource = objIp.Ds;
                gvIp.DataBind();

                if (objIp.Ds.Tables[0].Rows.Count == 1 && objIp.Ds.Tables[0].Rows[0]["Ip_ID"].ToString() == "")
                {
                    Button btnEdit = gvIp.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvIp.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objIp.GetDataSet("");
                gvIp.DataSource = objIp.Ds;
                gvIp.DataBind();


            }

            if (ViewState["SortExpression"] != null)
            {
                objIp.GetDataSet(txtSearch.Text.Trim());
                dataTable = objIp.Ds.Tables[0];
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
                    gvIp.DataSource = dataTable;
                    gvIp.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvIp.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvIp.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                //    gvIp.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvIp.HeaderRow.Cells[2].Visible = false;
            gvIp.HeaderRow.Cells[3].Visible = false;
            gvIp.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvIp.Rows.Count; i++)
            {
                GridViewRow row = gvIp.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            Label lblTitle = new Label();
            lblTitle.Text = "IP Master";
            lblTitle.Font.Bold = true;
            lblTitle.Font.Underline = true;
            lblTitle.RenderControl(hw);

            gvIp.RenderControl(hw);


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

            gvIp.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objIp.GetDataSet(txtSearch.Text.Trim());
                gvIp.DataSource = objIp.Ds;
                gvIp.DataBind();
                if (objIp.Ds.Tables[0].Rows.Count == 1 && objIp.Ds.Tables[0].Rows[0]["Ip_ID"].ToString() == "")
                {
                    Button btnEdit = gvIp.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvIp.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objIp.GetDataSet("");
                gvIp.DataSource = objIp.Ds;
                gvIp.DataBind();

            }

            if (ViewState["SortExpression"] != null)
            {
                objIp.GetDataSet(txtSearch.Text.Trim());
                dataTable = objIp.Ds.Tables[0];
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
                    gvIp.DataSource = dataTable;
                    gvIp.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvIp.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvIp.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                 //   gvIp.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvIp.HeaderRow.Cells[2].Visible = false;
            gvIp.HeaderRow.Cells[3].Visible = false;
            gvIp.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvIp.Rows.Count; i++)
            {
                GridViewRow row = gvIp.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            gvIp.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write("<b><u><big>IP Master</big></u><b><br><br>");
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

            gvIp.AllowPaging = false;
            //objIp.GetDataSet("");
            //gvIp.DataSource = objIp.Ds;
            //gvIp.DataBind();



            if (txtSearch.Text.Trim() != "")
            {
                objIp.GetDataSet(txtSearch.Text.Trim());
                gvIp.DataSource = objIp.Ds;
                gvIp.DataBind();

                if (objIp.Ds.Tables[0].Rows.Count == 1 && objIp.Ds.Tables[0].Rows[0]["Ip_ID"].ToString() == "")
                {
                    Button btnEdit = gvIp.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvIp.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objIp.GetDataSet("");
                gvIp.DataSource = objIp.Ds;
                gvIp.DataBind();
            }

            if (ViewState["SortExpression"] != null)
            {
                objIp.GetDataSet(txtSearch.Text.Trim());
                dataTable = objIp.Ds.Tables[0];
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
                    gvIp.DataSource = dataTable;
                    gvIp.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvIp.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvIp.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                  //  gvIp.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvIp.HeaderRow.Cells[2].Visible = false;
            gvIp.HeaderRow.Cells[3].Visible = false;
            gvIp.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvIp.Rows.Count; i++)
            {
                GridViewRow row = gvIp.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            gvIp.RenderControl(hw);
            Response.Output.Write("<b><u><big>IP Master</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }


        
     

    }
}