using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.AdminLab
{
    public partial class Request_forward : System.Web.UI.Page
    {
        BusLib.Transaction.Request objRequest = new BusLib.Transaction.Request();
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    if (Request.QueryString["Request_ID"].ToString() != "")
                    {
                        objRequest.Request_ID1 = Convert.ToInt16(Request.QueryString["Request_ID"].ToString());
                        objRequest.GetDataSet_GetViewRequestDetail();
                //        String IdProof=objRequest.Ds.Tables[0].Rows[0]["IdProof1"].ToString();
                //        String DiseaseDoc1="~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof2"].ToString();
                //        String  DiseaseDoc2="~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString();

                        ibIdProof.ImageUrl = "~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof1"].ToString();
                        ibDiseaseDoc1.ImageUrl = "~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof2"].ToString();
                       
                        if (objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString() != "")
                        {
                    //        ibDiseaseDoc2.Visible = true;
                        ibDiseaseDoc2.ImageUrl = "~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString();
                       }
                        else
                        {
                        //    ibDiseaseDoc2.Visible = false;
                            ibDiseaseDoc2.ImageUrl="";
                            ibDiseaseDoc2.AlternateText = " ";
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
                if (objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString() != "")
                {
                    ImagePath = "~/IdProof/" + objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString();
                }
                else
                {
                    ImagePath = "";
                }
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

        protected void ibDiseaseDoc1_Click(object sender, ImageClickEventArgs e)
        {
            ShowImage("DiseaseDoc1");
        }

        protected void ibDiseaseDoc2_Click(object sender, ImageClickEventArgs e)
        {
            ShowImage("DiseaseDoc2");
        }

    }
}