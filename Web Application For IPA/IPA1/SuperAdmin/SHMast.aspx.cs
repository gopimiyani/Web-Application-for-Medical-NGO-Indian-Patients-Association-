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
    public partial class SHMast : System.Web.UI.Page
    {
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();

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
            //if (Session["User_ID"] == null || Session["UserType"].ToString() != "Admin")
            //{
            //    Response.Redirect("~/LoginForm.aspx");
            //}

            if (!IsPostBack)
            {
                BindGrid();
            }
        }
        void BindGrid()
        {

            if (txtSearch.Text.Trim() != "")
            {
                objSH.GetDataSet(txtSearch.Text.Trim());
                gvSH.DataSource = objSH.Ds;
                gvSH.DataBind();
                if (objSH.Ds.Tables[0].Rows.Count == 1 && objSH.Ds.Tables[0].Rows[0]["StakeHolder_ID"].ToString() == "")
                {
                    Button btnEdit = gvSH.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvSH.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }
            else
            {
                objSH.GetDataSet("");
                gvSH.DataSource = objSH.Ds;
                gvSH.DataBind();
            }


        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            //  TextBox txtId = gvSH.FooterRow.FindControl("txtISHId") as TextBox;
            TextBox txtName = gvSH.FooterRow.FindControl("txtISHName") as TextBox;
            //  objSH.ID1 = 0;
            objSH.Name1 = txtName.Text;
            objSH.Insert();
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvSH.Rows[e.RowIndex];
            TextBox txtId = row.FindControl("txtSHId") as TextBox;
            TextBox txtName = row.FindControl("txtSHName") as TextBox;
            objSH.SHID1 = Convert.ToInt16(txtId.Text);
            objSH.Name1 = txtName.Text;
            objSH.Update();
            BindGrid();
            gvSH.EditIndex = -1;
            BindGrid();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            int Id = Convert.ToInt16(gvSH.DataKeys[e.RowIndex].Value);
            objSH.SHID1 = Id;
            objSH.Delete();
            BindGrid();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvSH.PageIndex = e.NewPageIndex;
            BindGrid();


            if (ViewState["SortExpression"] != null)
            {
                objSH.GetDataSet(txtSearch.Text.Trim());
                dataTable = objSH.Ds.Tables[0];
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
                    gvSH.DataSource = dataTable;
                    gvSH.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvSH.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvSH.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvSH.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvSH.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvSH.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvSH.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvSH.AllowPaging = true;
                gvSH.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }

            if (ViewState["SortExpression"] != null)
            {
                objSH.GetDataSet(txtSearch.Text.Trim());
                dataTable = objSH.Ds.Tables[0];
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
                    gvSH.DataSource = dataTable;
                    gvSH.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvSH.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvSH.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvSH.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }


        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

            objSH.GetDataSet(txtSearch.Text.Trim());
            gvSH.DataSource = objSH.Ds;
            gvSH.DataBind();


            if (ViewState["SortExpression"] != null)
            {
                objSH.GetDataSet(txtSearch.Text.Trim());
                dataTable = objSH.Ds.Tables[0];
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
                    gvSH.DataSource = dataTable;
                    gvSH.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvSH.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvSH.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvSH.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }




            if (objSH.Ds.Tables[0].Rows.Count == 1 && objSH.Ds.Tables[0].Rows[0]["StakeHolder_ID"].ToString() == "")
            {
                Button btnEdit = gvSH.Rows[0].FindControl("btnEdit") as Button;
                Button btnDelete = gvSH.Rows[0].FindControl("btnDelete") as Button;

                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }

        }

        protected void gvSH_Sorting(object sender, GridViewSortEventArgs e)
        {
            objSH.GetDataSet(txtSearch.Text.Trim());
            dataTable = objSH.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;
                gvSH.DataSource = dataTable;
                gvSH.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvSH.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvSH.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvSH.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
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

            gvSH.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objSH.GetDataSet(txtSearch.Text.Trim());
                gvSH.DataSource = objSH.Ds;
                gvSH.DataBind();

                if (objSH.Ds.Tables[0].Rows.Count == 1 && objSH.Ds.Tables[0].Rows[0]["StakeHolder_ID"].ToString() == "")
                {
                    Button btnEdit = gvSH.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvSH.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objSH.GetDataSet("");
                gvSH.DataSource = objSH.Ds;
                gvSH.DataBind();


            }

            if (ViewState["SortExpression"] != null)
            {
                objSH.GetDataSet(txtSearch.Text.Trim());
                dataTable = objSH.Ds.Tables[0];
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
                    gvSH.DataSource = dataTable;
                    gvSH.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvSH.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvSH.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                 //   gvSH.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvSH.HeaderRow.Cells[2].Visible = false;
            gvSH.HeaderRow.Cells[3].Visible = false;
            gvSH.FooterRow.Visible = false;

            
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvSH.Rows.Count; i++)
            {
                GridViewRow row = gvSH.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            Label lblTitle = new Label();
            lblTitle.Text = "StakeHolder Master <br /><br />";
            lblTitle.Font.Bold = true;
            lblTitle.Font.Underline = true;
            lblTitle.RenderControl(hw);

            gvSH.RenderControl(hw);


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

            gvSH.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objSH.GetDataSet(txtSearch.Text.Trim());
                gvSH.DataSource = objSH.Ds;
                gvSH.DataBind();
                if (objSH.Ds.Tables[0].Rows.Count == 1 && objSH.Ds.Tables[0].Rows[0]["StakeHolder_ID"].ToString() == "")
                {
                    Button btnEdit = gvSH.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvSH.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objSH.GetDataSet("");
                gvSH.DataSource = objSH.Ds;
                gvSH.DataBind();

            }

            if (ViewState["SortExpression"] != null)
            {
                objSH.GetDataSet(txtSearch.Text.Trim());
                dataTable = objSH.Ds.Tables[0];
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
                    gvSH.DataSource = dataTable;
                    gvSH.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvSH.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvSH.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                   // gvSH.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvSH.HeaderRow.Cells[2].Visible = false;
            gvSH.HeaderRow.Cells[3].Visible = false;
            gvSH.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvSH.Rows.Count; i++)
            {
                GridViewRow row = gvSH.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            gvSH.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write("<b><u><big>StakeHolder Master</big></u><b><br><br>");
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

            gvSH.AllowPaging = false;
            //objSH.GetDataSet("");
            //gvSH.DataSource = objSH.Ds;
            //gvSH.DataBind();



            if (txtSearch.Text.Trim() != "")
            {
                objSH.GetDataSet(txtSearch.Text.Trim());
                gvSH.DataSource = objSH.Ds;
                gvSH.DataBind();

                if (objSH.Ds.Tables[0].Rows.Count == 1 && objSH.Ds.Tables[0].Rows[0]["StakeHolder_ID"].ToString() == "")
                {
                    Button btnEdit = gvSH.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvSH.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objSH.GetDataSet("");
                gvSH.DataSource = objSH.Ds;
                gvSH.DataBind();
            }

            if (ViewState["SortExpression"] != null)
            {
                objSH.GetDataSet(txtSearch.Text.Trim());
                dataTable = objSH.Ds.Tables[0];
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
                    gvSH.DataSource = dataTable;
                    gvSH.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvSH.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvSH.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                   // gvSH.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvSH.HeaderRow.Cells[2].Visible = false;
            gvSH.HeaderRow.Cells[3].Visible = false;
            gvSH.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvSH.Rows.Count; i++)
            {
                GridViewRow row = gvSH.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            gvSH.RenderControl(hw);
            Response.Output.Write("<b><u><big>StakeHolder Master</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

    }

}

