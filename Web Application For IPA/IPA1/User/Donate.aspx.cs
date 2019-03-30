using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Text.RegularExpressions;

namespace IPA1.User
{
    public partial class Donate : System.Web.UI.Page
    {

        BusLib.Transaction.Donation objDonation = new BusLib.Transaction.Donation();
        BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }

        }
        protected void btnDonate_Click(object sender, EventArgs e)
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

            if (Session["User_ID"] != null)
            {
                objDonation.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            }
          
            objDonation.Amount1 = Convert.ToInt16(txtAmount.Text);
            objDonation.Type1 = "By Pay";
            objDonation.Date1 = DateTime.Now.ToString("yyyy-MM-dd");
            objDonation.Insert();


            if (Session["User_ID"] != null)
            {
                PayWithPayPal(Session["User_ID"].ToString());
            }
            else
            {
                PayWithPayPal("");
            }
          
            //Response.Write("<script language='javascript'>window.alert('Inserted Sucessfully');window.location='DashBoard.aspx';</script>");
            //Reset();

        }



        protected void PayWithPayPal(string User_ID)
        {
            string FirstName = "";
            string LastName = "";
            string Address = "";
            string City = "";
            string State = "";
            string MobileNo = "";
            string Email = "";
            string PinCode = "";

            if (Session["User_ID"] != null)
            {
                objRegistration.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objRegistration.GetDataSet_Select();
                FirstName = objRegistration.Ds.Tables[0].Rows[0]["FirstName"].ToString();
                LastName = objRegistration.Ds.Tables[0].Rows[0]["LastName"].ToString();
                Address = objRegistration.Ds.Tables[0].Rows[0]["Address"].ToString();
                City = objRegistration.Ds.Tables[0].Rows[0]["City"].ToString();
                State = objRegistration.Ds.Tables[0].Rows[0]["State"].ToString();
                MobileNo = objRegistration.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                Email = objRegistration.Ds.Tables[0].Rows[0]["Email"].ToString();
                PinCode = objRegistration.Ds.Tables[0].Rows[0]["PinCode"].ToString();

            }
       
            string redirecturl = "";

            //Mention URL to redirect content to paypal site
            redirecturl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_xclick&business=" +
                           ConfigurationManager.AppSettings["paypalemail"].ToString();

            //First name i assign static based on login details assign this value
            redirecturl += "&first_name=" + FirstName;

            redirecturl += "&last_name=" + LastName;

            //City i assign static based on login user detail you change this value
            redirecturl += "&city=" + City;

            //State i assign static based on login user detail you change this value
            redirecturl += "&state=" + State;

            //Product Name
            redirecturl += "&item_name=" + txtPurpose.Text;

            //Product Name
            redirecturl += "&amount=" + txtAmount.Text;

            //Phone No
            redirecturl += "&night_phone_a=" + MobileNo;

            redirecturl += "&H_PhoneNumber=" + MobileNo;

            redirecturl += "&zip=" + PinCode;

            redirecturl += "&email-address=" + Email;
            //Address 
            redirecturl += "&address1=" + Address;

            //Business contact id
            // redirecturl += "&business=k.tapankumar@gmail.com";

            //Shipping charges if any
            redirecturl += "&shipping=0";

            //Handling charges if any
            redirecturl += "&handling=0";

            //Tax amount if any
            redirecturl += "&tax=0";

            //Add quatity i added one only statically 
            redirecturl += "&quantity=1";

            //Currency code 
            redirecturl += "&currency_code=" + ddlCurrency.SelectedValue;

            //Success return page url
            redirecturl += "&return=" +
              ConfigurationManager.AppSettings["SuccessURL"].ToString();

            //Failed return page url
            redirecturl += "&cancel_return=" +
              ConfigurationManager.AppSettings["FailedURL"].ToString();

            Response.Redirect(redirecturl);
        }
        void Reset()
        {
            txtAmount.Text = "";


        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();

        }

    }
}