using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;


namespace IPA1.AdminLab
{
    public partial class DonationForm : System.Web.UI.Page
    {
        BusLib.Transaction.Donation objDonation = new BusLib.Transaction.Donation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtChequeDate.Attributes.Add("readonly", "readonly");
                CalendarExtender1.StartDate = DateTime.Now.Date; 
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtAmount.Text))
                {

                    lblcvAmount.Text = "";

                }
                else
                {
                    lblcvAmount.Text = "Please enter valid Amount (e.g 1000.50)";
                    return;


                }
            }

            objDonation.Amount1=Convert.ToDecimal(txtAmount.Text);
            objDonation.BankName1="";
            objDonation.ChequeNo1=Convert.ToInt32(txtChequeNo.Text);
            objDonation.ChequeDate1 = ConvertDate(txtChequeDate.Text);
            objDonation.Type1 = "By Cheque";
            if (Session["UserType"].ToString() == "Admin")
            {
                objDonation.Admin_ID1 = Convert.ToInt16(Session["User_ID"]);
            }
            else
            {
                objDonation.User_ID1 = Convert.ToInt16(Session["User_ID"]);
            }
            objDonation.Date1 =   DateTime.Now.ToString("yyyy-MM-dd");
            objDonation.Insert();
            Response.Write("<script language='javascript'>window.alert('Donation Detail is Inserted Sucessfully');window.location='ViewDonation.aspx';</script>");
            Reset();

        }

        void Reset()
        {
            txtAmount.Text = "";
            txtChequeDate.Text = "";
            txtChequeNo.Text = "";
            lblcvAmount.Text = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/ViewDonation.aspx");
        }


        
       

       



    }
}