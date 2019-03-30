using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Data;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;


namespace IPA1.AdminLab
{
    public partial class ViewInquiry : System.Web.UI.Page
    {
        BusLib.Transaction.Inquiry objInquiry = new BusLib.Transaction.Inquiry();
        int Inquiry_ID = 0;
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

        void BindGrid()
        {
            objInquiry.GetDataSet();
            gvInquiry.DataSource = objInquiry.Ds;
            gvInquiry.DataBind();
            
        }

        protected void gvInquiry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvInquiry.PageIndex = e.NewPageIndex;
            BindGrid();


            if (ViewState["SortExpression"] != null)
            {
                objInquiry.GetDataSet();
                dataTable = objInquiry.Ds.Tables[0];
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
                    gvInquiry.DataSource = dataTable;
                    gvInquiry.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvInquiry.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvInquiry.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvInquiry.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
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


        protected void gvInquiry_Sorting(object sender, GridViewSortEventArgs e)
        {
            objInquiry.GetDataSet();

            dataTable = objInquiry.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;

                gvInquiry.DataSource = dataTable;
                gvInquiry.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvInquiry.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvInquiry.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvInquiry.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
        }
       

        protected void gvInquiry_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {

                Inquiry_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvInquiry.ActiveViewIndex = 1;
                ViewInquiryDetail();


            }

        }

        void ViewInquiryDetail()
        {
            objInquiry.Inquiry_ID1 = Convert.ToInt16(Inquiry_ID.ToString());
            objInquiry.GetDataSet_GetInquiryDetail();
            txtInquiryID.Text = objInquiry.Ds.Tables[0].Rows[0]["Inquiry_ID"].ToString();
            txtEmail.Text = objInquiry.Ds.Tables[0].Rows[0]["Email"].ToString();
            txtName.Text = objInquiry.Ds.Tables[0].Rows[0]["Name"].ToString();
            txtmessage.Text = objInquiry.Ds.Tables[0].Rows[0]["Question"].ToString();
            txtSubject.Text = objInquiry.Ds.Tables[0].Rows[0]["Subject"].ToString();
            txtAnswer.Text = objInquiry.Ds.Tables[0].Rows[0]["Answer"].ToString();




        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objInquiry.Inquiry_ID1 = Convert.ToInt16(txtInquiryID.Text);
            objInquiry.Name1 = txtName.Text;
            objInquiry.Admin_ID1 = 101;
            objInquiry.Email1 = txtEmail.Text;
            objInquiry.Subject1 = txtSubject.Text;
            objInquiry.Question1 = txtmessage.Text;
            objInquiry.Answer1 = txtAnswer.Text;
            
            objInquiry.Update();
            Response.Write("<script language='javascript'>window.alert('Answer is given to their Email Sucessfully');window.location='ViewInquiry.aspx';</script>");
            String mailto = txtEmail.Text;
            //Send Email

            //var fromAddress = new MailAddress("IPANGO992015@gmail.com");
            //var fromPassword = "IPANGO2015";

            //using (System.Net.Mail.MailMessage msg1 = new System.Net.Mail.MailMessage())
            //{
            //    System.Net.Mail.SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            //    smtpClient.EnableSsl = true;
            //    smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            //    smtpClient.UseDefaultCredentials = false;


            //    smtpClient.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
            //    msg1.From = new MailAddress("IPANGO992015@gmail.com");

            //    msg1.To.Add(mailto);   //Dynamic
            //    string Body = "";
            //    Body += "Subject" + txtSubject.Text + "<br/><br/>";
            //    Body += "Question" + txtmessage.Text + "<br/><br/>";
            //    Body += "Answer" + txtAnswer.Text + "<br/><br/>";
            //    msg1.Subject = "Inquiry";
            //    msg1.IsBodyHtml = true;
            //    msg1.Body = Body;
            //    smtpClient.Timeout = 1000000;
            //    smtpClient.Send(msg1);
            //}

        }

        void Reset()
        {
            txtAnswer.Text = "";
            txtEmail.Text = "";
            txtmessage.Text = "";
            txtName.Text = "";
            
            txtSubject.Text = "";
        }

        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvInquiry.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvInquiry.AllowPaging = true;
                gvInquiry.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }

            if (ViewState["SortExpression"] != null)
            {
                objInquiry.GetDataSet();
                dataTable = objInquiry.Ds.Tables[0];
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
                    gvInquiry.DataSource = dataTable;
                    gvInquiry.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvInquiry.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvInquiry.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvInquiry.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
        }

