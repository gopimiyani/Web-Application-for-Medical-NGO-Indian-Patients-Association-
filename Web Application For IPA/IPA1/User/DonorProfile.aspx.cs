using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.User
{
    public partial class DonorProfile : System.Web.UI.Page
    {
        BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserType"] != null)
                {
                    if (Session["UserType"].ToString() != "Donor")
                    {
                        Response.Redirect("~/Visitor/Login.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Visitor/Login.aspx");
                }
                FillddlState();
                FillddlCity();
                DonorDetailDisplay();

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

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillddlCity();
        }

        void DonorDetailDisplay()
        {
            if (Session["User_ID"] != null)
            {
                objRegistration.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objRegistration.GetDataSet_GetDonorProfile();
                //  txtUserID.Text = objVolunteer.Ds.Tables[0].Rows[0]["User_ID"].ToString();
                ImgProfilePic.ImageUrl = "~//ProfilePic//" + objRegistration.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();

                txtFirstName.Text = objRegistration.Ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = objRegistration.Ds.Tables[0].Rows[0]["LastName"].ToString();

                txtUserName.Text = objRegistration.Ds.Tables[0].Rows[0]["UserName"].ToString();
                txtEmail.Text = objRegistration.Ds.Tables[0].Rows[0]["Email"].ToString();
                // txtPassword.Text = objUserRegister.Ds.Tables[0].Rows[0]["Password"].ToString();
                //txtConfirmPassword.Text = objUserRegister.Ds.Tables[0].Rows[0]["ConfirmPassword"].ToString();
                txtAddress.Text = objRegistration.Ds.Tables[0].Rows[0]["Address"].ToString();
                ddlState.SelectedItem.Text = objRegistration.Ds.Tables[0].Rows[0]["State"].ToString();
                ddlCity.SelectedItem.Text = objRegistration.Ds.Tables[0].Rows[0]["City"].ToString();
                txtPinCode.Text = objRegistration.Ds.Tables[0].Rows[0]["PinCode"].ToString();
                txtMobileNo.Text = objRegistration.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                ddlBloodGroup.SelectedValue = objRegistration.Ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                VtxtDOB.Text = objRegistration.Ds.Tables[0].Rows[0]["BirthDate"].ToString();
            }

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
                objRegistration.ProfilePic1 = fileName;
                fuProfilePic.SaveAs(savePath);
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
            objRegistration.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            objRegistration.FirstName1 = txtFirstName.Text;
            objRegistration.LastName1 = txtLastName.Text;
            objRegistration.UserName1 = txtUserName.Text;
            objRegistration.Email1 = txtEmail.Text;
            objRegistration.Address1 = txtAddress.Text;
            objRegistration.State1 = ddlState.SelectedItem.Text;
            objRegistration.City1 = ddlCity.SelectedItem.Text;
            objRegistration.Prefix1 = "Do";
            objRegistration.StackHolder1 = "Donor";
            objRegistration.PinCode1 = Convert.ToInt32(txtPinCode.Text);
            objRegistration.MobileNo1 = Convert.ToInt64(txtMobileNo.Text);
            objRegistration.BloodGroup1 = ddlBloodGroup.SelectedValue;
            objRegistration.BirthDate1 = ConvertDate(VtxtDOB.Text);
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
                    objRegistration.User_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                    objRegistration.GetDataSet_GetDonorProfile();
                    objRegistration.ProfilePic1 = objRegistration.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                }
            }

            objRegistration.Update();
            

            
            Response.Write("<script language='javascript'>window.alert('Updated Sucessfully');window.location='Home.aspx';</script>");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/User/Home.aspx");
        }

    }
}
