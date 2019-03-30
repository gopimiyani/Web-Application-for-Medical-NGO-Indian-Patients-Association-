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
    public partial class CityMast : System.Web.UI.Page
    {
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();

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
                FillDropDown();
            }

        }
        void BindGrid()
        {
            if (txtSearch.Text.Trim() != "")
            {
                objCity.GetDataSet(txtSearch.Text.Trim());
                gvCity.DataSource = objCity.Ds;
                gvCity.DataBind();
                if (objCity.Ds.Tables[0].Rows.Count == 1 && objCity.Ds.Tables[0].Rows[0]["City_ID"].ToString() == "")
                {
                    Button btnEdit = gvCity.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvCity.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }
            else
            {
                objCity.GetDataSet("");
                gvCity.DataSource = objCity.Ds;
                gvCity.DataBind();

            }
         
            
         
        }

        void FillDropDown()
        {
            DropDownList ddlState = gvCity.FooterRow.FindControl("ddlStateName") as DropDownList;
            //    StateMasterLogic objState = new StateMasterLogic();

            objState.GetDataSet("");
            ddlState.DataSource = objState.Ds.Tables[0];
            //    ddlState.DataMember = objCity.TableName;
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "State_ID";
            ddlState.SelectedIndex = 0;  //VALUE
            ddlState.DataBind();
        }
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            TextBox txtCityName = gvCity.FooterRow.FindControl("txtICityName") as TextBox;
            DropDownList ddlState = gvCity.FooterRow.FindControl("ddlStateName") as DropDownList;
            objCity.StateID1 = Convert.ToInt16(ddlState.SelectedValue);
            objCity.Name1 = txtCityName.Text;
            objCity.Insert();
            BindGrid();
            FillDropDown();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvCity.Rows[e.RowIndex];
            TextBox txtId = row.FindControl("txtCityId") as TextBox;
            TextBox txtName = row.FindControl("txtCityName") as TextBox;
            DropDownList ddlState1 = row.FindControl("ddlEditStateName") as DropDownList;
            objCity.CityID1 = Convert.ToInt16(txtId.Text);
            objCity.StateID1 = Convert.ToInt16(ddlState1.SelectedValue);
            objCity.Name1 = txtName.Text;
            objCity.Update();
            BindGrid();
            gvCity.EditIndex = -1;
            BindGrid();
            FillDropDown();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt16(gvCity.DataKeys[e.RowIndex].Value);
            objCity.CityID1 = Id;
            objCity.Delete();
            BindGrid();
            FillDropDown();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCity.PageIndex = e.NewPageIndex;
            BindGrid();
            

            if (ViewState["SortExpression"] != null)
            {
                objCity.GetDataSet(txtSearch.Text.Trim());
                dataTable = objCity.Ds.Tables[0];
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
                    gvCity.DataSource = dataTable;
                    gvCity.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvCity.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvCity.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvCity.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
            FillDropDown();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCity.EditIndex = -1;
            BindGrid();
            FillDropDown();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCity.EditIndex = e.NewEditIndex;
            BindGrid();
            GridViewRow row = gvCity.Rows[e.NewEditIndex];
            Label lblState_ID = row.FindControl("lblStateID") as Label;
            DropDownList ddlState1 = row.FindControl("ddlEditStateName") as DropDownList;
            objState.GetDataSet("");
            ddlState1.DataSource = objState.Ds.Tables[0];
            ddlState1.DataTextField = "StateName";
            ddlState1.DataValueField = "State_ID";
            ddlState1.DataBind();
            ddlState1.SelectedValue = lblState_ID.Text;
            FillDropDown();
        }

        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvCity.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvCity.AllowPaging = true;
                gvCity.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }


            if (ViewState["SortExpression"] != null)
            {
                objCity.GetDataSet(txtSearch.Text.Trim());
                dataTable = objCity.Ds.Tables[0];
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
                    gvCity.DataSource = dataTable;
                    gvCity.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvCity.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvCity.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvCity.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
            FillDropDown();
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

            objCity.GetDataSet(txtSearch.Text.Trim());
            gvCity.DataSource = objCity.Ds;
            gvCity.DataBind();


            if (ViewState["SortExpression"] != null)
            {
                objCity.GetDataSet(txtSearch.Text.Trim());
                dataTable = objCity.Ds.Tables[0];
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
                    gvCity.DataSource = dataTable;
                    gvCity.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvCity.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvCity.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvCity.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
         
            if (objCity.Ds.Tables[0].Rows.Count == 1 && objCity.Ds.Tables[0].Rows[0]["City_ID"].ToString() == "")
            {
                Button btnEdit = gvCity.Rows[0].FindControl("btnEdit") as Button;
                Button btnDelete = gvCity.Rows[0].FindControl("btnDelete") as Button;

                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }
            FillDropDown();
        }

        protected void gvCity_Sorting(object sender, GridViewSortEventArgs e)
        {
             
            objCity.GetDataSet(txtSearch.Text.Trim());
            dataTable = objCity.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;

                gvCity.DataSource = dataTable;
                gvCity.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvCity.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvCity.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvCity.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
            FillDropDown();
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

            gvCity.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objCity.GetDataSet(txtSearch.Text.Trim());
                gvCity.DataSource = objCity.Ds;
                gvCity.DataBind();

                if (objCity.Ds.Tables[0].Rows.Count == 1 && objCity.Ds.Tables[0].Rows[0]["City_ID"].ToString() == "")
                {
                    Button btnEdit = gvCity.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvCity.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objCity.GetDataSet("");
                gvCity.DataSource = objCity.Ds;
                gvCity.DataBind();


            }

            if (ViewState["SortExpression"] != null)
            {
                objCity.GetDataSet(txtSearch.Text.Trim());
                dataTable = objCity.Ds.Tables[0];
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
                    gvCity.DataSource = dataTable;
                    gvCity.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvCity.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvCity.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                  //  gvCity.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvCity.HeaderRow.Cells[3].Visible = false;
            gvCity.HeaderRow.Cells[4].Visible = false;
            gvCity.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvCity.Rows.Count; i++)
            {
                GridViewRow row = gvCity.Rows[i];
                row.Cells[3].Visible = false;
                row.Cells[4].Visible = false;
            }

            Label lblTitle = new Label();
            lblTitle.Text = "City Master <br /><br /><br />";
            lblTitle.Font.Bold = true;
            lblTitle.Font.Underline = true;
            lblTitle.RenderControl(hw);

            gvCity.RenderControl(hw);


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

            gvCity.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objCity.GetDataSet(txtSearch.Text.Trim());
                gvCity.DataSource = objCity.Ds;
                gvCity.DataBind();
                if (objCity.Ds.Tables[0].Rows.Count == 1 && objCity.Ds.Tables[0].Rows[0]["City_ID"].ToString() == "")
                {
                    Button btnEdit = gvCity.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvCity.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objCity.GetDataSet("");
                gvCity.DataSource = objCity.Ds;
                gvCity.DataBind();

            }

            if (ViewState["SortExpression"] != null)
            {
                objCity.GetDataSet(txtSearch.Text.Trim());
                dataTable = objCity.Ds.Tables[0];
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
                    gvCity.DataSource = dataTable;
                    gvCity.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvCity.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvCity.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                 //   gvCity.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvCity.HeaderRow.Cells[3].Visible = false;
            gvCity.HeaderRow.Cells[4].Visible = false;
            gvCity.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvCity.Rows.Count; i++)
            {
                GridViewRow row = gvCity.Rows[i];
                row.Cells[3].Visible = false;
                row.Cells[4].Visible = false;
            }

            gvCity.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write("<b><u><big>City Master</big></u><b><br><br>");
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

            gvCity.AllowPaging = false;
            //objCity.GetDataSet("");
            //gvCity.DataSource = objCity.Ds;
            //gvCity.DataBind();

      

            if (txtSearch.Text.Trim() != "")
            {
                objCity.GetDataSet(txtSearch.Text.Trim());
                gvCity.DataSource = objCity.Ds;
                gvCity.DataBind();

                if (objCity.Ds.Tables[0].Rows.Count == 1 && objCity.Ds.Tables[0].Rows[0]["City_ID"].ToString() == "")
                {
                    Button btnEdit = gvCity.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvCity.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objCity.GetDataSet("");
                gvCity.DataSource = objCity.Ds;
                gvCity.DataBind();
            }

            if (ViewState["SortExpression"] != null)
            {
                objCity.GetDataSet(txtSearch.Text.Trim());
                dataTable = objCity.Ds.Tables[0];
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
                    gvCity.DataSource = dataTable;
                    gvCity.DataBind();
       
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvCity.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvCity.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                 //   gvCity.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvCity.HeaderRow.Cells[3].Visible = false;
            gvCity.HeaderRow.Cells[4].Visible = false;
            gvCity.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvCity.Rows.Count; i++)
            {
                GridViewRow row = gvCity.Rows[i];
                row.Cells[3].Visible = false;
                row.Cells[4].Visible = false;
            }

            gvCity.RenderControl(hw);
            Response.Output.Write("<b><u><big>City Master</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        }


        }

    
