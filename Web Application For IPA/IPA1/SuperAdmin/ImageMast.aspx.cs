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
    public partial class ImageMast : System.Web.UI.Page
    {
        BusLib.Master.AlbumMast objAlbum = new BusLib.Master.AlbumMast();
        BusLib.Master.ImageMast objImage = new BusLib.Master.ImageMast();

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
                objImage.GetDataSet(txtSearch.Text.Trim());
                gvImage.DataSource = objImage.Ds;
                gvImage.DataBind();
                if (objImage.Ds.Tables[0].Rows.Count == 1 && objImage.Ds.Tables[0].Rows[0]["Image_ID"].ToString() == "")
                {
                    Button btnEdit = gvImage.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvImage.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }
            else
            {
                objImage.GetDataSet("");
                gvImage.DataSource = objImage.Ds;
                gvImage.DataBind();
            }
         
         
        }
        void FillDropDown()
        {
            DropDownList ddlAlbum = gvImage.FooterRow.FindControl("ddlAlbumName") as DropDownList;
        //   StateMasterLogic objState = new StateMasterLogic();
     
            objAlbum.GetDataSet("");
            ddlAlbum.DataSource = objAlbum.Ds.Tables[0];
        //    ddlState.DataMember = objCity.TableName;
           ddlAlbum.DataTextField = "Name";
           ddlAlbum.DataValueField = "Album_ID";
           ddlAlbum.SelectedIndex = 0;  //VALUE
           ddlAlbum.DataBind();
        }

       

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            FileUpload fuImageName = (FileUpload)gvImage.FooterRow.FindControl("fuImageInsert") ;
           // TextBox txtImageName = gvImage.FooterRow.FindControl("txtIImageName") as TextBox;
            DropDownList ddlAlbum = gvImage.FooterRow.FindControl("ddlAlbumName") as DropDownList;
            objImage.AlbumID1 = Convert.ToInt16(ddlAlbum.SelectedValue);
           // objImage.ImageName1=fuImageName.ImageUrl;

            if (fuImageName.HasFile)
            {
                objImage.ImageName1=fuImageName.FileName;
                fuImageName.SaveAs(Server.MapPath("~//Visitor//images//"+ fuImageName.FileName));

            }

            objImage.Insert();
            BindGrid();
            FillDropDown();
        }

        protected void gvImage_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvImage.Rows[e.RowIndex];
            TextBox txtId = row.FindControl("txtImageId") as TextBox;
            FileUpload fuImageName = (FileUpload)row.FindControl("fuImageName");
            //TextBox txtName = row.FindControl("txtImageName") as TextBox;
           // Label lblAlbum_ID=row.FindControl("lblAlbumId") as Label;
            DropDownList ddlAlbumName = row.FindControl("ddlEditAlbumName") as DropDownList;   
            objImage.ImageID1 = Convert.ToInt16(txtId.Text);
            if (fuImageName.HasFile)
            {
                Label lblImageName = row.FindControl("lblImageName") as Label;
                objImage.ImageName1 = fuImageName.FileName;
                fuImageName.SaveAs(Server.MapPath("~//Visitor//images//" + fuImageName.FileName));
                lblImageName.Text = fuImageName.FileName;
                
            }
            else
            {
                Label lblImageName = row.FindControl("lblImageName") as Label;
                objImage.ImageName1 = lblImageName.Text;
            }
            objImage.AlbumID1 = Convert.ToInt16(ddlAlbumName.SelectedValue);
            objImage.Update();
            BindGrid();
            gvImage.EditIndex = -1;
            BindGrid();
            FillDropDown();
        }

        protected void gvImage_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvImage.EditIndex = e.NewEditIndex;
            BindGrid();
            GridViewRow row = gvImage.Rows[e.NewEditIndex];
            FileUpload fuImageName = (FileUpload)row.FindControl("fuImageName");
            Label lblAlbum_ID = row.FindControl("lblAlbumId") as Label;
            DropDownList ddlAlbumName = row.FindControl("ddlEditAlbumName") as DropDownList;
            objAlbum.GetDataSet("");
            ddlAlbumName.DataSource = objAlbum.Ds.Tables[0];
            ddlAlbumName.DataTextField = "Name";
            ddlAlbumName.DataValueField = "Album_ID";
            ddlAlbumName.DataBind();
            ddlAlbumName.SelectedValue = lblAlbum_ID.Text;
           
       //     BindGrid();
            FillDropDown();
        }

        protected void gvImage_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int Id = Convert.ToInt16(gvImage.DataKeys[e.RowIndex].Value);
            objImage.ImageID1 = Id;
            objImage.Delete();
            BindGrid();
            FillDropDown();
        }

        protected void gvImage_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvImage.EditIndex = -1;
            BindGrid();
            FillDropDown();

        }

         protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvImage.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvImage.AllowPaging = true;
                gvImage.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }


            if (ViewState["SortExpression"] != null)
            {
                objImage.GetDataSet(txtSearch.Text.Trim());
                dataTable = objImage.Ds.Tables[0];
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
                    gvImage.DataSource = dataTable;
                    gvImage.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvImage.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvImage.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvImage.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
            FillDropDown();


        }

        protected void gvImage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvImage.PageIndex = e.NewPageIndex;
            BindGrid();
            

            if (ViewState["SortExpression"] != null)
            {
                objImage.GetDataSet(txtSearch.Text.Trim());
                dataTable = objImage.Ds.Tables[0];
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
                    gvImage.DataSource = dataTable;
                    gvImage.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvImage.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvImage.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvImage.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
            FillDropDown();

        }

        protected void gvImage_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

            objImage.GetDataSet(txtSearch.Text.Trim());
            gvImage.DataSource = objImage.Ds;
            gvImage.DataBind();


            if (ViewState["SortExpression"] != null)
            {
                objImage.GetDataSet(txtSearch.Text.Trim());
                dataTable = objImage.Ds.Tables[0];
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
                    gvImage.DataSource = dataTable;
                    gvImage.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvImage.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvImage.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvImage.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }



            if (objImage.Ds.Tables[0].Rows.Count == 1 && objImage.Ds.Tables[0].Rows[0]["Image_ID"].ToString() == "")
            {
                Button btnEdit = gvImage.Rows[0].FindControl("btnEdit") as Button;
                Button btnDelete = gvImage.Rows[0].FindControl("btnDelete") as Button;

                btnEdit.Visible = false;
                btnDelete.Visible = false;
            }

        }

        protected void gvImage_Sorting(object sender, GridViewSortEventArgs e)
        {
            objImage.GetDataSet(txtSearch.Text.Trim());
            dataTable = objImage.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;
                gvImage.DataSource = dataTable;
                gvImage.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvImage.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvImage.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvImage.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
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

            gvImage.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objImage.GetDataSet(txtSearch.Text.Trim());
                gvImage.DataSource = objImage.Ds;
                gvImage.DataBind();

                if (objImage.Ds.Tables[0].Rows.Count == 1 && objImage.Ds.Tables[0].Rows[0]["Image_ID"].ToString() == "")
                {
                    Button btnEdit = gvImage.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvImage.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objImage.GetDataSet("");
                gvImage.DataSource = objImage.Ds;
                gvImage.DataBind();


            }

            if (ViewState["SortExpression"] != null)
            {
                objImage.GetDataSet(txtSearch.Text.Trim());
                dataTable = objImage.Ds.Tables[0];
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
                    gvImage.DataSource = dataTable;
                    gvImage.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvImage.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvImage.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                 //   gvImage.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvImage.HeaderRow.Cells[3].Visible = false;
            gvImage.HeaderRow.Cells[4].Visible = false;
            gvImage.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvImage.Rows.Count; i++)
            {
                GridViewRow row = gvImage.Rows[i];
                row.Cells[3].Visible = false;
                row.Cells[4].Visible = false;
            
            }

            Label lblTitle = new Label();
            lblTitle.Text = "Image Master <br /> <br />";
            lblTitle.Font.Bold = true;
            lblTitle.Font.Underline = true;
            lblTitle.RenderControl(hw);

            gvImage.RenderControl(hw);


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

            gvImage.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objImage.GetDataSet(txtSearch.Text.Trim());
                gvImage.DataSource = objImage.Ds;
                gvImage.DataBind();
                if (objImage.Ds.Tables[0].Rows.Count == 1 && objImage.Ds.Tables[0].Rows[0]["Image_ID"].ToString() == "")
                {
                    Button btnEdit = gvImage.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvImage.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objImage.GetDataSet("");
                gvImage.DataSource = objImage.Ds;
                gvImage.DataBind();

            }

            if (ViewState["SortExpression"] != null)
            {
                objImage.GetDataSet(txtSearch.Text.Trim());
                dataTable = objImage.Ds.Tables[0];
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
                    gvImage.DataSource = dataTable;
                    gvImage.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvImage.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvImage.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                 //   gvImage.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvImage.HeaderRow.Cells[3].Visible = false;
            gvImage.HeaderRow.Cells[4].Visible = false;
            gvImage.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvImage.Rows.Count; i++)
            {
                GridViewRow row = gvImage.Rows[i];
                row.Cells[3].Visible = false;
                row.Cells[4].Visible = false;
            }

            gvImage.RenderControl(hw);


            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write("<b><u><big>Image Master</big></u><b><br><br>");
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

            gvImage.AllowPaging = false;
            //objImage.GetDataSet("");
            //gvImage.DataSource = objImage.Ds;
            //gvImage.DataBind();



            if (txtSearch.Text.Trim() != "")
            {
                objImage.GetDataSet(txtSearch.Text.Trim());
                gvImage.DataSource = objImage.Ds;
                gvImage.DataBind();

                if (objImage.Ds.Tables[0].Rows.Count == 1 && objImage.Ds.Tables[0].Rows[0]["Image_ID"].ToString() == "")
                {
                    Button btnEdit = gvImage.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvImage.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objImage.GetDataSet("");
                gvImage.DataSource = objImage.Ds;
                gvImage.DataBind();
            }

            if (ViewState["SortExpression"] != null)
            {
                objImage.GetDataSet(txtSearch.Text.Trim());
                dataTable = objImage.Ds.Tables[0];
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
                    gvImage.DataSource = dataTable;
                    gvImage.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvImage.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvImage.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                  //  gvImage.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvImage.HeaderRow.Cells[3].Visible = false;
            gvImage.HeaderRow.Cells[4].Visible = false;
            gvImage.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvImage.Rows.Count; i++)
            {
                GridViewRow row = gvImage.Rows[i];
                row.Cells[3].Visible = false;
                row.Cells[4].Visible = false;
            }

            gvImage.RenderControl(hw);
            Response.Output.Write("<b><u><big>Image Master</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
       
        }


    }
}

       
   