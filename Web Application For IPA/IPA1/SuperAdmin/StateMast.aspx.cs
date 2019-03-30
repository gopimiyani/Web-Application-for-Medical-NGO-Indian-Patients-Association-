using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.Text.RegularExpressions;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;


namespace IPA1.SuperAdmin
{
    public partial class StateMast : System.Web.UI.Page
    {

        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();

        //sort start
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();

    //    iTextSharp.text.Image sortImage = iTextSharp.text.Image(
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
                objState.GetDataSet(txtSearch.Text.Trim());
                gvState.DataSource = objState.Ds;
                gvState.DataBind();
                if (objState.Ds.Tables[0].Rows.Count == 1 && objState.Ds.Tables[0].Rows[0]["State_ID"].ToString() == "")
                {
                    Button btnEdit = gvState.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvState.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }
            
            }
            else
            {
                objState.GetDataSet("");
                gvState.DataSource = objState.Ds;
                gvState.DataBind();
          
            }
         
          
        }


        protected void btnInsert_Click(object sender, EventArgs e)
        {
            TextBox txtId = gvState.FooterRow.FindControl("txtIId") as TextBox;
            TextBox txtName = gvState.FooterRow.FindControl("txtIName") as TextBox;
            //   objState.ID1 = 0;
            objState.Name1 = txtName.Text;
            objState.Insert();
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvState.Rows[e.RowIndex];
            TextBox txtId = row.FindControl("txtId") as TextBox;
            TextBox txtName = row.FindControl("txtName") as TextBox;
            objState.ID1 = Convert.ToInt16(txtId.Text);
            objState.Name1 = txtName.Text;
            objState.Update();
            BindGrid();
            gvState.EditIndex = -1;
            BindGrid();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt16(gvState.DataKeys[e.RowIndex].Value);
            objState.ID1 = Id;
            objState.Delete();
            BindGrid();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvState.PageIndex = e.NewPageIndex;
            BindGrid();

            if (ViewState["SortExpression"] != null)
            {
                objState.GetDataSet(txtSearch.Text.Trim());
                dataTable = objState.Ds.Tables[0];
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
                    gvState.DataSource = dataTable;
                    gvState.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvState.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvState.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                   gvState.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvState.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvState.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue=="All")
            {
                gvState.AllowPaging = false;
                BindGrid();
            }
           
            else
            {
                gvState.AllowPaging = true;
                gvState.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }

            if (ViewState["SortExpression"] != null)
            {
                objState.GetDataSet(txtSearch.Text.Trim());
                dataTable = objState.Ds.Tables[0];
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
                    gvState.DataSource = dataTable;
                    gvState.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvState.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvState.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvState.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

            objState.GetDataSet(txtSearch.Text.Trim());
            gvState.DataSource = objState.Ds;
            gvState.DataBind();

            if (ViewState["SortExpression"] != null)
            {
                objState.GetDataSet(txtSearch.Text.Trim());
                dataTable = objState.Ds.Tables[0];
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
                    gvState.DataSource = dataTable;
                    gvState.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvState.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvState.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvState.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
            if (objState.Ds.Tables[0].Rows.Count == 1 && objState.Ds.Tables[0].Rows[0]["State_ID"].ToString() == "")
            {
                Button btnEdit = gvState.Rows[0].FindControl("btnEdit") as Button;
                Button btnDelete = gvState.Rows[0].FindControl("btnDelete") as Button;

                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
            

        }

        protected void gvState_Sorting(object sender, GridViewSortEventArgs e)
        {

            objState.GetDataSet(txtSearch.Text.Trim());
            dataTable = objState.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;

                gvState.DataSource = dataTable;
                gvState.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvState.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvState.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvState.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
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
           
            gvState.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objState.GetDataSet(txtSearch.Text.Trim());
                gvState.DataSource = objState.Ds;
                gvState.DataBind();
                
                if (objState.Ds.Tables[0].Rows.Count == 1 && objState.Ds.Tables[0].Rows[0]["State_ID"].ToString() == "")
                {
                    Button btnEdit = gvState.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvState.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objState.GetDataSet("");
                gvState.DataSource = objState.Ds;
                gvState.DataBind();


            }

            if (ViewState["SortExpression"] != null)
            {
                objState.GetDataSet(txtSearch.Text.Trim());
                dataTable = objState.Ds.Tables[0];
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
                    gvState.DataSource = dataTable;
                    gvState.DataBind();
                
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvState.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvState.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

               //     gvState.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvState.HeaderRow.Cells[2].Visible = false;
            gvState.HeaderRow.Cells[3].Visible = false;
            gvState.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvState.Rows.Count; i++)
            {
                GridViewRow row = gvState.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            Label lblTitle = new Label();
            lblTitle.Text = "State Master <br /> <br />";
            lblTitle.Font.Bold = true;
            lblTitle.Font.Underline = true;
            lblTitle.RenderControl(hw);
          
            gvState.RenderControl(hw);
            

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

            gvState.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objState.GetDataSet(txtSearch.Text.Trim());
                gvState.DataSource = objState.Ds;
                gvState.DataBind();
                if (objState.Ds.Tables[0].Rows.Count == 1 && objState.Ds.Tables[0].Rows[0]["State_ID"].ToString() == "")
                {
                    Button btnEdit = gvState.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvState.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objState.GetDataSet("");
                gvState.DataSource = objState.Ds;
                gvState.DataBind();

            }

            if (ViewState["SortExpression"] != null)
            {
                objState.GetDataSet(txtSearch.Text.Trim());
                dataTable = objState.Ds.Tables[0];
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
                    gvState.DataSource = dataTable;
                    gvState.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvState.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvState.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

               //     gvState.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvState.HeaderRow.Cells[2].Visible = false;
            gvState.HeaderRow.Cells[3].Visible = false;
            gvState.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvState.Rows.Count; i++)
            {
                GridViewRow row = gvState.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            gvState.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write("<b><u><big>State Master</big></u><b><br><br>");
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

            gvState.AllowPaging = false;
            //objState.GetDataSet("");
            //gvState.DataSource = objState.Ds;
            //gvState.DataBind();

      

            if (txtSearch.Text.Trim() != "")
            {
                objState.GetDataSet(txtSearch.Text.Trim());
                gvState.DataSource = objState.Ds;
                gvState.DataBind();

                if (objState.Ds.Tables[0].Rows.Count == 1 && objState.Ds.Tables[0].Rows[0]["State_ID"].ToString() == "")
                {
                    Button btnEdit = gvState.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvState.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objState.GetDataSet("");
                gvState.DataSource = objState.Ds;
                gvState.DataBind();
            }

            if (ViewState["SortExpression"] != null)
            {
                objState.GetDataSet(txtSearch.Text.Trim());
                dataTable = objState.Ds.Tables[0];
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
                    gvState.DataSource = dataTable;
                    gvState.DataBind();
       
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvState.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvState.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                  //  gvState.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvState.HeaderRow.Cells[2].Visible = false;
            gvState.HeaderRow.Cells[3].Visible = false;
            gvState.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvState.Rows.Count; i++)
            {
                GridViewRow row = gvState.Rows[i];
                row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            gvState.RenderControl(hw);
            Response.Output.Write("<b><u><big>State Master</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        //protected void gvState_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        e.Row.Cells[1].Text = Regex.Replace(e.Row.Cells[1].Text, txtSearch.Text.Trim(), delegate(Match match)
        //        {
        //            return string.Format("<span style = 'background-color:#D9EDF7;fore-color:#dddddd'>{0}</span>", match.Value);
        //        }, RegexOptions.IgnoreCase);
        //    }
        //}

        //start serach highlight

        //protected string HighlightText(string searchWord, string inputText)
        //{

        //    Regex expression = new Regex(searchWord.Replace(" ", "|"), RegexOptions.IgnoreCase);

        //    return expression.Replace(inputText, new MatchEvaluator(ReplaceKeywords));
        //}

        //public string ReplaceKeywords(Match m)
        //{
        //    return "<span class='highlight'>" + m.Value + "</span>";
        //}

        //end serach highlight
    }
}