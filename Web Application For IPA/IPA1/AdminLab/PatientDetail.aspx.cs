using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace IPA1.AdminLab
{
    public partial class View_Patient : System.Web.UI.Page
    {
        
        BusLib.Transaction.Patient objPatient = new BusLib.Transaction.Patient();
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        bool PFlg = true;
        bool MFlg = true;
        int Patient_ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
                FillddlState();
                FillddlCity();
              //  ViewPatientDetail();
                

            }
        }


        void BindGrid()
        {
            objPatient.GetDataSet();
            gvPatientDetail.DataSource = objPatient.Ds;
            gvPatientDetail.DataBind();
        }


        void FillddlState()
        {
            objState.GetDataSet("");
            ddlState.DataSource = objState.Ds.Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "State_ID";
            ddlState.SelectedIndex = 6;
            ddlState.DataBind();
        }

        void FillddlCity()
        {
            objCity.StateID1 = Convert.ToInt16(ddlState.SelectedValue);
            objCity.GetCity();
            ddlCity.DataSource = objCity.Ds.Tables[0];
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "City_ID";
            ddlCity.DataBind();
            if (objCity.Ds.Tables[0].Rows.Count > 0)
            {
                ddlCity.SelectedIndex = 0;

            }



        }



        protected void cvPinCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 6)
            {

                args.IsValid = true;
                PFlg = true;

            }
            else
            {

                args.IsValid = false;
                PFlg = false;

            }
        }


        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillddlCity();
        }

        protected void cvMobileNo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 10)
            {

                args.IsValid = true;
                MFlg = true;
            }
            else
            {

                args.IsValid = false;
                MFlg = false;
            }

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objPatient.Patient_ID1 = Convert.ToInt16(txtPatientID.Text);
            objPatient.Request_ID1 = 1;
            objPatient.Address1 = txtAddress.Text;
            objPatient.Name1 = txtName.Text;
            objPatient.City1 = ddlCity.SelectedItem.ToString();
            objPatient.State1 = ddlState.SelectedItem.ToString();
            objPatient.PinCode1 = Convert.ToInt32(txtPinCode.Text);
            objPatient.MobileNo1 = Convert.ToInt64(txtMobileNo.Text);
            objPatient.Update();
            Reset();
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvPatient.ActiveViewIndex = 0;
        }


        void ViewPatientDetail()
        {
            objPatient.Patient_ID1 = Convert.ToInt16(Patient_ID.ToString());
            objPatient.GetDataSet_GetPatientDetail();
            txtRequestID.Text = objPatient.Ds.Tables[0].Rows[0]["Request_ID"].ToString();
            txtPatientID.Text = objPatient.Ds.Tables[0].Rows[0]["Patient_ID"].ToString();
            txtName.Text = objPatient.Ds.Tables[0].Rows[0]["Name"].ToString();
            txtAddress.Text = objPatient.Ds.Tables[0].Rows[0]["Address"].ToString();
            ddlState.SelectedItem.Text = objPatient.Ds.Tables[0].Rows[0]["State"].ToString();

            ddlCity.SelectedItem.Text = objPatient.Ds.Tables[0].Rows[0]["City"].ToString();

            txtPinCode.Text = objPatient.Ds.Tables[0].Rows[0]["PinCode"].ToString();
            txtMobileNo.Text = objPatient.Ds.Tables[0].Rows[0]["MobileNo"].ToString();



        }


        void Reset()
        {
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtName.Text = "";
            txtPinCode.Text = "";
            ddlCity.ClearSelection();
            ddlState.ClearSelection();
            txtPatientID.Text = "";
            txtRequestID.Text = "";

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            txtName.Text = "";
            txtPinCode.Text = "";
            ddlCity.ClearSelection();
            ddlState.ClearSelection();
            txtPatientID.Text = "";
        }

        Image sortImage = new Image();
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
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        BindGrid();
        //    }
        //}

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PatientForm.aspx");

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

        protected void gvPatientDetail_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            gvPatientDetail.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvPatientDetail_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                
                Patient_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvPatient.ActiveViewIndex = 1;
                ViewPatientDetail();
               

            }
        }


        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvPatientDetail.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvPatientDetail.AllowPaging = true;
                gvPatientDetail.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }

            if (ViewState["SortExpression"] != null)
            {
                objPatient.GetDataSet();
                dataTable = objPatient.Ds.Tables[0];
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
                    gvPatientDetail.DataSource = dataTable;
                    gvPatientDetail.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvPatientDetail.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvPatientDetail.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvPatientDetail.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
        }



        protected void gvPatientDetail_Sorting1(object sender, GridViewSortEventArgs e)
        {
            objPatient.GetDataSet();

            dataTable = objPatient.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                gvPatientDetail.DataSource = dataTable;
                gvPatientDetail.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvPatientDetail.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvPatientDetail.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvPatientDetail.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
        }

      

        protected void lblPatient_Click(object sender, EventArgs e)
        {
            mvPatient.ActiveViewIndex = 0;
        }
        
    }
}