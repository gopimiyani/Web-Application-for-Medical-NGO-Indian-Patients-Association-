using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace IPA1.AdminLab
{
    public partial class PharmaCompanyDetail : System.Web.UI.Page
    {
        BusLib.Transaction.PharmaCompanyDetail objPCDetail = new BusLib.Transaction.PharmaCompanyDetail();
        BusLib.Transaction.PharmaCompanyServiceDetail objPCServiceDetail = new BusLib.Transaction.PharmaCompanyServiceDetail();
        BusLib.Transaction.Patient objPatient = new BusLib.Transaction.Patient();
        int PharmaCompanyDetail_ID = 0;
        DataTable tb = new DataTable();
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
                ViewState["BindGrid_DB"] = 0;
                FillddlPharmaCompanyName();
                BindGrid();

            }
        }

        void BindGrid()
        {
            objPCDetail.GetDataSet(ddlPharmaCompanyName.SelectedValue.ToString(), txtSearch.Text);
            mvPC.ActiveViewIndex = 0;
            gvPharmaCompany.DataSource = objPCDetail.Ds;
            gvPharmaCompany.DataBind();
            if (objPCDetail.Ds.Tables[0].Rows.Count == 1 && objPCDetail.Ds.Tables[0].Rows[0]["PharmaCompanyDetail_ID"].ToString() == "")
            {
                Button btnView = gvPharmaCompany.Rows[0].FindControl("btnView") as Button;
                btnView.Visible = false;
            }
        }

        void FillddlPharmaCompanyName()
        {
            objPCDetail.GetDataSet_GetPharmaCompanyName();
            ddlPharmaCompanyName.AppendDataBoundItems = true;
            ddlPharmaCompanyName.Items.Add(new ListItem("--Select PharmaCompany Name | ID--", ""));

            ddlPharmaCompanyName.DataSource = objPCDetail.Ds.Tables[0];
            ddlPharmaCompanyName.DataTextField = "Name";
            ddlPharmaCompanyName.DataValueField = "User_ID";
            ddlPharmaCompanyName.SelectedIndex = 0;
            ddlPharmaCompanyName.DataBind();

        }

        protected void ddlPharmaCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvPharmaCompany_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "View")
            {
                PharmaCompanyDetail_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvPC.ActiveViewIndex = 1;
                ViewState["BindGrid_DB"] = 0;
                FillddlPharmaCompanyName1();
                FillddlName1();
                ViewPharmaCompanyServiceDetail();
            }
        }

        //PC Detail

        void FillddlPharmaCompanyName1()
        {
            objPCDetail.GetDataSet_GetPharmaCompanyName();
            ddlPCName.AppendDataBoundItems = true;
            ddlPCName.Items.Add(new ListItem("--Select Patient Name | ID--", ""));
            ddlPCName.DataSource = objPCDetail.Ds.Tables[0];
            ddlPCName.DataTextField = "Name";
            ddlPCName.DataValueField = "User_ID";
            ddlPCName.SelectedIndex = 0;
            ddlPCName.DataBind();

        }

        void FillddlName1()
        {
            objPatient.GetViewPatientName();
            ddlName.AppendDataBoundItems = true;
            ddlName.Items.Add(new ListItem("--Select PharmaCompany Name | ID--", ""));
            ddlName.DataSource = objPatient.Ds.Tables[0];
            ddlName.DataTextField = "Name";
            ddlName.DataValueField = "Patient_ID";
            ddlName.SelectedIndex = 0;
            ddlName.DataBind();

        }

        void ViewPharmaCompanyServiceDetail()
        {
            if (PharmaCompanyDetail_ID != 0)
            {

                objPCDetail.PharmaCompanyDetail_ID1 = Convert.ToInt16(PharmaCompanyDetail_ID.ToString());
                objPCDetail.GetDataSet();

                ddlName.Enabled = false;
                ddlPCName.Enabled = false;
                txtBillNo.Enabled = false;

                txtPharmaCompanyDetail_ID.Text = objPCDetail.Ds.Tables[0].Rows[0]["PharmaCompanyDetail_ID"].ToString();
                ddlName.SelectedValue = objPCDetail.Ds.Tables[0].Rows[0]["Patient_ID"].ToString();
                ddlPCName.SelectedValue = objPCDetail.Ds.Tables[0].Rows[0]["User_ID"].ToString();
                txtBillNo.Text = objPCDetail.Ds.Tables[0].Rows[0]["BillNo"].ToString();
                txtTAmount.Text = objPCDetail.Ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                txtDiscount.Text = objPCDetail.Ds.Tables[0].Rows[0]["Discount"].ToString();
                txtDiscountAmount.Text = objPCDetail.Ds.Tables[0].Rows[0]["DiscountAmount"].ToString();
                txtFinalAmount.Text = objPCDetail.Ds.Tables[0].Rows[0]["FinalAmount"].ToString();
                String PStatus = objPCDetail.Ds.Tables[0].Rows[0]["PaymentStatus"].ToString();
                if (PStatus == "False")
                {
                    ddlPStatus.SelectedValue = "Unpaid";

                    txtDiscount.Enabled = true;
                    btnSubmit.Visible = true;
                    btnReset.Visible = true;

                    gvPCDetail.Columns[6].Visible = true;
                    gvPCDetail.Columns[7].Visible = true;

                }
                else
                {
                    ddlPStatus.SelectedValue = "Paid";
                    txtDiscount.Enabled = false;
                    btnSubmit.Visible = false;
                    btnReset.Visible = false;
                    
                    gvPCDetail.Columns[6].Visible = false;
                    gvPCDetail.Columns[7].Visible = false;
                }
                BindTable();
                BindGrid1();
            }
        }

        private void BindGrid1()
        {
            objPCDetail.PharmaCompanyDetail_ID1 = Convert.ToInt16(txtPharmaCompanyDetail_ID.Text);
            objPCDetail.GetDataSet();

            DataTable tb = (DataTable)Session["dt"];
            if (ViewState["BindGrid_DB"].ToString() != "1")
            {
                for (int i = 0; i < objPCDetail.Ds.Tables[1].Rows.Count; i++)
                {
                    DataRow r1 = tb.NewRow();
                    r1["id"] = i + 1;
                    r1["PharmaCompanyService_ID"] = objPCDetail.Ds.Tables[1].Rows[i]["PharmaCompanyService_ID"].ToString();
                    r1["ItemName"] = objPCDetail.Ds.Tables[1].Rows[i]["ItemName"].ToString();
                    r1["Rate"] = objPCDetail.Ds.Tables[1].Rows[i]["Rate"].ToString();
                    r1["Quantity"] = objPCDetail.Ds.Tables[1].Rows[i]["Quantity"].ToString();
                    r1["Amount"] = objPCDetail.Ds.Tables[1].Rows[i]["Amount"].ToString();
                    tb.Rows.Add(r1);
                }
                Session["dt"] = tb;
                gvPCDetail.DataSource = tb;
                gvPCDetail.DataBind();
                ViewState["BindGrid_DB"] = 1;
                decimal TAmount = 0;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    TAmount += Convert.ToDecimal(tb.Rows[i]["Amount"].ToString());
                }
                txtTAmount.Text = TAmount.ToString();

            }

            int a = 0;
            if (tb.Rows.Count == 0)
            {
                tb.Rows.Add(tb.NewRow());
                Session["dt"] = tb;

                gvPCDetail.DataSource = (DataTable)(Session["dt"]);
                gvPCDetail.DataBind(); // gridview
                a = 1;

            }
            else
            {
                decimal TAmount = 0;
                gvPCDetail.DataSource = (DataTable)(Session["dt"]);// storing in “tb” datatable variable and bind with
                gvPCDetail.DataBind(); // gridview
                for (int i = 1; i < tb.Rows.Count; i++)
                {
                    TAmount += Convert.ToDecimal(tb.Rows[i]["Amount"].ToString());
                }
                txtTAmount.Text = TAmount.ToString();

                if (tb.Rows[0]["id"].ToString() == "")
                {
                    gvPCDetail.Rows[0].Visible = false;
                }

            }
            if (a == 1)
            {
                gvPCDetail.Rows[0].Visible = false;
            }
        }
        private void BindTable()
        {
            DataTable PCServiceDetail = new DataTable("Table"); //the “Table” value must be same for
            DataColumn c = new DataColumn();        // always
            PCServiceDetail.Columns.Add(new DataColumn("id", Type.GetType("System.Int16")));
            PCServiceDetail.Columns.Add(new DataColumn("PharmaCompanyService_ID", Type.GetType("System.Int16")));
            PCServiceDetail.Columns.Add(new DataColumn("ItemName", Type.GetType("System.String")));
            PCServiceDetail.Columns.Add(new DataColumn("Rate", Type.GetType("System.Double")));
            PCServiceDetail.Columns.Add(new DataColumn("Quantity", Type.GetType("System.Double")));
            PCServiceDetail.Columns.Add(new DataColumn("Amount", Type.GetType("System.Double")));

            Session["dt"] = PCServiceDetail;
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            TextBox txtIItemName = gvPCDetail.FooterRow.FindControl("txtIItemName") as TextBox;
            TextBox txtIRate = gvPCDetail.FooterRow.FindControl("txtIRate") as TextBox;
            TextBox txtIQuantity = gvPCDetail.FooterRow.FindControl("txtIQuantity") as TextBox;
            Label lblcvIRate = gvPCDetail.FooterRow.FindControl("lblcvIRate") as Label;
            Label lblcvIQuantity = gvPCDetail.FooterRow.FindControl("lblcvIQuantity") as Label;
            Label lblcvTotalAmount = gvPCDetail.FooterRow.FindControl("lblcvTotalAmount") as Label;

            if (txtIRate.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtIRate.Text))
                {

                    lblcvIRate.Text = "";

                }
                else
                {
                    lblcvIRate.Text = "Enter valid Rate(e.g 100.12)";
                    return;


                }


            }

            if (txtIQuantity.Text != "")
            {
                Regex regx = new Regex(@"[0-9]+");
                if (regx.IsMatch(txtIQuantity.Text))
                {

                    lblcvIQuantity.Text = "";
                    if (txtIQuantity.Text != "" && txtIRate.Text != "")
                    {

                        lblcvTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtIRate.Text.Trim())) * (Convert.ToInt16(txtIQuantity.Text.Trim()))); ;
                    }
                    else
                    {
                        lblcvTotalAmount.Text = "";
                    }


                }
                else
                {
                    lblcvIQuantity.Text = "Enter digits only";
                    return;


                }
            }





            Double Amount = Convert.ToDouble(txtIRate.Text) * Convert.ToDouble(txtIQuantity.Text);
            DataTable tb = (DataTable)(Session["dt"]);
            DataRow r1 = tb.NewRow();
            r1["id"] = tb.Rows.Count + 1;
            r1["ItemName"] = txtIItemName.Text;
            r1["Rate"] = txtIRate.Text;
            r1["Quantity"] = txtIQuantity.Text;
            r1["Amount"] = Amount.ToString();
            tb.Rows.Add(r1);
            Session["dt"] = tb;
            BindGrid1();



            if (tb.Rows.Count > 0)
            {
                lblgvPharmaCompany.Text = "";
                if (txtDiscount.Text != "" && txtTAmount.Text != "")
                {
                    txtDiscountAmount.Text = (Convert.ToDecimal(txtTAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100).ToString();
                    txtFinalAmount.Text = (Convert.ToDecimal(txtTAmount.Text) - objPCDetail.DiscountAmount1).ToString();
                }
            }

        }


        protected void gvPCDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvPCDetail.Rows[e.RowIndex];
            TextBox txtId = row.FindControl("txtId") as TextBox;
            TextBox txtItemName = row.FindControl("txtItemName") as TextBox;
            TextBox txtRate = row.FindControl("txtRate") as TextBox;
            TextBox txtQuantity = row.FindControl("txtQuantity") as TextBox;
            Label lblcvIRate = gvPCDetail.FooterRow.FindControl("lblcvIRate") as Label;
            Label lblcvQuantity = row.FindControl("lblcvQuantity") as Label;
            TextBox txtIRate = gvPCDetail.FooterRow.FindControl("txtIRate") as TextBox;
            TextBox txtTotalAmount = row.FindControl("txtTotalAmount") as TextBox;
            if (txtIRate.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtIRate.Text))
                {

                    lblcvIRate.Text = "";

                }
                else
                {
                    lblcvIRate.Text = "Enter valid Rate(e.g 100.12)";
                    return;


                }


            }

            if (txtQuantity.Text != "")
            {
                Regex regx = new Regex(@"[0-9]+");
                if (regx.IsMatch(txtQuantity.Text))
                {

                    lblcvQuantity.Text = "";
                    if (txtQuantity.Text != "" && txtRate.Text != "")
                    {

                        txtTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt16(txtQuantity.Text.Trim()))); ;
                    }

                    else
                    {
                        txtTotalAmount.Text = "";
                    }

                }
                else
                {
                    lblcvQuantity.Text = "Enter digits only";
                    txtTotalAmount.Text = "";
                    return;


                }
            }






            DataTable tb1 = (DataTable)Session["dt"];
            DataRow r = tb1.Select("id =" + txtId.Text + "").FirstOrDefault();
            r["id"] = txtId.Text;
            r["ItemName"] = txtItemName.Text;
            r["Rate"] = txtRate.Text;
            r["Quantity"] = txtQuantity.Text;
            Double Amount = Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtQuantity.Text);

            r["Amount"] = Amount;
            Session["dt"] = tb1;
            gvPCDetail.EditIndex = -1;
            BindGrid1();


        }

        protected void gvPCDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPCDetail.EditIndex = e.NewEditIndex;
            BindGrid1();
        }

        protected void gvPCDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            DataTable tb = (DataTable)(Session["dt"]);
            tb.Rows.RemoveAt(e.RowIndex); //deleting the records and decreasing the  total
            BindGrid1(); //calling the tempdata form refresh the output

            if (tb.Rows.Count > 1)
            {
                lblgvPharmaCompany.Text = "";
                if (txtDiscount.Text != "" && txtTAmount.Text != "")
                {
                    txtDiscountAmount.Text = (Convert.ToDecimal(txtTAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100).ToString();
                    txtFinalAmount.Text = (Convert.ToDecimal(txtTAmount.Text) - objPCDetail.DiscountAmount1).ToString();
                }
            }

            else
            {
                lblgvPharmaCompany.Text = "Please fill the above details !";
                txtTAmount.Text = "";
                txtDiscountAmount.Text = "";
                txtFinalAmount.Text = "";
                return;
            }



        }

        protected void gvPCDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPCDetail.EditIndex = -1;
            BindGrid1();
        }

        protected void gvPCDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPCDetail.PageIndex = e.NewPageIndex;
            BindGrid1();

        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }





        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvPC.ActiveViewIndex = 0;
        }


        void Reset()
        {
            txtDiscount.Text = "";
            txtFinalAmount.Text = "";
            txtTAmount.Text = "";
            ddlName.ClearSelection();
            ddlPCName.ClearSelection();
            // ddlPStatus.ClearSelection();
            txtDiscountAmount.Text = "";
            lblcvDiscount.Text = "";
            lblcvName.Text = "";
            lblcvPCName.Text = "";
            lblgvPharmaCompany.Text = "";
            lblcvTAmount.Text = "";
            DataTable tb = (DataTable)Session["dt"];
            tb.Rows.Clear();
            int a = 0;
            if (tb.Rows.Count == 0)
            {
                tb.Rows.Add(tb.NewRow());
                Session["dt"] = tb;

                gvPCDetail.DataSource = (DataTable)(Session["dt"]);
                gvPCDetail.DataBind(); // gridview
                a = 1;

            }

            if (a == 1)
            {
                gvPCDetail.Rows[0].Visible = false;
            }


        }

        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            //Decimal DiscountAmount = (Convert.ToDecimal(txtTAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100);
            //Decimal FinalAmount = Convert.ToDecimal(txtTAmount.Text.Trim()) - DiscountAmount;
            //txtDiscountAmount.Text = DiscountAmount.ToString();
            //txtFinalAmount.Text = FinalAmount.ToString();


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

            if (txtDiscount.Text != "" && txtTAmount.Text != "")
            {
                objPCDetail.DiscountAmount1 = (Convert.ToDecimal(txtTAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100);
                objPCDetail.FinalAmount1 = Convert.ToDecimal(txtTAmount.Text) - objPCDetail.DiscountAmount1;
                txtDiscountAmount.Text = Convert.ToString(objPCDetail.DiscountAmount1);
                txtFinalAmount.Text = Convert.ToString(objPCDetail.FinalAmount1);
                lblcvDiscount.Visible = false;

            }




        }

        protected void ddlPCName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlPCName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPCName.SelectedIndex == 0)
            {
                lblcvPCName.Text = "Please choose pharmacompany name";
                return;
            }
            else
            {
                lblcvPCName.Text = "";

            }

        }



        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlName.SelectedIndex == 0)
            {
                lblcvName.Text = "Please choose patient name";
                return;
            }
            else
            {
                lblcvName.Text = "";

            }

        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPCDetail.Rows[gvPCDetail.EditIndex];
            TextBox txtRate = row.FindControl("txtRate") as TextBox;
            TextBox txtQuantity = row.FindControl("txtQuantity") as TextBox;
            TextBox txtTotalAmount = row.FindControl("txtTotalAmount") as TextBox;
            Label lblcvQuantity = row.FindControl("lblcvQuantity") as Label;

            if (txtQuantity.Text != "")
            {
                Regex regx = new Regex(@"[0-9]+");
                if (regx.IsMatch(txtQuantity.Text))
                {

                    lblcvQuantity.Text = "";
                    if (txtQuantity.Text != "" && txtRate.Text != "")
                    {
                        txtTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt16(txtQuantity.Text.Trim()))); ;
                    }
                    else
                    {
                        txtTotalAmount.Text = "";
                    }

                }
                else
                {
                    lblcvQuantity.Text = "Enter digits only";
                    txtTotalAmount.Text = "";
                    return;


                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtTAmount.Text == "0")
            {
                lblcvTAmount.Text = "Total Amount can not be 0";
                return;
            }

            else
            {
                lblcvTAmount.Text = "";
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




            DataTable tb1 = (DataTable)Session["dt"];
            if (tb1.Rows.Count == 1 && tb1.Rows[0]["id"].ToString() == "")
            {
                lblgvPharmaCompany.Text = "Please Fill the above details !";
                return;
            }
            else
            {
                lblgvPharmaCompany.Text = "";
            }


            objPCDetail.PharmaCompanyDetail_ID1 = Convert.ToInt16(txtPharmaCompanyDetail_ID.Text);
            objPCDetail.User_ID1 = Convert.ToInt16(ddlPCName.SelectedValue);
            objPCDetail.Patient_ID1 = Convert.ToInt16(ddlName.SelectedValue);
            objPCDetail.BillNo1 = Convert.ToInt16(txtBillNo.Text);
            objPCDetail.TotalAmount1 = Convert.ToDecimal(txtTAmount.Text.Trim());
            objPCDetail.Discount1 = Convert.ToDecimal(txtDiscount.Text.Trim());
            objPCDetail.DiscountAmount1 = (Convert.ToDecimal(txtTAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100);
            objPCDetail.FinalAmount1 = Convert.ToDecimal(txtTAmount.Text) - objPCDetail.DiscountAmount1;
            if (ddlPStatus.SelectedValue == "Unpaid")
            {
                objPCDetail.PaymentStatus1 = false;
            }
            else
            {
                objPCDetail.PaymentStatus1 = true;
            }
            //objPCDetail.PaymentStatus1 = ddlPStatus.SelectedValue;
            objPCDetail.Update();

            DataTable tb = (DataTable)Session["dt"];
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["PharmaCompanyService_ID"].ToString() != "")
                {
                    objPCServiceDetail.PharmaCompanyService_ID1 = Convert.ToInt16(tb.Rows[i]["PharmaCompanyService_ID"].ToString());
                }
                else
                {
                    objPCServiceDetail.PharmaCompanyService_ID1 = 0;
                }
                objPCServiceDetail.PharmaCompanyDetail_ID1 = Convert.ToInt16(txtPharmaCompanyDetail_ID.Text);
        
                objPCServiceDetail.ItemName1 = tb.Rows[i]["ItemName"].ToString();
                objPCServiceDetail.Rate1 = Convert.ToDecimal(tb.Rows[i]["Rate"].ToString());
                objPCServiceDetail.Quantity1 = Convert.ToDecimal(tb.Rows[i]["Quantity"].ToString());
                objPCServiceDetail.Amount1 = Convert.ToDecimal(tb.Rows[i]["Amount"].ToString());
                objPCServiceDetail.Update();

            }
            //    Reset();
            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('PharmaCompany Service Detail Successfully Updated.'); </script>");

            mvPC.ActiveViewIndex = 0;
            BindGrid();

            //  Reset();
        }




        //End


        protected void btnNew_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/AdminLab/PCDetailForm.aspx");

        }

        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvPharmaCompany.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvPharmaCompany.AllowPaging = true;
                gvPharmaCompany.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }
        }

        protected void gvPharmaCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPharmaCompany.PageIndex = e.NewPageIndex;
            BindGrid();

        }

        protected void txtIRate_TextChanged(object sender, EventArgs e)
        {
            TextBox txtIRate = gvPCDetail.FooterRow.FindControl("txtIRate") as TextBox;
            Label lblcvIRate = gvPCDetail.FooterRow.FindControl("lblcvIRate") as Label;

            if (txtIRate.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtIRate.Text))
                {

                    lblcvIRate.Text = "";

                }
                else
                {
                    lblcvIRate.Text = "Enter valid Rate(e.g 100.12)";
                    return;


                }
            }



        }

        protected void txtIQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBox txtIRate = gvPCDetail.FooterRow.FindControl("txtIRate") as TextBox;
            TextBox txtIQuantity = gvPCDetail.FooterRow.FindControl("txtIQuantity") as TextBox;
            Label lblcvIQuantity = gvPCDetail.FooterRow.FindControl("lblcvIQuantity") as Label;
            Label lblcvTotalAmount = gvPCDetail.FooterRow.FindControl("lblcvTotalAmount") as Label;

            if (txtIQuantity.Text != "")
            {
                Regex regx = new Regex(@"[0-9]+");
                if (regx.IsMatch(txtIQuantity.Text))
                {

                    lblcvIQuantity.Text = "";
                    if (txtIQuantity.Text != "" && txtIRate.Text != "")
                    {

                        lblcvTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtIRate.Text.Trim())) * (Convert.ToInt16(txtIQuantity.Text.Trim()))); ;
                    }
                    else
                    {
                        lblcvTotalAmount.Text = "";
                    }


                }
                else
                {
                    lblcvIQuantity.Text = "Enter digits only";
                    lblcvTotalAmount.Text = "";
                    return;


                }
            }


        }

        protected void lbPharmaCompany_Click(object sender, EventArgs e)
        {
            mvPC.ActiveViewIndex = 0;
            BindGrid();
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

        protected void gvPharmaCompany_Sorting1(object sender, GridViewSortEventArgs e)
        {
            objPCDetail.GetDataSet(ddlPharmaCompanyName.SelectedValue.ToString(), "");
            dataTable = objPCDetail.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                gvPharmaCompany.DataSource = dataTable;
                gvPharmaCompany.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvPharmaCompany.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvPharmaCompany.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvPharmaCompany.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
        }

        
    }
}