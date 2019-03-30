using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.AdminLab
{
    public partial class PaymentForm : System.Web.UI.Page
    {
        BusLib.Utility.Payment objPayment = new BusLib.Utility.Payment();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindPID();        
                FillddlSH();
                btnSubmit.Visible = false;
                btnReset.Visible = false;
                btnCancle.Visible = false;
                txtChequeDate.Attributes.Add("readonly", "readonly");
       

                CalendarExtender1.StartDate = DateTime.Now.Date; 
            }

        }


        void BindPID()
        {
            objPayment.GetNextPID();
            String Payment_ID = objPayment.Ds.Tables[0].Rows[0]["Payment_ID"].ToString();
            if (Payment_ID != "")
            {
                txtPaymentID.Text = Payment_ID;
            }
            else
            {
                txtPaymentID.Text = "1";
            }
        }

        void FillddlSH()
        {
            
            ddlselecttype.AppendDataBoundItems = true;
            ddlselecttype.Items.Add(new ListItem("----- Select User Type -----", ""));

            ddlName.AppendDataBoundItems = true;
            ddlName.Items.Add(new ListItem("------- Select Name -------", ""));

            ddlBillNo.AppendDataBoundItems = true;
            ddlBillNo.Items.Add(new ListItem("------- Select Bill No -------", ""));

            objSH.GetDataSet("");
            
            ddlselecttype.DataSource = objSH.Ds.Tables[0];
            ddlselecttype.DataTextField = "Name";
            ddlselecttype.DataValueField = "StakeHolder_ID";

            ddlselecttype.DataBind();
            ddlselecttype.Items.Remove(new ListItem("Volunteer","1"));
            ddlselecttype.Items.Remove(new ListItem("Donor","2"));
            ddlselecttype.Items.Remove(new ListItem("Doctor", "6"));
            ddlselecttype.Items.Remove(new ListItem("NGO", "8"));  
        }

        void FillddlSHName()
        {

            ddlName.Items.Clear();
            ddlName.AppendDataBoundItems = true;
            ddlName.Items.Add(new ListItem("------- Select Name -------", ""));

            if (ddlselecttype.SelectedIndex != 0)
            {
                objRegistration.GetDataSet_FillSHName(ddlselecttype.SelectedItem.ToString());

                if (objRegistration.Ds.Tables.Count != 0)
                {
                    if (objRegistration.Ds.Tables[0].Rows.Count > 0)
                    {
                        ddlName.DataSource = objRegistration.Ds.Tables[0];
                        ddlName.DataTextField = "Name";
                        ddlName.DataValueField = "User_ID";
                        ddlName.DataBind();
                    }
                }

            }

            else
            {
                ddlName.SelectedIndex = 0;
                ddlBillNo.SelectedIndex = 0;
                txtTotalAmount.Text = "";
            }
        }


        void BindBillNo()
        {
            ddlBillNo.Items.Clear();

            ddlBillNo.AppendDataBoundItems = true;
            ddlBillNo.Items.Add(new ListItem("------- Select Bill No -------", ""));

            if (ddlName.SelectedIndex != 0 && ddlselecttype.SelectedIndex !=0)
            {
                objPayment.User_ID1 = Convert.ToInt16(ddlName.SelectedValue);
                objPayment.StackHolder1 = ddlselecttype.SelectedItem.ToString();
                objPayment.GetBillNo();


                if (objPayment.Ds.Tables.Count != 0)
                {
                    if (objPayment.Ds.Tables[0].Rows.Count > 0)
                    {
                        ddlBillNo.DataSource = objPayment.Ds.Tables[0];
                        ddlBillNo.DataTextField = "BillNo";
                        ddlBillNo.DataValueField = "BillNo";
                        ddlBillNo.DataBind();
                    }
                }

            }
            else
            {
                ddlBillNo.SelectedIndex = 0;
                txtTotalAmount.Text = "";
            }            
        }

        void BindTotalAmount()
        {
            if (ddlBillNo.SelectedIndex != 0 && ddlName.SelectedIndex!=0 && ddlselecttype.SelectedIndex!=0)
            {
                objPayment.User_ID1 = Convert.ToInt16(ddlName.SelectedValue);
                objPayment.StackHolder1 = ddlselecttype.SelectedItem.ToString();
                objPayment.BillNo1 = Convert.ToInt16(ddlBillNo.SelectedItem.ToString());
                objPayment.GetAmount();

                if (objPayment.Ds.Tables.Count != 0)
                {
                    if (objPayment.Ds.Tables[0].Rows.Count > 0)
                    {
                        txtTotalAmount.Text = objPayment.Ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                        
                    }
                }

            }
            else
            {
                txtTotalAmount.Text = "";
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
        protected void ddlName_SelectedIndexChanged(object sender, EventArgs e)
        {

            BindBillNo();

            if (ddlName.SelectedIndex == 0)
            {
                lblcvName.Text = "Please choose User Name";
                return;
            }
            else
            {
                lblcvName.Text = "";

            }
            
           
        }

        protected void ddlselecttype_SelectedIndexChanged1(object sender, EventArgs e)
        {

           
            if (ddlselecttype.SelectedIndex==0)
            {
                txtTotalAmount.Text = "";
            }
            FillddlSHName();

            if (ddlselecttype.SelectedIndex == 0)
            {
                lblcvType.Text = "Please choose User Type";
                return;
            }
            else
            {
                lblcvType.Text = "";

            }

           
        }


        protected void ddlBillNo_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            BindTotalAmount();
            if (ddlBillNo.SelectedIndex == 0)
            {
                lblcvBillNo.Text = "Please Select Bill No";
                return;
            }
            else
            {
                lblcvBillNo.Text = "";

            }
            
           
          
            
          
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {



            if (ddlselecttype.SelectedIndex == 0)
            {
                lblcvType.Text = "Please choose User Type";
                return;
            }
            else
            {
                lblcvType.Text = "";

            }


            if (ddlName.SelectedIndex == 0)
            {
                lblcvName.Text = "Please choose User Name";
                return;
            }
            else
            {
                lblcvName.Text = "";

            }
            


            if (ddlBillNo.SelectedIndex == 0)
            {
                lblcvBillNo.Text = "Please Select Bill No";
                return;
            }
            else
            {
                lblcvBillNo.Text = "";

            }
            
            objPayment.Admin_ID1 = Convert.ToInt16(Session["User_ID"]);
            objPayment.User_ID1 = Convert.ToInt16(ddlName.SelectedValue);
            objPayment.PaymentDate1 = DateTime.Now.ToString("yyyy-MM-dd");
            objPayment.BillNo1 = Convert.ToInt16(ddlBillNo.SelectedValue);
            objPayment.Amount1 = Convert.ToDecimal(txtTotalAmount.Text);
            objPayment.ChequeNo1 = Convert.ToInt32(txtChequeNo.Text);
            objPayment.ChequeDate1 = ConvertDate( txtChequeDate.Text );
            objPayment.Insert();

            objPayment.User_ID1 = Convert.ToInt16(ddlName.SelectedValue);
            objPayment.BillNo1 = Convert.ToInt16(ddlBillNo.SelectedValue);
            objPayment.UpdatePaymentStatus();

            Reset();
            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Inserted Successfully'); </script>");
            Response.Redirect("~/AdminLab/PaymentDetail.aspx");
        }


        void Reset()
        {
            txtTotalAmount.Text = "";
            ddlBillNo.ClearSelection();
            ddlName.ClearSelection();
            ddlselecttype.ClearSelection();
            txtChequeNo.Text = "";
            txtChequeDate.Text = "";

          //  txtPaymentID.Text = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/PaymentDetail.aspx");
        }

        protected void cbconfirmstep_CheckedChanged(object sender, EventArgs e)
        {
            if (cbconfirmstep.Checked == true)
            {
                btnSubmit.Visible = true;
                btnCancle.Visible = true;
                btnReset.Visible = true;
            }

            else
            {
                btnSubmit.Visible = false;
                btnCancle.Visible = false;
                btnReset.Visible = false;

            }
            
        }

     
    }
}