using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.AdminLab
{
    public partial class NewsForm : System.Web.UI.Page
    {
        BusLib.Transaction.News objNews = new BusLib.Transaction.News();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtStartDate.Attributes.Add("readonly", "readonly");
                txtCloseDate.Attributes.Add("readonly", "readonly");
                CalendarExtender_StartDate.StartDate = DateTime.Now;
                CalendarExtender_CloseDate.StartDate = DateTime.Now;

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

        void Reset()
        {
            txtNewsTitle.Text = "";
            txtNewsDescription.Text = "";
            txtStartDate.Text = "";
            txtCloseDate.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            
            if (Session["User_ID"] != null)
            {
                objNews.Admin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            }

            objNews.NewsTitle1 = txtNewsTitle.Text;
            objNews.NewsDescription1 = txtNewsDescription.Text;
            objNews.EntryDate1= DateTime.Now.ToString("yyyy-MM-dd");
            objNews.EntryTime1 = DateTime.Now.ToShortTimeString();
            objNews.StartDate1 = ConvertDate( txtStartDate.Text );
            objNews.CloseDate1 =  ConvertDate( txtCloseDate.Text );

            objNews.Insert();
            Reset();
            Response.Write("<script language='javascript'>window.alert('News Added Successfully');window.location='NewsDetail.aspx';</script>");

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/NewsDetail.aspx");
        }


        protected void txtStartDate_TextChanged(object sender, EventArgs e)
        {
            
            if (txtStartDate.Text!="")
            {
                txtCloseDate.Text = "";
                CalendarExtender_CloseDate.StartDate = DateTime.ParseExact(txtStartDate.Text, "dd-MM-yyyy", null).AddDays(1);
            }
        }
    }
}