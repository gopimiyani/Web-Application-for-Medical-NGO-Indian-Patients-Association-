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


using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;

namespace IPA1.SuperAdmin
{
    public partial class AdminDetail1 : System.Web.UI.Page
    {
        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        int Admin_ID = 0;
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();

        //sort start
       
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
                FillddlState();
                FillddlCity();
                AdminDetailDisplay();
       
            }
        
        }


        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvAdmin.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvAdmin.AllowPaging = true;
                gvAdmin.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }
        }

        //AdminDetail start
        void BindGrid()
        {

            objAdmin.GetDataset();
            gvAdmin.DataSource = objAdmin.Ds;
            gvAdmin.DataBind();

        }

        protected void gvAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAdmin.PageIndex = e.NewPageIndex;
            BindGrid();

        }

        protected void gvAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();

        }

        protected void gvAdmin_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                Admin_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvAdmin.ActiveViewIndex = 1;

                FillddlCity();
                FillddlState();
                AdminDetailDisplay();
            }
        }

      //AdminDetail end

        // ViewAdminDetail start 
        void FillddlState()
        {
            objState.GetDataSet("");
            ddlState.DataSource = objState.Ds.Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "State_ID";
         //   ddlState.SelectedIndex = 6;
            ddlState.DataBind();
        }

        void FillddlCity()
        {
            objCity.GetDataSet("");
            ddlCity.DataSource = objCity.Ds.Tables[0];
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "City_ID";
          //  ddlCity.SelectedIndex = 1;
            ddlCity.DataBind();
        }
        void AdminDetailDisplay()
        {

            if (Admin_ID != 0)
            {
                objAdmin.Admin_ID1 = Convert.ToInt16(Admin_ID.ToString());
                objAdmin.GetDataSet_GetAdminDetail();
                txtAdminID.Text = objAdmin.Ds.Tables[0].Rows[0]["Admin_ID"].ToString();
                txtFirstName.Text = objAdmin.Ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = objAdmin.Ds.Tables[0].Rows[0]["LastName"].ToString();
                txtUserName.Text = objAdmin.Ds.Tables[0].Rows[0]["UserName"].ToString();
                txtEmail.Text = objAdmin.Ds.Tables[0].Rows[0]["Email"].ToString();
                txtAddress.Text = objAdmin.Ds.Tables[0].Rows[0]["Address"].ToString();
                ddlState.SelectedItem.Text = objAdmin.Ds.Tables[0].Rows[0]["State"].ToString();
                ddlCity.SelectedItem.Text = objAdmin.Ds.Tables[0].Rows[0]["City"].ToString();
                txtPinCode.Text = objAdmin.Ds.Tables[0].Rows[0]["PinCode"].ToString();
                txtMobileNo.Text = objAdmin.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                txtWorkingArea.Text = objAdmin.Ds.Tables[0].Rows[0]["WorkingPinCode"].ToString();
                txtIpaddress.Text = objAdmin.Ds.Tables[0].Rows[0]["IP"].ToString();
                ImgProfilePic.ImageUrl = "~//ProfilePic//" + objAdmin.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                lblProfilePicName.Text = objAdmin.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                fuProfilePic.Visible = false;

                
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objAdmin.Admin_ID1 = Convert.ToInt16(txtAdminID.Text);
            objAdmin.FirstName1 = txtFirstName.Text;
            objAdmin.LastName1 = txtLastName.Text;

            objAdmin.Address1 = txtAddress.Text;
            objAdmin.City1 = ddlCity.SelectedItem.Text;
            objAdmin.State1 = ddlState.SelectedItem.Text;
            objAdmin.PinCode1 = Convert.ToInt32(txtPinCode.Text);
            objAdmin.MobileNo1 = Convert.ToInt64(txtMobileNo.Text);
            objAdmin.UserName1 = txtUserName.Text;
            objAdmin.Email1 = txtEmail.Text;
            objAdmin.IP1 = txtIpaddress.Text;
            objAdmin.ProfilePic1 = lblProfilePicName.Text;
       
                objAdmin.Update();
                Response.Write("<script language='javascript'>window.alert('Updated Sucessfully');window.location='AdminDetail.aspx';</script>");
                mvAdmin.ActiveViewIndex = 0;
                //string message = "Updated Successfully";
                //string url = "AdminDetail1.aspx";
                //string script = "window.onload = function(){ alert('";
                //script += message;
                //script += "');";
                //script += "window.location = '";
                //script += url;
                //script += "'; }";
                //ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                //Reset();
            
        }
         void Reset()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUserName.Text = "";
           
            txtEmail.Text = "";
            txtPinCode.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtIpaddress.Text = "";
            


        }


        

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvAdmin.ActiveViewIndex = 0;
        //    Response.Redirect("~/AdminLab/AdminDetail.aspx");
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillddlCity();
        }

        protected void lblAdmin_Click(object sender, EventArgs e)
        {
            mvAdmin.ActiveViewIndex = 0;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SuperAdmin/AdminForm.aspx");
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            objAdmin.UserName1 = txtUserName.Text;
            objAdmin.GetDataSet_GetUserName();
            if (objAdmin.Ds.Tables[0].Rows.Count > 0)
            {
                lblcvUserName.Visible = true;
                lblcvUserName.Text = "UserName already exist";
                return;
            }
            else
            {
                lblcvUserName.Text = "";
            }

        }

        protected void gvAdmin_Sorting(object sender, GridViewSortEventArgs e)
        {
            objAdmin.GetDataset();
            dataTable = objAdmin.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;
                gvAdmin.DataSource = dataTable;
                gvAdmin.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvAdmin.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvAdmin.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvAdmin.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
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

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            objAdmin.GetDataset();
            gvAdmin.DataSource = objState.Ds;
            gvAdmin.DataBind();
            if (objAdmin.Ds.Tables[0].Rows.Count == 1 && objState.Ds.Tables[0].Rows[0]["Admin_ID"].ToString() == "")
            {
                Button btnView = gvAdmin.Rows[0].FindControl("btnView") as Button;
              

                btnView.Visible = false;
                
            }


            else
            {
                objAdmin.GetDataset();
                gvAdmin.DataSource = objAdmin.Ds;
                gvAdmin.DataBind();

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

            gvAdmin.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objAdmin.GetDataset();
                gvAdmin.DataSource = objAdmin.Ds;
                gvAdmin.DataBind();

                if (objAdmin.Ds.Tables[0].Rows.Count == 1 && objAdmin.Ds.Tables[0].Rows[0]["Admin_ID"].ToString() == "")
                {
                    Button btnEdit = gvAdmin.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvAdmin.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objAdmin.GetDataset();
                gvAdmin.DataSource = objAdmin.Ds;
                gvAdmin.DataBind();


            }

            if (ViewState["SortExpression"] != null)
            {
                objAdmin.GetDataset();
                dataTable = objAdmin.Ds.Tables[0];
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
                    gvAdmin.DataSource = dataTable;
                    gvAdmin.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvAdmin.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvAdmin.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

               //     gvAdmin.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

          //  gvAdmin.HeaderRow.Cells[2].Visible = false;
            gvAdmin.HeaderRow.Cells[4].Visible = false;
            gvAdmin.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvAdmin.Rows.Count; i++)
            {
                GridViewRow row = gvAdmin.Rows[i];
              //  row.Cells[2].Visible = false;
                row.Cells[4].Visible = false;
            }

            Label lblTitle = new Label();
            lblTitle.Text = "Admin Detail<br /> <br />";
            lblTitle.Font.Bold = true;
            lblTitle.Font.Underline = true;
            lblTitle.RenderControl(hw);

            gvAdmin.RenderControl(hw);


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

            gvAdmin.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objAdmin.GetDataset();
                gvAdmin.DataSource = objAdmin.Ds;
                gvAdmin.DataBind();
                if (objAdmin.Ds.Tables[0].Rows.Count == 1 && objAdmin.Ds.Tables[0].Rows[0]["Admin_ID"].ToString() == "")
                {
                    Button btnEdit = gvAdmin.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvAdmin.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objAdmin.GetDataset();
                gvAdmin.DataSource = objAdmin.Ds;
                gvAdmin.DataBind();

            }

            if (ViewState["SortExpression"] != null)
            {
                objAdmin.GetDataset();
                dataTable = objAdmin.Ds.Tables[0];
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
                    gvAdmin.DataSource = dataTable;
                    gvAdmin.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvAdmin.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvAdmin.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                  //  gvAdmin.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

          //  gvAdmin.HeaderRow.Cells[2].Visible = false;
            gvAdmin.HeaderRow.Cells[4].Visible = false;
            gvAdmin.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvAdmin.Rows.Count; i++)
            {
                GridViewRow row = gvAdmin.Rows[i];
              //  row.Cells[2].Visible = false;
                row.Cells[4].Visible = false;
            }

            gvAdmin.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write("<b><u><big>Admin Detail</big></u><b><br><br>");
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

            gvAdmin.AllowPaging = false;
            //objState.GetDataSet("");
            //gvState.DataSource = objState.Ds;
            //gvState.DataBind();



            if (txtSearch.Text.Trim() != "")
            {
                objAdmin.GetDataset();
                gvAdmin.DataSource = objAdmin.Ds;
                gvAdmin.DataBind();

                if (objAdmin.Ds.Tables[0].Rows.Count == 1 && objAdmin.Ds.Tables[0].Rows[0]["Admin_ID"].ToString() == "")
                {
                    Button btnEdit = gvAdmin.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvAdmin.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objAdmin.GetDataset();
                gvAdmin.DataSource = objAdmin.Ds;
                gvAdmin.DataBind();
            }

            if (ViewState["SortExpression"] != null)
            {
                objAdmin.GetDataset();
                dataTable = objAdmin.Ds.Tables[0];
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
                    gvAdmin.DataSource = dataTable;
                    gvAdmin.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvAdmin.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvAdmin.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                  //  gvAdmin.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

         //   gvAdmin.HeaderRow.Cells[2].Visible = false;
            gvAdmin.HeaderRow.Cells[4].Visible = false;
            gvAdmin.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvAdmin.Rows.Count; i++)
            {
                GridViewRow row = gvAdmin.Rows[i];
           //     row.Cells[2].Visible = false;
                row.Cells[4].Visible = false;
            }

            gvAdmin.RenderControl(hw);
            Response.Output.Write("<b><u><big>Admin Detail</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            
            objAdmin.Admin_ID1 = Convert.ToInt16(txtAdminID.Text);

            objAdmin.Delete();
            Response.Redirect("AdminDetail.aspx");
            
               
        }

        
        


        // ViewAdminDetail end
    }
}