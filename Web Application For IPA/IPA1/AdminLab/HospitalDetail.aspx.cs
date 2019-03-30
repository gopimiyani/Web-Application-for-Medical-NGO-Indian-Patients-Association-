using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace IPA1.AdminLab
{
    public partial class HospitalDetail : System.Web.UI.Page
    {
        BusLib.Transaction.HospitalDetail objHPDetail = new BusLib.Transaction.HospitalDetail();
        BusLib.Transaction.HospitalServiceDetail objHPServiceDetail = new BusLib.Transaction.HospitalServiceDetail();
        BusLib.Transaction.Patient objPatient = new BusLib.Transaction.Patient();
        
        int HospitalDetail_ID = 0;

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
            if (!IsPostBack)
            {
                ViewState["BindGrid_DB"] = 0;
                FillddlHospitalName();

                txtAdmitDate.Attributes.Add("readonly", "readonly");
                txtDischargeDate.Attributes.Add("readonly", "readonly");

                txtAdmitDate_CalendarExtender.EndDate = DateTime.Now;
                txtDischargeDate_CalendarExtender.EndDate = DateTime.Now;
    
                BindGrid();
            }
        }


        void BindGrid()
        {
            objHPDetail.GetDataSet(ddlHospitalName.SelectedValue, "");
            mvHospital.ActiveViewIndex = 0;
            gvHospital.DataSource = objHPDetail.Ds;
            gvHospital.DataBind();
            if (objHPDetail.Ds.Tables[0].Rows.Count == 1 && objHPDetail.Ds.Tables[0].Rows[0]["HospitalDetail_ID"].ToString() == "")
            {
                Button btnView = gvHospital.Rows[0].FindControl("btnView") as Button;
                btnView.Visible = false;
            }
        }

        void FillddlHospitalName()
        {
            objHPDetail.GetDataSet_GetHospitalName();
            ddlHospitalName.AppendDataBoundItems = true;

            ddlHospitalName.Items.Add(new ListItem("--Select Name | ID--", ""));
            ddlHospitalName.DataSource = objHPDetail.Ds.Tables[0];
            ddlHospitalName.DataTextField = "Name";
            ddlHospitalName.DataValueField = "User_ID";
            ddlHospitalName.SelectedIndex = 0;
            ddlHospitalName.DataBind();

        }


        protected void gvHospital_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHospital.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/HospitalDetailForm.aspx");
        }


        protected void ddlRecPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlRecPerPage.SelectedValue == "All")
            {
                gvHospital.AllowPaging = false;
                BindGrid();
            }

            else
            {
                gvHospital.AllowPaging = true;
                gvHospital.PageSize = Convert.ToInt16(ddlRecPerPage.SelectedValue);
                BindGrid();
            }
        }

        protected void gvHospital_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                HospitalDetail_ID = Convert.ToInt16(e.CommandArgument.ToString());
                mvHospital.ActiveViewIndex = 1;
                ViewState["BindGrid_DB"] = 0;
                FillddlHospitalName1();
                FillddlPatientName1();

                ddlHour.Items.Clear();
                ddlMinute.Items.Clear();
                ddlHour1.Items.Clear();
                ddlMinute1.Items.Clear();
               
                FillddlHour();
                FillddlMinute();
                ViewHospitalServiceDetail();
            }
        }


        protected void ddlHospitalName_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }


        protected void gvHospital_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            gvHospital.PageIndex = e.NewPageIndex;
            BindGrid();
        }



        //Hospital Detail

        void FillddlPatientName1()
        {
            objPatient.GetViewPatientName();
            ddlPName.Items.Add(new ListItem("--Select Name | ID--", ""));
            ddlPName.DataSource = objPatient.Ds.Tables[0];
            ddlPName.DataTextField = "Name";
            ddlPName.DataValueField = "Patient_ID";
            ddlPName.SelectedIndex = 0;
            ddlPName.DataBind();

        }

        void FillddlHospitalName1()
        {
            objHPDetail.GetDataSet_GetHospitalName();
            ddlHospitalName1.Items.Add(new ListItem("--Select Name | ID--", ""));
            ddlHospitalName1.DataSource = objHPDetail.Ds.Tables[0];
            ddlHospitalName1.DataTextField = "Name";
            ddlHospitalName1.DataValueField = "User_ID";
            ddlHospitalName1.SelectedIndex = 0;
            ddlHospitalName1.DataBind();
        }

        void FillddlHour()
        {
            ddlHour.Items.Add(new ListItem("-HH-", ""));
            ddlHour1.Items.Add(new ListItem("-HH-", ""));

            for (int i = 1; i < 13; i++)
            {
                if (i < 10)
                {
                    ddlHour.Items.Add(new ListItem("0" + i.ToString(), "0" + i.ToString()));
                    ddlHour1.Items.Add(new ListItem("0" + i.ToString(), "0" + i.ToString()));
                }
                else
                {
                    ddlHour.Items.Add(new ListItem(i.ToString(), i.ToString()));
                    ddlHour1.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

            }
            ddlHour.SelectedIndex = 0;
            ddlHour1.SelectedIndex = 0;

        }
        void FillddlMinute()
        {
            ddlMinute.Items.Add(new ListItem("-MM-"));
            ddlMinute1.Items.Add(new ListItem("-MM-"));
            for (int i = 0; i < 60; i = i + 5)
            {
                if (i <= 5)
                {
                    ddlMinute.Items.Add(new ListItem(("0" + i).ToString(), ("0" + i).ToString()));
                    ddlMinute1.Items.Add(new ListItem(("0" + i).ToString(), ("0" + i).ToString()));
                }
                else
                {
                    ddlMinute.Items.Add(new ListItem((i).ToString(), (i).ToString()));
                    ddlMinute1.Items.Add(new ListItem((i).ToString(), (i).ToString()));
                }

            }
            ddlMinute.SelectedIndex = 0;
            ddlMinute1.SelectedIndex = 0;
        }
        void FillddlAMPM()
        {
            ddlAMPM.Items.Add(new ListItem("AM", "AM"));
            ddlAMPM.Items.Add(new ListItem("PM", "PM"));
            ddlAMPM.SelectedIndex = 1;

            // Actual CTime
            ddlAMPM1.Items.Add(new ListItem("AM", "AM"));
            ddlAMPM1.Items.Add(new ListItem("PM", "PM"));
            ddlAMPM1.SelectedIndex = 1;
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


        void ViewHospitalServiceDetail()
        {
            if (HospitalDetail_ID != 0)
            {
                lblcvAdmitTime.Text = "";
                lblcvDischargeDate.Text = "";
                lblcvDischargeTime.Text = "";
                lblcvDischargeDate.Text = "";
                lblcvDiscount.Text = "";
                lblcvTAmount.Text = "";

                ddlHour.Items.Clear();
                ddlMinute.Items.Clear();
                ddlAMPM.Items.Clear();
                ddlHour1.Items.Clear();
                ddlMinute1.Items.Clear();
                ddlAMPM1.Items.Clear();

                FillddlHour();
                FillddlMinute();
                FillddlAMPM();
         

                objHPDetail.HospitalDetail_ID1 = Convert.ToInt16(HospitalDetail_ID.ToString());
                objHPDetail.GetDataSet();

                ddlPName.Enabled = false;
                ddlHospitalName1.Enabled = false;
                txtBillNo.Enabled = false;

                txtHospitalDetail_ID.Text = objHPDetail.Ds.Tables[0].Rows[0]["HospitalDetail_ID"].ToString();
                ddlPName.SelectedValue = objHPDetail.Ds.Tables[0].Rows[0]["Patient_ID"].ToString();
         
                ddlHospitalName1.SelectedValue = objHPDetail.Ds.Tables[0].Rows[0]["User_ID"].ToString();
                txtBillNo.Text = objHPDetail.Ds.Tables[0].Rows[0]["BillNo"].ToString();

                txtDName.Text = objHPDetail.Ds.Tables[0].Rows[0]["DoctorName"].ToString();

                txtAdmitDate.Text = objHPDetail.Ds.Tables[0].Rows[0]["AdmitDate"].ToString();

                if (objHPDetail.Ds.Tables[0].Rows[0]["AdmitTime"].ToString() != "")
                {
                    String ATime = objHPDetail.Ds.Tables[0].Rows[0]["AdmitTime"].ToString();
                    ddlHour.Text = ATime.Substring(0, 2);
                    ddlMinute.Text = ATime.Substring(3, 2);
                    ddlAMPM.Text = ATime.Substring(6, 2);

                }

                if (txtAdmitDate.Text != "")
                {
                    txtDischargeDate_CalendarExtender.StartDate = DateTime.ParseExact(txtAdmitDate.Text, "dd-MM-yyyy", null);

                }
                if (objHPDetail.Ds.Tables[0].Rows[0]["DischargeDate"].ToString() != "")
                {
                    txtDischargeDate.Text = objHPDetail.Ds.Tables[0].Rows[0]["DischargeDate"].ToString();

                }

                if (objHPDetail.Ds.Tables[0].Rows[0]["DischargeTime"].ToString() != "")
                {
                    String DTime = objHPDetail.Ds.Tables[0].Rows[0]["DischargeTime"].ToString();
                    ddlHour1.Text = DTime.Substring(0, 2);
                    ddlMinute1.Text = DTime.Substring(3, 2);
                    ddlAMPM1.Text = DTime.Substring(6, 2);

                }


                txtTAmount.Text = objHPDetail.Ds.Tables[0].Rows[0]["TotalAmount"].ToString();
                txtDiscount.Text = objHPDetail.Ds.Tables[0].Rows[0]["Discount"].ToString();
                txtDiscountAmount.Text = objHPDetail.Ds.Tables[0].Rows[0]["DiscountAmount"].ToString();
                txtFinalAmount.Text = objHPDetail.Ds.Tables[0].Rows[0]["FinalAmount"].ToString();
                String PStatus = objHPDetail.Ds.Tables[0].Rows[0]["PaymentStatus"].ToString();

                if (PStatus == "UnPaid")
                {
                    ddlPStatus.SelectedValue = "Unpaid";

                    txtDName.Enabled = true;
                    txtAdmitDate.Enabled = true;
                    txtDischargeDate.Enabled = true;
                    ddlHour.Enabled = true;
                    ddlMinute.Enabled = true;
                    ddlAMPM.Enabled = true;
                    ddlHour1.Enabled = true;
                    ddlMinute1.Enabled = true;
                    ddlAMPM1.Enabled = true;
                    txtDiscount.Enabled = true;

                    ddlPName.Enabled = false;
                    ddlPStatus.Enabled = false;

                    gvHospitalDetail.Columns[3].Visible = true;
                    gvHospitalDetail.Columns[4].Visible = true;

                    //    gvHospitalDetail.FooterRow.FindControl("txtIServiceDescription").Visible = false;
                    //   gvHospitalDetail.FooterRow.FindControl("txtIServiceCharge").Visible = false;


                    btnSubmit.Visible = true;
                    btnReset.Visible = true;
                }
                else
                {
                    ddlPStatus.SelectedValue = "Paid";

                    txtDName.Enabled = false;
                    ddlPName.Enabled = false;
                    txtAdmitDate.Enabled = false;
                    txtDischargeDate.Enabled = false;
                    ddlHour.Enabled = false;
                    ddlMinute.Enabled = false;
                    ddlAMPM.Enabled = false;
                    ddlHour1.Enabled = false;
                    ddlMinute1.Enabled = false;
                    ddlAMPM1.Enabled = false;
                    txtDiscount.Enabled = false;

                    ddlPName.Enabled = false;
                    ddlPStatus.Enabled = false;

                    gvHospitalDetail.Columns[3].Visible = false;
                    gvHospitalDetail.Columns[4].Visible = false;


                    btnSubmit.Visible = false;
                    btnReset.Visible = false;
                }
              
                BindTable();
                BindGrid1();
            }
        }

        private void BindGrid1()
        {
            objHPDetail.HospitalDetail_ID1 = Convert.ToInt16(HospitalDetail_ID.ToString());
            objHPDetail.GetDataSet();


            DataTable tb = (DataTable)Session["dt"];

            if (ViewState["BindGrid_DB"].ToString() != "1")
            {
          

                for (int i = 0; i < objHPDetail.Ds.Tables[1].Rows.Count; i++)
                {
                    DataRow r1 = tb.NewRow();
                    r1["id"] = i + 1;
                    r1["HospitalServiceDetail_ID"] = objHPDetail.Ds.Tables[1].Rows[i]["HospitalServiceDetail_ID"].ToString();

                    r1["ServiceDescription"] = objHPDetail.Ds.Tables[1].Rows[i]["ServiceDescription"].ToString();
                    r1["ServiceCharges"] = objHPDetail.Ds.Tables[1].Rows[i]["ServiceCharges"].ToString();
                    tb.Rows.Add(r1);
                }
                Session["dt"] = tb;
                gvHospitalDetail.DataSource = tb;
                gvHospitalDetail.DataBind();
                ViewState["BindGrid_DB"] = 1;
                decimal TAmount = 0;
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    TAmount += Convert.ToDecimal(tb.Rows[i]["ServiceCharges"].ToString());
                }
                txtTAmount.Text = TAmount.ToString();



                if (tb.Rows[0]["id"].ToString() == "")
                {
                    gvHospitalDetail.Rows[0].Visible = false;
                }
            }

            int a = 0;
            if (tb.Rows.Count == 0)
            {
                tb.Rows.Add(tb.NewRow());
                Session["dt"] = tb;

                gvHospitalDetail.DataSource = (DataTable)(Session["dt"]);
                gvHospitalDetail.DataBind(); // gridview
                a = 1;

            }
            else
            {
                decimal TAmount = 0;
                gvHospitalDetail.DataSource = (DataTable)(Session["dt"]);// storing in “tb” datatable variable and bind with
                gvHospitalDetail.DataBind(); // gridview
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    TAmount += Convert.ToDecimal(tb.Rows[i]["ServiceCharges"].ToString());
                }
                txtTAmount.Text = TAmount.ToString();


                if (tb.Rows[0]["id"].ToString() == "")
                {
                    gvHospitalDetail.Rows[0].Visible = false;
                }

            }
            if (a == 1)
            {
                gvHospitalDetail.Rows[0].Visible = false;
            }

        }

        private void BindTable()
        {
            DataTable HospitalServiceDetail = new DataTable("Table"); //the “Table” value must be same for
            DataColumn c = new DataColumn();        // always
            HospitalServiceDetail.Columns.Add(new DataColumn("id", Type.GetType("System.Int16")));
            HospitalServiceDetail.Columns.Add(new DataColumn("HospitalServiceDetail_ID", Type.GetType("System.Int16")));
            HospitalServiceDetail.Columns.Add(new DataColumn("ServiceDescription", Type.GetType("System.String")));
            HospitalServiceDetail.Columns.Add(new DataColumn("ServiceCharges", Type.GetType("System.Double")));

            Session["dt"] = HospitalServiceDetail;
        }


        protected void btnInsert_Click(object sender, EventArgs e)
        {
            TextBox txtIServiceDescription = gvHospitalDetail.FooterRow.FindControl("txtIServiceDescription") as TextBox;
            TextBox txtIServiceCharge = gvHospitalDetail.FooterRow.FindControl("txtIServiceCharge") as TextBox;
            Label lblcvIServiceCharge = gvHospitalDetail.FooterRow.FindControl("lblcvIServiceCharge") as Label;

            if (txtIServiceCharge.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtIServiceCharge.Text))
                {
                    //   lblcvIRate.ForeColor = System.Drawing.Color.Red;

                    lblcvIServiceCharge.Text = "";

                }
                else
                {
                    lblcvIServiceCharge.Text = "Enter valid Service Charge(e.g 100.12)";
                    return;


                }
            }



            DataTable tb = (DataTable)(Session["dt"]);
            DataRow r1 = tb.NewRow();
            r1["id"] = tb.Rows.Count + 1;
            r1["ServiceDescription"] = txtIServiceDescription.Text;
            r1["ServiceCharges"] = txtIServiceCharge.Text;
            tb.Rows.Add(r1);
            Session["dt"] = tb;
            BindGrid1();
        }


        protected void gvHospitalDetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable tb = (DataTable)(Session["dt"]);
            tb.Rows.RemoveAt(e.RowIndex); //deleting the records and decreasing the  total
            BindGrid1(); //calling the tempdata form refresh the output
        }

        protected void gvHospitalDetail_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHospitalDetail.EditIndex = e.NewEditIndex;
            BindGrid1();
        }

        protected void gvHospitalDetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //GridViewRow row = gvHospitalDetail.Rows[e.RowIndex];
            //TextBox txtId = row.FindControl("txtId") as TextBox;
            //TextBox txtDesc = row.FindControl("txtServiceDescription") as TextBox;
            //TextBox txtCharge = row.FindControl("txtServiceCharge") as TextBox;



            GridViewRow row = gvHospitalDetail.Rows[gvHospitalDetail.EditIndex];
            TextBox txtId = row.FindControl("txtId") as TextBox;
            TextBox txtServiceCharge = row.FindControl("txtServiceCharge") as TextBox;
            TextBox txtServiceDescription = row.FindControl("txtServiceDescription") as TextBox;
            Label lblcvServiceCharge = row.FindControl("lblcvServiceCharge") as Label;

            if (txtServiceCharge.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtServiceCharge.Text))
                {


                    lblcvServiceCharge.Text = "";

                }
                else
                {
                    lblcvServiceCharge.Text = "Enter valid Service Charge(e.g 100.12)";
                    return;
                }
            }




            DataTable tb1 = (DataTable)Session["dt"];
            DataRow r = tb1.Select("id =" + txtId.Text + "").FirstOrDefault();
            r["id"] = txtId.Text;
            r["ServiceDescription"] = txtServiceDescription.Text;
            r["ServiceCharges"] = txtServiceCharge.Text;


            Session["dt"] = tb1;
            gvHospitalDetail.EditIndex = -1;
            BindGrid1();


        }

        protected void gvHospitalDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHospitalDetail.PageIndex = e.NewPageIndex;
            BindGrid1();

        }

        protected void gvHospitalDetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHospitalDetail.EditIndex = -1;
            BindGrid1();
        }


        protected void txtDiscount_TextChanged(object sender, EventArgs e)
        {

            if (txtDiscount.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtDiscount.Text))
                {
                    if ((Convert.ToDecimal(txtDiscount.Text)).CompareTo(new decimal(100.00)) > 0 || (Convert.ToDecimal(txtDiscount.Text)).CompareTo(new decimal(00.00)) < 0)
                    {

                        txtDiscountAmount.Text = "";
                        txtFinalAmount.Text = "";

                        lblcvDiscount.Text = "Enter valid Discount in between 0.00 to 100.00!";
                        return;



                    }
                    else
                    {


                        lblcvDiscount.Text = "";
                    }
                }
                else
                {

                    txtDiscountAmount.Text = "";
                    txtFinalAmount.Text = "";

                    lblcvDiscount.Text = "Enter valid Discount";
                    return;
                }

            }
            if (txtDiscount.Text == "")
            {
                lblcvDiscount.Visible = true;
                lblcvDiscount.Text = "Enter Discount!";
                lblcvDiscount.ForeColor = System.Drawing.Color.Red;
                txtDiscountAmount.Text = "";
                txtFinalAmount.Text = "";
                return;
            }



            if (txtDiscount.Text != "" && txtTAmount.Text != "")
            {
                //objHospitalDetail.DiscountAmount1 = (Convert.ToInt16(txtTAmount.Text.Trim()) * (Convert.ToInt16(txtDiscount.Text.Trim())) / 100);
                //objHospitalDetail.FinalAmount1 = Convert.ToInt16(txtTAmount.Text) - objHospitalDetail.DiscountAmount1;
                //txtDiscountAmount.Text = Convert.ToString(objHospitalDetail.DiscountAmount1);
                //txtFinalAmount.Text = Convert.ToString(objHospitalDetail.FinalAmount1);



                Decimal DiscountAmount = (Convert.ToDecimal(txtTAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100);
                Decimal FinalAmount = Convert.ToDecimal(txtTAmount.Text.Trim()) - DiscountAmount;
                txtDiscountAmount.Text = DiscountAmount.ToString();
                txtFinalAmount.Text = FinalAmount.ToString();


                lblcvDiscount.Visible = false;

            }

        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {



            if (ddlHour.SelectedIndex == 0 || ddlMinute.SelectedIndex == 0)
            {
                lblcvAdmitTime.Text = "please fill the Admint Time properly";
                return;
            }
            else
            {
                lblcvAdmitTime.Text = "";

            }

            if (ddlHour1.SelectedIndex == 0 || ddlMinute1.SelectedIndex == 0)
            {
                lblcvDischargeTime.Text = "please fill the Discharge Time properly";
                return;
            }
            else
            {
                lblcvDischargeTime.Text = "";

            }

            if (txtDischargeDate.Text != "")
            {
                if (Convert.ToDateTime(ConvertDate(txtDischargeDate.Text)).CompareTo(Convert.ToDateTime(ConvertDate(txtAdmitDate.Text))) < 0)
                {
                    lblcvDischargeDate.Text = "Discharge date can not be before admit date";
                    return;
                }
                else
                {
                    lblcvDischargeDate.Text = "";

                }
            }
            if ((ddlHour1.SelectedIndex == 0 && ddlMinute1.SelectedIndex != 0) || (ddlHour1.SelectedIndex != 0 && ddlMinute1.SelectedIndex == 0))
            {

                lblcvDischargeTime.Text = "please fill the Discharge Time properly";
                return;
            }
            else
            {
                lblcvDischargeTime.Text = "";
               
            }

            if (ddlHour1.SelectedIndex != 0 && ddlMinute1.SelectedIndex != 0)
            {
                if (txtDischargeDate.Text == "")
                {
                    lblcvDischargeDate.Text = "Please fill the discharge date with discharge time";
                    return;
                }
                else
                {
                    lblcvDischargeDate.Text = "";
                }

            }

            if (txtDischargeDate.Text != "")
            {
                if (ddlHour1.SelectedIndex != 0 && ddlMinute1.SelectedIndex != 0)
                {
                    if (Convert.ToDateTime(ConvertDate(txtDischargeDate.Text)).Equals(Convert.ToDateTime(ConvertDate(txtAdmitDate.Text))))
                    {

                        String A_Time = ddlHour.SelectedItem.Text + ":" + ddlMinute.SelectedItem.Text + " " + ddlAMPM.SelectedItem.Text;
                        String D_Time = ddlHour1.SelectedItem.Text + ":" + ddlMinute1.SelectedItem.Text + " " + ddlAMPM1.SelectedItem.Text;

                        if (Convert.ToDateTime(D_Time) <= Convert.ToDateTime(A_Time))
                        {
                            lblcvDischargeTime.Text = "Dischage time can not be on or before Admit time !";
                            return;
                        }
                        else
                        {
                            lblcvDischargeTime.Text = "";
                        }
                    }

                }
            }


            if (txtTAmount.Text == "0")
            {
                lblcvTAmount.Text = "Total Amount can not be 0";
                return;
            }
            else
            {
                lblcvTAmount.Text = "";
            }


            if (txtDiscount.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtDiscount.Text))
                {
                    if ((Convert.ToDecimal(txtDiscount.Text)).CompareTo(new decimal(100.00)) > 0 || (Convert.ToDecimal(txtDiscount.Text)).CompareTo(new decimal(00.00)) < 0)
                    {

                        txtDiscountAmount.Text = "";
                        txtFinalAmount.Text = "";

                        lblcvDiscount.Text = "Enter valid Discount in between 0.00 to 100.00!";
                        return;



                    }
                    else
                    {


                        lblcvDiscount.Text = "";
                    }
                }
                else
                {

                    txtDiscountAmount.Text = "";
                    txtFinalAmount.Text = "";

                    lblcvDiscount.Text = "Enter valid Discount";
                    return;
                }

            }
            if (txtDiscount.Text == "")
            {
                lblcvDiscount.Visible = true;
                lblcvDiscount.Text = "Enter Discount!";
                lblcvDiscount.ForeColor = System.Drawing.Color.Red;
                txtDiscountAmount.Text = "";
                txtFinalAmount.Text = "";
                return;
            }



            if (txtDiscount.Text != "" && txtTAmount.Text != "")
            {
                //objHospitalDetail.DiscountAmount1 = (Convert.ToInt16(txtTAmount.Text.Trim()) * (Convert.ToInt16(txtDiscount.Text.Trim())) / 100);
                //objHospitalDetail.FinalAmount1 = Convert.ToInt16(txtTAmount.Text) - objHospitalDetail.DiscountAmount1;
                //txtDiscountAmount.Text = Convert.ToString(objHospitalDetail.DiscountAmount1);
                //txtFinalAmount.Text = Convert.ToString(objHospitalDetail.FinalAmount1);



                Decimal DiscountAmount = (Convert.ToDecimal(txtTAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100);
                Decimal FinalAmount = Convert.ToDecimal(txtTAmount.Text.Trim()) - DiscountAmount;
                txtDiscountAmount.Text = DiscountAmount.ToString();
                txtFinalAmount.Text = FinalAmount.ToString();


                lblcvDiscount.Visible = false;

            }


            objHPDetail.HospitalDetail_ID1 = Convert.ToInt16(txtHospitalDetail_ID.Text);
            objHPDetail.BillNo1 = Convert.ToInt16(txtBillNo.Text);
            objHPDetail.User_ID1 = Convert.ToInt16(ddlHospitalName1.SelectedValue);
            objHPDetail.Patient_ID1 = Convert.ToInt16(ddlPName.SelectedValue);

            objHPDetail.DoctorName1 = txtDName.Text;
            //objHPDetail.AdmitDate1 = txtAdmitDate.Text;
            //objHPDetail.AdmitTime1 = ddlHour.SelectedItem.Text + ":" + ddlMinute.SelectedItem.Text + " " + ddlAMPM.SelectedItem.Text;

            String ADate1 = ConvertDate(txtAdmitDate.Text);
            objHPDetail.AdmitDate1 = ADate1;
            String ATime1 = ddlHour.SelectedItem.Text + ":" + ddlMinute.SelectedItem.Text + " " + ddlAMPM.SelectedItem.Text;
            objHPDetail.AdmitTime1 = ATime1;

            //objHPDetail.DischargeDate1 = txtDischargeDate.Text;
            //objHPDetail.DischargeTime1 = ddlHour.SelectedItem.Text + ":" + ddlMinute.SelectedItem.Text + " " + ddlAMPM.SelectedItem.Text;

            String DDate1 = ConvertDate(txtDischargeDate.Text);
            objHPDetail.DischargeDate1 = DDate1;


            if (ddlHour1.SelectedIndex != 0 && ddlMinute1.SelectedIndex != 0)
            {
                String DTime1 = ddlHour1.SelectedItem.Text + ":" + ddlMinute1.SelectedItem.Text + " " + ddlAMPM1.SelectedItem.Text;
                objHPDetail.DischargeTime1 = DTime1;
            }
            else
            {
                objHPDetail.DischargeTime1 = "";
            }

            objHPDetail.TotalAmount1 = Convert.ToDecimal(txtTAmount.Text.Trim());
            objHPDetail.Discount1 = Convert.ToDecimal(txtDiscount.Text.Trim());
            objHPDetail.DiscountAmount1 = (Convert.ToDecimal(txtTAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100);
            objHPDetail.FinalAmount1 = Convert.ToDecimal(txtTAmount.Text) - objHPDetail.DiscountAmount1;
            if (ddlPStatus.SelectedValue == "Unpaid")
            {
                objHPDetail.PaymentStatus1 = false;
            }
            else
            {
                objHPDetail.PaymentStatus1 = true;
            }
            //objHPDetail.PaymentStatus1 = ddlPStatus.SelectedValue;
            objHPDetail.Update();

            DataTable tb = (DataTable)Session["dt"];
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                if (tb.Rows[i]["HospitalServiceDetail_ID"].ToString() != "")
                {
                    objHPServiceDetail.HospitalServiceDetail_ID1 = Convert.ToInt16(tb.Rows[i]["HospitalServiceDetail_ID"].ToString());
                }
                else
                {
                    objHPServiceDetail.HospitalServiceDetail_ID1 = 0;
                }
                objHPServiceDetail.HospitalDetail_ID1 = Convert.ToInt16(txtHospitalDetail_ID.Text);
                objHPServiceDetail.ServiceDescription1 = tb.Rows[i]["ServiceDescription"].ToString();
                objHPServiceDetail.ServiceCharges1 = Convert.ToDecimal(tb.Rows[i]["ServiceCharges"].ToString());

                objHPServiceDetail.Update();



            }
            Reset();
            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script language='javascript'> alert ('Hospital Service Detail Updated Successfully.'); </script>");
            mvHospital.ActiveViewIndex = 0;
            BindGrid();

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            mvHospital.ActiveViewIndex = 0;
        }

        protected void lbHospital_Click(object sender, EventArgs e)
        {
            mvHospital.ActiveViewIndex = 0;
            BindGrid();
        }

        void Reset()
        {
            ddlHospitalName1.ClearSelection();
            ddlPName.ClearSelection();
            ddlHour.ClearSelection();
            ddlHour1.ClearSelection();
            ddlMinute.ClearSelection();
            ddlMinute1.ClearSelection();
            ddlAMPM.ClearSelection();
            ddlAMPM1.ClearSelection();
         
            txtDiscount.Text = "";
            txtFinalAmount.Text = "";
            txtTAmount.Text = "";
            txtDiscountAmount.Text = "";
            lblcvTAmount.Text = "";
            lblcvAdmitTime.Text = "";
            lblcvDischargeTime.Text = "";
            lblcvDischargeDate.Text = "";


            DataTable tb = (DataTable)Session["dt"];
            tb.Rows.Clear();
            int a = 0;
            if (tb.Rows.Count == 0)
            {
                tb.Rows.Add(tb.NewRow());
                Session["dt"] = tb;

                gvHospitalDetail.DataSource = (DataTable)(Session["dt"]);
                gvHospitalDetail.DataBind(); // gridview
                a = 1;

            }

            if (a == 1)
            {
                gvHospitalDetail.Rows[0].Visible = false;
            }


        }

        protected void txtServiceCharge_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvHospitalDetail.Rows[gvHospitalDetail.EditIndex];
            TextBox txtServiceCharge = row.FindControl("txtServiceCharge") as TextBox;

            Label lblcvServiceCharge = row.FindControl("lblcvServiceCharge") as Label;

            if (txtServiceCharge.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtServiceCharge.Text))
                {


                    lblcvServiceCharge.Text = "";

                }
                else
                {
                    lblcvServiceCharge.Text = "Enter valid Service Charge(e.g 100.12)";
                    return;
                }
            }

        }

        protected void txtIServiceCharge_TextChanged(object sender, EventArgs e)
        {
            TextBox txtIServiceCharge = gvHospitalDetail.FooterRow.FindControl("txtIServiceCharge") as TextBox;
            Label lblcvIServiceCharge = gvHospitalDetail.FooterRow.FindControl("lblcvIServiceCharge") as Label;

            if (txtIServiceCharge.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtIServiceCharge.Text))
                {
                    //   lblcvIRate.ForeColor = System.Drawing.Color.Red;

                    lblcvIServiceCharge.Text = "";

                }
                else
                {
                    lblcvIServiceCharge.Text = "Enter valid Service Charge(e.g 100.12)";
                    return;


                }
            }


        }

        protected void txtAdmitDate_TextChanged(object sender, EventArgs e)
        {
            txtDischargeDate_CalendarExtender.StartDate = DateTime.ParseExact(txtAdmitDate.Text, "dd-MM-yyyy", null);
        }

        protected void txtDischargeDate_TextChanged(object sender, EventArgs e)
        {
            if (txtDischargeDate.Text != "")
            {
                if (Convert.ToDateTime(ConvertDate(txtDischargeDate.Text)).CompareTo(Convert.ToDateTime(ConvertDate(txtDischargeDate.Text))) < 0)
                {
                    lblcvDischargeDate.Text = "Discharge date can not be before admit date";
                    return;
                }
                else
                {
                    lblcvDischargeDate.Text = "";

                }
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


        protected void gvHospital_Sorting(object sender, GridViewSortEventArgs e)
        {
            objHPDetail.GetDataSet(Session["User_ID"].ToString(), "");

            dataTable = objHPDetail.Ds.Tables[0];
            SetSortDirection(SortDireaction);
            if (dataTable != null)
            {
                //Sort the data.
                SetSortDirection(SortDireaction);
                dataTable.DefaultView.Sort = e.SortExpression + " " + _sortDirection;
                gvHospital.DataSource = dataTable;
                gvHospital.DataBind();
                SortDireaction = _sortDirection;
                int columnIndex = 0;
                foreach (DataControlFieldHeaderCell headerCell in gvHospital.HeaderRow.Cells)
                {
                    if (headerCell.ContainingField.SortExpression == e.SortExpression)
                    {
                        columnIndex = gvHospital.HeaderRow.Cells.GetCellIndex(headerCell);
                    }
                }

                gvHospital.HeaderRow.Cells[columnIndex].Controls.Add(sortImage);
            }
        }

        
        //end detail
    }
}