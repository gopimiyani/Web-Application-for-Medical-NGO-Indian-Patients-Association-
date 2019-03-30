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

namespace IPA1.AdminLab
{
    public partial class ApproveNewUser : System.Web.UI.Page
    {
        BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();
        Image sortImage = new Image();
        DataTable dataTable;
        int User_ID = 0;
      
        //User Detail
        BusLib.Master.StateMast objState = new BusLib.Master.StateMast();
        BusLib.Master.CityMast objCity = new BusLib.Master.CityMast();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        bool Mflag = true;
        bool Pflag = true;

        //End
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
                DtxtDOB.Attributes.Add("readonly", "readonly");
                VtxtDOB.Attributes.Add("readonly", "readonly");

                FillddlType();
                BindGrid();
                lblRFR.Visible = false;
                txtRejectionReason.Visible = false;
            }
        }


        void FillddlType()
        {
            
            //ddlType.AppendDataBoundItems = true;
            //ddlType.Items.Add(new ListItem("Select User Type", ""));
            objSH.GetDataSet("");
            objSH.Ds.Tables[0].DefaultView.Sort = "Name";
            ddlType.DataSource = objSH.Ds.Tables[0];
            ddlType.DataTextField = "Name";
            ddlType.DataValueField = "Name";
            ddlType.DataBind();
            ddlType.Items.Remove(new System.Web.UI.WebControls.ListItem("NGO"));
            ddlType.Items.Remove(new System.Web.UI.WebControls.ListItem("Donor"));
     


        }
        void BindGrid()
        {
            if (Request.QueryString.Count != 0)
            {
                ddlType.SelectedIndex = ddlType.Items.IndexOf(ddlType.Items.FindByText(Request.QueryString["UserType"].ToString()));
               
            }


            if (txtSearch.Text.Trim() != "")
            {
                objRegistration.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objRegistration.GetDataSet_GetPendingUser(txtSearch.Text.Trim(),"");
                gvRegistration.DataSource = objRegistration.Ds;
                gvRegistration.DataBind();
          
            }
            else
            {
                objRegistration.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objRegistration.GetDataSet_GetPendingUser(ddlType.SelectedValue.ToString(),"");
                mvNewUser.ActiveViewIndex = 0;
                gvRegistration.DataSource = objRegistration.Ds;
                gvRegistration.DataBind();
        
            }
            if (objRegistration.Ds.Tables[0].Rows.Count == 1 && objRegistration.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
            {
                Button btnView = gvRegistration.Rows[0].FindControl("btnView") as Button;
                btnView.Visible = false;
            }

         }

       


        protected void gvRegistration_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRegistration.PageIndex = e.NewPageIndex;
            BindGrid();
        }


        protected void gvRegistration_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
            //    Response.Redirect("~/Admin_ViewRegistration.aspx?User_ID=" + e.CommandArgument.ToString() + "");
                User_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvNewUser.ActiveViewIndex = 1;
                FillddlState();
                FillddlCity();
                FillddlSH();

                UserDetailDisplay();
            
            }

        }

        //Start User Detail

        void FillddlState()
        {

            objState.GetDataSet("");
            ddlState.DataSource = objState.Ds.Tables[0];
            ddlState.DataTextField = "StateName";
            ddlState.DataValueField = "State_ID";
        //    ddlState.SelectedIndex = 6;
            ddlState.DataBind();

        }

        void FillddlCity()
        {
            //objRegistration.State_ID1 = Convert.ToInt16(ddlState.SelectedValue);
            //objRegistration.GetDataSet_CityName();
            objCity.GetDataSet("");
            ddlCity.DataSource = objCity.Ds.Tables[0];
            ddlCity.DataTextField = "CityName";
            ddlCity.DataValueField = "City_ID";
       //     ddlCity.SelectedIndex = 1;
            ddlCity.DataBind();
        }

        void FillddlSH()
        {
            objSH.GetDataSet("");
            ddlselecttype.AppendDataBoundItems = true;
            ddlselecttype.Items.Add(new ListItem("--Select User Type--", "--Select User Type--"));
            // objSH.Ds.Tables[0].DefaultView.Sort = "Name";
            ddlselecttype.DataSource = objSH.Ds.Tables[0];
            ddlselecttype.DataTextField = "Name";
            ddlselecttype.DataValueField = "StakeHolder_ID";
            ddlselecttype.DataBind();
            ddlselecttype.Items.Remove(new System.Web.UI.WebControls.ListItem("NGO", "8"));
            ddlselecttype.Items.Remove(new System.Web.UI.WebControls.ListItem("Donor", "2"));
     

        }
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
        private string ConvertDate(string Date)
        {
            string Rdate = "";
            if (Date != "")
            {

                Rdate = Date.Substring(6, 4) + "-" + Date.Substring(3, 2) + "-" + Date.Substring(0, 2);
            }
            return Rdate;
        }
        void UserDetailDisplay()
        {
            if (User_ID != 0)
            {
                if (Request.QueryString.Count > 0)
                {
                    objRegistration.User_ID1 = Convert.ToInt16(User_ID.ToString());
                    if (Request.QueryString["UserType"] != "")
                    {
                        objRegistration.StackHolder1 = Request.QueryString["UserType"].ToString();
                    }
                    objRegistration.NotificationFlag1 = true;
                }
                objRegistration.Registration_UpdateNF();
               
                objRegistration.User_ID1 = Convert.ToInt16(User_ID.ToString());
                objRegistration.GetDataSet_GetUserDetail();
                txtUserID.Text = objRegistration.Ds.Tables[0].Rows[0]["User_ID"].ToString();

                ddlselecttype.SelectedItem.Text = objRegistration.Ds.Tables[0].Rows[0]["StackHolder"].ToString();
                txtFirstName.Text = objRegistration.Ds.Tables[0].Rows[0]["FirstName"].ToString();
                txtLastName.Text = objRegistration.Ds.Tables[0].Rows[0]["LastName"].ToString();
                txtUserName.Text = objRegistration.Ds.Tables[0].Rows[0]["UserName"].ToString();
                txtEmail.Text = objRegistration.Ds.Tables[0].Rows[0]["Email"].ToString();
                txtAddress.Text = objRegistration.Ds.Tables[0].Rows[0]["Address"].ToString();
                ddlState.SelectedItem.Text = objRegistration.Ds.Tables[0].Rows[0]["State"].ToString();
                ddlCity.SelectedItem.Text = objRegistration.Ds.Tables[0].Rows[0]["City"].ToString();
                txtPinCode.Text = objRegistration.Ds.Tables[0].Rows[0]["PinCode"].ToString();
                txtMobileNo.Text = objRegistration.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                ImgProfilePic.ImageUrl = "~//ProfilePic//" + objRegistration.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                
       
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
                    VImgIdProof.ImageUrl = "~//IdProof//" + objRegistration.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    VddlBloodGroup.SelectedItem.Text = objRegistration.Ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                    VtxtDOB.Text = objRegistration.Ds.Tables[0].Rows[0]["BirthDate"].ToString();


                }
                else if (ddlselecttype.SelectedItem.ToString() == "Donor")
                {
                    DddlBloodGroup.SelectedItem.Text = objRegistration.Ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                    DtxtDOB.Text = objRegistration.Ds.Tables[0].Rows[0]["BirthDate"].ToString();

                }
                else if (ddlselecttype.SelectedItem.ToString() == "Hospital")
                {

                    HImgIdProof.ImageUrl = "~//IdProof//" + objRegistration.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    HtxtWebsite.Text = objRegistration.Ds.Tables[0].Rows[0]["Website"].ToString();
                    HtxtContactPerson.Text = objRegistration.Ds.Tables[0].Rows[0]["ContactPerson"].ToString();

                }
                else if (ddlselecttype.SelectedItem.ToString() == "BloodBank")
                {


                    // ImgBIdProof.ImageUrl="~//IdProof//" + BfuIdProof.FileName;
                    BImgIdProof.ImageUrl = "~//IdProof" + objRegistration.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    BtxtWebsite.Text = objRegistration.Ds.Tables[0].Rows[0]["Website"].ToString();
                    BtxtContactPerson.Text = objRegistration.Ds.Tables[0].Rows[0]["ContactPerson"].ToString();

                }
                else if (ddlselecttype.SelectedItem.ToString() == "PharmaCompany")
                {

                    PImgIdProof.ImageUrl = "~//IdProof//" + objRegistration.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    PtxtWebsite.Text = objRegistration.Ds.Tables[0].Rows[0]["Website"].ToString();
                    PtxtContactPerson.Text = objRegistration.Ds.Tables[0].Rows[0]["ContactPerson"].ToString();

                }
                else if (ddlselecttype.SelectedItem.ToString() == "Doctor")
                {
                    DoImgIdProof.ImageUrl = "~//IdProof//" + objRegistration.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    DotxtDegree.Text = objRegistration.Ds.Tables[0].Rows[0]["Degree"].ToString();
                    DotxtDisease.Text = objRegistration.Ds.Tables[0].Rows[0]["Disease"].ToString();

                }

                else if (ddlselecttype.SelectedItem.ToString() == "NGO")
                {
                    NtxtPurpose.Text = objRegistration.Ds.Tables[0].Rows[0]["Purpose"].ToString();
                    NtxtMission.Text = objRegistration.Ds.Tables[0].Rows[0]["Mission"].ToString();
                    NtxtWebsite.Text = objRegistration.Ds.Tables[0].Rows[0]["Website"].ToString();

                }

                


            }



        }

        protected void ddlselecttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            MvRegister.ActiveViewIndex = ddlselecttype.SelectedIndex;
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvNewUser.ActiveViewIndex = 0;
           // BindGrid();
            Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
        }

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

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if (Mflag && Pflag)
            {
                objRegistration.User_ID1 = Convert.ToInt16(txtUserID.Text) ;
                objRegistration.Status1 = "Approved";
                objRegistration.Registration_UpdateStatus();
            
                // Send email
                String mailto = txtEmail.Text;
                String smsto = txtMobileNo.Text;

                var fromAddress = new MailAddress("IPANGO992015@gmail.com");
                var fromPassword = "IPANGO2015";

                using (System.Net.Mail.MailMessage msg1 = new System.Net.Mail.MailMessage())
                {
                    System.Net.Mail.SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;


                    smtpClient.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
                    msg1.From = new MailAddress("IPANGO992015@gmail.com");

                    msg1.To.Add(mailto);   //Dynamic
                    string Body = "";
                    Body = "Your Registration is Approved and now you are a member of our Association ";
                    msg1.Subject = "Registration is Approved by IPA";
                    msg1.IsBodyHtml = true;
                    msg1.Body = Body;
                    smtpClient.Timeout = 1000000;
                 //   smtpClient.Send(msg1);
                }


                //Send SMS


                //WebClient client = new WebClient();

                //String msg = "Your Registration is Approved and now you are a member of IPA\r\n";
                //msg += "\r\nPlease refer mail for more details";
                //string baseurl = "http://smsidea.co.in/sendsms.aspx?mobile=9574017480&pass=prabhu&senderid=WEBSMS&to=" + smsto + "&msg=" + msg + "";
                //Stream data = client.OpenRead(baseurl);
                //StreamReader reader = new StreamReader(data);
                //string s = reader.ReadToEnd();

                
                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Registration is approved'); </script>");
                mvNewUser.ActiveViewIndex = 0;
                BindGrid();
            }

        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            lblRFR.Visible = true;
            txtRejectionReason.Visible = true;
            

            if (Mflag && Pflag)
            {
                objRegistration.User_ID1 = Convert.ToInt16(txtUserID.Text);
                if (txtRejectionReason.Text == "")
                {
                    lblRFR.Visible = true;
                    lblrvReason.Visible=true;
                    return;
                }
                objRegistration.Status1 = "Rejected";              
                objRegistration.ReasonForRejection1 = txtRejectionReason.Text;
                objRegistration.Registration_UpdateStatus();

                // Send email
                String mailto = txtEmail.Text;
                String smsto = txtMobileNo.Text;

                var fromAddress = new MailAddress("IPANGO992015@gmail.com");
                var fromPassword = "IPANGO2015";

                using (System.Net.Mail.MailMessage msg1 = new System.Net.Mail.MailMessage())
                {
                    System.Net.Mail.SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;


                    smtpClient.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
                    msg1.From = new MailAddress("IPANGO992015@gmail.com");

                    msg1.To.Add(mailto);   //Dynamic
                    string Body = "";
                    Body = "your registration is rejected due to following reason:\n ";
                    Body += txtRejectionReason.Text;
                    msg1.Subject = "registration is rejected by IPA";
                    msg1.IsBodyHtml = true;
                    msg1.Body = Body;
                    smtpClient.Timeout = 1000000;
                //    smtpClient.Send(msg1);
                }


                //Send SMS


                //WebClient client = new WebClient();

                //string msg = "your registration is rejected\r\n";
                //msg += "\r\nplease refer mail for more details";
                //string baseurl = "http://smsidea.co.in/sendsms.aspx?mobile=9574017480&pass=prabhu&senderid=WEBSMS&to=" + smsto + "&msg=" + msg + "";
                //Stream data = client.OpenRead(baseurl);
                //StreamReader reader = new StreamReader(data);
                //string s = reader.ReadToEnd();

                Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Registration is rejected'); </script>");
               
                mvNewUser.ActiveViewIndex = 0;
                BindGrid();
           
            }
            
        }

        //End User Detail

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            objRegistration.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            if (txtSearch.Text.Trim() != "")
            {
                objRegistration.GetDataSet_GetPendingUser(txtSearch.Text.Trim(),"");
                

            }
            else
            {
                objRegistration.GetDataSet_GetPendingUser(ddlType.SelectedValue.ToString(),"");
                
            }
         
            dataTable = objRegistration.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                if (objRegistration.Ds.Tables[0].Rows.Count == 1 && objRegistration.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                {
                    Button btnView = gvRegistration.Rows[0].FindControl("btnView") as Button;
                    btnView.Visible = false;
                }
               
                gvRegistration.DataSource = dataTable;
                gvRegistration.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvRegistration.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvRegistration.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvRegistration.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
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

        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvRegistration.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvRegistration.AllowPaging = true;
                gvRegistration.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            objRegistration.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            objRegistration.GetDataSet_GetPendingUser(txtSearch.Text.Trim(),"");
            gvRegistration.DataSource = objRegistration.Ds;
            gvRegistration.DataBind();
            if (objRegistration.Ds.Tables[0].Rows.Count == 1 && objRegistration.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
            {
                Button btnView = gvRegistration.Rows[0].FindControl("btnView") as Button;
                btnView.Visible = false;
            }
        }
        protected void lbApproveNewUsers_Click(object sender, EventArgs e)
        {
            mvNewUser.ActiveViewIndex = 0;
            BindGrid();
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

        protected void VImgIdProof_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                //string filePath = "../IdProof/" + VlblImgIdProof.Text;
                //Response.ContentType = "image/jpg";
                //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                //Response.TransmitFile(Server.MapPath(filePath));
                // Response.End();
                objRegistration.User_ID1 = Convert.ToInt16(txtUserID.Text);
                objRegistration.GetDataSet_GetUserDetail();
                String Image = objRegistration.Ds.Tables[0].Rows[0]["IdProof"].ToString();
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
                objRegistration.User_ID1 = Convert.ToInt16(txtUserID.Text);
                objRegistration.GetDataSet_GetUserDetail();
                String Image = objRegistration.Ds.Tables[0].Rows[0]["IdProof"].ToString();
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
                objRegistration.User_ID1 = Convert.ToInt16(txtUserID.Text);
                objRegistration.GetDataSet_GetUserDetail();
                String Image = objRegistration.Ds.Tables[0].Rows[0]["IdProof"].ToString();
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
                objRegistration.User_ID1 = Convert.ToInt16(txtUserID.Text);
                objRegistration.GetDataSet_GetUserDetail();
                String Image = objRegistration.Ds.Tables[0].Rows[0]["IdProof"].ToString();
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

                objRegistration.User_ID1 = Convert.ToInt16(txtUserID.Text);
                objRegistration.GetDataSet_GetUserDetail();
                String Image = objRegistration.Ds.Tables[0].Rows[0]["IdProof"].ToString();
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
                objRegistration.User_ID1 = Convert.ToInt16(txtUserID.Text);
                objRegistration.GetDataSet_GetUserDetail();
                String Image = objRegistration.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
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