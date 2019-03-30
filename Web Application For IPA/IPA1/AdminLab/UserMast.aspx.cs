using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using System.Net;
using System.Net.Mail;

using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Text;


namespace IPA1.AdminLab
{
    public partial class UserMast : System.Web.UI.Page
    {
        BusLib.Common.Registration objUser = new BusLib.Common.Registration();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();
        int User_ID = 0;
        //User Dtail
        BusLib.Common.Registration objUserRegister = new BusLib.Common.Registration();
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
  //      BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        bool Mflag = true;
        bool Pflag = true;
        //End

        System.Web.UI.WebControls.Image sortImage = new System.Web.UI.WebControls.Image();
        DataTable dataTable;

        private string _sortDirection;

        public string SortDireaction
        {
            get
            {
                if (ViewState["SortDireaction"] == null)
                    return string.Empty;
                else
                    return ViewState["SortDireaction"].ToString();
            }
            set
            {
                ViewState["SortDireaction"] = value;
            }
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDropDown();
                BindGrid();

            }
        }
        void BindGrid()
        {
    
            if (Request.QueryString.Count != 0)
            {
                ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByText(Request.QueryString["UserType"].ToString()));
               
            }
            if (txtSearch.Text.Trim() != "")
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(), txtSearch.Text.Trim(),true);
                gvUser.DataSource = objUser.Ds;
                gvUser.DataBind();
                if (objUser.Ds.Tables[0].Rows.Count == 1 && objUser.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                {
                    Button btnView= gvUser.Rows[0].FindControl("btnView") as Button;
                    btnView.Visible = false;
                }

            }
            else
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(),"",true);
                mvUser.ActiveViewIndex = 0;
                gvUser.DataSource = objUser.Ds;

                gvUser.DataBind();
                if (objUser.Ds.Tables[0].Rows.Count == 1 && objUser.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                {
                    Button btnView = gvUser.Rows[0].FindControl("btnView") as Button;
                    btnView.Visible = false;
                }

            }
         


        }



        void FillDropDown()
        {
            //ddlType.AppendDataBoundItems = true;
            //ddlType.Items.Add(new ListItem("Select User Type", ""));
            objSH.GetDataSet("");
            objSH.Ds.Tables[0].DefaultView.Sort = "Name";
            ddlType.DataSource = objSH.Ds.Tables[0];
            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "Name";
            //    ddlType.SelectedIndex = 0;  //VALUE
            //   ddlType.SelectedItem.Text = "Volunteer";
            ddlType.DataBind();
            ddlType.Items.Remove(new System.Web.UI.WebControls.ListItem("NGO"));
        }

        protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUser.PageIndex = e.NewPageIndex;
            BindGrid();

            if (ViewState["SortExpression"] != null)
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16( Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(), txtSearch.Text.Trim(), true);
                dataTable = objUser.Ds.Tables[0];
                if (dataTable != null)
                {
                    if (SortDireaction == "ASC")
                    {
                        sortImage.ImageUrl = "../img/icon_up_sort_arrow.png";
                    }
                    else
                    {
                        sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";
                    }

                    dataTable.DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + SortDireaction;
                    gvUser.DataSource = dataTable;
                    gvUser.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvUser.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvUser.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvUser.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
        
        }

        protected void ddlType_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
                                        "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                isreadonly.SetValue(this.Request.QueryString, false, null);
                Request.QueryString.Clear();

            }

            BindGrid();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {


        }

        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "View")
            {
                //  Response.Redirect("~/Admin_ViewUserDetail.aspx?User_ID=" + e.CommandArgument.ToString() + "");
                User_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvUser.ActiveViewIndex = 1;
                FillddlState();
                FillddlCity();
                FillddlSH();

                UserDetailDisplay();
                mvUser.ActiveViewIndex = 1;
            }

        }


        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/NewUserRegistration.aspx");
        }

        protected void gvUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        //User Detail

        void FillddlState()
        {
            objState.GetDataSet("");
            ddlState.DataSource = objState.Ds.Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "State_ID";
          //  ddlState.SelectedIndex = 6;
            ddlState.DataBind();
        }

        void FillddlCity()
        {
            //objRegister.State_ID1 = Convert.ToInt16(ddlState.SelectedValue);
            //objRegister.GetDataSet_CityName();
            objCity.GetDataSet("");
            ddlCity.DataSource = objCity.Ds.Tables[0];
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "City_ID";
        //    ddlCity.SelectedIndex = 1;
            ddlCity.DataBind();
        }

        void FillddlSH()
        {
            objSH.GetDataSet("");
            ddlselecttype.AppendDataBoundItems = true;
            ddlselecttype.Items.Add(new System.Web.UI.WebControls.ListItem("--Select User Type--", "--Select User Type--"));
            // objSH.Ds.Tables[0].DefaultView.Sort = "Name";
            ddlselecttype.DataSource = objSH.Ds.Tables[0];
            ddlselecttype.DataTextField = "Name";
            ddlselecttype.DataValueField = "StakeHolder_ID";
            ddlselecttype.DataBind();
            ddlselecttype.Items.Remove(new System.Web.UI.WebControls.ListItem("NGO", "8"));
     


        }

        //protected void cvPassword_ServerValidate(object source, ServerValidateEventArgs args)
        //{
        //    if (args.Value.Length < 8)
        //    {
        //        args.IsValid = false;
        //    }
        //    else
        //    {
        //        args.IsValid = true;
        //    }
        //}

        protected void cvMobileNo_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 10)
            {

                args.IsValid = true;
            }
            else
            {

                args.IsValid = false;
            }
        }
        void UserDetailDisplay()
        {
            if (User_ID != 0)
            {

                if (Request.QueryString.Count > 0)
                {
                    objUserRegister.User_ID1 = Convert.ToInt16(User_ID.ToString());
                    if (Request.QueryString["UserType"] != "")
                    {
                        objUserRegister.StackHolder1 = Request.QueryString["UserType"].ToString();
                    }
                   
                }
                
                objUserRegister.User_ID1 = Convert.ToInt16(User_ID.ToString());
                objUserRegister.NotificationFlag1 = true;
                objUser.Registration_UpdateNF();
               
                
                objUserRegister.User_ID1 = Convert.ToInt16(User_ID.ToString());
             
                objUserRegister.GetDataSet_GetUserDetail();
                txtUserID.Text = objUserRegister.Ds.Tables[0].Rows[0]["User_ID"].ToString();

                ddlselecttype.SelectedItem.Text = objUserRegister.Ds.Tables[0].Rows[0]["StackHolder"].ToString();
                txtFirstName.Text = objUserRegister.Ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = objUserRegister.Ds.Tables[0].Rows[0]["LastName"].ToString();
                txtUserName.Text = objUserRegister.Ds.Tables[0].Rows[0]["UserName"].ToString();
                txtEmail.Text = objUserRegister.Ds.Tables[0].Rows[0]["Email"].ToString();
                // txtPassword.Text = objUserRegister.Ds.Tables[0].Rows[0]["Password"].ToString();
                //txtConfirmPassword.Text = objUserRegister.Ds.Tables[0].Rows[0]["ConfirmPassword"].ToString();
                txtAddress.Text = objUserRegister.Ds.Tables[0].Rows[0]["Address"].ToString();
                ddlState.SelectedItem.Text = objUserRegister.Ds.Tables[0].Rows[0]["State"].ToString();
                ddlCity.SelectedItem.Text = objUserRegister.Ds.Tables[0].Rows[0]["City"].ToString();
                txtPinCode.Text = objUserRegister.Ds.Tables[0].Rows[0]["PinCode"].ToString();
                txtMobileNo.Text = objUserRegister.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                ImgProfilePic.ImageUrl = "../ProfilePic/" + objUserRegister.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                //        TextBox txtUserType = objUserRegister.Ds.Tables[0].Rows[0]["StackHolder"] as TextBox;
                //   MvRegister.ActiveViewIndex = Convert.ToInt16(ddlselecttype.SelectedValue);
                if (ddlselecttype.SelectedItem.Text == "Volunteer")
                {
                    MvRegister.ActiveViewIndex = 0;

                }
                else if (ddlselecttype.SelectedItem.Text == "Donor")
                {
                    MvRegister.ActiveViewIndex = 1;

                }

                else if (ddlselecttype.SelectedItem.Text == "Hospital")
                {
                    MvRegister.ActiveViewIndex = 2;

                }

                else if (ddlselecttype.SelectedItem.Text == "BloodBank")
                {
                    MvRegister.ActiveViewIndex = 3;

                }

                else if (ddlselecttype.SelectedItem.Text == "PharmaCompany")
                {
                    MvRegister.ActiveViewIndex = 4;

                }

                else if (ddlselecttype.SelectedItem.Text == "Doctor")
                {
                    MvRegister.ActiveViewIndex = 5;

                }

                else if (ddlselecttype.SelectedItem.Text == "NGO")
                {
                    MvRegister.ActiveViewIndex = 6;

                }
                else
                {
                    MvRegister.ActiveViewIndex = 7;

                }

                if (ddlselecttype.SelectedItem.ToString() == "Volunteer")
                {
                    VImgIdProof.ImageUrl = "../IdProof/" + objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    VddlBloodGroup.SelectedItem.Text = objUserRegister.Ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                    VtxtDOB.Text = objUserRegister.Ds.Tables[0].Rows[0]["BirthDate"].ToString();

                }
                else if (ddlselecttype.SelectedItem.ToString() == "Donor")
                {
                    DddlBloodGroup.SelectedItem.Text = objUserRegister.Ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                    DtxtDOB.Text = objUserRegister.Ds.Tables[0].Rows[0]["BirthDate"].ToString();

                }
                else if (ddlselecttype.SelectedItem.ToString() == "Hospital")
                {

                    HImgIdProof.ImageUrl = "../IdProof/" + objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    HtxtWebsite.Text = objUserRegister.Ds.Tables[0].Rows[0]["Website"].ToString();
                    HtxtContactPerson.Text = objUserRegister.Ds.Tables[0].Rows[0]["ContactPerson"].ToString();

                }
                else if (ddlselecttype.SelectedItem.ToString() == "BloodBank")
                {


                    // ImgBIdProof.ImageUrl="~//IdProof//" + BfuIdProof.FileName;
                    BImgIdProof.ImageUrl = "../IdProof/" + objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    BtxtWebsite.Text = objUserRegister.Ds.Tables[0].Rows[0]["Website"].ToString();
                    BtxtContactPerson.Text = objUserRegister.Ds.Tables[0].Rows[0]["ContactPerson"].ToString();

                }
                else if (ddlselecttype.SelectedItem.ToString() == "PharmaCompany")
                {

                    PImgIdProof.ImageUrl = "../IdProof/" + objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    PtxtWebsite.Text = objUserRegister.Ds.Tables[0].Rows[0]["Website"].ToString();
                    PtxtContactPerson.Text = objUserRegister.Ds.Tables[0].Rows[0]["ContactPerson"].ToString();

                }
                else if (ddlselecttype.SelectedItem.ToString() == "Doctor")
                {
                    DoImgIdProof.ImageUrl = "../IdProof/" + objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    DotxtDegree.Text = objUserRegister.Ds.Tables[0].Rows[0]["Degree"].ToString();
                    DotxtDisease.Text = objUserRegister.Ds.Tables[0].Rows[0]["Disease"].ToString();

                }

                else if (ddlselecttype.SelectedItem.ToString() == "NGO")
                {
                    NtxtPurpose.Text = objUserRegister.Ds.Tables[0].Rows[0]["Purpose"].ToString();
                    NtxtMission.Text = objUserRegister.Ds.Tables[0].Rows[0]["Mission"].ToString();
                    NtxtWebsite.Text = objUserRegister.Ds.Tables[0].Rows[0]["Website"].ToString();

                }

            }



        }


        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillddlCity();
        }

        protected void cvddlselecttype_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ddlselecttype.Text == "--Select User Type--")
            {
                cvddlselecttype.ErrorMessage = "Required";

            }

            else
            {
                cvddlselecttype.ErrorMessage = "";
            }
        }
        


        protected void ddlselecttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            MvRegister.ActiveViewIndex = ddlselecttype.SelectedIndex;
        }

        //protected void btnSubmit_Click(object sender, EventArgs e)
        //{
        ////    if (Mflag && Pflag)
        ////    {
        ////        objUserRegister.User_ID1 = Convert.ToInt16(User_ID.ToString());
        ////        objUserRegister.FirstName1 = txtFirstName.Text + " " + txtLastName.Text;
        ////        objUserRegister.Address1 = txtAddress.Text;
        ////        objUserRegister.City1 = ddlCity.SelectedValue;
        ////        objUserRegister.State1 = ddlState.SelectedValue;
        ////        objUserRegister.PinCode1 = Convert.ToInt32(txtPinCode.Text);
        ////        objUserRegister.MobileNo1 = Convert.ToInt64(txtMobileNo.Text);
        ////        objUserRegister.UserName1 = txtUserName.Text;
        ////        objUserRegister.Email1 = txtEmail.Text;
        ////        //  objUserRegister.Pwd1 = txtPassword.Text;
        ////        objUserRegister.StackHolder1 = ddlselecttype.SelectedItem.ToString();
        ////        objUserRegister.Prefix1 = ddlselecttype.Text[0].ToString();
        ////        objUserRegister.JoinDate1 = DateTime.Now;

        //   if (fuProfilePic.HasFile)
        //{
        //    string[] validFileTypes = { "bmp", "gif", "png", "jpg", "jpeg" };
        //    string ext = System.IO.Path.GetExtension(fuProfilePic.PostedFile.FileName);
        //    bool isvalidFile = false;
        //    for (int i = 0; i < validFileTypes.Length; i++)
        //    {
        //        if (ext == "." + validFileTypes[i])
        //        {
        //            isvalidFile = true;
        //            objUserRegister.ProfilePic1 = fuProfilePic.FileName.Trim();
        //      //      fuProfilePic.SaveAs(Server.MapPath("~../ProfilePic/" + fuProfilePic.FileName));
        //            fuProfilePic.SaveAs(Server.MapPath("~//ProfilePic//") + fuProfilePic.FileName);

        //            break;
        //        }
        //    }
        //    if (!isvalidFile)
        //    {
        //        lblProfilePicture.ForeColor = System.Drawing.Color.Red;
        //        lblProfilePicture.Text = "Invalid File. Please upload a File with extension ." + string.Join(",.", validFileTypes);
        //        return;
        //    }


        //}


        //        if (VtxtDOB.Text == "" || DtxtDOB.Text == "")
        //        {
        //            VtxtDOB.Text = "";
        //            DtxtDOB.Text = "";
        //        }



        //        if (ddlselecttype.SelectedItem.ToString() == "Volunteer")
        //        {


        //            objUserRegister.BirthDate1 = Convert.ToString(String.Format("{0:yyyy-MM-dd}", VtxtDOB.Text).ToString());
        //            objUserRegister.BloodGroup1 = VddlBloodGroup.SelectedValue;
        //        }
        //        else if (ddlselecttype.SelectedItem.ToString() == "Donor")
        //        {

        //            objUserRegister.BirthDate1 = Convert.ToString(String.Format("{0:yyyy-MM-dd}", DtxtDOB.Text).ToString());
        //            objUserRegister.BloodGroup1 = DddlBloodGroup.SelectedValue;
        //        }
        //        else if (ddlselecttype.SelectedItem.ToString() == "Hospital")
        //        {


        //            objUserRegister.IdProof1 = HfuIdProof.FileName;
        //            HfuIdProof.SaveAs(Server.MapPath("~//IdProof//" + HfuIdProof.FileName));
        //            objUserRegister.Website1 = HtxtWebsite.Text;
        //            objUserRegister.ContactPerson1 = HtxtContactPerson.Text;

        //        }
        //        else if (ddlselecttype.SelectedItem.ToString() == "BloodBank")
        //        {

        //            objUserRegister.IdProof1 = BfuIdProof.FileName;
        //            BfuIdProof.SaveAs(Server.MapPath("~//IdProof//" + BfuIdProof.FileName));
        //            objUserRegister.Website1 = BtxtWebsite.Text;
        //            objUserRegister.ContactPerson1 = BtxtContactPerson.Text;

        //        }
        //        else if (ddlselecttype.SelectedItem.ToString() == "PharmaCompany")
        //        {

        //            objUserRegister.IdProof1 = PfuIdProof.FileName;
        //            PfuIdProof.SaveAs(Server.MapPath("~//IdProof//" + PfuIdProof.FileName));
        //            objUserRegister.Website1 = PtxtWebsite.Text;
        //            objUserRegister.ContactPerson1 = PtxtContactPerson.Text;

        //        }
        //        else if (ddlselecttype.SelectedItem.ToString() == "Doctor")
        //        {


        //            objUserRegister.IdProof1 = DfuIdProof.FileName;
        //            DfuIdProof.SaveAs(Server.MapPath("~//IdProof//" + DfuIdProof.FileName));
        //            objUserRegister.Degree1 = DotxtDegree.Text;
        //            objUserRegister.Disease1 = DotxtDisease.Text;

        //        }
        //        else if (ddlselecttype.SelectedItem.ToString() == "NGO")
        //        {

        //            objUserRegister.Purpose1 = NtxtPurpose.Text;
        //            objUserRegister.Website1 = NtxtWebsite.Text;
        //            objUserRegister.Mission1 = NtxtMission.Text;

        //        }
        //        objUserRegister.Update();

        //     //   Response.Redirect("~/UserMast.aspx");
        //        mvUser.ActiveViewIndex = 0;
        //    }

        //}

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue == "Yes")
            {
                objUserRegister.User_ID1 = Convert.ToInt16(User_ID.ToString());
                objUserRegister.Delete();

            //    Response.Redirect("~/UserMast.aspx");
                mvUser.ActiveViewIndex = 0;
                BindGrid();
            }
            else
            {

            }


        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
           // Response.Redirect("~/UserMast.aspx");
            mvUser.ActiveViewIndex = 0;
            BindGrid();
            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
        }

        //protected void txtUserID_TextChanged(object sender, EventArgs e)
        //{
        //    objUserRegister.User_ID1 = Convert.ToInt16(txtUserID.Text);
        //    objUserRegister.GetDataSet_GetAViewUserDetail();
        //    MvRegister.ActiveViewIndex = ddlselecttype.SelectedIndex;
        //    if (objUserRegister.Ds.Tables[0].Rows.Count>0)
        //    {
        //        txtUserID.Text = objUserRegister.Ds.Tables[0].Rows[0]["User_ID"].ToString();
        //        txtFirstName.Text = objUserRegister.Ds.Tables[0].Rows[0]["FirstName"].ToString();
        //        txtLastName.Text = objUserRegister.Ds.Tables[0].Rows[0]["LastName"].ToString();
        //        txtUserName.Text = objUserRegister.Ds.Tables[0].Rows[0]["UserName"].ToString();
        //        txtEmail.Text = objUserRegister.Ds.Tables[0].Rows[0]["Email"].ToString();
        //        // txtPassword.Text = objUserRegister.Ds.Tables[0].Rows[0]["Password"].ToString();
        //        //txtConfirmPassword.Text = objUserRegister.Ds.Tables[0].Rows[0]["ConfirmPassword"].ToString();
        //        txtAddress.Text = objUserRegister.Ds.Tables[0].Rows[0]["Address"].ToString();
        //        ddlState.SelectedItem.Text = objUserRegister.Ds.Tables[0].Rows[0]["State"].ToString();
        //        ddlCity.SelectedItem.Text = objUserRegister.Ds.Tables[0].Rows[0]["City"].ToString();
        //        txtPinCode.Text = objUserRegister.Ds.Tables[0].Rows[0]["PinCode"].ToString();
        //        txtMobileNo.Text = objUserRegister.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
        //        MvRegister.ActiveViewIndex = ddlselecttype.SelectedIndex;
        //        if (ddlselecttype.SelectedItem.ToString() == "Volunteer")
        //        {
        //            VddlBloodGroup.SelectedItem.Text = objUserRegister.Ds.Tables[0].Rows[0]["BloodGroup"].ToString();
        //            VtxtDOB.Text = objUserRegister.Ds.Tables[0].Rows[0]["BirthDate"].ToString();

        //        }
        //        else if (ddlselecttype.SelectedItem.ToString() == "Donor")
        //        {
        //            DddlBloodGroup.SelectedItem.Text = objUserRegister.Ds.Tables[0].Rows[0]["BloodGroup"].ToString();
        //            DtxtDOB.Text = objUserRegister.Ds.Tables[0].Rows[0]["BirthDate"].ToString();

        //        }
        //        else if (ddlselecttype.SelectedItem.ToString() == "Hospital")
        //        {


        //            HfuIdProof.Text = objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
        //            HtxtWebsite.Text = objUserRegister.Ds.Tables[0].Rows[0]["Website"].ToString();
        //            HtxtContactPerson.Text = objUserRegister.Ds.Tables[0].Rows[0]["ContactPerson"].ToString();

        //        }
        //        else if (ddlselecttype.SelectedItem.ToString() == "BloodBank")
        //        {

        //            BfuIdProof.Text= objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
        //            BtxtWebsite.Text = objUserRegister.Ds.Tables[0].Rows[0]["Website"].ToString();
        //            BtxtContactPerson.Text = objUserRegister.Ds.Tables[0].Rows[0]["ContactPerson"].ToString();

        //        }
        //        else if (ddlselecttype.SelectedItem.ToString() == "PharmaCompany")
        //        {
        //            PfuIdProof.Text = objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
        //            PtxtWebsite.Text = objUserRegister.Ds.Tables[0].Rows[0]["Website"].ToString();
        //            PtxtContactPerson.Text = objUserRegister.Ds.Tables[0].Rows[0]["ContactPerson"].ToString();

        //        }
        //        else if (ddlselecttype.SelectedItem.ToString() == "Doctor")
        //        {
        //            DfuIdProof.Text = objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
        //            DotxtDegree.Text = objUserRegister.Ds.Tables[0].Rows[0]["Degree"].ToString();
        //            DotxtDisease.Text = objUserRegister.Ds.Tables[0].Rows[0]["Disease"].ToString();

        //        }

        //        else if (ddlselecttype.SelectedItem.ToString() == "NGO")
        //        {
        //            NtxtPurpose.Text = objUserRegister.Ds.Tables[0].Rows[0]["Purpose"].ToString();
        //            NtxtMission.Text = objUserRegister.Ds.Tables[0].Rows[0]["Mission"].ToString();
        //            NtxtWebsite.Text = objUserRegister.Ds.Tables[0].Rows[0]["Website"].ToString();

        //        }

        //    }
        //    else
        //    {
        //        Clear();

        //    }

        //}

        void Clear()
        {

            txtUserID.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMobileNo.Text = "";
            txtEmail.Text = "";
            txtUserName.Text = "";
            txtAddress.Text = "";
            ddlCity.ClearSelection();
            ddlState.ClearSelection();
            VtxtDOB.Text = "";
            VddlBloodGroup.ClearSelection();
            DtxtDOB.Text = "";
            DddlBloodGroup.ClearSelection();
            HtxtWebsite.Text = "";
            HtxtContactPerson.Text = "";
            PtxtContactPerson.Text = "";
            PtxtWebsite.Text = "";
            BtxtContactPerson.Text = "";
            BtxtWebsite.Text = "";
            NtxtMission.Text = "";
            NtxtPurpose.Text = "";
            NtxtWebsite.Text = "";
            DtxtDOB.Text = "";
            DddlBloodGroup.ClearSelection();


        }

        protected void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void VddlBloodGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlselecttype_SelectedIndexChanged1(object sender, EventArgs e)
        {

            if (ddlselecttype.SelectedItem.Text == "Volunteer")
            {
                MvRegister.ActiveViewIndex = 0;

            }
            else if (ddlselecttype.SelectedItem.Text == "Donor")
            {
                MvRegister.ActiveViewIndex = 1;

            }

            else if (ddlselecttype.SelectedItem.Text == "Hospital")
            {
                MvRegister.ActiveViewIndex = 2;

            }

            else if (ddlselecttype.SelectedItem.Text == "BloodBank")
            {
                MvRegister.ActiveViewIndex = 3;

            }

            else if (ddlselecttype.SelectedItem.Text == "PharmaCompany")
            {
                MvRegister.ActiveViewIndex = 4;

            }

            else if (ddlselecttype.SelectedItem.Text == "Doctor")
            {
                MvRegister.ActiveViewIndex = 5;

            }

            else if (ddlselecttype.SelectedItem.Text == "NGO")
            {
                MvRegister.ActiveViewIndex = 6;

            }
            else
            {
                MvRegister.ActiveViewIndex = 7;

            }
        }


        protected void cvPinCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 6)
            {

                args.IsValid = true;
                Pflag = true;
            }
            else
            {

                args.IsValid = false;
                Pflag = false;
            }
        }

        protected void cvMobileNo_ServerValidate1(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Length == 10)
            {

                args.IsValid = true;
                Mflag = true;
            }
            else
            {

                args.IsValid = false;
                Mflag = false;
            }
        }






        /* protected void btnCancel_Click(object sender, EventArgs e)
         {

             Response.Redirect("~/Admin_UserMastNew.aspx");
         }*/

        //End User Detail

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            objUser.GetUser(ddlType.SelectedValue.ToString(),"",true);

            dataTable = objUser.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;
                gvUser.DataSource = dataTable;
                gvUser.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvUser.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvUser.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvUser.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
        }
        protected void SetSortDirection(string sortDirection)
        {
            if (sortDirection == "ASC")
            {
                _sortDirection = "DESC";
                sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";

            }
            else
            {
                _sortDirection = "ASC";
                sortImage.ImageUrl = "../img/icon_up_sort_arrow.png";
            }
        }




        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvUser.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvUser.AllowPaging = true;
                gvUser.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }



            if (ViewState["SortExpression"] != null)
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(), txtSearch.Text.Trim(), true);
                dataTable = objUser.Ds.Tables[0];
                if (dataTable != null)
                {
                    if (SortDireaction == "ASC")
                    {
                        sortImage.ImageUrl = "../img/icon_up_sort_arrow.png";
                    }
                    else
                    {
                        sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";
                    }

                    dataTable.DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + SortDireaction;
                    gvUser.DataSource = dataTable;
                    gvUser.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvUser.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvUser.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvUser.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }



        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            objUser.GetUser(ddlType.SelectedValue.ToString(), txtSearch.Text.Trim(),true);
            gvUser.DataSource = objUser.Ds;
            gvUser.DataBind();

            if (ViewState["SortExpression"] != null)
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(), txtSearch.Text.Trim(), true);
                dataTable = objUser.Ds.Tables[0];
                if (dataTable != null)
                {
                    if (SortDireaction == "ASC")
                    {
                        sortImage.ImageUrl = "../img/icon_up_sort_arrow.png";
                    }
                    else
                    {
                        sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";
                    }

                    dataTable.DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + SortDireaction;
                    gvUser.DataSource = dataTable;
                    gvUser.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvUser.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvUser.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvUser.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
          



            if (objUser.Ds.Tables[0].Rows.Count == 1 && objUser.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
            {
                Button btnView = gvUser.Rows[0].FindControl("btnView") as Button;
                
                btnView.Visible = false;
                
            }
            txtSearch.Focus();
        }
        protected void lbUserMaster_Click(object sender, EventArgs e)
        {
            mvUser.ActiveViewIndex = 0;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void lbSaveAsPDF_Click(object sender, EventArgs e)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Export.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            gvUser.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(), txtSearch.Text.Trim(), true);
                gvUser.DataSource = objUser.Ds;
                gvUser.DataBind();

                if (objUser.Ds.Tables[0].Rows.Count == 1 && objUser.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                {
                    Button btnView = gvUser.Rows[0].FindControl("btnView") as Button;
                      btnView.Visible = false;
                }

            }

            else
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(), "", true);
                gvUser.DataSource = objUser.Ds;
                gvUser.DataBind();


            }

            if (ViewState["SortExpression"] != null)
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(), txtSearch.Text.Trim(), true);
                dataTable = objUser.Ds.Tables[0];
                if (dataTable != null)
                {
                    if (SortDireaction == "ASC")
                    {
                        sortImage.ImageUrl = "../img/icon_up_sort_arrow.png";
                    }
                    else
                    {
                        sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";
                    }

                    dataTable.DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + SortDireaction;
                    gvUser.DataSource = dataTable;
                    gvUser.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvUser.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvUser.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                 //   gvUser.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvUser.HeaderRow.Cells[5].Visible = false;
            
            gvUser.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvUser.Rows.Count; i++)
            {
                GridViewRow row = gvUser.Rows[i];
                row.Cells[5].Visible = false;
                
            }

            Label lblTitle = new Label();
            lblTitle.Text = "User Master <br /><br />";
            lblTitle.Font.Bold = true;
            lblTitle.Font.Underline = true;
            lblTitle.RenderControl(hw);

            gvUser.RenderControl(hw);


            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();  
    
        }

        protected void lbExportToExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;

            Response.AddHeader("content-disposition",
             "attachment;filename=Export.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            gvUser.AllowPaging = false;

            if (txtSearch.Text.Trim() != "")
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(), txtSearch.Text.Trim(), true);
                gvUser.DataSource = objUser.Ds;
                gvUser.DataBind();
                if (objUser.Ds.Tables[0].Rows.Count == 1 && objUser.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                {
                    Button btnView = gvUser.Rows[0].FindControl("btnView") as Button;
                
                   
                    btnView.Visible = false;
                }

            }

            else
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(),"", true);
                gvUser.DataSource = objUser.Ds;
                gvUser.DataBind();

            }

            if (ViewState["SortExpression"] != null)
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(), txtSearch.Text.Trim(), true);
                dataTable = objUser.Ds.Tables[0];
                if (dataTable != null)
                {
                    if (SortDireaction == "ASC")
                    {
                        sortImage.ImageUrl = "../img/icon_up_sort_arrow.png";
                    }
                    else
                    {
                        sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";
                    }

                    dataTable.DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + SortDireaction;
                    gvUser.DataSource = dataTable;
                    gvUser.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvUser.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvUser.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                  //  gvUser.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvUser.HeaderRow.Cells[5].Visible = false;
            
            gvUser.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvUser.Rows.Count; i++)
            {
                GridViewRow row = gvUser.Rows[i];
                row.Cells[5].Visible = false;
                
            }

            gvUser.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write("<b><u><big>User Master</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
   
        }

        protected void lbExportToWord_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Export.doc");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-word ";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            gvUser.AllowPaging = false;
            //objUser.GetDataSet("");
            //gvUser.DataSource = objUser.Ds;
            //gvUser.DataBind();



            if (txtSearch.Text.Trim() != "")
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(), txtSearch.Text.Trim(), true);
                gvUser.DataSource = objUser.Ds;
                gvUser.DataBind();

                if (objUser.Ds.Tables[0].Rows.Count == 1 && objUser.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                {
                    Button btnView = gvUser.Rows[0].FindControl("btnView") as Button;
                   

                    btnView.Visible = false;
                 
                }

            }

            else
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(),"", true);
                gvUser.DataSource = objUser.Ds;
                gvUser.DataBind();
            }

            if (ViewState["SortExpression"] != null)
            {
                objUser.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objUser.GetUser(ddlType.SelectedValue.ToString(), txtSearch.Text.Trim(), true);
                dataTable = objUser.Ds.Tables[0];
                if (dataTable != null)
                {
                    if (SortDireaction == "ASC")
                    {
                        sortImage.ImageUrl = "../img/icon_up_sort_arrow.png";
                    }
                    else
                    {
                        sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";
                    }

                    dataTable.DefaultView.Sort = ViewState["SortExpression"].ToString() + " " + SortDireaction;
                    gvUser.DataSource = dataTable;
                    gvUser.DataBind();

                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvUser.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvUser.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                //    gvUser.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }

            gvUser.HeaderRow.Cells[5].Visible = false;
           
            gvUser.FooterRow.Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gvUser.Rows.Count; i++)
            {
                GridViewRow row = gvUser.Rows[i];
                row.Cells[5].Visible = false;
              
            }

            gvUser.RenderControl(hw);
            Response.Output.Write("<b><u><big>User Master</big></u><b><br><br>");
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
       

        }

        protected void VImgIdProof_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                //string filePath = "../IdProof/" + VlblImgIdProof.Text;
                //Response.ContentType = "image/jpg";
                //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                //Response.TransmitFile(Server.MapPath(filePath));
                // Response.End();
                objUser.User_ID1 = Convert.ToInt16(txtUserID.Text);
                objUser.GetDataSet_GetUserDetail();
                String Image = objUser.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                String strURL = "../IdProof//" + Image;
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

        protected void DoImgIdProof_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                //string filePath = "../IdProof/" + VlblImgIdProof.Text;
                //Response.ContentType = "image/jpg";
                //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                //Response.TransmitFile(Server.MapPath(filePath));
                // Response.End();
                objUser.User_ID1 = Convert.ToInt16(txtUserID.Text);
                objUser.GetDataSet_GetUserDetail();
                String Image = objUser.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                String strURL = "../IdProof//" + Image;
               
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

        protected void PImgIdProof_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                //string filePath = "../IdProof/" + VlblImgIdProof.Text;
                //Response.ContentType = "image/jpg";
                //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                //Response.TransmitFile(Server.MapPath(filePath));
                // Response.End();
                objUser.User_ID1 = Convert.ToInt16(txtUserID.Text);
                objUser.GetDataSet_GetUserDetail();
                String Image = objUser.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                String strURL = "../IdProof//" + Image;
               
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

        protected void BImgIdProof_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                //string filePath = "../IdProof/" + VlblImgIdProof.Text;
                //Response.ContentType = "image/jpg";
                //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                //Response.TransmitFile(Server.MapPath(filePath));
                // Response.End();
                objUser.User_ID1 = Convert.ToInt16(txtUserID.Text);
                objUser.GetDataSet_GetUserDetail();
                String Image = objUser.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                String strURL = "../IdProof//" + Image;
               
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

        protected void HImgIdProof_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                //string filePath = "../IdProof/" + VlblImgIdProof.Text;
                //Response.ContentType = "image/jpg";
                //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                //Response.TransmitFile(Server.MapPath(filePath));
                // Response.End();
                objUser.User_ID1 = Convert.ToInt16(txtUserID.Text);
                objUser.GetDataSet_GetUserDetail();
                String Image = objUser.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                String strURL = "../IdProof//" + Image;
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

        protected void ImgProfilePic_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                //string filePath = "../IdProof/" + VlblImgIdProof.Text;
                //Response.ContentType = "image/jpg";
                //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                //Response.TransmitFile(Server.MapPath(filePath));
                // Response.End();
                objUser.User_ID1 = Convert.ToInt16(txtUserID.Text);
                objUser.GetDataSet_GetUserDetail();
                String Image = objUser.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                String strURL = "../ProfilePic//" + Image;
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

       

    }
}