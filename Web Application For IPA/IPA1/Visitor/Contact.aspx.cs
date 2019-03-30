using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.Visitor
{
    public partial class Contact : System.Web.UI.Page
    {
        BusLib.Transaction.Inquiry objInquiry = new BusLib.Transaction.Inquiry();

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        /* Contact Form start */

        protected void btnSend_Click(object sender, EventArgs e)
        {
            objInquiry.Admin_ID1 = 101;
            objInquiry.Name1 = txtName.Text;
            objInquiry.Email1 = txtEmail.Text;
            objInquiry.Subject1 = txtSubject.Text;
            objInquiry.Question1 = txtmessage.Text;
            objInquiry.Insert();
            Reset_ContactForm();
            Response.Write("<script language='javascript'>window.alert('Message has been sent Sucessfully');</script>");

        }

        void Reset_ContactForm()
        {
            txtEmail.Text = "";
            txtmessage.Text = "";
            txtName.Text = "";
            txtSubject.Text = "";
        }

        /* Contact Form end */
    }
}