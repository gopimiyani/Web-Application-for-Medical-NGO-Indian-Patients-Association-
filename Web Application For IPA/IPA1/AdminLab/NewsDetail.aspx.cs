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


namespace IPA1.AdminLab
{
    public partial class NewsDetail : System.Web.UI.Page
    {
        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();
        BusLib.Transaction.News objNews = new BusLib.Transaction.News();

        DataTable dataTable;
        String News_ID;

        public int PageSize = 5;

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

            }
        }


        private string ConvertDate(string Date)
        {
            string Rdate = "";
            if (Date != "")
            {
                Rdate = Date.Substring(6, 4) + "-" + Date.Substring(3, 2) + "-" + Date.Substring(0, 2);
            }
            return Rdate;
        }

        void BindGrid()
        {
            if (txtSearch.Text.Trim() != "")
            {
                objNews.GetDataset(txtSearch.Text.Trim());
                gvNews.DataSource = objNews.Ds;
                gvNews.DataBind();
                if (objNews.Ds.Tables[0].Rows.Count == 1 && objNews.Ds.Tables[0].Rows[0]["News_ID"].ToString() == "")
                {
                    Button btnView = gvNews.Rows[0].FindControl("btnView") as Button;
                    btnView.Visible = false;
                }

            }
            else
            {
                objNews.GetDataset("");
                gvNews.DataSource = objNews.Ds.Tables[0];
                gvNews.DataBind();
                mvNews.ActiveViewIndex = 0;

            }


        }
        protected void btnAddNews_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/NewsForm.aspx");
        }



        protected void gvNews_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvNews.PageIndex = e.NewPageIndex;
            BindGrid();

            if (ViewState["SortExpression"] != null)
            {
                objNews.GetDataset(txtSearch.Text.Trim());
                dataTable = objNews.Ds.Tables[0];
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
                    gvNews.DataSource = dataTable;
                    gvNews.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvNews.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvNews.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvNews.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

        }

        protected void gvNews_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                News_ID = e.CommandArgument.ToString();
                mvNews.ActiveViewIndex = 1;
                NewsDetailDisplay();
                txtStartDate.Attributes.Add("readonly", "readonly");
                txtCloseDate.Attributes.Add("readonly", "readonly");
                CalendarExtender_StartDate.StartDate = DateTime.Now;
                CalendarExtender_CloseDate.StartDate = DateTime.Now;

            }

        }

        void NewsDetailDisplay()
        {
            if (News_ID!="")
            {
                objNews.News_ID1 = Convert.ToInt16(News_ID);
                objNews.GetDataset("");

                txtNews_ID.Text = objNews.Ds.Tables[0].Rows[0]["News_ID"].ToString();
                String EntryDateTime = objNews.Ds.Tables[0].Rows[0]["EntryDate"].ToString() + "  " + objNews.Ds.Tables[0].Rows[0]["EntryTime"].ToString();
                txtEntryDateTime.Text = EntryDateTime;
                txtNewsTitle.Text = objNews.Ds.Tables[0].Rows[0]["NewsTitle"].ToString();
                txtNewsDescription.Text = objNews.Ds.Tables[0].Rows[0]["NewsDescription"].ToString();
                txtStartDate.Text = objNews.Ds.Tables[0].Rows[0]["StartDate"].ToString();
                txtCloseDate.Text = objNews.Ds.Tables[0].Rows[0]["CloseDate"].ToString();

                DateTime StartDate=DateTime.ParseExact(txtStartDate.Text,"dd-MM-yyyy",null);
                DateTime CloseDate=DateTime.ParseExact(txtCloseDate.Text,"dd-MM-yyyy",null);
                DateTime TodayDate=DateTime.Now;

                if (TodayDate < StartDate)
                {
                    btnDelete.Visible = true;
                    txtStartDate.Enabled = true;
                    txtCloseDate.Enabled = true;
                    txtNewsTitle.Enabled = true;
                    txtNewsDescription.Enabled = true;
                    CalendarExtender_CloseDate.StartDate = DateTime.ParseExact(txtStartDate.Text, "dd-MM-yyyy", null).AddDays(1);

                }
                if( StartDate <= TodayDate  && CloseDate > TodayDate)
                {
                    btnDelete.Visible = false;
                    txtStartDate.Enabled = false;
                    txtCloseDate.Enabled = true;
                    txtNewsTitle.Enabled = true;
                    txtNewsDescription.Enabled = true;
                   
                    
                }
                if (StartDate <= TodayDate && CloseDate < TodayDate)
                {
                    btnDelete.Visible = false;
                    txtNewsTitle.Enabled = false;
                    txtNewsDescription.Enabled = false;
                    txtCloseDate.Enabled = false;
                    txtStartDate.Enabled = false;

                    
                }
            }
        }
        protected void gvNews_Sorting(object sender, GridViewSortEventArgs e)
        {
            objNews.GetDataset("");

            dataTable = objNews.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;
                gvNews.DataSource = dataTable;
                gvNews.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvNews.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvNews.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvNews.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
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




        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvNews.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvNews.AllowPaging = true;
                gvNews.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }

            if (ViewState["SortExpression"] != null)
            {
                objNews.GetDataset(txtSearch.Text.Trim());
                dataTable = objNews.Ds.Tables[0];
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
                    gvNews.DataSource = dataTable;
                    gvNews.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvNews.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvNews.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvNews.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            objNews.GetDataset(txtSearch.Text.Trim());
            gvNews.DataSource = objNews.Ds;
            gvNews.DataBind();
            if (objNews.Ds.Tables[0].Rows.Count == 1 && objNews.Ds.Tables[0].Rows[0]["News_ID"].ToString() == "")
            {
                Button btnView = gvNews.Rows[0].FindControl("btnView") as Button;
                btnView.Visible = false;
            }
        }

        

        //Start News Detail

        void Reset()
        {
            txtNews_ID.Text = "";
            txtNewsTitle.Text = "";
            txtNewsDescription.Text = "";
            txtStartDate.Text = "";
            txtCloseDate.Text = "";
            txtEntryDateTime.Text = "";
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objNews.News_ID1 = Convert.ToInt16(txtNews_ID.Text);
            if (Session["User_ID"] != null)
            {
                objNews.Admin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            }

            objNews.NewsTitle1 = txtNewsTitle.Text;
            objNews.NewsDescription1 = txtNewsDescription.Text;
            objNews.EntryDate1 = DateTime.Now.ToString("yyyy-MM-dd");
            objNews.EntryTime1 = DateTime.Now.ToShortTimeString();
            objNews.StartDate1 = ConvertDate(txtStartDate.Text);
            objNews.CloseDate1 = ConvertDate(txtCloseDate.Text);

            objNews.Update();
            Response.Write("<script language='javascript'>window.alert('News Detail Updated Successfully');window.location='NewsDetail.aspx';</script>");

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            objNews.News_ID1 = Convert.ToInt16(txtNews_ID.Text);
            objNews.Delete();
            Reset();
            mvNews.ActiveViewIndex = 0;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvNews.ActiveViewIndex = 0;
        }



        protected void lbNewss_Click(object sender, EventArgs e)
        {
            mvNews.ActiveViewIndex = 0;
        }

        protected void txtStartDate_TextChanged(object sender, EventArgs e)
        {
            if (txtStartDate.Text != "")
            {
                txtCloseDate.Text = "";
                CalendarExtender_CloseDate.StartDate = DateTime.ParseExact(txtStartDate.Text, "dd-MM-yyyy", null).AddDays(1);
            }
        }





        //End News Detail

    }
}