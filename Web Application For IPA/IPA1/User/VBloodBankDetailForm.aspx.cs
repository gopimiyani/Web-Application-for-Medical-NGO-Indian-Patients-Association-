using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
namespace IPA1.User
{
    public partial class VBloodBankDetailForm : System.Web.UI.Page
    {
        BusLib.Transaction.BloodBankDetail objBloodBank = new BusLib.Transaction.BloodBankDetail();
        BusLib.Transaction.Patient objPatient = new BusLib.Transaction.Patient(); 
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
                BindBillNo();
                FillddlName();
            
            }
        }

        void BindBillNo()
        {
            objBloodBank.GetNextBillNo();
            if (objBloodBank.Ds.Tables[0].Rows[0]["BillNo"].ToString() != "")
            {
                lblBillNo1.Text = objBloodBank.Ds.Tables[0].Rows[0]["BillNo"].ToString();
            }
            else
            {
                lblBillNo1.Text = "1";
            }

            
        }


        void FillddlName()
        {
            if (Session["User_ID"] != null)
            {
                objPatient.ServiceProviderUser_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objPatient.GetNewPatientName();

                ddlName.AppendDataBoundItems = true;
                ddlName.Items.Add(new ListItem("--Select Patient Name | ID--", ""));
                ddlName.DataSource = objPatient.Ds.Tables[0];
                ddlName.DataTextField = "Name";
                ddlName.DataValueField = "Patient_ID";
                ddlName.SelectedIndex = 0;
                ddlName.DataBind();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (ddlName.SelectedIndex == 0)
            {
                lblcvName.Text = "Please choose Patient Name";
                return;
            }
            else
            {
                lblcvName.Text = "";

            }


            if (ddlBloodGroup.SelectedIndex == 0)
            {
                lblBloodGroup.Text = "Please choose Blood Group";
                return;
            }
            else
            {
                lblcvBloodGroup.Text = "";

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
                //lblcvDiscount.Visible = true;
                //lblcvDiscount.Text = "Enter Discount!";
                //lblcvDiscount.ForeColor = System.Drawing.Color.Red;
                txtDiscountAmount.Text = "";
                txtFinalAmount.Text = "";
              
            }


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
         
            objBloodBank.Insert();
            Reset();


            //Response.Redirect("BloodBankDetail.aspx");

            //Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('BloodBank Service Detail inserted successfully'); </script>");

            string message = "BloodBank Service Detail Inserted successfully.";
            string url = "VBloodBankDetail.aspx";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        void Reset()
        {
            txtDiscount.Text = "";
            txtFinalAmount.Text = "";
            txtNoOfBottle.Text = "";
            txtTotalAmount.Text = "";
            ddlBloodGroup.ClearSelection();
            ddlName.ClearSelection();
            txtDiscountAmount.Text = "";
            txtRate.Text = "";
            lblcvBloodGroup.Text = "";
            lblcvDiscount.Text = "";
            lblcvRate.Text = "";
            lblcvTotalAmount.Text = "";

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/VBloodBankDetail.aspx");
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
                //lblcvDiscount.Visible = true;
                //lblcvDiscount.Text = "Enter Discount!";
                //lblcvDiscount.ForeColor = System.Drawing.Color.Red;
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

            btnSubmit.Focus();
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
                lblcvRate.Text = "";
            }

            txtDiscount.Focus();
        }


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

        //protected void ddlBloodBankName_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlBloodBankName.SelectedIndex == 0)
        //    {
        //        lblcvBBName.Text = "Please choose Blood Bank Name";
        //        return;
        //    }
        //    else
        //    {
        //        lblcvBBName.Text = "";

        //    }

        //}

        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlName.SelectedIndex == 0)
            {
                lblcvName.Text = "Please choose Patient Name";
                return;
            }
            else
            {
                lblcvName.Text = "";

            }

        }

        protected void txtNoOfBottle_TextChanged1(object sender, EventArgs e)
        {
            //  if (txtNoOfBottle.Text != "" && txtRate.Text != "")
            //  {
            ////      objBloodBank.TotalAmount1 = (Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt16(txtNoOfBottle.Text.Trim()));
            //      txtTotalAmount.Text = Convert.ToString((Convert.ToDecimal(txtRate.Text.Trim())) * (Convert.ToInt16(txtNoOfBottle.Text.Trim()))); ;

            //  }


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

            txtRate.Focus();

        }




    }
}