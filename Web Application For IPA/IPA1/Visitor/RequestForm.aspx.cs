using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace IPA1.Visitor
{
    public partial class Request1 : System.Web.UI.Page
    {
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();
        BusLib.Transaction.Request objRequest = new BusLib.Transaction.Request();

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {

                FillddlState();
                FillddlCity();
                ViewState["FileUploadText"]="";
                PnlRequestDetail.Visible = false;
                pnlTransactionID.Visible = false;
                pnlVisitor.Visible = false;
            }
        }


        void FillddlState()
        {
            objState.GetDataSet("");
            ddlState.DataSource = objState.Ds.Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "State_ID";
          //ddlState.SelectedIndex = 6;
            ddlState.DataBind();
            ddlState.SelectedIndex = 6;
        }

        void FillddlCity()
        {
            objCity.StateID1 = Convert.ToInt16(ddlState.SelectedValue);
            objCity.GetCity();
            ddlCity.DataSource = objCity.Ds.Tables[0];
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "City_ID";
            ddlCity.DataBind();
            if (objCity.Ds.Tables[0].Rows.Count > 0)
            {
                ddlCity.SelectedIndex = 0;

            }



        }


        void FillddlState1()
        {
            objState.GetDataSet("");
            vddlState.DataSource = objState.Ds.Tables[0];
            vddlState.DataTextField = "StateName";
            vddlState.DataValueField = "State_ID";
            //ddlState.SelectedIndex = 6;
            vddlState.DataBind();
            vddlState.SelectedIndex = 6;
        }

        void FillddlCity1()
        {
            objCity.StateID1 = Convert.ToInt16(ddlState.SelectedValue);
            objCity.GetCity();
            vddlCity.DataSource = objCity.Ds.Tables[0];
            vddlCity.DataTextField = "CityName";
            vddlCity.DataValueField = "City_ID";
            vddlCity.DataBind();
            if (objCity.Ds.Tables[0].Rows.Count > 0)
            {
                vddlCity.SelectedIndex = 0;

            }


            
        }

        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["User_ID"] != null)
            {
                int UserID = Convert.ToInt16(Session["User_ID"].ToString());
                if (Session["UserType"].ToString() == "Admin")
                {
                    objRequest.Admin_ID1 = UserID;
                }
                else
                {
                    objRequest.User_ID1 = UserID;
                }

            }

            objRequest.Date1 = DateTime.Now;
            objRequest.Name1 = txtName.Text;
            objRequest.Subject1 = txtSubject.Text;
            objRequest.Description1 = txtDescr.Text;
            objRequest.Address1 = txtAddress.Text;
            objRequest.Email1 = txtEmail.Text;

            objRequest.City1 = ddlCity.SelectedItem.ToString();
            objRequest.State1 = ddlState.SelectedItem.ToString();
            objRequest.PinCode1 = Convert.ToInt32(txtPinCode.Text);
            objRequest.MobileNo1 = Convert.ToInt64(txtMobileNo.Text);
            objRequest.Status1 = "Pending";

            objAdmin.WorkingPinCode1 = ddlState.SelectedItem.Text;
            objAdmin.GetWorkingPinCodeDetail();

            objRequest.WorkingAdmin_ID1 = Convert.ToInt16(objAdmin.Ds.Tables[0].Rows[0]["Admin_ID"].ToString());

            if (fuIdProof.HasFile)
            {
                string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg","JPG","JPEG","PNG","GIF","BMP"  };
                string ext = System.IO.Path.GetExtension(fuIdProof.PostedFile.FileName);
                bool isvalidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isvalidFile = true;
                        if (fuIdProof.PostedFile.ContentLength > 4194304)
                        {
                            lblcvIdProof.Text = "Please upload a file having size upto 4 MB.";
                            return;
                        }
                        
                        // fuIdProof.SaveAs(Server.MapPath("~//IdProof//") + fuIdProof.FileName);
                        SaveFile(fuIdProof.PostedFile, lblcvIdProof, "IdProof");
                        break;
                    }
                }
                if (!isvalidFile)
                {
                    lblcvIdProof.ForeColor = System.Drawing.Color.Red;
                    lblcvIdProof.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                    return;
                }
            }

            else
            {
                lblcvIdProof.Text = "Please Select a File";
                return;
            }
            if (fuDocument1.HasFile)
            {
                string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg","JPG","JPEG","PNG","GIF","BMP"  };
                string ext = System.IO.Path.GetExtension(fuDocument1.PostedFile.FileName);
                bool isvalidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isvalidFile = true;
                        if (fuDocument1.PostedFile.ContentLength > 4194304)
                        {
                            lblcvDocument1.Text = "Please upload a file having size upto 4 MB.";
                            return;
                        }
                       
                        //      fuProfilePic.SaveAs(Server.MapPath("~../ProfilePic/" + fuProfilePic.FileName));
                        //  fuDocument1.SaveAs(Server.MapPath("~//IdProof//") + fuDocument1.FileName);
                        SaveFile(fuDocument1.PostedFile, lblcvDocument1, "Document1");
                        break;
                    }
                }
                if (!isvalidFile)
                {
                    lblcvDocument1.ForeColor = System.Drawing.Color.Red;
                    lblcvDocument1.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                    return;
                }

            }
            else
            {
                lblcvDocument1.Text = "Please Select a File";
                return;
            }

            if (fuDocument2.HasFile)
            {
                string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "JPG", "JPEG", "PNG", "GIF", "BMP" };
                string ext = System.IO.Path.GetExtension(fuDocument2.PostedFile.FileName);
                bool isvalidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isvalidFile = true;
                        if (fuDocument2.PostedFile.ContentLength > 4194304)
                        {
                            lblcvDocument2.Text = "Please upload a file having size upto 4 MB.";
                            return;
                        }
                       

                        SaveFile(fuDocument2.PostedFile, lblcvDocument2, "Document2");
                        break;
                    }
                }
                if (!isvalidFile)
                {
                    lblcvDocument2.ForeColor = System.Drawing.Color.Red;
                    lblcvDocument2.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                    return;
                }
            }

            
            objRequest.Insert();

            Reset();
            string message = "Your Request sent successfully and the response will be given by email as soon as possible";
        //    mvRequestForm.ActiveViewIndex = 0;
            //string url = "ViewRequest.aspx";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            //  script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);


            //Reset();
        }



        void Reset()
        {
            txtName.Text = "";
            txtSubject.Text = "";
            txtDescr.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            FillddlState();
            FillddlCity();
            ddlState.SelectedIndex = 6;
            ddlCity.ClearSelection();
            txtPinCode.Text = "";
            txtMobileNo.Text = "";


        }



        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }



        protected void btnCancle_Click(object sender, EventArgs e)
        {
         //   mvRequestForm.ActiveViewIndex = 0;
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillddlCity();
        }

        void SaveFile(HttpPostedFile file, Label lblName, String FileType)
        {

            String savePath = "";
            String fileName = "";
            String lblName1 = "";

            if (FileType == "IdProof" )
            {
                savePath = Server.MapPath("~//IdProof//" );
            }

            if (FileType == "vIdProof")
            {
                savePath = Server.MapPath("~//IdProof//");
            }

            if (FileType == "Document1")
            {
                savePath = Server.MapPath("~//IdProof//");
            }

            if (FileType == "Document2")
            {
                savePath = Server.MapPath("~//IdProof//");
            }

           



            // Specify the path to save the uploaded file to.
            // Get the name of the file to upload.

            if (FileType == "IdProof")
            {

                fileName = fuIdProof.FileName;

            }

            if (FileType == "Document1")
            {
                fileName = fuDocument1.FileName;

            }

            if (FileType == "Document2")
            {
                fileName = fuDocument2.FileName;

            }

            if (FileType == "vIdProof")
            {
                fileName = vfuIdproof.FileName;

            }



            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            string originalfile = fileName;
            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";

            
            // Check to see if a file already exists with the
            // same name as the file to upload.
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    String[] tempfilename1 = fileName.Split('.');
                    String FileName = tempfilename1[0];
                    String FileExtension = tempfilename1[1];
                    tempfileName = FileName + counter.ToString() + ('.') + FileExtension;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }


                fileName = tempfileName;


                // Notify the user that the file name was changed.
                lblName.Text = "A file with the same name already exists." +
                    "<br />Your file was saved as " + fileName;
                
            }
            else
            {
                // Notify the user that the file was saved successfully.
                lblName.Text = "Your file was uploaded successfully";
            }

           
            // Append the name of the file to upload to the path.
            savePath += fileName;


            // Call the SaveAs method to save the uploaded
            // file to the specified directory.


            if (FileType == "vIdProof")
            {
                savePath = Server.MapPath("~//IdProof//"+fileName);
                objRequest.IdProof11 = fileName;
                vfuIdproof.SaveAs(savePath);
            }

            if (FileType == "IdProof")
            {
                savePath = Server.MapPath("~//IdProof//" + fileName);
                objRequest.IdProof11 = fileName;
                fuIdProof.SaveAs(savePath);
            }

            if (FileType == "Document1")
            {
                savePath = Server.MapPath("~//IdProof//" + fileName);
                objRequest.IdProof21 = fileName;
                fuDocument1.SaveAs(savePath);
            }

            if (FileType == "Document2")
            {
                savePath = Server.MapPath("~//IdProof//" + fileName);
                objRequest.IdProof31 = fileName;
                fuDocument2.SaveAs(savePath);
            }


        }


        void vSaveFile(HttpPostedFile file, Label lblName, String FileType)
        {

            String savePath = "";
            String fileName = "";
            String lblName1 = "";

            if (FileType == "IdProof")
            {
                savePath = Server.MapPath("~//IdProof//");
            }

            if (FileType == "vIdProof")
            {
                savePath = Server.MapPath("~//IdProof//");
            }

            if (FileType == "Document1")
            {
                savePath = Server.MapPath("~//IdProof//");
            }

            if (FileType == "Document2")
            {
                savePath = Server.MapPath("~//IdProof//");
            }

           

            // Specify the path to save the uploaded file to.
            // Get the name of the file to upload.

            if (FileType == "IdProof")
            {

                fileName = vfuIdproof.FileName;

            }

            if (FileType == "Document1")
            {
                fileName = vfuDocument1.FileName;

            }

            if (FileType == "Document2")
            {
                fileName = vfuDocument2.FileName;

            }

            if (FileType == "vIdProof")
            {
                fileName = vfuIdproof.FileName;

            }



            // Create the path and file name to check for duplicates.
            string pathToCheck = savePath + fileName;

            
            // Create a temporary file name to use for checking duplicates.
            string tempfileName = "";


            // Check to see if a file already exists with the
            // same name as the file to upload.
            if (System.IO.File.Exists(pathToCheck))
            {
                int counter = 2;
                while (System.IO.File.Exists(pathToCheck))
                {
                    // if a file with this name already exists,
                    // prefix the filename with a number.
                    String[] tempfilename1 = fileName.Split('.');
                    String FileName = tempfilename1[0];
                    String FileExtension = tempfilename1[1];
                    tempfileName = FileName + counter.ToString() + ('.') + FileExtension;
                    pathToCheck = savePath + tempfileName;
                    counter++;
                }


                fileName = tempfileName;


                // Notify the user that the file name was changed.
                lblName.Text = "A file with the same name already exists." +
                    "<br />Your file was saved as " + fileName;

            }
            else
            {
                // Notify the user that the file was saved successfully.
                lblName.Text = "Your file was uploaded successfully";
            }


            // Append the name of the file to upload to the path.
            savePath += fileName;


            // Call the SaveAs method to save the uploaded
            // file to the specified directory.


            if (FileType == "vIdProof")
            {
                savePath = Server.MapPath("~//IdProof//" + fileName);
                objRequest.IdProof11 = fileName;
                vfuIdproof.SaveAs(savePath);
            }

            if (FileType == "IdProof")
            {
                savePath = Server.MapPath("~//IdProof//" + fileName);
                objRequest.IdProof11 = fileName;
                vfuIdproof.SaveAs(savePath);
            }

            if (FileType == "Document1")
            {
                savePath = Server.MapPath("~//IdProof//" + fileName);
                objRequest.IdProof21 = fileName;
                vfuDocument1.SaveAs(savePath);
            }

            if (FileType == "Document2")
            {
                savePath = Server.MapPath("~//IdProof//" + fileName);
                objRequest.IdProof31 = fileName;
                vfuDocument2.SaveAs(savePath);
            }


        }



        

       
        protected void ImgDocument2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                String strURL = "../IdProof//" + lblImgDocument2.Text;
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("content-Disposition", "attachment;filename=\"" + Server.MapPath(strURL) + "\"");
                byte[] data = req.DownloadData(Server.MapPath(strURL));
                response.BinaryWrite(data);
                response.End();
            }
            catch (Exception ex)
            {
            }
        }

        protected void ImgDocument1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                String strURL = "../IdProof//" + lblImgDocument1.Text;
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("content-Disposition", "attachment;filename=\"" + Server.MapPath(strURL) + "\"");
                byte[] data = req.DownloadData(Server.MapPath(strURL));
                response.BinaryWrite(data);
                response.End();
            }
            catch (Exception ex)
            {
            }
        }

        protected void ImgIdProof_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

               
                String strURL = "../IdProof//" + lblImgIdProof.Text;
                WebClient req = new WebClient();
                HttpResponse response = HttpContext.Current.Response;
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.Buffer = true;
                response.AddHeader("content-Disposition", "attachment;filename=\"" + Server.MapPath(strURL) + "\"");
                byte[] data = req.DownloadData(Server.MapPath(strURL));
                response.BinaryWrite(data);
                response.End();
            }
            catch (Exception ex)
            {
            }
        }

       

        protected void btnGetInformation_Click(object sender, EventArgs e)
        {
           
            vddlState.Items.Clear();
            FillddlState1();
            vddlCity.Items.Clear();
            FillddlCity1();
          
            if (txtTransactionID.Text == "")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Enter Request Transaction_ID'); </script>");
                return;
            }
           // mvRequestForm.ActiveViewIndex = 3;

            if (txtTransactionID.Text != "")
            {
                Regex regx = new Regex(@"^\d");
                if (regx.IsMatch(txtTransactionID.Text))
                {


                   

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Invalid Transaction_ID !'); </script>");
                    return;


                }
            }
           
            objRequest.Request_Patient_ID1 = Convert.ToInt32(txtTransactionID.Text.Trim());
            objRequest.GetDataSet_GetInfoFromTransaction_ID();
            if (objRequest.Ds.Tables[0].Rows.Count > 0)
            {
                // vtxtAdminID.Text = objRequest.Ds.Tables[0].Rows[0]["Admin_ID"].ToString();
                vtxtName.Text = objRequest.Ds.Tables[0].Rows[0]["Name"].ToString();
                vtxtSubject.Text = objRequest.Ds.Tables[0].Rows[0]["Subject"].ToString();

                vtxtRequestDetail.Text = objRequest.Ds.Tables[0].Rows[0]["Description"].ToString();



                vtxtAddress.Text = objRequest.Ds.Tables[0].Rows[0]["Address"].ToString();
                vddlState.SelectedItem.Text = objRequest.Ds.Tables[0].Rows[0]["State"].ToString();

                vddlCity.SelectedItem.Text = objRequest.Ds.Tables[0].Rows[0]["City"].ToString();

                vtxtPinCode.Text = objRequest.Ds.Tables[0].Rows[0]["PinCode"].ToString();
                vtxtMobileNo.Text = objRequest.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                vtxtEmail.Text = objRequest.Ds.Tables[0].Rows[0]["Email"].ToString();


                //    txtResponse.Text = objRequest.Ds.Tables[0].Rows[0]["Response"].ToString();
                //   txtRejectionReason.Text = objRequest.Ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                //  txtRejectionReason.Enabled = false;



                ImgIdProof.ImageUrl = "~//IdProof//" + objRequest.Ds.Tables[0].Rows[0]["IdProof1"].ToString();
                lblImgIdProof.Text = objRequest.Ds.Tables[0].Rows[0]["IdProof1"].ToString();
                ImgDocument1.ImageUrl = "~//IdProof//" + objRequest.Ds.Tables[0].Rows[0]["IdProof2"].ToString();
                lblImgDocument1.Text = objRequest.Ds.Tables[0].Rows[0]["IdProof2"].ToString();
                if (objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString() != "")
                {
                    ImgDocument2.ImageUrl = "~//IdProof//" + objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString();
                    lblImgDocument2.Text = objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString();
                    ImgDocument2.Visible = true;
                }
                else
                {
                    ImgDocument2.ImageUrl = "";
                    ImgDocument2.AlternateText = "";
                    lblImgDocument2.Text = "No Document";
                    ImgDocument2.Visible = false;
                }

            }

            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Invalid Transaction_ID !'); </script>");
                
                return;
            }

            PnlRequestDetail.Visible = true;
            pnlVisitor.Visible = false;
            pnlTransactionID.Visible = true;
            

        }

        

        protected void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            pnlVisitor.Visible = false;
            pnlTransactionID.Visible = true;
            PnlRequestDetail.Visible = false;

        }

        protected void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            pnlVisitor.Visible = true;
            PnlRequestDetail.Visible = false;
            pnlTransactionID.Visible = false;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            if (vfuIdproof.HasFile)
            {
                string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "JPG", "JPEG", "PNG", "GIF", "BMP" };
                string ext = System.IO.Path.GetExtension(vfuIdproof.PostedFile.FileName);
                bool isvalidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isvalidFile = true;
                        if (vfuIdproof.PostedFile.ContentLength > 4194304)
                        {
                            Label1.Text = "Please upload a file having size upto 4 MB.";
                            return;
                        }
                        objRequest.IdProof11 = vfuIdproof.FileName.Trim();
                        // fuIdProof.SaveAs(Server.MapPath("~//IdProof//") + fuIdProof.FileName);
                        SaveFile(vfuIdproof.PostedFile, Label1, "vIdProof");
                        ImgIdProof.ImageUrl = Server.MapPath("~//IdProof//") + vfuIdproof.FileName;
                        break;
                    }
                }
                if (!isvalidFile)
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                    return;
                }
            }

            else
            {
                Label1.Text = "Please Select a File";
                return;
            }

            

        }

        protected void vbtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Visitor/RequestForm.aspx");
        }

        protected void vbtnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void vbtnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["User_ID"] != null)
            {
                int UserID = Convert.ToInt16(Session["User_ID"].ToString());
                if (Session["UserType"].ToString() == "Admin")
                {
                    objRequest.Admin_ID1 = UserID;
                }
                else
                {
                    objRequest.User_ID1 = UserID;
                }

            }

            objRequest.Date1 = DateTime.Now;
            objRequest.Request_Patient_ID1=Convert.ToInt32(txtTransactionID.Text);
            objRequest.Name1 = vtxtName.Text;
            objRequest.Subject1 = vtxtSubject.Text;
            objRequest.Description1 = vtxtRequestDetail.Text;
            objRequest.Address1 = vtxtAddress.Text;
            objRequest.Email1 = vtxtEmail.Text;

            objRequest.City1 = vddlCity.SelectedItem.ToString();
            objRequest.State1 = vddlState.SelectedItem.ToString();
            objRequest.PinCode1 = Convert.ToInt32(vtxtPinCode.Text);
            objRequest.MobileNo1 = Convert.ToInt64(vtxtMobileNo.Text);
            objRequest.Status1 = "Pending";

            objAdmin.WorkingPinCode1 = vddlState.SelectedItem.Text;
            objAdmin.GetWorkingPinCodeDetail();

            objRequest.WorkingAdmin_ID1 = Convert.ToInt16(objAdmin.Ds.Tables[0].Rows[0]["Admin_ID"].ToString());

            if (vfuIdproof.HasFile)
            {
                string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg","JPG","JPEG","PNG","GIF","BMP"  };
                string ext = System.IO.Path.GetExtension(vfuIdproof.PostedFile.FileName);
                bool isvalidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isvalidFile = true;
                        if (vfuIdproof.PostedFile.ContentLength > 4194304)
                        {
                            Label1.Text = "Please upload a file having size upto 4 MB.";
                            return;
                        }
                        
                        // fuIdProof.SaveAs(Server.MapPath("~//IdProof//") + fuIdProof.FileName);
                        vSaveFile(vfuIdproof.PostedFile, Label1, "IdProof");
                        break;
                    }
                }
                if (!isvalidFile)
                {
                    Label1.ForeColor = System.Drawing.Color.Red;
                    Label1.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                    return;
                }
            }

            else
            {
                objRequest.IdProof11 = lblImgIdProof.Text;
            }
            if (vfuDocument1.HasFile)
            {
                string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg","JPG","JPEG","PNG","GIF","BMP"  };
                string ext = System.IO.Path.GetExtension(vfuDocument1.PostedFile.FileName);
                bool isvalidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isvalidFile = true;
                        if (vfuDocument1.PostedFile.ContentLength > 4194304)
                        {
                            Label4.Text = "Please upload a file having size upto 4 MB.";
                            return;
                        }
                        
                        //      fuProfilePic.SaveAs(Server.MapPath("~../ProfilePic/" + fuProfilePic.FileName));
                        //  fuDocument1.SaveAs(Server.MapPath("~//IdProof//") + fuDocument1.FileName);
                        vSaveFile(vfuDocument1.PostedFile, Label4, "Document1");
                        break;
                    }
                }
                if (!isvalidFile)
                {
                   Label4.ForeColor = System.Drawing.Color.Red;
                   Label4.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                    return;
                }

            }
            else
            {
                objRequest.IdProof21 = lblImgDocument1.Text;
            }

            if (vfuDocument2.HasFile)
            {
                string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg","JPG","JPEG","PNG","GIF","BMP" };
                string ext = System.IO.Path.GetExtension(vfuDocument2.PostedFile.FileName);
                bool isvalidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isvalidFile = true;
                        if (vfuDocument2.PostedFile.ContentLength > 4194304)
                        {
                            Label5.Text = "Please upload a file having size upto 4 MB.";
                            return;
                        }
                       
                        
                        vSaveFile(vfuDocument2.PostedFile, Label5, "Document2");
                        break;
                    }
                }
                if (!isvalidFile)
                {
                    Label5.ForeColor = System.Drawing.Color.Red;
                    Label5.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                    return;
                }
            }

            else
            {
                if (lblImgDocument2.Text != "No Document")
                {
                    objRequest.IdProof31 = lblImgDocument2.Text;
                }
                else
                {
                    objRequest.IdProof31 = "";
                }
            }


            objRequest.IsHold1 = false;
            objRequest.UpdateIsHold();

            objRequest.TUpdate();

            Reset();
            string message = "Your Request sent successfully and the response will be given by email as soon as possible";
        //    mvRequestForm.ActiveViewIndex = 0;
            //string url = "ViewRequest.aspx";
            string script = "window.onload = function(){ alert('";
            script += message;
            script += "');";
            script += "window.location = '";
            //  script += url;
            script += "'; }";
            ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);


            //Reset();
        }


        }


    }
