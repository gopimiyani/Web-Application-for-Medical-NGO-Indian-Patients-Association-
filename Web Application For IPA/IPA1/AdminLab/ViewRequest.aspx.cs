using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Web.UI.WebControls;
using System.Data;
using System.Reflection;
using System.Net.Mail;
using System.IO;

namespace IPA1.AdminLab
{
    public partial class ViewRequest : System.Web.UI.Page
    {
        BusLib.Transaction.Request objRequest = new BusLib.Transaction.Request();
        BusLib.Master.Admin objAdmin = new BusLib.Master.Admin();
        BusLib.Transaction.Patient objPatient = new BusLib.Transaction.Patient();
        BusLib.Common.Registration objReg = new BusLib.Common.Registration();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();
        int Request_ID = 0;
        int WorkinAdmin_ID = 0;
        Image sortImage = new Image();

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
            if (Session["User_ID"] != null)
            {
                WorkinAdmin_ID = Convert.ToInt16(Session["User_ID"].ToString());
            }
            if (!IsPostBack)
            {

                mvRequest.ActiveViewIndex = 0;
                BindGrid();
                gvRequestDetail.AllowPaging = true;
                sortImage.ImageUrl = "../img/bullet-arrow-up-down-icon.png";
            }
        }
        void BindGrid()
        {
            if (Request.QueryString.Count != 0)
            {
                if (Request.QueryString["Status"].ToString() != "")
                {
                    ddlStatus1.SelectedIndex = ddlStatus1.Items.IndexOf(ddlStatus1.Items.FindByText(Request.QueryString["Status"].ToString()));

                }

            }

            if (ddlStatus1.SelectedIndex != 0)
            {
                objRequest.Status1 = ddlStatus1.SelectedValue.ToString();

            }

            if (txtSearch.Text.Trim() != "")
            {
                objRequest.WorkingAdmin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
                objRequest.GetDataSet(txtSearch.Text.Trim());
                gvRequestDetail.DataSource = objRequest.Ds;
                gvRequestDetail.DataBind();
                if (objRequest.Ds.Tables[0].Rows.Count == 1 && objRequest.Ds.Tables[0].Rows[0]["Request_ID"].ToString() == "")
                {
                    Button btnView = gvRequestDetail.Rows[0].FindControl("btnView") as Button;
                    btnView.Visible = false;
                }
            }
            else
            {
                objRequest.WorkingAdmin_ID1 = WorkinAdmin_ID;
                objRequest.GetDataSet("");
                //  mvRequest.ActiveViewIndex = 0;
                gvRequestDetail.DataSource = objRequest.Ds;
                gvRequestDetail.DataBind();
              
            }

        }

        protected void gvRequestDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvRequestDetail.PageIndex = e.NewPageIndex;
            BindGrid();

            if (ViewState["SortExpression"] != null)
            {
                objRequest.WorkingAdmin_ID1 = WorkinAdmin_ID;
                objRequest.GetDataSet(txtSearch.Text.Trim());
                dataTable = objRequest.Ds.Tables[0];
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
                    gvRequestDetail.DataSource = dataTable;
                    gvRequestDetail.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvRequestDetail.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvRequestDetail.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvRequestDetail.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
        }

