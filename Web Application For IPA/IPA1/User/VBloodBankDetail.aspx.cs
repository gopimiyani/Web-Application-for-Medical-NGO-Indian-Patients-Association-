using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;


namespace IPA1.User
{
    public partial class VBloodBankDetail : System.Web.UI.Page
    {
        BusLib.Transaction.BloodBankDetail objBloodBank = new BusLib.Transaction.BloodBankDetail();
        BusLib.Transaction.Patient objPatient = new BusLib.Transaction.Patient();
        int BloodBankDetail_ID = 0;

        //sort start
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


        //sort end

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["UserType"] != null)
                {
                    if (Session["UserType"].ToString() != "BloodBank")
                    {
                        Response.Redirect("~/Visitor/Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Visitor/Login.aspx");
                }

                BindGrid();
            }
        }

        void BindGrid()
        {
            objBloodBank.GetDataSet(Session["User_ID"].ToString(), txtSearch.Text);
            gvBloodBank.DataSource = objBloodBank.Ds;
            gvBloodBank.DataBind();
            if (objBloodBank.Ds.Tables[0].Rows.Count == 1 && objBloodBank.Ds.Tables[0].Rows[0]["BloodBankDetail_ID"].ToString() == "")
            {
                Button btnView = gvBloodBank.Rows[0].FindControl("btnView") as Button;
                btnView.Visible = false;
            }
        }

        protected void ddlBloodBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvBloodBank_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBloodBank.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        //BloodBank Detail
        protected void gvBloodBank_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                BloodBankDetail_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvBloodBank.ActiveViewIndex = 1;
                FillddlName1();
                ViewBloodBankDetail();
            }
        }


        void FillddlName1()
        {
            objPatient.GetViewPatientName();
            ddlName.Items.Add(new ListItem("--Select Name | ID--", ""));
            ddlName.DataSource = objPatient.Ds.Tables[0];
            ddlName.DataTextField = "Name";
            ddlName.DataValueField = "Patient_ID";
            ddlName.SelectedIndex = 0;
            ddlName.DataBind();

        }


        void ViewBloodBankDetail()
        {
            if (BloodBankDetail_ID != 0)
            {

                objBloodBank.BloodBankDetail_ID1 = Convert.ToInt16(BloodBankDetail_ID.ToString());
                objBloodBank.GetDataSet_GetBloodBankServiceDetail();
                ddlName.Enabled = false;
                lblBillNo1.Enabled = false;
                txtBloodBankDetail_ID.Text = objBloodBank.Ds.Tables[0].Rows[0]["BloodBankDetail_ID"].ToString();
                ddlName.SelectedValue = objBloodBank.Ds.Tables[0].Rows[0]["Patient_ID"].ToString();

                ddlBloodGroup.SelectedValue = objBloodBank.Ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                txtNoOfBottle.Text = objBloodBank.Ds.Tables[0].Rows[0]["NoOfBottle"].ToString();
                txtRate.Text = objBloodBank.Ds.Tables[0].Rows[0]["Charges"].ToString();
                txtTotalAmount.Text = objBloodBank.Ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                txtDiscountAmount.Text = objBloodBank.Ds.Tables[0].Rows[0]["DiscountAmount"].ToString();
                txtDiscount.Text = objBloodBank.Ds.Tables[0].Rows[0]["Discount"].ToString();
                txtFinalAmount.Text = objBloodBank.Ds.Tables[0].Rows[0]["FinalAmount"].ToString();
                String PStatus = objBloodBank.Ds.Tables[0].Rows[0]["PaymentStatus"].ToString();
                lblBillNo1.Text = objBloodBank.Ds.Tables[0].Rows[0]["BillNo"].ToString();
                if (PStatus == "False")
                {
                    ddlPStatus.SelectedValue = "Unpaid";

                    ddlBloodGroup.Enabled = true;
                    txtNoOfBottle.Enabled = true;
                    txtRate.Enabled = true;
                    txtDiscount.Enabled = true;

                    btnSubmit.Visible = true;
                    btnReset.Visible = true;
                }
                else
                {
                    ddlPStatus.SelectedValue = "Paid";

                    ddlBloodGroup.Enabled = false;
                    txtNoOfBottle.Enabled = false;
                    txtRate.Enabled = false;
                    txtDiscount.Enabled = false;

                    btnSubmit.Visible = false;
                    btnReset.Visible = false;
                }
            }
        }


        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvBloodBank.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvBloodBank.AllowPaging = true;
                gvBloodBank.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }
        }
        void Reset()
        {
            txtDiscount.Text = "";
            txtFinalAmount.Text = "";
            txtNoOfBottle.Text = "";
            txtTotalAmount.Text = "";
            txtDiscountAmount.Text = "";
            ddlBloodGroup.ClearSelection();
            txtRate.Text = "";
            ddlBloodGroup.ClearSelection();
            lblcvDiscount.Text = "";
            lblcvBloodGroup.Text = "";
            lblcvTotalAmount.Text = "";
        }

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {
            if (txtRate.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtRate.Text))
                {
                    //   lblcvIRate.ForeColor = System.Drawing.Color.Red;

                    lblcvRate.Text = "";

                }
                else
                {
                    lblcvRate.Text = "Enter valid Rate(e.g 100.12)";
                    return;


                }
            }






            if (txtNoOfBottle.Text != "" && txtRate.Text != "")
            {
                objBloodBank.TotalAmount1 = (Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt16(txtNoOfBottle.Text.Trim()));
                txtTotalAmount.Text = Convert.ToString(objBloodBank.TotalAmount1);
                lblcvRate.Visible = false;
            }



        }

        protected void txtDiscount_TextChanged1(object sender, EventArgs e)
        {
            if (txtDiscount.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtDiscount.Text))
                {
                    if ((Convert.ToDecimal(txtDiscount.Text)).CompareTo(new decimal(100.00)) > 0 || (Convert.ToDecimal(txtDiscount.Text)).CompareTo(new decimal(00.00)) < 0)
                    {
                        lblcvDiscount.Text = "Enter valid Discount in between 0.00 to 100.00!";
                        return;
                    }
                    else
                    {
                        lblcvDiscount.Text = "";
                    }
                }
                else
                {
                    lblcvDiscount.Text = "Enter valid Discount";
                    return;
                }

            }
            if (txtDiscount.Text == "")
            {
                lblcvDiscount.Visible = true;
                lblcvDiscount.Text = "Enter Discount!";
                lblcvDiscount.ForeColor = System.Drawing.Color.Red;
                txtDiscountAmount.Text = "";
                txtFinalAmount.Text = "";
                return;
            }





            if (txtDiscount.Text != "" && txtTotalAmount.Text != "")
            {
                objBloodBank.DiscountAmount1 = (Convert.ToDecimal(txtTotalAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100);
                objBloodBank.FinalAmount1 = Convert.ToDecimal(txtTotalAmount.Text) - objBloodBank.DiscountAmount1;
                txtDiscountAmount.Text = Convert.ToString(objBloodBank.DiscountAmount1);
                txtFinalAmount.Text = Convert.ToString(objBloodBank.FinalAmount1);
                lblcvDiscount.Visible = false;

            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtTotalAmount.Text == "0")
            {
                lblcvTotalAmount.Text = "Total Amount can not be 0";
                return;
            }


            else
            {
                lblcvTotalAmount.Text = "";
            }



            if (txtDiscount.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtDiscount.Text))
                {
                    if ((Convert.ToDecimal(txtDiscount.Text)).CompareTo(new decimal(100.00)) > 0 || (Convert.ToDecimal(txtDiscount.Text)).CompareTo(new decimal(00.00)) < 0)
                    {
                        lblcvDiscount.Text = "Enter valid Discount in between 0.00 to 100.00!";
                        return;



                    }
                    else
                    {
                        //  lblcvDiscount.ForeColor = System.Drawing.Color.Red;

                        lblcvDiscount.Text = "";
                    }
                }
                else
                {
                    lblcvDiscount.Text = "Enter valid Discount";
                    return;
                }

            }
            if (txtDiscount.Text == "")
            {
                lblcvDiscount.Visible = true;
                lblcvDiscount.Text = "Enter Discount!";
                lblcvDiscount.ForeColor = System.Drawing.Color.Red;
                txtDiscountAmount.Text = "";
                txtFinalAmount.Text = "";
                return;
            }



            if (ddlBloodGroup.SelectedIndex == 0)
            {
                lblcvBloodGroup.Text = "Please choose Blood Group";
                return;
            }
            else
            {
                lblcvBloodGroup.Text = "";

            }


            if (txtRate.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtRate.Text))
                {
                    //   lblcvIRate.ForeColor = System.Drawing.Color.Red;

                    lblcvRate.Text = "";

                }
                else
                {
                    lblcvRate.Text = "Enter valid Rate(e.g 100.12)";
                    return;


                }
            }


            if (txtNoOfBottle.Text != "")
            {
                Regex regx = new Regex(@"[0-9]+");
                if (regx.IsMatch(txtNoOfBottle.Text))
                {

                    lblcvNoOfBottle.Text = "";
                    if (txtNoOfBottle.Text != "" && txtRate.Text != "")
                    {

                        txtTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt16(txtNoOfBottle.Text.Trim())));
                    }
                    else
                    {
                        txtTotalAmount.Text = "";
                    }


                }
                else
                {
                    lblcvNoOfBottle.Text = "Enter digits only";
                    txtTotalAmount.Text = "";
                    return;


                }
            }

            objBloodBank.BloodBankDetail_ID1 = Convert.ToInt16(txtBloodBankDetail_ID.Text);
            objBloodBank.Patient_ID1 = Convert.ToInt16(ddlName.SelectedValue);
            objBloodBank.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            objBloodBank.BillNo1 = Convert.ToDecimal(lblBillNo1.Text.Trim());

            objBloodBank.TotalAmount1 = Convert.ToDecimal(txtTotalAmount.Text.Trim());
            objBloodBank.Discount1 = Convert.ToDecimal(txtDiscount.Text.Trim());
            objBloodBank.DiscountAmount1 = (Convert.ToDecimal(txtTotalAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100);
            objBloodBank.FinalAmount1 = Convert.ToDecimal(txtTotalAmount.Text) - objBloodBank.DiscountAmount1;
            objBloodBank.NoOfBottle1 = Convert.ToInt16(txtNoOfBottle.Text.Trim());
            objBloodBank.BloodGroup1 = ddlBloodGroup.SelectedValue;

            objBloodBank.Charges1 = Convert.ToDecimal(txtRate.Text.Trim());
            objBloodBank.PaymentStatus1 = false;

            objBloodBank.Update();
           
            //  Reset();
            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('BloodBank Service detail updated suceessfully.'); </script>");
            mvBloodBank.ActiveViewIndex = 0;
            BindGrid();


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvBloodBank.ActiveViewIndex = 0;
        }

        protected void btnNew_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/User/VBloodBankDetailForm.aspx");
        }

        //protected void txtNoOfBottle_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtNoOfBottle.Text != "" && txtRate.Text == "")
        //    {
        //        txtTotalAmount.Text = Convert.ToString(txtNoOfBottle.Text);
        //    }

        //    if (txtNoOfBottle.Text == "" && txtRate.Text != "")
        //    {
        //        txtTotalAmount.Text = Convert.ToString(txtRate.Text);
        //    }
        //    if (txtNoOfBottle.Text == "")
        //    {
        //        lblcvNoOfBottle.Visible = true;
        //        lblcvNoOfBottle.Text = "Required";
        //        lblcvNoOfBottle.ForeColor = System.Drawing.Color.Red;
        //        return;
        //    }

        //    if (txtNoOfBottle.Text != "" && txtRate.Text != "")
        //    {
        //        objBloodBank.TotalAmount1 = (Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt16(txtNoOfBottle.Text.Trim()));
        //        txtTotalAmount.Text = Convert.ToString(objBloodBank.TotalAmount1);
        //        lblcvNoOfBottle.Visible = false;
        //    }



        //}

        protected void ddlBloodGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBloodGroup.SelectedIndex == 0)
            {
                lblcvBloodGroup.Text = "Please choose Blood Group";
                return;
            }
            else
            {
                lblcvBloodGroup.Text = "";

            }

        }

        protected void txtNoOfBottle_TextChanged(object sender, EventArgs e)
        {
            //if (txtNoOfBottle.Text != "" && txtRate.Text != "")
            //{
            //         txtTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt16(txtNoOfBottle.Text.Trim()))); 

            //}

            if (txtNoOfBottle.Text != "")
            {
                Regex regx = new Regex(@"[0-9]+");
                if (regx.IsMatch(txtNoOfBottle.Text))
                {

                    lblcvNoOfBottle.Text = "";
                    if (txtNoOfBottle.Text != "" && txtRate.Text != "")
                    {

                        txtTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt16(txtNoOfBottle.Text.Trim())));
                    }
                    else
                    {
                        txtTotalAmount.Text = "";
                    }


                }
                else
                {
                    lblcvNoOfBottle.Text = "Enter digits only";
                    txtTotalAmount.Text = "";
                    return;


                }
            }

        }

        protected void lbBloodBank_Click(object sender, EventArgs e)
        {
            mvBloodBank.ActiveViewIndex = 0;
            BindGrid();
        }

        protected void gvBloodBank_Sorting(object sender, GridViewSortEventArgs e)
        {
            objBloodBank.GetDataSet(Session["User_ID"].ToString(), txtSearch.Text);
            dataTable = objBloodBank.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                gvBloodBank.DataSource = dataTable;
                gvBloodBank.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvBloodBank.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvBloodBank.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvBloodBank.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
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

        protected void ddlBloodBankName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 
    }
}



