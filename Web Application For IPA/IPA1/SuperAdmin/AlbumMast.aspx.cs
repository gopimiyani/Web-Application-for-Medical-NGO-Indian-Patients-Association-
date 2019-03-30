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
    public partial class AlbumMast : System.Web.UI.Page
    {
        BusLib.Master.AlbumMast objAlbum = new BusLib.Master.AlbumMast();

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
                objAlbum.GetDataSet(txtSearch.Text.Trim());
                gvAlbum.DataSource = objAlbum.Ds;
                gvAlbum.DataBind();
                if (objAlbum.Ds.Tables[0].Rows.Count == 1 && objAlbum.Ds.Tables[0].Rows[0]["Album_ID"].ToString() == "")
                {
                    Button btnEdit = gvAlbum.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvAlbum.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }
            }

            else
            {
                objAlbum.GetDataSet("");
                gvAlbum.DataSource = objAlbum.Ds;
                gvAlbum.DataBind();


            }




        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            TextBox txtAlbumId = gvAlbum.FooterRow.FindControl("txtIAlbumId") as TextBox;
            TextBox txtName = gvAlbum.FooterRow.FindControl("txtIName") as TextBox;
            objAlbum.Name = txtName.Text;
            objAlbum.Insert();
            BindGrid();
        }

        protected void gvAlbum_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = gvAlbum.Rows[e.RowIndex];
            TextBox txtAlbumId = row.FindControl("txtAlbumId") as TextBox;
            TextBox txtName = row.FindControl("txtName") as TextBox;
            objAlbum.ID1 = Convert.ToInt16(txtAlbumId.Text);
            objAlbum.Name = txtName.Text;
            objAlbum.Update();
            BindGrid();
            gvAlbum.EditIndex = -1;
            BindGrid();
        }

        protected void gvAlbum_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt16(gvAlbum.DataKeys[e.RowIndex].Value);
            objAlbum.ID1 = id;
            objAlbum.Delete();
            BindGrid();
        }

        protected void gvAlbum_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAlbum.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvAlbum_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAlbum.EditIndex = -1;
            BindGrid();
        }

        protected void gvAlbum_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAlbum.PageIndex = e.NewPageIndex;
            BindGrid();

            if (ViewState["SortExpression"] != null)
            {
                objAlbum.GetDataSet(txtSearch.Text.Trim());
                dataTable = objAlbum.Ds.Tables[0];
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
                    gvAlbum.DataSource = dataTable;
                    gvAlbum.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvAlbum.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvAlbum.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvAlbum.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

        }

        protected void gvAlbum_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvAlbum.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvAlbum.AllowPaging = true;
                gvAlbum.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }

            if (ViewState["SortExpression"] != null)
            {
                objAlbum.GetDataSet(txtSearch.Text.Trim());
                dataTable = objAlbum.Ds.Tables[0];
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
                    gvAlbum.DataSource = dataTable;
                    gvAlbum.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvAlbum.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvAlbum.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvAlbum.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }


        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

            objAlbum.GetDataSet(txtSearch.Text.Trim());
            gvAlbum.DataSource = objAlbum.Ds;
            gvAlbum.DataBind();

            if (ViewState["SortExpression"] != null)
            {
                objAlbum.GetDataSet(txtSearch.Text.Trim());
                dataTable = objAlbum.Ds.Tables[0];
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
                    gvAlbum.DataSource = dataTable;
                    gvAlbum.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvAlbum.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvAlbum.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvAlbum.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }






            if (objAlbum.Ds.Tables[0].Rows.Count == 1 && objAlbum.Ds.Tables[0].Rows[0]["Album_ID"].ToString() == "")
            {
                Button btnEdit = gvAlbum.Rows[0].FindControl("btnEdit") as Button;
                Button btnDelete = gvAlbum.Rows[0].FindControl("btnDelete") as Button;

                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }

        }

        protected void gvAlbum_Sorting(object sender, GridViewSortEventArgs e)
        {
            objAlbum.GetDataSet(txtSearch.Text.Trim());
            dataTable = objAlbum.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;
                gvAlbum.DataSource = dataTable;
                gvAlbum.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvAlbum.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvAlbum.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvAlbum.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
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

            gvAlbum.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objAlbum.GetDataSet(txtSearch.Text.Trim());
                gvAlbum.DataSource = objAlbum.Ds;
                gvAlbum.DataBind();

                if (objAlbum.Ds.Tables[0].Rows.Count == 1 && objAlbum.Ds.Tables[0].Rows[0]["Album_ID"].ToString() == "")
                {
                    Button btnEdit = gvAlbum.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvAlbum.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objAlbum.GetDataSet("");
                gvAlbum.DataSource = objAlbum.Ds;
                gvAlbum.DataBind();


            }

            if (ViewState["SortExpression"] != null)
            {
                objAlbum.GetDataSet(txtSearch.Text.Trim());
                dataTable = objAlbum.Ds.Tables[0];
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
                    gvAlbum.DataSource = dataTable;
                    gvAlbum.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvAlbum.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvAlbum.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                 //   gvAlbum.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvAlbum.HeaderRow.Cells[2].Visible = false;
            gvAlbum.HeaderRow.Cells[3].Visible = false;
            gvAlbum.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvAlbum.Rows.Count; i++)
            {
                GridViewRow row = gvAlbum.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            Label lblTitle = new Label();
            lblTitle.Text = "Album Master <br /><br />";
            lblTitle.Font.Bold = true;
            lblTitle.Font.Underline = true;
            lblTitle.RenderControl(hw);

            gvAlbum.RenderControl(hw);


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

            gvAlbum.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objAlbum.GetDataSet(txtSearch.Text.Trim());
                gvAlbum.DataSource = objAlbum.Ds;
                gvAlbum.DataBind();
                if (objAlbum.Ds.Tables[0].Rows.Count == 1 && objAlbum.Ds.Tables[0].Rows[0]["Album_ID"].ToString() == "")
                {
                    Button btnEdit = gvAlbum.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvAlbum.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objAlbum.GetDataSet("");
                gvAlbum.DataSource = objAlbum.Ds;
                gvAlbum.DataBind();

            }

            if (ViewState["SortExpression"] != null)
            {
                objAlbum.GetDataSet(txtSearch.Text.Trim());
                dataTable = objAlbum.Ds.Tables[0];
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
                    gvAlbum.DataSource = dataTable;
                    gvAlbum.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvAlbum.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvAlbum.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                   // gvAlbum.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvAlbum.HeaderRow.Cells[2].Visible = false;
            gvAlbum.HeaderRow.Cells[3].Visible = false;
            gvAlbum.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvAlbum.Rows.Count; i++)
            {
                GridViewRow row = gvAlbum.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            gvAlbum.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write("<b><u><big>Album Master</big></u><b><br><br>");
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

            gvAlbum.AllowPaging = false;
            //objAlbum.GetDataSet("");
            //gvAlbum.DataSource = objAlbum.Ds;
            //gvAlbum.DataBind();



            if (txtSearch.Text.Trim() != "")
            {
                objAlbum.GetDataSet(txtSearch.Text.Trim());
                gvAlbum.DataSource = objAlbum.Ds;
                gvAlbum.DataBind();

                if (objAlbum.Ds.Tables[0].Rows.Count == 1 && objAlbum.Ds.Tables[0].Rows[0]["Album_ID"].ToString() == "")
                {
                    Button btnEdit = gvAlbum.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvAlbum.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objAlbum.GetDataSet("");
                gvAlbum.DataSource = objAlbum.Ds;
                gvAlbum.DataBind();
            }

            if (ViewState["SortExpression"] != null)
            {
                objAlbum.GetDataSet(txtSearch.Text.Trim());
                dataTable = objAlbum.Ds.Tables[0];
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
                    gvAlbum.DataSource = dataTable;
                    gvAlbum.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvAlbum.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvAlbum.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                  //  gvAlbum.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvAlbum.HeaderRow.Cells[2].Visible = false;
            gvAlbum.HeaderRow.Cells[3].Visible = false;
            gvAlbum.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvAlbum.Rows.Count; i++)
            {
                GridViewRow row = gvAlbum.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            gvAlbum.RenderControl(hw);
            Response.Output.Write("<b><u><big>Album Master</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        
    }
}