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
    public partial class TermMast : System.Web.UI.Page
    {
        BusLib.Master.TermMast objTerm = new BusLib.Master.TermMast();

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
                Bind();
            }
        }

        protected void GvTerm_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvTerm.PageIndex = e.NewPageIndex;
            Bind();

            if (ViewState["SortExpression"] != null)
            {
                objTerm.GetDataSet(txtSearch.Text.Trim());
                dataTable = objTerm.Ds.Tables[0];
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
                    GvTerm.DataSource = dataTable;
                    GvTerm.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in GvTerm.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = GvTerm.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    GvTerm.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

        }

        protected void GvTerm_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GvTerm.EditIndex = -1;
            Bind();
        }

        protected void GvTerm_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Term_ID = Convert.ToInt16(GvTerm.DataKeys[e.RowIndex].Value);
            objTerm.TermID1 = Term_ID;
            objTerm.Delete();
            Bind();
        }

        protected void GvTerm_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GvTerm.EditIndex = e.NewEditIndex;
            Bind();
        }


        protected void GvTerm_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row;
            row = GvTerm.Rows[e.RowIndex];
            Label lblCode = row.FindControl("lblCode") as Label;
            TextBox txtName = row.FindControl("txtName") as TextBox;
            objTerm.TermID1 = Convert.ToInt16(lblCode.Text);
            objTerm.TermName1 = txtName.Text;
            objTerm.Update();
            GvTerm.EditIndex = -1;
            Bind();

        }



        private void Bind()
        {
            if (txtSearch.Text.Trim() != "")
            {
                objTerm.GetDataSet(txtSearch.Text.Trim());
                GvTerm.DataSource = objTerm.Ds;
                GvTerm.DataBind();
                if (objTerm.Ds.Tables[0].Rows.Count == 1 && objTerm.Ds.Tables[0].Rows[0]["Term_ID"].ToString() == "")
                {
                    Button btnEdit = GvTerm.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = GvTerm.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }
            else
            {
                objTerm.GetDataSet("");
                GvTerm.DataSource = objTerm.Ds;
                GvTerm.DataBind();
         
            }
         
            //objTerm.GetDataset();
            //DataSet Ds = objTerm.Ds;
            //int a = 0;
            //if (Ds.Tables[0].Rows.Count == 0)
            //{
            //    Ds.Tables[0].Rows.Add(Ds.Tables[0].NewRow());
            //    GvTerm.DataSource = Ds;
            //    GvTerm.DataBind();
            //    a = 1;
            //}
            //else
            //{
            //    GvTerm.DataSource = Ds;
            //    GvTerm.DataBind();
            //}
            //if (a == 1)
            //{
            //    GvTerm.Rows[0].Visible = false;
            //}


        }

        protected void btninsert_Click(object sender, EventArgs e)
        {
            TextBox txtCode = GvTerm.FooterRow.FindControl("txtICode") as TextBox;
            TextBox txtName = GvTerm.FooterRow.FindControl("txtIName") as TextBox;
            //        objTerm.TermID1 = Convert.ToInt16(txtCode.Text);
            objTerm.TermName1 = txtName.Text;
            objTerm.Insert();
            Bind();
        }

        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                GvTerm.AllowPaging = false;
                Bind();
            }

            else
            {
                GvTerm.AllowPaging = true;
                GvTerm.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                Bind();
            }


            if (ViewState["SortExpression"] != null)
            {
                objTerm.GetDataSet(txtSearch.Text.Trim());
                dataTable = objTerm.Ds.Tables[0];
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
                    GvTerm.DataSource = dataTable;
                    GvTerm.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in GvTerm.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = GvTerm.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    GvTerm.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }



        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

            objTerm.GetDataSet(txtSearch.Text.Trim());
            GvTerm.DataSource = objTerm.Ds;
            GvTerm.DataBind();


            if (ViewState["SortExpression"] != null)
            {
                objTerm.GetDataSet(txtSearch.Text.Trim());
                dataTable = objTerm.Ds.Tables[0];
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
                    GvTerm.DataSource = dataTable;
                    GvTerm.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in GvTerm.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = GvTerm.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    GvTerm.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }






            if (objTerm.Ds.Tables[0].Rows.Count == 1 && objTerm.Ds.Tables[0].Rows[0]["Term_ID"].ToString() == "")
            {
                Button btnEdit = GvTerm.Rows[0].FindControl("btnEdit") as Button;
                Button btnDelete = GvTerm.Rows[0].FindControl("btnDelete") as Button;

                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }

        }

        protected void GvTerm_Sorting(object sender, GridViewSortEventArgs e)
        {
            objTerm.GetDataSet(txtSearch.Text.Trim());
            dataTable = objTerm.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;
                GvTerm.DataSource = dataTable;
                GvTerm.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in GvTerm.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = GvTerm.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                GvTerm.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
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

            GvTerm.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objTerm.GetDataSet(txtSearch.Text.Trim());
                GvTerm.DataSource = objTerm.Ds;
                GvTerm.DataBind();

                if (objTerm.Ds.Tables[0].Rows.Count == 1 && objTerm.Ds.Tables[0].Rows[0]["Term_ID"].ToString() == "")
                {
                    Button btnEdit = GvTerm.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = GvTerm.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objTerm.GetDataSet("");
                GvTerm.DataSource = objTerm.Ds;
                GvTerm.DataBind();


            }

            if (ViewState["SortExpression"] != null)
            {
                objTerm.GetDataSet(txtSearch.Text.Trim());
                dataTable = objTerm.Ds.Tables[0];
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
                    GvTerm.DataSource = dataTable;
                    GvTerm.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in GvTerm.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = GvTerm.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                  //  GvTerm.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            GvTerm.HeaderRow.Cells[2].Visible = false;
            GvTerm.HeaderRow.Cells[3].Visible = false;
            GvTerm.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < GvTerm.Rows.Count; i++)
            {
                GridViewRow row = GvTerm.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            Label lblTitle = new Label();
            lblTitle.Text = "Term Master<br /><br />";
            lblTitle.Font.Bold = true;
            lblTitle.Font.Underline = true;
            lblTitle.RenderControl(hw);

            GvTerm.RenderControl(hw);


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

            GvTerm.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objTerm.GetDataSet(txtSearch.Text.Trim());
                GvTerm.DataSource = objTerm.Ds;
                GvTerm.DataBind();
                if (objTerm.Ds.Tables[0].Rows.Count == 1 && objTerm.Ds.Tables[0].Rows[0]["Term_ID"].ToString() == "")
                {
                    Button btnEdit = GvTerm.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = GvTerm.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objTerm.GetDataSet("");
                GvTerm.DataSource = objTerm.Ds;
                GvTerm.DataBind();

            }

            if (ViewState["SortExpression"] != null)
            {
                objTerm.GetDataSet(txtSearch.Text.Trim());
                dataTable = objTerm.Ds.Tables[0];
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
                    GvTerm.DataSource = dataTable;
                    GvTerm.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in GvTerm.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = GvTerm.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                  //  GvTerm.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            GvTerm.HeaderRow.Cells[2].Visible = false;
            GvTerm.HeaderRow.Cells[3].Visible = false;
            GvTerm.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < GvTerm.Rows.Count; i++)
            {
                GridViewRow row = GvTerm.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            GvTerm.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write("<b><u><big>Term Master</big></u><b><br><br>");
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

            GvTerm.AllowPaging = false;
            //objTerm.GetDataSet("");
            //GvTerm.DataSource = objTerm.Ds;
            //GvTerm.DataBind();



            if (txtSearch.Text.Trim() != "")
            {
                objTerm.GetDataSet(txtSearch.Text.Trim());
                GvTerm.DataSource = objTerm.Ds;
                GvTerm.DataBind();

                if (objTerm.Ds.Tables[0].Rows.Count == 1 && objTerm.Ds.Tables[0].Rows[0]["Term_ID"].ToString() == "")
                {
                    Button btnEdit = GvTerm.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = GvTerm.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objTerm.GetDataSet("");
                GvTerm.DataSource = objTerm.Ds;
                GvTerm.DataBind();
            }

            if (ViewState["SortExpression"] != null)
            {
                objTerm.GetDataSet(txtSearch.Text.Trim());
                dataTable = objTerm.Ds.Tables[0];
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
                    GvTerm.DataSource = dataTable;
                    GvTerm.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in GvTerm.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = GvTerm.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                 //   GvTerm.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            GvTerm.HeaderRow.Cells[2].Visible = false;
            GvTerm.HeaderRow.Cells[3].Visible = false;
            GvTerm.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < GvTerm.Rows.Count; i++)
            {
                GridViewRow row = GvTerm.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            GvTerm.RenderControl(hw);
            Response.Output.Write("<b><u><big>Term Master</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        }
    }
