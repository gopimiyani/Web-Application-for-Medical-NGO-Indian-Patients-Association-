using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPA1.VolunteerLab
{
    public partial class Search1 : System.Web.UI.Page
    {
        BusLib.Common.Registration objUser = new BusLib.Common.Registration();
        BusLib.Master.SHMast objSH = new BusLib.Master.SHMast();
        BusLib.Common.Registration objUserRegister = new BusLib.Common.Registration();
        BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();
        int User_ID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillddlSH();
                FillddlSH1();

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
            //  ddlselecttype.SelectedIndex = 0;
            //ddlselecttype.SelectedItem.Text = "Volunteer";
            ddlselecttype.DataBind();


        }

        void FillddlSH1()
        {
            objSH.GetDataSet("");
            ddlUserType.AppendDataBoundItems = true;
            ddlUserType.Items.Add(new ListItem("--Select User Type--", "--Select User Type--"));
            // objSH.Ds.Tables[0].DefaultView.Sort = "Name";
            ddlUserType.DataSource = objSH.Ds.Tables[0];
            ddlUserType.DataTextField = "Name";
            ddlUserType.DataValueField = "StakeHolder_ID";
            //  ddlselecttype.SelectedIndex = 0;
            //ddlselecttype.SelectedItem.Text = "Volunteer";
            ddlUserType.DataBind();
        }
        protected void ddlselecttype_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (txtSearch.Text != "")
            {

                objRegistration.PinCode1 = Convert.ToInt32(txtSearch.Text);
                objRegistration.StackHolder1 = ddlselecttype.SelectedItem.Text;
                objRegistration.GetDataSet_Search();
                gvUser.DataSource = objRegistration.Ds;
                gvUser.DataBind();
            }

        }

        protected void ddlselecttype_TextChanged1(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {

                objRegistration.PinCode1 = Convert.ToInt32(txtSearch.Text);
                objRegistration.StackHolder1 = ddlselecttype.SelectedItem.Text;
                objRegistration.GetDataSet_Search();
                gvUser.DataSource = objRegistration.Ds;
                gvUser.DataBind();
            }
        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }







        protected void btnSearch_Click(object sender, EventArgs e)
        {

            objRegistration.PinCode1 = Convert.ToInt32(txtSearch.Text);
            objRegistration.StackHolder1 = ddlselecttype.SelectedItem.Text;
            objRegistration.GetDataSet_Search();
            gvUser.DataSource = objRegistration.Ds;
            gvUser.DataBind();


        }

        void UserDetailDisplay()
        {
            if (User_ID != 0)
            {
                objUserRegister.User_ID1 = Convert.ToInt16(User_ID.ToString());
                objUserRegister.GetDataSet_GetUserDetail();
                //txtUserID.Text = objUserRegister.Ds.Tables[0].Rows[0]["User_ID"].ToString();

                ddlUserType.SelectedItem.Text = objUserRegister.Ds.Tables[0].Rows[0]["StackHolder"].ToString();
                txtFirstName.Text = objUserRegister.Ds.Tables[0].Rows[0]["FirstName"].ToString() + " " + objUserRegister.Ds.Tables[0].Rows[0]["LastName"].ToString();

                // txtUserName.Text = objUserRegister.Ds.Tables[0].Rows[0]["UserName"].ToString();
                txtEmail.Text = objUserRegister.Ds.Tables[0].Rows[0]["Email"].ToString();
                // txtPassword.Text = objUserRegister.Ds.Tables[0].Rows[0]["Password"].ToString();
                //txtConfirmPassword.Text = objUserRegister.Ds.Tables[0].Rows[0]["ConfirmPassword"].ToString();
                txtAddress.Text = objUserRegister.Ds.Tables[0].Rows[0]["Address"].ToString() + ", " + objUserRegister.Ds.Tables[0].Rows[0]["City"].ToString() + "- " + objUserRegister.Ds.Tables[0].Rows[0]["PinCode"].ToString() + ", " + objUserRegister.Ds.Tables[0].Rows[0]["State"].ToString();

                txtMobileNo.Text = objUserRegister.Ds.Tables[0].Rows[0]["MobileNo"].ToString();
                //ImgProfilePic.ImageUrl = "../ProfilePic/" + objUserRegister.Ds.Tables[0].Rows[0]["ProfilePic"].ToString();
                //        TextBox txtUserType = objUserRegister.Ds.Tables[0].Rows[0]["StackHolder"] as TextBox;
                //   MvRegister.ActiveViewIndex = Convert.ToInt16(ddlUserType.SelectedValue);
                if (ddlUserType.SelectedItem.Text == "Volunteer")
                {
                    MvRegister.ActiveViewIndex = 0;


                }
                else if (ddlUserType.SelectedItem.Text == "Donor")
                {
                    MvRegister.ActiveViewIndex = 1;

                }

                else if (ddlUserType.SelectedItem.Text == "Hospital")
                {
                    MvRegister.ActiveViewIndex = 2;

                }

                else if (ddlUserType.SelectedItem.Text == "BloodBank")
                {
                    MvRegister.ActiveViewIndex = 3;

                }

                else if (ddlUserType.SelectedItem.Text == "PharmaCompany")
                {
                    MvRegister.ActiveViewIndex = 4;

                }

                else if (ddlUserType.SelectedItem.Text == "Doctor")
                {
                    MvRegister.ActiveViewIndex = 5;

                }

                else if (ddlUserType.SelectedItem.Text == "NGO")
                {
                    MvRegister.ActiveViewIndex = 6;

                }
                else
                {
                    MvRegister.ActiveViewIndex = 7;

                }

                if (ddlUserType.SelectedItem.ToString() == "Volunteer")
                {
                    //VddlBloodGroup.SelectedItem.Text = objUserRegister.Ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                    //VtxtDOB.Text = objUserRegister.Ds.Tables[0].Rows[0]["BirthDate"].ToString();

                }
                else if (ddlUserType.SelectedItem.ToString() == "Donor")
                {
                    //DddlBloodGroup.SelectedItem.Text = objUserRegister.Ds.Tables[0].Rows[0]["BloodGroup"].ToString();
                    //DtxtDOB.Text = objUserRegister.Ds.Tables[0].Rows[0]["BirthDate"].ToString();

                }
                else if (ddlUserType.SelectedItem.ToString() == "Hospital")
                {

                    //   ImgHIdProof.ImageUrl = "../IdProof/" + objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    //HtxtWebsite.Text = objUserRegister.Ds.Tables[0].Rows[0]["Website"].ToString();
                    //HtxtContactPerson.Text = objUserRegister.Ds.Tables[0].Rows[0]["ContactPerson"].ToString();

                }
                else if (ddlUserType.SelectedItem.ToString() == "BloodBank")
                {


                    // ImgBIdProof.ImageUrl="~//IdProof//" + BfuIdProof.FileName;
                    //  ImgBIdProof.ImageUrl = "../IdProof/" + objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    //BtxtWebsite.Text = objUserRegister.Ds.Tables[0].Rows[0]["Website"].ToString();
                    //BtxtContactPerson.Text = objUserRegister.Ds.Tables[0].Rows[0]["ContactPerson"].ToString();

                }
                else if (ddlUserType.SelectedItem.ToString() == "PharmaCompany")
                {

                    // ImgPIdProof.ImageUrl = "../IdProof/" + objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    //PtxtWebsite.Text = objUserRegister.Ds.Tables[0].Rows[0]["Website"].ToString();
                    //PtxtContactPerson.Text = objUserRegister.Ds.Tables[0].Rows[0]["ContactPerson"].ToString();

                }
                else if (ddlUserType.SelectedItem.ToString() == "Doctor")
                {
                    //  ImgDIdProof.ImageUrl = "../IdProof/" + objUserRegister.Ds.Tables[0].Rows[0]["IdProof"].ToString();
                    //  DotxtDegree.Text = objUserRegister.Ds.Tables[0].Rows[0]["Degree"].ToString();
                    //  DotxtDisease.Text = objUserRegister.Ds.Tables[0].Rows[0]["Disease"].ToString();

                }

                else if (ddlUserType.SelectedItem.ToString() == "NGO")
                {
                    //  NtxtPurpose.Text = objUserRegister.Ds.Tables[0].Rows[0]["Purpose"].ToString();
                    //NtxtMission.Text = objUserRegister.Ds.Tables[0].Rows[0]["Mission"].ToString();
                    //NtxtWebsite.Text = objUserRegister.Ds.Tables[0].Rows[0]["Website"].ToString();

                }

            }



        }



        //protected void gvPCDetail_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gvPCDetail.EditIndex = e.NewEditIndex;
        //    BindGrid1();
        //}

        //protected void gvPCDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{

        //    DataTable tb = (DataTable)(Session["dt"]);
        //    tb.Rows.RemoveAt(e.RowIndex); //deleting the records and decreasing the  total
        //    BindGrid1(); //calling the tempdata form refresh the output

        //}

        //protected void gvPCDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    gvPCDetail.EditIndex = -1;
        //    BindGrid1();
        //}


        protected void gvUser_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvUser_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUser.PageIndex = e.NewPageIndex;

        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void gvUser_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                //  Response.Redirect("~/Admin_ViewUserDetail.aspx?User_ID=" + e.CommandArgument.ToString() + "");
                User_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvSeach.ActiveViewIndex = 1;

                FillddlSH1();

                UserDetailDisplay();

            }

        }

        protected void ddlUserType_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        protected void cvddlselecttype_ServerValidate1(object source, ServerValidateEventArgs args)
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

        protected void lbSearch_Click(object sender, EventArgs e)
        {
            mvSeach.ActiveViewIndex = 0;
        }

    }
}