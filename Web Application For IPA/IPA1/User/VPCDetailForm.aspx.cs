using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace IPA1.User
{
    public partial class VPCDetailForm : System.Web.UI.Page
    {
        BusLib.Transaction.PharmaCompanyDetail objPCDetail = new BusLib.Transaction.PharmaCompanyDetail();
        BusLib.Transaction.PharmaCompanyServiceDetail objPCServiceDetail = new BusLib.Transaction.PharmaCompanyServiceDetail();
        BusLib.Transaction.Patient objPatient = new BusLib.Transaction.Patient();
        DataTable tb = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Session["UserType"] != null)
                {
                    if (Session["UserType"].ToString() != "PharmaCompany")
                    {
                        Response.Redirect("~/Visitor/Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Visitor/Login.aspx");
                }
                BindBillNo();
                FillddlPatientName();
                BindTable();
                BindGrid();
            }
        }

        void BindBillNo()
        {
            objPCDetail.GetNextBillNo();
            if (objPCDetail.Ds.Tables[0].Rows[0]["BillNo"].ToString() != "")
            {
                lblBillNo1.Text = objPCDetail.Ds.Tables[0].Rows[0]["BillNo"].ToString();
            }
            else
            {
                lblBillNo1.Text = "1";
            }

        }

      
        void FillddlPatientName()
        {
            if (Session["User_ID"] != null)
            {
                objPatient.ServiceProviderUser_ID1 = Convert.ToInt16(Session["User_ID"].ToString());

                objPatient.GetNewPatientName();
                ddlPatientName.AppendDataBoundItems = true;
                ddlPatientName.Items.Add(new ListItem("--Select Patient Name | ID--", ""));
                ddlPatientName.DataSource = objPatient.Ds.Tables[0];
                ddlPatientName.DataTextField = "Name";
                ddlPatientName.DataValueField = "Patient_ID";
                ddlPatientName.SelectedIndex = 0;
                ddlPatientName.DataBind();
            }
        }

        private void BindTable()
        {
            DataTable PCServiceDetail = new DataTable("Table"); //the “Table” value must be same for
            DataColumn c = new DataColumn();        // always
            PCServiceDetail.Columns.Add(new DataColumn("id", Type.GetType("System.Int16")));
            PCServiceDetail.Columns.Add(new DataColumn("ItemName", Type.GetType("System.String")));
            PCServiceDetail.Columns.Add(new DataColumn("Rate", Type.GetType("System.Double")));
            PCServiceDetail.Columns.Add(new DataColumn("Quantity", Type.GetType("System.Double")));
            PCServiceDetail.Columns.Add(new DataColumn("Amount", Type.GetType("System.Double")));

            Session["dt"] = PCServiceDetail;
        }

        void BindGrid()
        {
            tb = (DataTable)(Session["dt"]);

            int a = 0;
            if (tb.Rows.Count == 0)
            {
                tb.Rows.Add(tb.NewRow());
                Session["dt"] = tb;

                gvPharmaCompany.DataSource = (DataTable)(Session["dt"]);
                gvPharmaCompany.DataBind(); // gridview
                a = 1;

            }
            else
            {
                decimal TAmount = 0;
                gvPharmaCompany.DataSource = (DataTable)(Session["dt"]);// storing in “tb” datatable variable and bind with
                gvPharmaCompany.DataBind(); // gridview
                for (int i = 1; i < tb.Rows.Count; i++)
                {
                    TAmount += Convert.ToDecimal(tb.Rows[i]["Amount"].ToString());
                }
                txtTAmount.Text = TAmount.ToString();
                if (tb.Rows[0]["id"].ToString() == "")
                {
                    gvPharmaCompany.Rows[0].Visible = false;
                }

            }
            if (a == 1)
            {
                gvPharmaCompany.Rows[0].Visible = false;
            }

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            TextBox txtIItemName = gvPharmaCompany.FooterRow.FindControl("txtIItemName") as TextBox;
            TextBox txtIRate = gvPharmaCompany.FooterRow.FindControl("txtIRate") as TextBox;
            TextBox txtIQuantity = gvPharmaCompany.FooterRow.FindControl("txtIQuantity") as TextBox;
            Label lblcvIRate = gvPharmaCompany.FooterRow.FindControl("lblcvIRate") as Label;
            Label lblcvIQuantity = gvPharmaCompany.FooterRow.FindControl("lblcvIQuantity") as Label;
            Label lblcvTotalAmount = gvPharmaCompany.FooterRow.FindControl("lblcvTotalAmount") as Label;
            if (txtIRate.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtIRate.Text))
                {
                    //   lblcvIRate.ForeColor = System.Drawing.Color.Red;

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

                        lblcvTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtIRate.Text.Trim())) * (Convert.ToInt32(txtIQuantity.Text.Trim()))); ;
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

            Double Amount = Convert.ToDouble(txtIRate.Text) * Convert.ToDouble(txtIQuantity.Text);
            tb = (DataTable)(Session["dt"]);
            DataRow r1 = tb.NewRow();
            r1["id"] = tb.Rows.Count;
            r1["ItemName"] = txtIItemName.Text;
            r1["Rate"] = txtIRate.Text;
            r1["Quantity"] = txtIQuantity.Text;
            r1["Amount"] = Amount.ToString();
            tb.Rows.Add(r1);
            Session["dt"] = tb;


            BindGrid();

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

        protected void gvPharmaCompany_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            GridViewRow row = gvPharmaCompany.Rows[e.RowIndex];
            TextBox txtId = row.FindControl("txtId") as TextBox;
            TextBox txtItemName = row.FindControl("txtItemName") as TextBox;
            TextBox txtRate = row.FindControl("txtRate") as TextBox;
            TextBox txtQuantity = row.FindControl("txtQuantity") as TextBox;
            TextBox txtAmount = row.FindControl("txtAmount") as TextBox;
            Label lblcvQuantity = row.FindControl("lblcvQuantity") as Label;
            Label lblcvRate = row.FindControl("lblcvRate") as Label;
            TextBox txtTotalAmount = row.FindControl("txtTotalAmount") as TextBox;



            if (txtQuantity.Text != "")
            {
                Regex regx = new Regex(@"[0-9]+");
                if (regx.IsMatch(txtQuantity.Text))
                {

                    lblcvQuantity.Text = "";
                    if (txtQuantity.Text != "" && txtRate.Text != "")
                    {

                        txtTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt32(txtQuantity.Text.Trim()))); ;
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


            DataTable tb1 = (DataTable)Session["dt"];
            DataRow r = tb1.Select("id =" + txtId.Text + "").FirstOrDefault();
            r["id"] = txtId.Text;
            r["ItemName"] = txtItemName.Text;
            r["Rate"] = txtRate.Text;
            r["Quantity"] = txtQuantity.Text;
            Double Amount = Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtQuantity.Text);

            r["Amount"] = Amount;
            Session["dt"] = tb1;
            gvPharmaCompany.EditIndex = -1;
            BindGrid();

        }

        protected void gvPharmaCompany_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPharmaCompany.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvPharmaCompany_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            tb = (DataTable)(Session["dt"]);
            tb.Rows.RemoveAt(e.RowIndex); //deleting the records and decreasing the  total
            BindGrid(); //calling the tempdata form refresh the output

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

        protected void gvPharmaCompany_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPharmaCompany.EditIndex = -1;
            BindGrid();
        }

        protected void gvPharmaCompany_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPharmaCompany.PageIndex = e.NewPageIndex;
            BindGrid();

        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/VPharmaCompanyDetail.aspx");
        }


        void Reset()
        {
            ddlPatientName.ClearSelection();
            //ddlPCName.ClearSelection();
            txtTAmount.Text = "";
            txtDiscount.Text = "";
            txtDiscountAmount.Text = "";
            txtFinalAmount.Text = "";
            lblcvDiscount.Text = "";
            lblcvName.Text = "";
          
            lblgvPharmaCompany.Text = "";
            lblcvTAmount.Text = "";
            //    ddlPStatus.ClearSelection();
            DataTable tb = (DataTable)Session["dt"];
            tb.Rows.Clear();
            int a = 0;
            if (tb.Rows.Count == 0)
            {
                tb.Rows.Add(tb.NewRow());
                Session["dt"] = tb;

                gvPharmaCompany.DataSource = (DataTable)(Session["dt"]);
                gvPharmaCompany.DataBind(); // gridview
                a = 1;

            }

            if (a == 1)
            {
                gvPharmaCompany.Rows[0].Visible = false;
            }


        }

        protected void ddlPatientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPatientName.SelectedIndex == 0)
            {
                lblcvName.Text = "Please choose patient name";
                return;
            }
            else
            {
                lblcvName.Text = "";

            }

        }



        protected void txtDiscount_TextChanged(object sender, EventArgs e)
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

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvPharmaCompany.Rows[gvPharmaCompany.EditIndex];
            TextBox txtRate = row.FindControl("txtRate") as TextBox;
            TextBox txtQuantity = row.FindControl("txtQuantity") as TextBox;

            TextBox txtTotalAmount = row.FindControl("txtTotalAmount") as TextBox;
            Label lblcvQuantity = row.FindControl("lblcvQuantity") as Label;
            Button btnUpdate = row.FindControl("btnUpdate") as Button;

            if (txtQuantity.Text == "")
            {
                txtTotalAmount.Text = "";
            }

            if (txtQuantity.Text != "")
            {
                Regex regx = new Regex(@"[0-9]+");
                if (regx.IsMatch(txtQuantity.Text))
                {

                    lblcvQuantity.Text = "";
                    if (txtQuantity.Text != "" && txtRate.Text != "")
                    {

                        txtTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt32(txtQuantity.Text.Trim()))); ;
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

            btnUpdate.Focus();

        }

        protected void txtRate_TextChanged(object sender, EventArgs e)
        {

            GridViewRow row = gvPharmaCompany.Rows[gvPharmaCompany.EditIndex];
            TextBox txtRate = row.FindControl("txtRate") as TextBox;
            TextBox txtQuantity = row.FindControl("txtQuantity") as TextBox;
            Label lblcvQuantity = row.FindControl("lblcvQuantity") as Label;
            Label lblcvRate = row.FindControl("lblcvRate") as Label;
            TextBox txtTotalAmount = row.FindControl("txtTotalAmount") as TextBox;
            if (txtRate.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtRate.Text))
                {
                    //   lblcvIRate.ForeColor = System.Drawing.Color.Red;

                    lblcvRate.Text = "";
                    txtQuantity.Focus();


                }
                else
                {
                    lblcvRate.Text = "Enter valid Rate(e.g 100.12)";
                    return;
                }
            }

            if (txtQuantity.Text != "" && txtRate.Text != "")
            {

                txtTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt32(txtQuantity.Text.Trim())));
            }
            else
            {
                txtTotalAmount.Text = "";
            }



            //if (txtQuantity.Text != "" && txtRate.Text != "")
            //{
            //    objPCDetail.TotalAmount1 = (Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt32(txtQuantity.Text.Trim()));
            //    txtTotalAmount.Text = Convert.ToString(objPCDetail.TotalAmount1);
            //    lblcvRate.Visible = false;
            //}

            txtQuantity.Focus();
        }

        protected void txtIRate_TextChanged(object sender, EventArgs e)
        {
            TextBox txtIRate = gvPharmaCompany.FooterRow.FindControl("txtIRate") as TextBox;
            Label lblcvIRate = gvPharmaCompany.FooterRow.FindControl("lblcvIRate") as Label;
            TextBox txtIQuantity = gvPharmaCompany.FooterRow.FindControl("txtIQuantity") as TextBox;
            Label lblcvTotalAmount = gvPharmaCompany.FooterRow.FindControl("lblcvTotalAmount") as Label;
            if (txtIRate.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtIRate.Text))
                {
                    //   lblcvIRate.ForeColor = System.Drawing.Color.Red;

                    lblcvIRate.Text = "";

                }
                else
                {
                    lblcvIRate.Text = "Enter valid Rate(e.g 100.12)";
                    return;


                }
            }

            if (txtIQuantity.Text != "" && txtIRate.Text != "")
            {

                lblcvTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtIRate.Text.Trim())) * (Convert.ToInt32(txtIQuantity.Text.Trim()))); ;
            }
            else
            {
                lblcvTotalAmount.Text = "";
            }

            txtIQuantity.Focus();
        }



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (ddlPatientName.SelectedIndex == 0)
            {
                lblcvName.Text = "Please choose patient name";
                return;
            }
            else
            {
                lblcvName.Text = "";

            }


            if (txtTAmount.Text == "0")
            {
                lblcvTAmount.Text = "Total Amount can not be Zero.";
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

            objPCDetail.BillNo1 = Convert.ToInt16(lblBillNo1.Text);
            objPCDetail.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            objPCDetail.Patient_ID1 = Convert.ToInt16(ddlPatientName.SelectedValue);
            objPCDetail.TotalAmount1 = Convert.ToDecimal(txtTAmount.Text.Trim());
            objPCDetail.Discount1 = Convert.ToDecimal(txtDiscount.Text.Trim());
            objPCDetail.DiscountAmount1 = (Convert.ToDecimal(txtTAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100);
            objPCDetail.FinalAmount1 = Convert.ToDecimal(txtTAmount.Text) - objPCDetail.DiscountAmount1;

            objPCDetail.PaymentStatus1 = false;
          
            objPCDetail.Insert();

            DataTable tb = (DataTable)Session["dt"];

            for (int i = 1; i < tb.Rows.Count; i++)
            {
                objPCServiceDetail.ItemName1 = tb.Rows[i]["ItemName"].ToString();
                objPCServiceDetail.Rate1 = Convert.ToDecimal(tb.Rows[i]["Rate"].ToString());
                objPCServiceDetail.Quantity1 = Convert.ToDecimal(tb.Rows[i]["Quantity"].ToString());
                objPCServiceDetail.Amount1 = Convert.ToDecimal(tb.Rows[i]["Amount"].ToString());
                objPCServiceDetail.Insert();
            }

            Reset();

            string message = "PharmaCompny Service Detail Inserted successfully.";
            string url = "VPCDetail.aspx";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
        }


        void TotalAmount()
        {


        }

        protected void txtIQuantity_TextChanged(object sender, EventArgs e)
        {
            TextBox txtIRate = gvPharmaCompany.FooterRow.FindControl("txtIRate") as TextBox;
            TextBox txtIQuantity = gvPharmaCompany.FooterRow.FindControl("txtIQuantity") as TextBox;
            Label lblcvIQuantity = gvPharmaCompany.FooterRow.FindControl("lblcvIQuantity") as Label;
            Label lblcvTotalAmount = gvPharmaCompany.FooterRow.FindControl("lblcvTotalAmount") as Label;
            Button btnInsert = gvPharmaCompany.FooterRow.FindControl("btnInsert") as Button;

            if (txtIQuantity.Text == "")
            {
                lblcvTotalAmount.Text = "";
            }


            if (txtIQuantity.Text != "")
            {
                Regex regx = new Regex(@"[0-9]+");
                if (regx.IsMatch(txtIQuantity.Text))
                {

                    lblcvIQuantity.Text = "";
                    if (txtIQuantity.Text != "" && txtIRate.Text != "")
                    {

                        lblcvTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtIRate.Text.Trim())) * (Convert.ToInt32(txtIQuantity.Text.Trim()))); ;

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
            btnInsert.Focus();

        }

       
        protected void txtTAmount_TextChanged(object sender, EventArgs e)
        {
            //if (txtTAmount.Text == "0")
            //{
            //    lblcvTAmount.Text = "Total Amount can not be Zero";
            //}
            //else
            //{
            //    lblcvTAmount.Text = "";
            //}

        }
    }

}
