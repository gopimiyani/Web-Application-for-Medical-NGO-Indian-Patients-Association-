﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.AdminLab
{
    public partial class AdminProfile : System.Web.UI.Page
    {
        BusLib.Master.Admin objAdmin= new BusLib.Master.Admin();
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                FillddlState();
                FillddlCity();
                AdminDetailDisplay();

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

        void AdminDetailDisplay()
        {
    
                objAdmin.Admin_ID1 = Convert.ToInt16(Session["User_ID"]);
                objAdmin.GetDataSet_GetAdminDetail();
                ImgProfilePic.ImageUrl = "~//ProfilePic//" + objAdmin.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                txtFirstName.Text = objAdmin.Ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text=objAdmin.Ds.Tables[0].Rows[0]["LastName"].ToString();
                txtUserName.Text = objAdmin.Ds.Tables[0].Rows[0]["UserName"].ToString();
                txtEmail.Text = objAdmin.Ds.Tables[0].Rows[0]["Email"].ToString();
                // txtPassword.Text = objUserRegister.Ds.Tables[0].Rows[0]["Password"].ToString();
                //txtConfirmPassword.Text = objUserRegister.Ds.Tables[0].Rows[0]["ConfirmPassword"].ToString();
                txtAddress.Text = objAdmin.Ds.Tables[0].Rows[0]["Address"].ToString();
                
                txtPinCode.Text = objAdmin.Ds.Tables[0].Rows[0]["PinCode"].ToString();
                txtMobileNo.Text = objAdmin.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                ddlState.SelectedItem.Text = objAdmin.Ds.Tables[0].Rows[0]["State"].ToString();
                ddlCity.SelectedItem.Text = objAdmin.Ds.Tables[0].Rows[0]["City"].ToString();
                txtPinCode.Text = objAdmin.Ds.Tables[0].Rows[0]["PinCode"].ToString();
                txtMobileNo.Text = objAdmin.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                txtIpaddress.Text = objAdmin.Ds.Tables[0].Rows[0]["IP"].ToString();



          }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            objAdmin.Admin_ID1 = Convert.ToInt16(Session["User_ID"]);
            objAdmin.FirstName1 = txtFirstName.Text;
            objAdmin.LastName1 = txtLastName.Text;

            objAdmin.Address1 = txtAddress.Text;
            objAdmin.City1 = ddlCity.SelectedItem.Text;
            objAdmin.State1 = ddlState.SelectedItem.Text;
            objAdmin.PinCode1 = Convert.ToInt32(txtPinCode.Text);
            objAdmin.MobileNo1 = Convert.ToInt64(txtMobileNo.Text);
            objAdmin.UserName1 = txtUserName.Text;
            objAdmin.Email1 = txtEmail.Text;
            objAdmin.IP1 = txtIpaddress.Text;
            if (fuProfilePic.HasFile)
            {
                string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "JPG", "JPEG", "PNG", "GIF", "BMP" };
                string ext = System.IO.Path.GetExtension(fuProfilePic.PostedFile.FileName);
                bool isvalidFile = false;
                for (int i = 0; i < validFileTypes.Length; i++)
                {
                    if (ext == "." + validFileTypes[i])
                    {
                        isvalidFile = true;
                        if (fuProfilePic.PostedFile.ContentLength > 4194304)
                        {
                            lblProfilePic.Text = "Please upload a file having size upto 4 MB.";
                            return;
                        }

                        //      fuProfilePic.SaveAs(Server.MapPath("~../ProfilePic/" + fuProfilePic.FileName));
                        // fuProfilePic.SaveAs(Server.MapPath("~//ProfilePic//") + fuProfilePic.FileName);
                        SaveFile(fuProfilePic.PostedFile, lblProfilePic, "ProfilePic");

                        break;
                    }
                }
                if (!isvalidFile)
                {
                    lblProfilePic.ForeColor = System.Drawing.Color.Red;
                    lblProfilePic.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                    return;
                }


            }
            else
            {
                if (Session["User_ID"] != null)
                {
                    objAdmin.Admin_ID1= Convert.ToInt16(Session["User_ID"].ToString());
                    objAdmin.GetDataset();
                    objAdmin.ProfilePic1 = objAdmin.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                }
            }

            

            objAdmin.Update();
            Response.Write("<script language='javascript'>window.alert('Updated Sucessfully');window.location='Dashboard1.aspx';</script>");
        }

        void SaveFile(HttpPostedFile file, Label lblName, String FileType)
        {

            String savePath = "";
            String fileName = "";
            savePath = Server.MapPath("~//ProfilePic//");
            
            // Specify the path to save the uploaded file to.
            // Get the name of the file to upload.

           


            if (FileType == "ProfilePic")
            {
                fileName = fuProfilePic.FileName;

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
                lblName.Text = "Your file was uploaded successfully.";
            }


            // Append the name of the file to upload to the path.
            savePath += fileName;


            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            if (FileType == "ProfilePic")
            {
                savePath = Server.MapPath("~//ProfilePic//" + fileName);
                objAdmin.ProfilePic1 = fileName;
                fuProfilePic.SaveAs(savePath);
            }

            
        }





        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillddlCity();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/Dashboard1.aspx");
        }


        }
    }