        protected void lbInquiry_Click(object sender, EventArgs e)
        {
            mvInquiry.ActiveViewIndex = 0;
            BindGrid();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvInquiry.ActiveViewIndex = 0;
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

            gvInquiry.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objInquiry.GetDataSet();
                gvInquiry.DataSource = objInquiry.Ds;
                gvInquiry.DataBind();

                if (objInquiry.Ds.Tables[0].Rows.Count == 1 && objInquiry.Ds.Tables[0].Rows[0]["Inquiry_ID"].ToString() == "")
                {
                    Button btnEdit = gvInquiry.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvInquiry.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objInquiry.GetDataSet();
                gvInquiry.DataSource = objInquiry.Ds;
                gvInquiry.DataBind();


            }

            if (ViewState["SortExpression"] != null)
            {
                objInquiry.GetDataSet();
                dataTable = objInquiry.Ds.Tables[0];
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
                    gvInquiry.DataSource = dataTable;
                    gvInquiry.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvInquiry.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvInquiry.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

     //               gvInquiry.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

          //  gvInquiry.HeaderRow.Cells[2].Visible = false;
            gvInquiry.HeaderRow.Cells[3].Visible = false;
            gvInquiry.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvInquiry.Rows.Count; i++)
            {
                GridViewRow row = gvInquiry.Rows[i];
             //   row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            Label lblTitle = new Label();
            lblTitle.Text = "Inquiry Detail<br /><br />";
            lblTitle.Font.Bold = true;
            lblTitle.Font.Underline = true;
            lblTitle.RenderControl(hw);

            gvInquiry.RenderControl(hw);


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

            gvInquiry.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objInquiry.GetDataSet();
                gvInquiry.DataSource = objInquiry.Ds;
                gvInquiry.DataBind();
                if (objInquiry.Ds.Tables[0].Rows.Count == 1 && objInquiry.Ds.Tables[0].Rows[0]["Inquiry_ID"].ToString() == "")
                {
                    Button btnEdit = gvInquiry.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvInquiry.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objInquiry.GetDataSet();
                gvInquiry.DataSource = objInquiry.Ds;
                gvInquiry.DataBind();

            }

            if (ViewState["SortExpression"] != null)
            {
                objInquiry.GetDataSet();
                dataTable = objInquiry.Ds.Tables[0];
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
                    gvInquiry.DataSource = dataTable;
                    gvInquiry.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvInquiry.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvInquiry.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

   //                 gvInquiry.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

         //   gvInquiry.HeaderRow.Cells[2].Visible = false;
            gvInquiry.HeaderRow.Cells[3].Visible = false;
            gvInquiry.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvInquiry.Rows.Count; i++)
            {
                GridViewRow row = gvInquiry.Rows[i];
              //  row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            gvInquiry.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write("<b><u><big>Inquiry Detail</big></u><b><br><br>");
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

            gvInquiry.AllowPaging = false;
            //objState.GetDataSet("");
            //gvState.DataSource = objState.Ds;
            //gvState.DataBind();

      

            if (txtSearch.Text.Trim() != "")
            {
                objInquiry.GetDataSet();
                gvInquiry.DataSource = objInquiry.Ds;
                gvInquiry.DataBind();

                if (objInquiry.Ds.Tables[0].Rows.Count == 1 && objInquiry.Ds.Tables[0].Rows[0]["Inquiry_ID"].ToString() == "")
                {
                    Button btnEdit = gvInquiry.Rows[0].FindControl("btnEdit") as Button;
                    Button btnDelete = gvInquiry.Rows[0].FindControl("btnDelete") as Button;

                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                }

            }

            else
            {
                objInquiry.GetDataSet();
                gvInquiry.DataSource = objInquiry.Ds;
                gvInquiry.DataBind();
            }

            if (ViewState["SortExpression"] != null)
            {
                objInquiry.GetDataSet();
                dataTable = objInquiry.Ds.Tables[0];
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
                    gvInquiry.DataSource = dataTable;
                    gvInquiry.DataBind();
       
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvInquiry.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvInquiry.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

 //                   gvInquiry.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

          //  gvInquiry.HeaderRow.Cells[2].Visible = false;
            gvInquiry.HeaderRow.Cells[3].Visible = false;
            gvInquiry.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvInquiry.Rows.Count; i++)
            {
                GridViewRow row = gvInquiry.Rows[i];
               // row.Cells[2].Visible = false;
                row.Cells[3].Visible = false;
            }

            gvInquiry.RenderControl(hw);
            Response.Output.Write("<b><u><big>Inquiry Detail</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

    
    }
}