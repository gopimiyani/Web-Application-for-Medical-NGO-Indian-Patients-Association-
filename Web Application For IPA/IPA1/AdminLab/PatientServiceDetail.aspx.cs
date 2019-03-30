using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.AdminLab
{
    public partial class PatientServiceDetail : System.Web.UI.Page
    {
        BusLib.Transaction.Request objRequest = new BusLib.Transaction.Request();
        String Request_ID="";
        String User_ID = "";


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    ViewState["User_ID"] = "";
                    ViewState["Request_ID"] = "";
                    string strReq = "";
                    strReq = Request.RawUrl;
                    strReq = strReq.Substring(strReq.IndexOf('?') + 1);

                    if (!strReq.Equals(""))
                    {
                        strReq = DecryptQueryString(strReq);

                        //Parse the value... this is done is very raw format.. you can add loops or so to get the values out of the query string...
                        string[] arrMsgs = strReq.Split('&');
                        string[] arrIndMsg;

                        arrIndMsg = arrMsgs[0].Split('=');
                        Request_ID = arrIndMsg[1].ToString().Trim();
                        ViewState["Request_ID"] = Request_ID;

                        arrIndMsg = arrMsgs[1].Split('='); //
                        User_ID = arrIndMsg[1].ToString().Trim();

                        if (Request_ID!= "")
                        {
                            objRequest.Request_ID1 = Convert.ToInt16(Request_ID);
                            objRequest.GetDataSet_GetViewRequestDetail();
                            ibIdProof.ImageUrl = "~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof1"].ToString();
                            ibDocument1.ImageUrl = "~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof2"].ToString();
                            ibDocument2.ImageUrl = "~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString();

                        }
                    }
                }
            }
        }

        public void ShowImage(String ImageType)
        {
            String ImagePath = "";
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["Request_ID"].ToString() != "")
                {
                    objRequest.Request_ID1 = Convert.ToInt16(Request.QueryString["Request_ID"].ToString());

                    objRequest.GetDataSet_GetViewRequestDetail();
                }
            }
            if (ImageType=="IdProof")
            {
                ImagePath = "~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof1"].ToString();
             
            }

            else if (ImageType == "DiseaseDoc1")
            {
                ImagePath = "~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof2"].ToString();
            }
            else if (ImageType == "DiseaseDoc2")
            {
              
                    ImagePath = "~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString();
              
            }
            else
            {
                ImagePath = "";
            }
            Response.Redirect(ImagePath);
        }

        protected void ibIdProof_Click(object sender, ImageClickEventArgs e)
        {
            ShowImage("IdProof");
        }

       

        protected void ibDocument1_Click(object sender, ImageClickEventArgs e)
        {
            ShowImage("DiseaseDoc1");
        }

        protected void ibDocument2_Click(object sender, ImageClickEventArgs e)
        {
            ShowImage("DiseaseDoc2");
        }

        protected string DecryptQueryString(string strQueryString)
        {
            BusLib.Common.EncryptDecryptQueryString objEDQueryString = new BusLib.Common.EncryptDecryptQueryString();
            return objEDQueryString.Decrypt(strQueryString, "r0b1nr0y");
        }

    }
}