        protected void gvRequestDetail_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                //Response.Redirect("~/Admin_ViewRequestDetail.aspx?Request_ID=" + e.CommandArgument.ToString() + "");
                Request_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvRequest.ActiveViewIndex = 1;
                RequestDetailDisplay();
                txtDate.Attributes.Add("readonly", "readonly");


            }

        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/PatientRequestForm.aspx");

        }

        protected void gvRequestDetail_Sorting(object sender, GridViewSortEventArgs e)
        {
            objRequest.WorkingAdmin_ID1 = WorkinAdmin_ID;
            objRequest.GetDataSet("");

            dataTable = objRequest.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                ViewState["SortExpression"] = e.SortExpression;

                gvRequestDetail.DataSource = dataTable;
                gvRequestDetail.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvRequestDetail.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvRequestDetail.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvRequestDetail.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
        }


        // Request detail


        private string ConvertDate(string Date)
        {
            string Rdate = "";
            if (Date != "")
            {


                Rdate = Date.Substring(6, 4) + "-" + Date.Substring(3, 2) + "-" + Date.Substring(0, 2);
            }
            return Rdate;
        }

        void RequestDetailDisplay()
        {
            lblrvReason.Text = "";

            if (Request_ID != 0)
            {

                ddlStatus.Items.Clear();
                ddlStatus.Items.Add("Pending");
                ddlStatus.Items.Add("Confirmed");
                ddlStatus.Items.Add("Rejected");

                //clear validation text

                lblselecttype.Text = "";
                lblcvResponse.Text = "";
                lblrvReason.Text = "";

                //end

                pServiceProvider.Visible = false;

                objRequest.Request_ID1 = Convert.ToInt16(Request_ID.ToString());
                objRequest.NotificationFlag1 = true;
                objRequest.UpdateNF();

                objRequest.Request_ID1 = Convert.ToInt16(Request_ID.ToString());
                objRequest.WorkingAdmin_ID1 = WorkinAdmin_ID;
                objRequest.GetDataSet_GetViewRequestDetail();

                txtRequestNo.Text = objRequest.Ds.Tables[0].Rows[0]["Request_ID"].ToString();
                if (objRequest.Ds.Tables[0].Rows[0]["User_ID"].ToString() != "0")
                {
                    int UserID = Convert.ToInt16(objRequest.Ds.Tables[0].Rows[0]["User_ID"].ToString());
                    objReg.User_ID1 = UserID;
                    objReg.GetDataSet_Select();
                    if (objReg.Ds.Tables[0].Rows[0]["FirstName"].ToString() != null)
                    {
                        String FirstName = objReg.Ds.Tables[0].Rows[0]["FirstName"].ToString();
                        txtUserID.Text = FirstName + " | " + UserID;
                    }
                }

                if (objRequest.Ds.Tables[0].Rows[0]["Admin_ID"].ToString() != "0")
                {
                    objAdmin.Admin_ID1 = Convert.ToInt16(objRequest.Ds.Tables[0].Rows[0]["Admin_ID"].ToString());
                    objAdmin.GetDataset();
                    String AdminName = objAdmin.Ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + objAdmin.Ds.Tables[0].Rows[0]["LastName"].ToString() + " | " + objRequest.Ds.Tables[0].Rows[0]["Admin_ID"].ToString();
                    txtAdminID.Text = AdminName;
                }

                if (objRequest.Ds.Tables[0].Rows[0]["Request_Patient_ID"].ToString() != "")
                {
                    lblTransaction_ID.Visible = true;
                    txtTransaction_ID.Visible = true;
                    txtTransaction_ID.Text = objRequest.Ds.Tables[0].Rows[0]["Request_Patient_ID"].ToString();
                }

                else
                {
                    lblTransaction_ID.Visible = false;
                    txtTransaction_ID.Visible = false;
                }

                txtName.Text = objRequest.Ds.Tables[0].Rows[0]["Name"].ToString();
                txtSubject.Text = objRequest.Ds.Tables[0].Rows[0]["Subject"].ToString();

                txtDescr.Text = objRequest.Ds.Tables[0].Rows[0]["Description"].ToString();

                DateTime RequestDate = Convert.ToDateTime(objRequest.Ds.Tables[0].Rows[0]["Date"].ToString());
                txtDate.Text = RequestDate.ToString("dd-MM-yyyy");

                txtAddress.Text = objRequest.Ds.Tables[0].Rows[0]["Address"].ToString();
                ddlState.SelectedItem.Text = objRequest.Ds.Tables[0].Rows[0]["State"].ToString();

                ddlCity.SelectedItem.Text = objRequest.Ds.Tables[0].Rows[0]["City"].ToString();

                txtPinCode.Text = objRequest.Ds.Tables[0].Rows[0]["PinCode"].ToString();
                txtMobileNo.Text = objRequest.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                txtEmail.Text = objRequest.Ds.Tables[0].Rows[0]["Email"].ToString();


                txtResponse.Text = objRequest.Ds.Tables[0].Rows[0]["Response"].ToString();
                txtRejectionReason.Text = objRequest.Ds.Tables[0].Rows[0]["ReasonForRejection"].ToString();
                txtRejectionReason.Enabled = false;

                String RequestStatus = objRequest.Ds.Tables[0].Rows[0]["Status"].ToString();
                ddlStatus.SelectedItem.Text = RequestStatus;
                //if (objRequest.Ds.Tables[0].Rows[0]["Status"].ToString() == "Pending")
                //{
                //    txtAutoResponse.Text = "Your Request is Pending";
                //}
                //else
                //{
                //    txtAutoResponse.Enabled = false;
                //}

                ImgIdProof.ImageUrl = "~//IdProof//" + objRequest.Ds.Tables[0].Rows[0]["IdProof1"].ToString();
                lblcvIdProof.Text = objRequest.Ds.Tables[0].Rows[0]["IdProof1"].ToString();
                ImgDocument1.ImageUrl = "~//IdProof//" + objRequest.Ds.Tables[0].Rows[0]["IdProof2"].ToString();
                lblcvDocument1.Text = objRequest.Ds.Tables[0].Rows[0]["IdProof2"].ToString();
                if (objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString() != "")
                {
                    ImgDocument2.ImageUrl = "~//IdProof//" + objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString();
                    lblcvDocument2.Text = objRequest.Ds.Tables[0].Rows[0]["IdProof3"].ToString();
                    ImgDocument2.Visible = true;
                }
                else
                {
                    ImgDocument2.ImageUrl = "";
                    ImgDocument2.AlternateText = "";
                    lblcvDocument2.Text = "No Document";
                    ImgDocument2.Visible = false;
                }

                if (RequestStatus.Equals("Confirmed"))
                {

                    ddlStatus.Enabled = false;
                    txtResponse.Enabled = false;
                    btnForward.Visible = false;
                    preasonforrejection.Visible = false;
                    txtResponse.ReadOnly = true;
                    pConfirmRequest.Visible = false;
                    btnSubmit1.Visible = false;
                    btnSubmit2.Visible = false;
                    btnSubmit3.Visible = false;
                    FillddlSH();

                    pServiceProvider.Visible = true;

                    objPatient.Request_ID1= Convert.ToInt16( txtRequestNo.Text);
                    objPatient.GetServiceProvider();
                    txtServiceProvider.Text = objPatient.Ds.Tables[0].Rows[0]["ServiceProviderName"].ToString();
                }

                else if (RequestStatus.Equals("Rejected"))
                {
                    ddlStatus.Enabled = false;
                    txtResponse.Enabled = false;
                    btnForward.Visible = false;
                    preasonforrejection.Visible = true;
                    txtResponse.ReadOnly = true;
                    pConfirmRequest.Visible = false;
                    btnSubmit1.Visible = false;
                    btnSubmit2.Visible = false;
                    btnSubmit3.Visible = false;
                }
                else
                {
                    ddlStatus.Items.Clear();
                    ddlStatus.Items.Add("Pending");
                    ddlStatus.Items.Add("Confirmed");
                    ddlStatus.Items.Add("Rejected");
                    ddlStatus.Enabled = true;

                    preasonforrejection.Visible = false;
                    txtResponse.ReadOnly = false;
                    pConfirmRequest.Visible = false;

                    btnSubmit1.Visible = true;
                    btnSubmit2.Visible = false;
                    btnSubmit3.Visible = false;

                }


            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            String RequestStatus = ddlStatus.SelectedItem.Text;
            objRequest.Request_ID1 = Convert.ToInt16(txtRequestNo.Text);

            if (Session["User_ID"] != null)
            {
                objRequest.Admin_ID1 = Convert.ToInt16(Session["User_ID"].ToString());
            }


            objRequest.Name1 = txtName.Text;
            objRequest.Subject1 = txtSubject.Text;
            objRequest.Description1 = txtDescr.Text;

            objRequest.Address1 = txtAddress.Text;
            objRequest.City1 = ddlCity.SelectedItem.ToString();
            objRequest.State1 = ddlState.SelectedItem.ToString();
            objRequest.PinCode1 = Convert.ToInt32(txtPinCode.Text);
            objRequest.MobileNo1 = Convert.ToInt64(txtMobileNo.Text);
            objRequest.Email1 = txtEmail.Text;

            objRequest.Response1 = txtResponse.Text;
            objRequest.Status1 = ddlStatus.SelectedItem.ToString();
            objRequest.ReasonForRejection1 = txtRejectionReason.Text;
            if (RequestStatus.Equals("Confirmed"))
            {
                btnForward.Visible = false;
                if (ddlselecttype.Text == "--Select User Type--")
                {
                    lblselecttype.ForeColor = System.Drawing.Color.Red;
                    lblselecttype.Text = "Required";
                    return;

                }


                //   CheckBox activeCheckBox = sender as CheckBox;

                if (gvUser.Rows.Count == 1)
                {
                    Label User_ID1 = gvUser.Rows[0].FindControl("lblID") as Label;
                    if (User_ID1.Text != "")
                    {
                        lblcvSelectServiceProvider.Text = "";
                    }
                    else
                    {
                        lblcvSelectServiceProvider.Text = "Please Select Service Provider";
                        return;
                    }

                }

                int f = 0;

                foreach (GridViewRow rw in gvUser.Rows)
                {
                    CheckBox chkBx = (CheckBox)rw.FindControl("ChkSelect");
                    if (chkBx.Checked == true)
                    {
                        f = 1;
                        break;
                    }
                }

                if (f == 0)
                {
                    lblcvSelectServiceProvider.Text = "Please Select One of the available service provider";
                    return;
                }
                else
                {
                    lblcvSelectServiceProvider.Text = "";
                }
                lblrvReason.Text = "";
                objPatient.Request_ID1 = Convert.ToInt16(txtRequestNo.Text); ;
                objPatient.Address1 = txtAddress.Text;
                objPatient.Name1 = txtName.Text;
                objPatient.City1 = ddlCity.SelectedItem.ToString();
                objPatient.State1 = ddlState.SelectedItem.ToString();
                objPatient.PinCode1 = Convert.ToInt32(txtPinCode.Text);
                objPatient.MobileNo1 = Convert.ToInt64(txtMobileNo.Text);
                objPatient.Email1 = txtEmail.Text;
                objPatient.Insert();
                int i = 0, SelectedIndex;
                for (i = 0; i < gvUser.Rows.Count; i++)
                {

                    GridViewRow row = gvUser.Rows[i];
                    CheckBox chkBx = (CheckBox)row.FindControl("ChkSelect");
                    if (chkBx.Checked == true)
                    {
                        f = 1;
                        SelectedIndex = i;
                        break;
                    }
                    //objPatient.IsSelect1 = (((CheckBox)row.FindControl("ChkSelect")).Checked);
                    
                   
                }

                Label label1 = (Label)gvUser.Rows[i].FindControl("lblID");
                string label1val = label1.Text;
                objRegistration.User_ID1 = Convert.ToInt16(label1val);
                objRegistration.GetDataSet_Select();
                String User_ID = objRegistration.Ds.Tables[0].Rows[0]["User_ID"].ToString();
                String mailto = objRegistration.Ds.Tables[0].Rows[0]["Email"].ToString();
                String smsto = objRegistration.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                objRequest.Request_ID1 = Convert.ToInt16(txtRequestNo.Text);
                objRequest.GetDataSet_GetPatientDetail();

                String Request_ID = objRequest.Ds.Tables[0].Rows[0]["Request_ID"].ToString();



                string strURL = "http://localhost:10399/AdminLab/PatientServiceDetail.aspx?";
                string strURLWithData = strURL + EncryptQueryString(string.Format("Request_ID={0}&User_ID={1}", Request_ID, User_ID));

                //Send Email to Hospital

                var fromAddress = new MailAddress("ipango9999@gmail.com");
                var fromPassword = "123qwertyu";

                using (System.Net.Mail.MailMessage msg1 = new System.Net.Mail.MailMessage())
                {
                    System.Net.Mail.SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;


                    smtpClient.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
                    msg1.From = new MailAddress("ipango9999@gmail.com");

                    // send mail...

                    msg1.To.Add(mailto);   //Dynamic
                    string Body = "";
                    Body = "<b><big>" + "Confirmation from IPA" + "</big></b><br/><br/>";
                    Body += "Please provide the appropriate services to the patient which has been confirmed by Indian Patients Association" + "<br/>" + "For the Patient Detail ";
                    Body += "<a href=" + strURLWithData + "> Click Here </a> ";
                    msg1.Subject = "Confirmation from IPA";
                    msg1.IsBodyHtml = true;
                    msg1.Body = Body;
                    smtpClient.Timeout = 1000000;
                  //  smtpClient.Send(msg1);

                }


                
                ////Send SMS To Service Provider

                //WebClient client = new WebClient();

                //String msg = "Confirmation From IPA\r\n";
                //msg += "\r\nThe Request of Patient No." + Patient_ID + " has been confirmed.";
                //msg += "\r\nPlease refer mail for the details.";
                //string baseurl = "http://smsidea.co.in/sendsms.aspx?mobile=9574017480&pass=prabhu&senderid=WEBSMS&to=" + smstoServiceProvider + "&msg=" + msg + "";
                //Stream data = client.OpenRead(baseurl);
                //StreamReader reader = new StreamReader(data);
                //string s = reader.ReadToEnd();


                ////Send SMS To Patient

                //WebClient client1 = new WebClient();

                //String msg1 = "Confirmation From IPA\r\n";
                //msg1 += "\r\nYour Request For Medical Help has been confirmed.\r\nPlease refer mail for the details";
                //string baseurl1 = "http://smsidea.co.in/sendsms.aspx?mobile=9574017480&pass=prabhu&senderid=WEBSMS&to=" + smstoPatient + "&msg=" + msg1 + "";
                //Stream data1 = client1.OpenRead(baseurl1);
                //StreamReader reader1 = new StreamReader(data1);
                //string s1 = reader1.ReadToEnd();



                //Send Email to Patient 

                objRequest.Request_ID1 = Convert.ToInt16(txtRequestNo.Text);
                objRequest.GetDataSet_GetPatientDetail();

                String Patient_ID = objRequest.Ds.Tables[0].Rows[0]["Patient_ID"].ToString();
                String mail1to = objRequest.Ds.Tables[0].Rows[0]["Email"].ToString();
                String sms1to = objRequest.Ds.Tables[0].Rows[0]["MobileNo"].ToString();



                // Send Email


                fromAddress = new MailAddress("ipango9999@gmail.com");
                fromPassword = "123qwertyu";

                using (System.Net.Mail.MailMessage msg1 = new System.Net.Mail.MailMessage())
                {
                    System.Net.Mail.SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;


                    smtpClient.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
                    msg1.From = new MailAddress("ipango9999@gmail.com");

                    // send mail...

                    msg1.To.Add(mail1to);   //Dynamic
                    string Body = "";
                    Body = "<b><big>" + "Confirmation from IPA" + "</big></b><br/><br/>";
                    Body += "Your Request has been confirmed. " + "<br/>" + "Take a Print out of this attachment when you come for getting services" + "<br/>";
                    Body += "<a href=" + strURLWithData + "> Click Here </a> ";
                    msg1.Subject = "Confirmation from IPA";
                    msg1.IsBodyHtml = true;
                    msg1.Body = Body;
                    smtpClient.Timeout = 1000000;
                  // smtpClient.Send(msg1);

                }



                
                //// Send SMS To Patient


                // WebClient client = new WebClient();

                // String msg = "A new task is assigned from IPA\r\nTask:" + txtSubject.Text;
                // //msg+=    "\r\nCompletion Date:" + txtCDate.Text;
                // msg += "\r\nFor more details: refer mail or login to system";
                // string baseurl = "http://smsidea.co.in/sendsms.aspx?mobile=9574017480&pass=prabhu&senderid=WEBSMS&to=" + smsto + "&msg=" + msg + "";
                // Stream data = client.OpenRead(baseurl);
                // StreamReader reader = new StreamReader(data);
                // string s = reader.ReadToEnd();


                objRequest.Request_ID1 = Convert.ToInt16(txtRequestNo.Text);
                objRequest.Patient_ID1 = Convert.ToInt16(Patient_ID);
                objRequest.ServiceProviderUser_ID1 = Convert.ToInt16(User_ID);
                objRequest.UpdateServiceProviderID();

                
              






                
                
                

                
            }

            
            if (RequestStatus.Equals("Pending"))
            {
                btnForward.Visible = true;
                lblrvReason.Text = "";
                objRequest.Request_ID1 = Convert.ToInt16(txtRequestNo.Text);

                objRequest.IsHold1 = true;
                objRequest.UpdateIsHold1();
                //objRequest.UpdateStatusToHold();

                objRequest.Request_ID1 = Convert.ToInt16(txtRequestNo.Text);
                objRequest.GetDataSet_GetViewRequestDetail();
                String Request_Patient_ID = objRequest.Ds.Tables[0].Rows[0]["Request_Patient_ID"].ToString();

                String mailto = objRequest.Ds.Tables[0].Rows[0]["Email"].ToString();
                String smsto = objRequest.Ds.Tables[0].Rows[0]["MobileNo"].ToString();

                //Send Email
                //using (System.Net.Mail.MailMessage msg1 = new System.Net.Mail.MailMessage())
                //{
                //    System.Net.Mail.SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                //    smtpClient.EnableSsl = true;
                //    smtpClient.Credentials = new NetworkCredential("IPA99NGO", "ipa99ngo+");
                //    msg1.From = new System.Net.Mail.MailAddress("IPA99NGO@gmail.com");
                //    msg1.To.Add(mailto);   //Dynamic
                //    string Body = "";


                //    Body = "<table cellspacing='5px' cellpadding='3px'><tr><td>";

                //    Body += "<tr><td><b>" + "Response " + "</b></td><td>" + txtResponse.Text + "</td></tr>";  
                //    Body += "<tr><td>" + "Your RequestTransaction_ID is " + "</td><td>" + Request_Patient_ID+ "</td></tr>";
                //    Body += "Please take this RequestTransaction_ID, When you are request for the same "; 
                //    Body += "</table>";
                //    msg1.Subject = "Your Request is Pending";
                //    msg1.IsBodyHtml = true;
                //    msg1.Body = Body;
                //    smtpClient.Timeout = 1000000;
                //    smtpClient.Send(msg1);


                //}


                //Send SMS


                //WebClient client = new WebClient();

                //String msg = "A new task is assigned from IPA\r\nTask:" + txtSubject.Text;
                ////msg+=    "\r\nCompletion Date:" + txtCDate.Text;
                //msg += "\r\nFor more details: refer mail or login to system";
                //string baseurl = "http://smsidea.co.in/sendsms.aspx?mobile=9574017480&pass=prabhu&senderid=WEBSMS&to=" + smsto + "&msg=" + msg + "";
                //Stream data = client.OpenRead(baseurl);
                //StreamReader reader = new StreamReader(data);
                //string s = reader.ReadToEnd();


                


            }


            if (RequestStatus.Equals("Rejected"))
            {
                if (txtRejectionReason.Text == "")
                {
                    lblrvReason.Text = "Enter reason for rejection";
                    btnForward.Visible = false;
                    return;


                }
                else
                {
                    lblrvReason.Text = "";
                }


                objRequest.Request_ID1 = Convert.ToInt16(txtRequestNo.Text);
                objRequest.GetDataSet_GetViewRequestDetail();
                // String Request_Patient_ID = objRequest.Ds.Tables[0].Rows[0]["Request_Patient_ID"].ToString();

                String mailto = objRequest.Ds.Tables[0].Rows[0]["Email"].ToString();
                String smsto = objRequest.Ds.Tables[0].Rows[0]["MobileNo"].ToString();

                //Send Email
                //using (System.Net.Mail.MailMessage msg1 = new System.Net.Mail.MailMessage())
                //{
                //    System.Net.Mail.SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                //    smtpClient.EnableSsl = true;
                //    smtpClient.Credentials = new NetworkCredential("IPA99NGO", "ipa99ngo+");
                //    msg1.From = new System.Net.Mail.MailAddress("IPA99NGO@gmail.com");
                //    msg1.To.Add(mailto);   //Dynamic
                //    string Body = "";


                //    Body = "<table cellspacing='5px' cellpadding='3px'><tr><td>";

                //    Body += "<tr><td><b>" + "Response " + "</b></td><td>" + txtResponse.Text + "</td></tr>";
                //    Body += "<tr><td>" + "Reason for Rejection  " + "</td><td>" + txtRejectionReason.Text + "</td></tr>";

                //    Body += "</table>";
                //    msg1.Subject = "Your Request is Rejected";
                //    msg1.IsBodyHtml = true;
                //    msg1.Body = Body;
                //    smtpClient.Timeout = 1000000;
                //    smtpClient.Send(msg1);


                //}

            }


            objRequest.Request_ID1 = Convert.ToInt16(txtRequestNo.Text);

            objRequest.Update();
            BindGrid();

            if (ddlStatus.SelectedItem.Text == "Pending")
            {
                Response.Write("<script language='javascript'>window.alert('Request is still Pending and the Response is sent to the Patient by Email');window.location='ViewRequest.aspx';</script>");

            }
            else if (ddlStatus.SelectedItem.Text == "Confirmed")
            {
                Response.Write("<script language='javascript'>window.alert('Confirmation is sent to the patient as well as the selected service provider by Email and SMS');window.location='ViewRequest.aspx';</script>");

            }
            else
            {
                Response.Write("<script language='javascript'>window.alert('Request is Rejected and the Reason for rejection is sent to the patient by email');window.location='ViewRequest.aspx';</script>");
            }

            return;




                   }



        protected void btnCancle_Click(object sender, EventArgs e)
        {
            FillddlSH();
            BindGrid();
            mvRequest.ActiveViewIndex = 0;
        }

        protected void ddlStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            String RequestStatus = ddlStatus.SelectedItem.Text;
            ddlStatus.Enabled = true;
            if (RequestStatus.Equals("Confirmed"))
            {

                preasonforrejection.Visible = false;
                pConfirmRequest.Visible = true;
                ddlselecttype.Items.Clear();
                FillddlSH();
                lblselecttype.Text = "";


                //     ddlStatus.Enabled = false;
                //    ddlStatus.cssClass = "disable";
                txtResponse.Text = "Your Request is confirmed.";
                txtResponse.ReadOnly = true;
                txtRejectionReason.Enabled = false;
                lblrvReason.Text = "";
                btnSubmit1.Visible = false;
                btnSubmit2.Visible = true;
                btnSubmit3.Visible = false;
                btnForward.Visible = false;
                //String mailto = objReg.Ds.Tables[0].Rows[0]["Email"].ToString();
                ////  String smsto = objReg.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                ////Send Email

                //using (System.Net.Mail.MailMessage msg1 = new System.Net.Mail.MailMessage())
                //{


                //    System.Net.Mail.SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                //    smtpClient.EnableSsl = true;
                //    smtpClient.Credentials = new NetworkCredential("IPA99NGO", "ipa99ngo+");
                //    msg1.From = new MailAddress("IPA99NGO@gmail.com");
                //    //ObjEmp.FillEmail(UltCmbDept.Text, "");
                //    //for (int i = 0; i < ObjEmp.DS.Tables["Email"].Rows.Count; i++)
                //    //{
                //    //    msg1.To.Add(ObjEmp.DS.Tables["Email"].Rows[i]["Email"].ToString());

                //    //}

                //    // send mail...

                //    //   msg1.To.Add("gopimiyani@gmail.com");   //Static
                //    msg1.To.Add(mailto);   //Dynamic
                //    string Body = "";
                //    //   Body = "<b><big>" + "Request " + "</big></b><br/><br/>";

                //    Body += "<table cellspacing='5px' cellpadding='3px'><tr><td>";
                //    Body += "Reference By" + "</td><td>" + Session["AdminName"].ToString() + "</td></tr>";
                //    Body += "<tr><td>" + "Request_No" + "</td><td>" + txtRequestNo.Text + "</td></tr>";
                //    //   Body += "<tr><td>" + "Reference By" + "</td><td>" + txtAdminID.Text + "</td></tr>";
                //    Body += "<tr><td>" + "+</td><td>" + txtResponse.Text + "</td></tr>";
                //    //Body += "<tr><td>" + "Completion Date" + "</td><td>" + txtCDate.Text + "</td></tr>";
                //    //Body += "<tr><td>" + "Completion Time" + "</td><td>" + CTime1 + "</td></tr>";
                //    Body += "</table>";
                //    msg1.Subject = "Confirmed Request";
                //    msg1.IsBodyHtml = true;
                //    msg1.Body = Body;
                //    smtpClient.Timeout = 1000000;
                //    smtpClient.Send(msg1);


                //}


            }
            else if (RequestStatus.Equals("Rejected"))
            {
                preasonforrejection.Visible = true;
                pConfirmRequest.Visible = false;
                txtResponse.Text = "Your Request is Rejected.";
                txtResponse.ReadOnly = true;
                txtRejectionReason.Enabled = true;
                btnForward.Visible = false;
                btnSubmit1.Visible = false;
                btnSubmit2.Visible = false;
                btnSubmit3.Visible = true;

                //String mailto = objReg.Ds.Tables[0].Rows[0]["Email"].ToString();
                //// String smsto = objReg.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                ////Send Email

                //using (System.Net.Mail.MailMessage msg1 = new System.Net.Mail.MailMessage())
                //{
                //    System.Net.Mail.SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                //    smtpClient.EnableSsl = true;
                //    smtpClient.Credentials = new NetworkCredential("IPA99NGO", "ipa99ngo+");
                //    msg1.From = new MailAddress("IPA99NGO@gmail.com");
                //    //ObjEmp.FillEmail(UltCmbDept.Text, "");
                //    //for (int i = 0; i < ObjEmp.DS.Tables["Email"].Rows.Count; i++)
                //    //{
                //    //    msg1.To.Add(ObjEmp.DS.Tables["Email"].Rows[i]["Email"].ToString());

                //    //}

                //    // send mail...

                //    // msg1.To.Add("gopimiyani@gmail.com");   //Static
                //    msg1.To.Add(mailto);   //Dynamic
                //    string Body = "";
                //    //    Body = "<b><big>" + "Request Description " + "</big></b><br/><br/>";

                //    Body += "<table cellspacing='5px' cellpadding='3px'><tr><td>";
                //    Body += "Reference By" + "</td><td>" + Session["AdminName"].ToString() + "</td></tr>";
                //    Body += "<tr><td>" + "Request_No" + "</td><td>" + txtRequestNo.Text + "</td></tr>";
                //    //   Body += "<tr><td>" + "Reference By" + "</td><td>" + txtAdminID.Text + "</td></tr>";
                //    Body += "<tr><td>" + "+</td><td>" + txtResponse.Text + "</td></tr>";
                //    Body += "<tr><td>" + "+</td><td>" + txtRejectionReason.Text + "</td></tr>";
                //    //Body += "<tr><td>" + "Completion Date" + "</td><td>" + txtCDate.Text + "</td></tr>";
                //    //Body += "<tr><td>" + "Completion Time" + "</td><td>" + CTime1 + "</td></tr>";
                //    Body += "</table>";
                //    msg1.Subject = "Rejected Request ";
                //    msg1.IsBodyHtml = true;
                //    msg1.Body = Body;
                //    smtpClient.Timeout = 1000000;
                //    smtpClient.Send(msg1);


                //}

            }
            else
            {

                preasonforrejection.Visible = false;
                pConfirmRequest.Visible = false;
                txtResponse.Text = "";
                txtResponse.ReadOnly = false;
                txtRejectionReason.Enabled = false;

                lblrvReason.Text = "";
                btnForward.Visible = true;
                btnSubmit1.Visible = true;
                btnSubmit2.Visible = false;
                btnSubmit3.Visible = false;
            }

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
            ddlselecttype.SelectedIndex = 0;
            ddlselecttype.DataBind();
            ddlselecttype.Items.Remove(new ListItem("Volunteer", "1"));
            ddlselecttype.Items.Remove(new ListItem("Donor", "2"));
            //ddlselecttype.Items.Remove(new ListItem("BloodBank", "4"));
            ddlselecttype.Items.Remove(new ListItem("Doctor", "6"));
            ddlselecttype.Items.Remove(new ListItem("NGO", "8"));
            ddlselecttype.Items.Remove(new ListItem("Media", "9"));



        }

        // end request detail



        protected void SetSortDirection(string sortDirection)
        {
            if (sortDirection == "ASC")
            {
                _sortDirection = "DESC";
                //       sortImage.ImageUrl = "../img/view_sort_ascending.png";
                sortImage.ImageUrl = "../img/icon_down_sort_arrow.png";
            }
            else
            {
                _sortDirection = "ASC";
                //      sortImage.ImageUrl = "../img/view_sort_descending.png";
                sortImage.ImageUrl = "../img/icon_up_sort_arrow.png";
            }
        }

        protected void ddlStatus1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty(
                                        "IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
                // make collection editable
                isreadonly.SetValue(this.Request.QueryString, false, null);
                // remove
                //  this.Request.QueryString.Remove("foo");
                Request.QueryString.Clear();

            }
            BindGrid();
        }

        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvRequestDetail.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvRequestDetail.AllowPaging = true;
                gvRequestDetail.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }

            if (ViewState["SortExpression"] != null)
            {
                objRequest.WorkingAdmin_ID1 = WorkinAdmin_ID;
                objRequest.GetDataSet(txtSearch.Text.Trim());
                dataTable = objRequest.Ds.Tables[0];
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
                    gvRequestDetail.DataSource = dataTable;
                    gvRequestDetail.DataBind();
                    int columnIndex = 0;
                    foreach (DataControlFieldHeaderCell headerCell in gvRequestDetail.HeaderRow.Cells)
                    {
                        if (headerCell.ContainingField.SortExpression == ViewState["SortExpression"].ToString())
                        {
                            columnIndex = gvRequestDetail.HeaderRow.Cells.GetCellIndex(headerCell);
                        }
                    }

                    gvRequestDetail.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
                }
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            objRequest.WorkingAdmin_ID1 = WorkinAdmin_ID;
            objRequest.GetDataSet(txtSearch.Text.Trim());
            gvRequestDetail.DataSource = objRequest.Ds;
            gvRequestDetail.DataBind();
            if (objRequest.Ds.Tables[0].Rows.Count == 1 && objRequest.Ds.Tables[0].Rows[0]["Request_ID"].ToString() == "")
            {
                Button btnView = gvRequestDetail.Rows[0].FindControl("btnView") as Button;
                btnView.Visible = false;
            }

        }

        protected void lbPatientRequests_Click(object sender, EventArgs e)
        {
            mvRequest.ActiveViewIndex = 0;
            BindGrid();
        }


        protected void btnForward_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/ForwardRequest.aspx?RequestNo=" + txtRequestNo.Text + "");
        }

        protected void ImgDocument2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {

                //string filePath = "../IdProof/" + VlblImgIdProof.Text;
                //Response.ContentType = "image/jpg";
                //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                //Response.TransmitFile(Server.MapPath(filePath));
                // Response.End();
                String strURL = "../IdProof//" + lblcvDocument2.Text;
                if (lblcvDocument2.Text != "")
                {
                     strURL = "../IdProof//" + lblcvDocument2.Text;
                }

                else
                {
                     strURL = "";
                }
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

                //string filePath = "../IdProof/" + VlblImgIdProof.Text;
                //Response.ContentType = "image/jpg";
                //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                //Response.TransmitFile(Server.MapPath(filePath));
                // Response.End();
                String strURL = "../IdProof//" + lblcvDocument1.Text;
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

                //string filePath = "../IdProof/" + VlblImgIdProof.Text;
                //Response.ContentType = "image/jpg";
                //Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
                //Response.TransmitFile(Server.MapPath(filePath));
                // Response.End();
                String strURL = "../IdProof//" + lblcvIdProof.Text;
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

        // Confirmed Request start



        protected void ddlselecttype_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
            Button1.Visible = true;
            if (ddlselecttype.Text == "--Select User Type--")
            {
                lblselecttype.ForeColor = System.Drawing.Color.Red;
                lblselecttype.Text = "Required";
                return;

            }



            lblselecttype.Text = "";



            if (txtPinCode1.Text == "")
            {
                objReg.StackHolder1 = ddlselecttype.SelectedItem.Text;
                objReg.GetDataSet_Search();
                gvUser.DataSource = objReg.Ds;
                gvUser.DataBind();

                if (ViewState["SortExpression"] != null)
                {


                    objReg.GetDataSet_Search();
                    dataTable = objReg.Ds.Tables[0];
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
            if (txtPinCode1.Text != "")
            {

                objReg.PinCode1 = Convert.ToInt32(txtPinCode1.Text);
                objReg.StackHolder1 = ddlselecttype.SelectedItem.Text;
                objReg.GetDataSet_Search();
                gvUser.DataSource = objReg.Ds;
                gvUser.DataBind();

                if (ViewState["SortExpression"] != null)
                {


                    objReg.GetDataSet_Search();
                    dataTable = objReg.Ds.Tables[0];
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

        }


        protected void btnSearch_Click1(object sender, EventArgs e)
        {
            //Button1.Visible = true;
            if (ddlselecttype.Text != "" && txtPinCode1.Text != "")
            {
                if (txtPinCode1.Text != "")
                {
                    objReg.PinCode1 = Convert.ToInt32(txtPinCode1.Text);

                }

                if (ddlselecttype.SelectedIndex != 0)
                {
                    objReg.StackHolder1 = ddlselecttype.SelectedItem.Text;
                }
                objReg.GetDataSet_Search();

                gvUser.DataSource = objReg.Ds;
                gvUser.DataBind();
                if (objReg.Ds.Tables[0].Rows.Count == 1 && objReg.Ds.Tables[0].Rows[0]["User_ID"].ToString() == "")
                {
                    CheckBox ChkSelect = gvUser.Rows[0].FindControl("ChkSelect") as CheckBox;
                    ChkSelect.Visible = false;
                }


            }

            if (ddlselecttype.Text == "--Select User Type--" && txtPinCode1.Text == "")
            {
                objReg.GetDataSet_Search();
                gvUser.DataSource = objReg.Ds;
                gvUser.DataBind();

            }

            else if (ddlselecttype.Text != "" && txtPinCode1.Text == "")
            {
                objReg.StackHolder1 = ddlselecttype.SelectedItem.Text;
                objReg.GetDataSet_Search();
                gvUser.DataSource = objReg.Ds;
                gvUser.DataBind();

            }

            else if (ddlselecttype.Text == "--Select User Type--" && txtPinCode1.Text != "")
            {
                objReg.PinCode1 = Convert.ToInt32(txtPinCode1.Text);
                objReg.GetDataSet_Search();
                gvUser.DataSource = objReg.Ds;
                gvUser.DataBind();

            }

            if (ViewState["SortExpression"] != null)
            {


                objReg.GetDataSet_Search();
                dataTable = objReg.Ds.Tables[0];
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

        protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUser.PageIndex = e.NewPageIndex;
            if (ViewState["SortExpression"] != null)
            {
                if (ddlselecttype.Text != "" && txtPinCode1.Text != "")
                {
                    objReg.PinCode1 = Convert.ToInt16(txtPinCode1.Text);
                    objReg.StackHolder1 = ddlselecttype.SelectedItem.Text;
                }
                else if (ddlselecttype.Text == "" && txtPinCode1.Text != "")
                {
                    objReg.PinCode1 = Convert.ToInt16(txtPinCode1.Text);
                }
                else if (ddlselecttype.Text != "" && txtPinCode1.Text == "")
                {
                    objReg.StackHolder1 = ddlselecttype.SelectedItem.Text;
                }
                objReg.GetDataSet_Search();
                dataTable = objReg.Ds.Tables[0];
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


        protected void ChkSelect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox activeCheckBox = sender as CheckBox;
            foreach (GridViewRow rw in gvUser.Rows)
            {
                CheckBox chkBx = (CheckBox)rw.FindControl("ChkSelect");
                if (chkBx != activeCheckBox)
                {
                    chkBx.Checked = false;
                }
                else
                {
                    chkBx.Checked = true;
                }
            }
            // Button1.Visible = true;
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            if (ddlselecttype.Text != "" && txtPinCode1.Text != "")
            {
                objReg.PinCode1 = Convert.ToInt16(txtPinCode1.Text);
                objReg.StackHolder1 = ddlselecttype.SelectedItem.Text;
            }
            else if (ddlselecttype.Text == "" && txtPinCode1.Text != "")
            {
                objReg.PinCode1 = Convert.ToInt16(txtPinCode1.Text);
            }
            else if (ddlselecttype.Text != "" && txtPinCode1.Text == "")
            {
                objReg.StackHolder1 = ddlselecttype.SelectedItem.Text;
            }
            objReg.GetDataSet_Search();
            dataTable = objReg.Ds.Tables[0];
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


        protected void btnSendConfirmation_Click(object sender, EventArgs e)
        {
            int i = 0, SelectedIndex;
            for (i = 0; i < gvUser.Rows.Count; i++)
            {
                GridViewRow row = gvUser.Rows[i];

                objPatient.IsSelect1 = (((CheckBox)row.FindControl("ChkSelect")).Checked);
                SelectedIndex = i;
                break;
            }
            Label label1 = (Label)gvUser.Rows[i].FindControl("lblID");
            string label1val = label1.Text;

            objReg.User_ID1 = Convert.ToInt16(label1val);
            objReg.GetDataSet_Select();


            //  objPatient.Patient_ID1 = Convert.ToInt16(txtPatientID.Text);
            objPatient.Patient_ID1 = 1;
            objPatient.GetDataSet_GetPatientDetail();
            String User_ID = objReg.Ds.Tables[0].Rows[0]["User_ID"].ToString();
            String Patient_ID = objPatient.Ds.Tables[0].Rows[0]["Patient_ID"].ToString();

            String mailtoPatient = objPatient.Ds.Tables[0].Rows[0]["Email"].ToString();
            String smstoPatient = objPatient.Ds.Tables[0].Rows[0]["MobileNo"].ToString();

            

            String mailtoServiceProvider = objReg.Ds.Tables[0].Rows[0]["Email"].ToString();
            String smstoServiceProvider = objReg.Ds.Tables[0].Rows[0]["MobileNo"].ToString();



            string strURL = "http://localhost:10399/AdminLab/PatientServiceDetail.aspx?";
            string strURLWithData = strURL + EncryptQueryString(string.Format("Patient_ID={0}&User_ID={1}", Patient_ID, User_ID));
   
            //Send Email to Hospital

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

                // send mail...

                msg1.To.Add(mailtoServiceProvider);   //Dynamic
                string Body = "";
                Body = "<b><big>" + "Confirmation from IPA" + "</big></b><br/><br/>";
                Body += "Please provide the appropriate services to the patient which has been confirmed by Indian Patients Association" + "<br/>" + "For the Patient Detail ";
                Body += "<a href=" + strURLWithData + "> Click Here </a> ";
                msg1.Subject = "Confirmation from IPA";
                msg1.IsBodyHtml = true;
                msg1.Body = Body;
                smtpClient.Timeout = 1000000;
            //    smtpClient.Send(msg1);

            }





            

            ////Send SMS To Service Provider

            //WebClient client = new WebClient();

            //String msg = "Confirmation From IPA\r\n";
            //msg += "\r\nThe Request of Patient No." + Patient_ID + " has been confirmed.";
            //msg += "\r\nPlease refer mail for the details.";
            //string baseurl = "http://smsidea.co.in/sendsms.aspx?mobile=9574017480&pass=prabhu&senderid=WEBSMS&to=" + smstoServiceProvider + "&msg=" + msg + "";
            //Stream data = client.OpenRead(baseurl);
            //StreamReader reader = new StreamReader(data);
            //string s = reader.ReadToEnd();


            ////Send SMS To Patient

            //WebClient client1 = new WebClient();

            //String msg1 = "Confirmation From IPA\r\n";
            //msg1 += "\r\nYour Request For Medical Help has been confirmed.\r\nPlease refer mail for the details";
            //string baseurl1 = "http://smsidea.co.in/sendsms.aspx?mobile=9574017480&pass=prabhu&senderid=WEBSMS&to=" + smstoPatient + "&msg=" + msg1 + "";
            //Stream data1 = client1.OpenRead(baseurl1);
            //StreamReader reader1 = new StreamReader(data1);
            //string s1 = reader1.ReadToEnd();



            //Send Email to Patient 

            String mail1to = objPatient.Ds.Tables[0].Rows[0]["Email"].ToString();
            String sms1to = objPatient.Ds.Tables[0].Rows[0]["MobileNo"].ToString();





           // Send Email


             fromAddress = new MailAddress("IPANGO992015@gmail.com");
             fromPassword = "IPANGO2015";

            using (System.Net.Mail.MailMessage msg1 = new System.Net.Mail.MailMessage())
            {
                System.Net.Mail.SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = false;


                smtpClient.Credentials = new NetworkCredential(fromAddress.Address, fromPassword);
                msg1.From = new MailAddress("IPANGO992015@gmail.com");

                // send mail...

                msg1.To.Add(mail1to);   //Dynamic
                string Body = "";
                Body = "<b><big>" + "Confirmation from IPA" + "</big></b><br/><br/>";
                Body += "Your Request has been confirmed. " + "<br/>" + "Take a Print out of this attachment when you come for getting services" + "<br/>";
                Body += "<" + strURLWithData + ">Contact Details</a>";
                msg1.Subject = "Confirmation from IPA";
                msg1.IsBodyHtml = true;
                msg1.Body = Body;
                smtpClient.Timeout = 1000000;
            //    smtpClient.Send(msg1);

            }



           //// Send SMS To Patient


           // WebClient client = new WebClient();

           // String msg = "A new task is assigned from IPA\r\nTask:" + txtSubject.Text;
           // //msg+=    "\r\nCompletion Date:" + txtCDate.Text;
           // msg += "\r\nFor more details: refer mail or login to system";
           // string baseurl = "http://smsidea.co.in/sendsms.aspx?mobile=9574017480&pass=prabhu&senderid=WEBSMS&to=" + smsto + "&msg=" + msg + "";
           // Stream data = client.OpenRead(baseurl);
           // StreamReader reader = new StreamReader(data);
           // string s = reader.ReadToEnd();



            //string message = "Task is successfully assigned to  + ddlVName.SelectedItem.Text";
            //string url = "ViewTask.aspx";
            //string script = "window.onload = function(){ alert('";
            //script += message;
            //script += "');";
            //script += "window.location = '";
            //script += url;
            //script += "'; }";
            //ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);


            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert (Task is successfully assigned. ); </script>");

            Response.Redirect("~/AdminLab/ViewTask.aspx");


            objPatient.Patient_ID1 = Convert.ToInt16(Patient_ID);
            objPatient.ServiceProviderUser_ID1 = Convert.ToInt16(User_ID);
            objPatient.UpdateServiceProviderID();




            Response.Write("<script language='javascript'>window.alert('Confirmation is sent by Email and SMS');window.location='PatientDetail.aspx';</script>");

        }

        public string EncryptQueryString(string strQueryString)
        {

            BusLib.Common.EncryptDecryptQueryString objEDQueryString = new BusLib.Common.EncryptDecryptQueryString();
            return objEDQueryString.Encrypt(strQueryString, "r0b1nr0y");
        }




        //Confirmed Request End

    }




}
