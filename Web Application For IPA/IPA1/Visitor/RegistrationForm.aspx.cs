using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.Visitor
{
    public partial class RegistrationForm1 : System.Web.UI.Page
    {
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        BusLib.Common.Registration objRegister = new BusLib.Common.Registration();
        BusLib.Transaction.Login objLogin = new BusLib.Transaction.Login();
        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                CalendarExtender_VBirthDate.StartDate = DateTime.Now.AddYears(-80);
                CalendarExtender_VBirthDate.EndDate = DateTime.Now.AddYears(-20);

                CalendarExtender_DonorBirthDate.StartDate = DateTime.Now.AddYears(-100);
                CalendarExtender_DonorBirthDate.EndDate = DateTime.Now.AddYears(-16);


                BindControls();
                FillddlState();
                FillddlCity();
                FillddlSH();

            }
        }
        void BindControls()
        {
            MvRegister.ActiveViewIndex = -1;

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

        private string ConvertDate(string Date)
        {
            string Rdate = "";
            if (Date != "")
            {

                Rdate = Date.Substring(6, 4) + "-" + Date.Substring(3, 2) + "-" + Date.Substring(0, 2);
            }
            return Rdate;
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

        void FillddlSH()
        {
            objSH.GetDataSet("");
            ddlselecttype.AppendDataBoundItems = true;
            ddlselecttype.Items.Add(new ListItem("Select User Type ", "---------- Select User Type ----------"));
            // objSH.Ds.Tables[0].DefaultView.Sort = "Name";
            ddlselecttype.DataSource = objSH.Ds.Tables[0];
            ddlselecttype.DataTextField = "Name";
            ddlselecttype.DataValueField = "StakeHolder_ID";
            //  ddlselecttype.SelectedIndex = 0;
            //ddlselecttype.SelectedItem.Text = "Volunteer";
            ddlselecttype.DataBind();
            ddlselecttype.Items.Remove(new ListItem("NGO", "8"));


        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            objRegister.Name1 = txtFirstName.Text.Trim();
            objRegister.LastName1 = txtLastName.Text.Trim();
            objRegister.Address1 = txtAddress.Text.Trim();
            objRegister.City1 = ddlCity.SelectedItem.ToString().Trim();
            objRegister.State1 = ddlState.SelectedItem.ToString().Trim();
            objRegister.PinCode1 = Convert.ToInt32(txtPinCode.Text);
            objRegister.MobileNo1 = Convert.ToInt64(txtMobileNo.Text);
            objRegister.NotificationFlag1 = false;

            objRegister.UserName1 = txtUserName.Text.Trim();
            objRegister.GetDataSet_GetUserName();
           
            if (objRegister.Ds.Tables[0].Rows.Count > 0)
            {
                lblcvUserName.Text = "Username already exist";
                return;
            }
            else
            {
                lblcvUserName.Text = "";
                objRegister.UserName1 = txtUserName.Text.Trim();

            }
            
            objRegister.Email1 = txtEmail.Text;
            objRegister.GetDataSet_GetEmail();
            if (objRegister.Ds.Tables[0].Rows.Count > 0)
            {
                lblcvEmail.Text = "Email already exist";
                return;
            }
            else
            {
                lblcvEmail.Text = "";
                objRegister.Email1 = txtEmail.Text.Trim();

            }

           
            //  objRegister.Pwd1 = txtPassword.Text.Trim();

            objRegister.Pwd1 = objLogin.ENCODE_DECODE(txtPassword.Text.Trim(), "E");


            String[] StackHolder = lblRegisterYourSelf.Text.Split(' ');
            String SelectedStackHolder = StackHolder[3];
            ddlselecttype.SelectedItem.Text = SelectedStackHolder;

            objRegister.StackHolder1 = ddlselecttype.SelectedItem.Text.Trim();


            objRegister.Prefix1 = ddlselecttype.SelectedItem.Text.Trim();
            objRegister.JoinDate1 = DateTime.Now;
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
                            lblProfilePicture.Text = "Please upload a file having size upto 4 MB.";
                            return;
                        }
                        
                        //      fuProfilePic.SaveAs(Server.MapPath("~../ProfilePic/" + fuProfilePic.FileName));

                        SaveFile(fuProfilePic.PostedFile, lblProfilePicture, "ProfilePic");

                        //fuProfilePic.SaveAs(Server.MapPath("~//ProfilePic//") + fuProfilePic.FileName);

                        break;
                    }
                }
                if (!isvalidFile)
                {
                    lblProfilePicture.ForeColor = System.Drawing.Color.Red;
                    lblProfilePicture.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                    return;
                }


            }


            else
            {
                objRegister.ProfilePic1 = "default1.png";
            }

            if (ddlselecttype.SelectedItem.ToString() == "Volunteer")
            {
                if (!IsPostBack)
                {
                    VtxtDOB.Text = "12-12-1975";
                }

                if (VfuIdProof.HasFile)
                {

                    objRegister.Status1 = "Pending";
                    string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "JPG", "JPEG", "PNG", "GIF", "BMP" };
                    string ext = System.IO.Path.GetExtension(VfuIdProof.PostedFile.FileName);
                    bool isvalidFile = false;
                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (ext == "." + validFileTypes[i])
                        {
                            isvalidFile = true;
                            if (VfuIdProof.PostedFile.ContentLength > 4194304)
                            {
                                VlblcvIdProof.Text = "Please upload a file having size upto 4 MB.";
                                return;
                            }
                            
                          //  SaveFile(fuProfilePic.PostedFile, VlblcvIdProof, "IdProof");
                            //VfuIdProof.SaveAs(Server.MapPath("~//IdProof//" + VfuIdProof.FileName));
                            SaveFile(VfuIdProof.PostedFile, VlblcvIdProof, "VIdProof");
                            break;
                        }
                    }
                    if (!isvalidFile)
                    {
                        VlblcvIdProof.ForeColor = System.Drawing.Color.Red;
                        VlblcvIdProof.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                        return;
                    }
                }
                else
                {
                    VlblcvIdProof.Text = "Required";
                    return;
                }
                // ConvertDate(VtxtDOB.Text);
                // objRegister.BirthDate1 = Convert.ToDateTime(ConvertDate(VtxtDOB.Text));
                //  objRegister.Status1 = "Approved";
                objRegister.BirthDate1 = ConvertDate(VtxtDOB.Text);
                objRegister.BloodGroup1 = VddlBloodGroup.SelectedValue;

            }
            else if (ddlselecttype.SelectedItem.ToString() == "Donor")
            {
                if (!IsPostBack)
                {
                    DtxtDOB.Text = "12-12-1975";
                }
                objRegister.Status1 = "Approved";
                objRegister.BirthDate1 = ConvertDate(DtxtDOB.Text);
                objRegister.BloodGroup1 = DddlBloodGroup.SelectedValue;
            }
            else if (ddlselecttype.SelectedItem.ToString() == "Hospital")
            {
                if (HfuIdProof.HasFile)
                {
                    //SaveFile(HfuIdProof.PostedFile, lblcvHfuIdProof, "IdProof");
                    objRegister.Status1 = "Pending";
                    string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "JPG", "JPEG", "PNG", "GIF", "BMP" };
                    string ext = System.IO.Path.GetExtension(HfuIdProof.PostedFile.FileName);
                    bool isvalidFile = false;
                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (ext == "." + validFileTypes[i])
                        {
                            isvalidFile = true;
                            if (HfuIdProof.PostedFile.ContentLength > 4194304)
                            {
                                lblcvHfuIdProof.Text = "Please upload a file having size upto 4 MB.";
                                return;
                            }
                           
                            SaveFile(HfuIdProof.PostedFile, lblcvHfuIdProof, "HIdProof");
                            // HfuIdProof.SaveAs(Server.MapPath("~//IdProof//" + HfuIdProof.FileName));

                            break;
                        }
                    }
                    if (!isvalidFile)
                    {
                        lblcvHfuIdProof.ForeColor = System.Drawing.Color.Red;
                        lblcvHfuIdProof.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                        return;
                    }
                }
                else
                {
                    lblcvHfuIdProof.Text = "Required";
                    return;
                }
                objRegister.Website1 = HtxtWebsite.Text.Trim();
                objRegister.ContactPerson1 = HtxtContactPerson.Text.Trim();
            }
            else if (ddlselecttype.SelectedItem.ToString() == "BloodBank")
            {
                if (BfuIdProof.HasFile)
                {
                    //SaveFile(BfuIdProof.PostedFile, lblcvBIdProof, "IdProof");
                    objRegister.Status1 = "Pending";
                    string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "JPG", "JPEG", "PNG", "GIF", "BMP" };
                    string ext = System.IO.Path.GetExtension(BfuIdProof.PostedFile.FileName);
                    bool isvalidFile = false;
                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (ext == "." + validFileTypes[i])
                        {
                            isvalidFile = true;
                            if (BfuIdProof.PostedFile.ContentLength > 4194304)
                            {
                                lblcvBIdProof.Text = "Please upload a file having size upto 4 MB.";
                                return;
                            }
                            
                            // BfuIdProof.SaveAs(Server.MapPath("~//IdProof//" + BfuIdProof.FileName));
                            SaveFile(BfuIdProof.PostedFile, lblcvBIdProof, "BIdProof");
                            break;
                        }
                    }
                    if (!isvalidFile)
                    {
                        lblcvBIdProof.ForeColor = System.Drawing.Color.Red;
                        lblcvBIdProof.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                        return;
                    }


                }
                else
                {

                    lblcvBIdProof.Text = "Required";
                    return;
                }
                objRegister.Website1 = BtxtWebsite.Text.Trim();
                objRegister.ContactPerson1 = BtxtContactPerson.Text.Trim();
            }
            else if (ddlselecttype.SelectedItem.ToString() == "PharmaCompany")
            {
                if (PfuIdProof.HasFile)
                {
                    //SaveFile(PfuIdProof.PostedFile, lblcvPfuIdProof, "IdProof");
                    objRegister.Status1 = "Pending";
                    string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "JPG", "JPEG", "PNG", "GIF", "BMP" };
                    string ext = System.IO.Path.GetExtension(PfuIdProof.PostedFile.FileName);
                    bool isvalidFile = false;
                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (ext == "." + validFileTypes[i])
                        {
                            isvalidFile = true;
                            if (PfuIdProof.PostedFile.ContentLength > 4194304)
                            {
                                lblcvPfuIdProof.Text = "Please upload a file having size upto 4 MB.";
                                return;
                            }
                            
                            // PfuIdProof.SaveAs(Server.MapPath("~//IdProof//" + PfuIdProof.FileName));
                            SaveFile(PfuIdProof.PostedFile, lblcvPfuIdProof, "PIdProof");
                            break;
                        }
                    }
                    if (!isvalidFile)
                    {
                        lblcvPfuIdProof.ForeColor = System.Drawing.Color.Red;
                        lblcvPfuIdProof.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                        return;
                    }


                }
                else
                {
                    lblcvPfuIdProof.Text = "Required";
                    return;
                }
                objRegister.Website1 = PtxtWebsite.Text.Trim();
                objRegister.ContactPerson1 = PtxtContactPerson.Text.Trim();
            }
            else if (ddlselecttype.SelectedItem.ToString() == "Doctor")
            {
                if (DfuIdProof.HasFile)
                {
                   // SaveFile(DfuIdProof.PostedFile, lblcvDfuIdProof, "IdProof");
                    objRegister.Status1 = "Pending";
                    string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg", "JPG", "JPEG", "PNG", "GIF", "BMP" };
                    string ext = System.IO.Path.GetExtension(DfuIdProof.PostedFile.FileName);
                    bool isvalidFile = false;
                    for (int i = 0; i < validFileTypes.Length; i++)
                    {
                        if (ext == "." + validFileTypes[i])
                        {
                            isvalidFile = true;
                            if (DfuIdProof.PostedFile.ContentLength > 4194304)
                            {
                                lblcvDfuIdProof.Text = "Please upload a file having size upto 4 MB.";
                                return;
                            }
                            
                            //DfuIdProof.SaveAs(Server.MapPath("~//IdProof//" + DfuIdProof.FileName));
                            SaveFile(DfuIdProof.PostedFile, lblcvDfuIdProof, "DIdProof");
                            break;
                        }
                    }
                    if (!isvalidFile)
                    {
                        lblcvDfuIdProof.ForeColor = System.Drawing.Color.Red;
                        lblcvDfuIdProof.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
                        return;
                    }


                }
                else
                {
                    lblcvDfuIdProof.Text = "Required";
                    return;
                }
                objRegister.Degree1 = DotxtDegree.Text.Trim();
                objRegister.Disease1 = DotxtDisease.Text.Trim();
            }
            else if (ddlselecttype.SelectedItem.ToString() == "NGO")
            {
                objRegister.Purpose1 = NtxtPurpose.Text.Trim();
                objRegister.Status1 = "Approved";
                objRegister.Website1 = NtxtWebsite.Text.Trim();
                objRegister.Mission1 = NtxtMission.Text.Trim();
            }

            objAdmin.WorkingPinCode1 = ddlState.SelectedItem.Text;
            objAdmin.GetWorkingPinCodeDetail();
            objRegister.WorkingAdmin_ID1 = Convert.ToInt16(objAdmin.Ds.Tables[0].Rows[0]["Admin_ID"].ToString());

            objRegister.Insert();
            if (ddlselecttype.SelectedItem.ToString() != "Donor")
            {


                string message = "Your registration detail sent successfully. You will be notified about the approval of registration by email and you can login after approving by IPA";
                string url = "Login.aspx";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                Reset();
            }

            else
            {
                string message = "Your Regisration is done Successfully,Now you can login to the system ";
                string url = "Login.aspx";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "');";
                script += "window.location = '";
                script += url;
                script += "'; }";
                ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
                Reset();


            }
        }


        protected void ddlselecttype_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlselecttype.SelectedItem.Text == "Volunteer")
            {
                MvRegister.ActiveViewIndex = 0;
                Reset();

            }
            else if (ddlselecttype.SelectedItem.Text == "Donor")
            {
                MvRegister.ActiveViewIndex = 1;
                Reset();

            }

            else if (ddlselecttype.SelectedItem.Text == "Hospital")
            {
                MvRegister.ActiveViewIndex = 2;
                Reset();
            }

            else if (ddlselecttype.SelectedItem.Text == "BloodBank")
            {
                MvRegister.ActiveViewIndex = 3;
                Reset();

            }

            else if (ddlselecttype.SelectedItem.Text == "PharmaCompany")
            {
                MvRegister.ActiveViewIndex = 4;
                Reset();

            }

            else if (ddlselecttype.SelectedItem.Text == "Doctor")
            {
                MvRegister.ActiveViewIndex = 5;
                Reset();

            }

            else if (ddlselecttype.SelectedItem.Text == "NGO")
            {
                MvRegister.ActiveViewIndex = 6;
                Reset();

            }
            else
            {
                MvRegister.ActiveViewIndex = 7;
                Reset();

            }
            ddlselecttype.Focus();
        }

        void Reset()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtEmail.Text = "";
            txtPinCode.Text = "";
            txtAddress.Text = "";
            txtMobileNo.Text = "";
            VtxtDOB.Text = "";
            VddlBloodGroup.ClearSelection();
            DtxtDOB.Text = "";
            DddlBloodGroup.ClearSelection();
            HtxtWebsite.Text = "";
            HtxtContactPerson.Text = "";
            HfuIdProof.ID = null;
            PtxtContactPerson.Text = "";
            PfuIdProof.ID = null;
            PtxtWebsite.Text = "";
            BtxtContactPerson.Text = "";
            BfuIdProof.ID = null;
            BtxtWebsite.Text = "";
            NtxtMission.Text = "";
            NtxtPurpose.Text = "";
            NtxtWebsite.Text = "";
            lblcvBIdProof.Text = "";
            lblcvDfuIdProof.Text = "";
            lblcvHfuIdProof.Text = "";
            lblcvPfuIdProof.Text = "";
            lblcvUserName.Text = "";

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

            Reset();
        }


        //protected void cvddlselecttype_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    if (ddlselecttype.Text == "--Select User Type--")
        //    {
        //        cvddlselecttype.ErrorMessage = "Required";

        //    }

        //    else
        //    {
        //        cvddlselecttype.ErrorMessage = "";
        //    }
        //}






        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillddlCity();
        }




        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            objRegister.UserName1 = txtUserName.Text;
            objRegister.GetDataSet_GetUserName();
            if (objRegister.Ds.Tables[0].Rows.Count > 0)
            {
                lblcvUserName.Visible = true;
                lblcvUserName.Text = "UserName already exist";
                return;
            }
            else
            {
                lblcvUserName.Text = "";
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

            //Response.Redirect("~/CommonUser/Home.htm");
            PStakeholder.Visible = true;
            PRegister.Visible = false;

        }

        protected void ddlselecttype_TextChanged(object sender, EventArgs e)
        {
            ddlselecttype.Focus();
        }


        void SaveFile(HttpPostedFile file, Label lblName, String FileType)
        {

            String savePath = "";
            String fileName = "";

            if (FileType == "VIdProof" || FileType == "PIdProof" || FileType == "HIdProof" || FileType == "BIdProof" || FileType == "DIdProof")
            {
                savePath = Server.MapPath("~//IdProof//");
            }
          
            else
            {
                savePath = Server.MapPath("~//ProfilePic//");
            }
            // Specify the path to save the uploaded file to.
            // Get the name of the file to upload.

            if (FileType == "PIdProof")
            {
                
                    fileName = PfuIdProof.FileName;
                }

               if (FileType == "HIdProof")
                {
                    fileName = HfuIdProof.FileName;
                }

                if(FileType =="BIdProof")
                {
                    fileName = BfuIdProof.FileName;
                }
            
                if(FileType=="DIdProof")
                {
                    fileName = DfuIdProof.FileName;
                }

                if(FileType=="VIdProof")
                {
                    fileName = VfuIdProof.FileName;
                }


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
            // ME   lblName.Text = "A file with the same name already exists." +
            //   ME     "<br />Your file was saved as " + fileName;
            //
            }
            else
            {
                // Notify the user that the file was saved successfully.
            //ME    lblName.Text = "Your file was uploaded successfully.";
            }


            // Append the name of the file to upload to the path.
            savePath += fileName;


            // Call the SaveAs method to save the uploaded
            // file to the specified directory.
            if (FileType == "ProfilePic")
            {
                savePath = Server.MapPath("~//ProfilePic//"+fileName);
                objRegister.ProfilePic1 = fileName;
                fuProfilePic.SaveAs(savePath);
            }
            
            if (FileType == "PIdProof")
            {
                savePath = Server.MapPath("~//IdProof//"+fileName);
                objRegister.IdProof1 = fileName;
                PfuIdProof.SaveAs(savePath);
            }

            if (FileType == "HIdProof")
            {
                savePath = Server.MapPath("~//IdProof//"+fileName);
                objRegister.IdProof1 = fileName;
                HfuIdProof.SaveAs(savePath);
            }

            if (FileType == "BIdProof")
            {
                 savePath = Server.MapPath("~//IdProof//"+fileName);
                 objRegister.IdProof1 = fileName;
                 BfuIdProof.SaveAs(savePath);
            }

            if (FileType== "DIdProof")
            {
                 savePath = Server.MapPath("~//IdProof//"+fileName);
                 objRegister.IdProof1 = fileName;
                 DfuIdProof.SaveAs(savePath);
            }

            if(FileType=="VIdProof")
            {
                 savePath = Server.MapPath("~//IdProof//" + fileName);
                 objRegister.IdProof1 = fileName;
                 VfuIdProof.SaveAs(savePath);
            }
            


        }

        protected void lbVolunteer_Click(object sender, EventArgs e)
        {
            lblRegisterYourSelf.Text = "Register Yourself As Volunteer";

            PStakeholder.Visible = false;
            PRegister.Visible = true;
            MvRegister.ActiveViewIndex = 0;

        }


        protected void lbHospital_click(object sender, EventArgs e)
        {
            lblRegisterYourSelf.Text = "Register Yourself As Hospital";

            PStakeholder.Visible = false;
            PRegister.Visible = true;
            MvRegister.ActiveViewIndex =2 ;
          

        }

       

        protected void lbBloodBank_Click(object sender, EventArgs e)
        {
            lblRegisterYourSelf.Text = "Register Yourself As BloodBank";

            PStakeholder.Visible = false;
            PRegister.Visible = true;
            MvRegister.ActiveViewIndex = 3;
          
        }

        protected void lbPharmaCompany_Click(object sender, EventArgs e)
        {
            lblRegisterYourSelf.Text = "Register Yourself As PharmaCompany";

            PStakeholder.Visible = false;
            PRegister.Visible = true;
            MvRegister.ActiveViewIndex = 4;
          
        }

        protected void lbDoctor_Click(object sender, EventArgs e)
        {
            lblRegisterYourSelf.Text = "Register Yourself As Doctor";

            PStakeholder.Visible = false;
            PRegister.Visible = true;
            MvRegister.ActiveViewIndex = 5;
          
        }

        protected void lbDonor_Click(object sender, EventArgs e)
        {
            lblRegisterYourSelf.Text = "Register Yourself As Donor";

            PStakeholder.Visible = false;
            PRegister.Visible = true;
            MvRegister.ActiveViewIndex = 1;
          
        }

        //protected void txtEmail_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtEmail.Text != "")
        //    {
        //        objRegister.Email1 = txtEmail.Text;
        //        objRegister.GetDataSet_GetEmail();
        //        if (objRegister.Ds.Tables[0].Rows.Count > 0)
        //        {
        //            lblcvEmail.Text = "Email already exist";
        //            return;
        //        }
        //        else
        //        {
        //            lblcvEmail.Text = "";
                   
        //        }
        //    }
        //}

      

    }
}
