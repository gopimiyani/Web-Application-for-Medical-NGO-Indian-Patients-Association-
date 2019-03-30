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


namespace IPA1.Visitor
{
    public partial class TermsandCondition : System.Web.UI.Page
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
                objTerm.GetDataSet("");
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
           
                objTerm.GetDataSet("");
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

        protected void btninsert_Click(object sender, EventArgs e)
        {
            TextBox txtCode = GvTerm.FooterRow.FindControl("txtICode") as TextBox;
            TextBox txtName = GvTerm.FooterRow.FindControl("txtIName") as TextBox;
            //        objTerm.TermID1 = Convert.ToInt16(txtCode.Text);
            objTerm.TermName1 = txtName.Text;
            objTerm.Insert();
            Bind();
        }

       
        

        //protected void GvTerm_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    objTerm.GetDataSet("");
        //    dataTable = objTerm.Ds.Tables[0];
        //    SetSortDirection(SortDireaction);
        //    if (dataTable != null)
        //    {
        //        //Sort the data.
        //        SetSortDirection(SortDireaction);
        //        dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
        //        ViewState["SortExpression"] = e.SortExpression;
        //        GvTerm.DataSource = dataTable;
        //        GvTerm.DataBind();
        //        SortDireaction = _sortDirection;
        //        int columnIndex = 0;
        //        foreach (DataControlFieldHeaderCell headerCell in GvTerm.HeaderRow.Cells)
        //        {
        //            if (headerCell.ContainingField.SortExpression == e.SortExpression)
        //            {
        //                columnIndex = GvTerm.HeaderRow.Cells.GetCellIndex(headerCell);
        //            }
        //        }

        //        GvTerm.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
        //    }
        //}

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

        
    }
}
