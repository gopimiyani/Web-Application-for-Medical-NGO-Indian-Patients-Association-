using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.VolunteerLab
{
    public partial class PatientRequestForm : System.Web.UI.Page
    {
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();
        BusLib.Transaction.Request objRequest = new BusLib.Transaction.Request();

        bool PFlg = true;
        bool MFlg = true;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillddlState();
                FillddlCity();
            }
        }
        void FillddlState()
        {
            objState.GetDataSet("");
            ddlState.DataSource = objState.Ds.Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "State_ID";
            ddlState.SelectedIndex = 6;
            ddlState.DataBind();
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


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (PFlg && MFlg)
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


                //    objRequest.Admin_ID1 = 101;
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

                objRequest.NotificationFlag1 = false;
                if (fuDocument1.HasFile)
                {
                    string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "JPG", "JPEG", "PNG", "GIF", "BMP" };
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
                string message = "Your Request Sent Successfully";
                string url = "ViewRequest.aspx";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);


                //Reset();
            }

        }

        void SaveFile(HttpPostedFile file, Label lblName, String FileType)
        {

            String savePath = "";
            String fileName = "";
            

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

            
            if (FileType == "Document1")
            {
                fileName = fuDocument1.FileName;

            }

            if (FileType == "Document2")
            {
                fileName = fuDocument2.FileName;

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

        protected void cvPinCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 6)
            {

                args.IsValid = true;
                PFlg = true;

            }
            else
            {

                args.IsValid = false;
                PFlg = false;

            }
        }

        protected void cvMobileNo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 10)
            {

                args.IsValid = true;
                MFlg = true;
            }
            else
            {

                args.IsValid = false;
                MFlg = false;
            }

        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/ViewRequest.aspx");
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillddlCity();
        }

       


    }
}