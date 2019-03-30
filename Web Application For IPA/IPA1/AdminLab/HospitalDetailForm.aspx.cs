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
    public partial class HospitalDetailForm : System.Web.UI.Page
    {
        BusLib.Transaction.HospitalDetail objHospitalDetail = new BusLib.Transaction.HospitalDetail();
        BusLib.Transaction.Patient objPatient = new BusLib.Transaction.Patient();
        BusLib.Transaction.HospitalServiceDetail objHospitalServiceDetail = new BusLib.Transaction.HospitalServiceDetail();
        DataTable tb = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBillNo();
                FillddlHospitalName();
                FillddlPatientName();
                FillddlHour();
                FillddlMinute();
                FillddlAMPM();

                txtAdmitDate.Attributes.Add("readonly", "readonly");
                txtDischargeDate.Attributes.Add("readonly", "readonly");
                txtAdmitDate_CalendarExtender.EndDate = DateTime.Now;
                txtDischargeDate_CalendarExtender.EndDate = DateTime.Now;
                
                BindTable();
                BindGrid();
        
            
            }
        }

        void BindBillNo()
        {
            objHospitalDetail.GetNextBillNo();
            if (objHospitalDetail.Ds.Tables[0].Rows[0]["BillNo"].ToString()!="")
            {
                txtBillNo.Text = objHospitalDetail.Ds.Tables[0].Rows[0]["BillNo"].ToString();
            }
            else
            {
                txtBillNo.Text = "1";
            }
            
        }

        void FillddlHospitalName()
        {
            objHospitalDetail.GetDataSet_GetHospitalName();
            ddlHName.AppendDataBoundItems = true;
            ddlHName.Items.Add(new ListItem("--Select Name | ID--", ""));
            ddlHName.DataSource = objHospitalDetail.Ds.Tables[0];
            ddlHName.DataTextField = "Name";
            ddlHName.DataValueField = "User_ID";
            ddlHName.SelectedIndex = 0;
            ddlHName.DataBind();

        }


        void FillddlPatientName()
        {
            ddlPName.Items.Clear();
            ddlPName.AppendDataBoundItems = true;
            ddlPName.Items.Add(new ListItem("--Select Name | ID--", ""));
            if (ddlHName.SelectedIndex != 0)
            {
                objPatient.ServiceProviderUser_ID1 = Convert.ToInt16(ddlHName.SelectedValue);
                objPatient.GetNewPatientName();
                if (objPatient.Ds.Tables.Count != 0)
                {
                    if (objPatient.Ds.Tables[0].Rows.Count > 0)
                    {
                        ddlPName.DataSource = objPatient.Ds.Tables[0];
                        ddlPName.DataTextField = "Name";
                        ddlPName.DataValueField = "Patient_ID";
                        ddlPName.SelectedIndex = 0;
                        ddlPName.DataBind();
                    }
                }

            }
        }
        private void BindTable()
        {
            DataTable HPServiceDetail = new DataTable("Table"); //the “Table” value must be same for
            DataColumn c = new DataColumn();        // always
            HPServiceDetail.Columns.Add(new DataColumn("id", Type.GetType("System.Int16")));
            HPServiceDetail.Columns.Add(new DataColumn("ServiceDescription", Type.GetType("System.String")));
            HPServiceDetail.Columns.Add(new DataColumn("ServiceCharges", Type.GetType("System.Double")));
       
            Session["dt"] = HPServiceDetail;
        }

        void BindGrid()
        {
            tb = (DataTable)(Session["dt"]);

            int a = 0;
            if (tb.Rows.Count == 0)
            {
                tb.Rows.Add(tb.NewRow());
                Session["dt"] = tb;

                gvHospital.DataSource = (DataTable)(Session["dt"]);
                gvHospital.DataBind(); // gridview
                a = 1;

            }
            else
            {
                decimal TAmount = 0;
                gvHospital.DataSource = (DataTable)(Session["dt"]);// storing in “tb” datatable variable and bind with
                gvHospital.DataBind(); // gridview
                for (int i = 1; i < tb.Rows.Count; i++)
                {
                    TAmount += Convert.ToDecimal(tb.Rows[i]["ServiceCharges"].ToString());
                }
                txtTAmount.Text = TAmount.ToString();
                if (tb.Rows[0]["id"].ToString() == "")
                {
                    gvHospital.Rows[0].Visible = false;
                }

            }
            if (a == 1)
            {
                gvHospital.Rows[0].Visible = false;
            }

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

            // Discharge Time
            ddlAMPM1.Items.Add(new ListItem("AM", "AM"));
            ddlAMPM1.Items.Add(new ListItem("PM", "PM"));
            ddlAMPM1.SelectedIndex = 1;
        }



        protected void btnInsert_Click(object sender, EventArgs e)
        {
            TextBox txtIServiceDescription = gvHospital.FooterRow.FindControl("txtIServiceDescription") as TextBox;
        
            Label lblcvServiceCharge = gvHospital.FooterRow.FindControl("lblcvServiceCharge") as Label;

            TextBox txtIServiceCharge = gvHospital.FooterRow.FindControl("txtIServiceCharge") as TextBox;
            Label lblcvIServiceCharge = gvHospital.FooterRow.FindControl("lblcvIServiceCharge") as Label;

            if (txtIServiceCharge.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtIServiceCharge.Text))
                {
                    

                    lblcvIServiceCharge.Text = "";

                }
                else
                {
                    lblcvIServiceCharge.Text = "Enter valid Service Charge(e.g 100.12)";
                    return;


                }
            }


            
            tb = (DataTable)(Session["dt"]);
            DataRow r1 = tb.NewRow();
            r1["id"] = tb.Rows.Count;
            r1["ServiceDescription"] = txtIServiceDescription.Text;
            r1["ServiceCharges"] = txtIServiceCharge.Text;
            tb.Rows.Add(r1);
            Session["dt"] = tb;
            BindGrid();

            if (tb.Rows.Count > 0)
            {
                lblgvHospital.Text = "";
                if (txtDiscount.Text != "" && txtTAmount.Text != "")
                {
                    txtDiscountAmount.Text = (Convert.ToDecimal(txtTAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100).ToString();
                    txtFinalAmount.Text = (Convert.ToDecimal(txtTAmount.Text) - objHospitalDetail.DiscountAmount1).ToString();
                }
            }
           
        }

        protected void gvHospital_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            //GridViewRow row = gvHospital.Rows[e.RowIndex];
          
          

            GridViewRow row = gvHospital.Rows[gvHospital.EditIndex];
            TextBox txtServiceCharge = row.FindControl("txtServiceCharge") as TextBox;

            Label lblcvServiceCharge = row.FindControl("lblcvServiceCharge") as Label;
            TextBox txtId = row.FindControl("txtId") as TextBox;
            TextBox txtServiceDescription = row.FindControl("txtServiceDescription") as TextBox;
          

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
            gvHospital.EditIndex = -1;
            BindGrid();
        }

        protected void gvHospital_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            tb = (DataTable)(Session["dt"]);
            tb.Rows.RemoveAt(e.RowIndex); //deleting the records and decreasing the  total
            BindGrid(); //calling the tempdata form refresh the output

            if (tb.Rows.Count > 1)
            {
                lblgvHospital.Text = "";
                if (txtDiscount.Text != "" && txtTAmount.Text != "")
                {
                    txtDiscountAmount.Text = (Convert.ToDecimal(txtTAmount.Text.Trim()) * (Convert.ToDecimal(txtDiscount.Text.Trim())) / 100).ToString();
                    txtFinalAmount.Text = (Convert.ToDecimal(txtTAmount.Text) - objHospitalDetail.DiscountAmount1).ToString();
                }
            }

            else
            {
                lblgvHospital.Text = "Please fill the above details !";
                txtTAmount.Text = "";
                txtDiscountAmount.Text = "";
                txtFinalAmount.Text = "";
                return;
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

            if (ddlHName.SelectedIndex == 0)
            {
                lblcvHName.Text = "Please choose Hospital name";
                return;
            }
            else
            {
                lblcvHName.Text = "";

            }


            if (ddlPName.SelectedIndex == 0)
            {
                lblcvPName.Text = "Please choose patient name";
                return;
            }
            else
            {
                lblcvPName.Text = "";

            }


            if (ddlHour.SelectedIndex == 0 || ddlMinute.SelectedIndex == 0)
            {
                lblcvAdmitTime.Text = "please fill the Admint Time properly";
                return;
            }
            else
            {
                lblcvAdmitTime.Text = "";

            }
            //validations added

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

            //end

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

                    lblcvDiscount.ForeColor = System.Drawing.Color.Red;
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
                objHospitalDetail.DiscountAmount1 = (Convert.ToInt16(txtTAmount.Text.Trim()) * (Convert.ToInt16(txtDiscount.Text.Trim())) / 100);
                objHospitalDetail.FinalAmount1 = Convert.ToInt16(txtTAmount.Text) - objHospitalDetail.DiscountAmount1;
                txtDiscountAmount.Text = Convert.ToString(objHospitalDetail.DiscountAmount1);
                txtFinalAmount.Text = Convert.ToString(objHospitalDetail.FinalAmount1);
                lblcvDiscount.Visible = false;

            }



            DataTable tb1 = (DataTable)Session["dt"];
            if (tb1.Rows.Count == 1 && tb1.Rows[0]["id"].ToString() == "")
            {
                lblgvHospital.Text = "Please Fill the above details !";
                return;
            }
            else
            {
                lblgvHospital.Text = "";
            }


            objHospitalDetail.User_ID1 = Convert.ToInt16(ddlHName.SelectedValue);
            objHospitalDetail.Patient_ID1 = Convert.ToInt16(ddlPName.SelectedValue);
            objHospitalDetail.BillNo1 = Convert.ToInt16(txtBillNo.Text);

            objHospitalDetail.DoctorName1 = txtDName.Text;

           

        //  objHospitalDetail.AdmitDate1 = DateTime.Now.ToString();



            String ADate1 = ConvertDate(txtAdmitDate.Text);
            objHospitalDetail.AdmitDate1 = ADate1;
            String ATime1 = ddlHour.SelectedItem.Text + ":" + ddlMinute.SelectedItem.Text + " " + ddlAMPM.SelectedItem.Text;
            objHospitalDetail.AdmitTime1 = ATime1;

            String DDate1 = ConvertDate(txtDischargeDate.Text);
            objHospitalDetail.DischargeDate1 = DDate1;

            if (ddlHour1.SelectedIndex != 0 && ddlMinute1.SelectedIndex != 0)
            {
                String DTime1 = ddlHour1.SelectedItem.Text + ":" + ddlMinute1.SelectedItem.Text + " " + ddlAMPM1.SelectedItem.Text;
                objHospitalDetail.DischargeTime1 = DTime1;
            }
            else
            {
                objHospitalDetail.DischargeTime1 = "";
            }

            objHospitalDetail.TotalAmount1 = Convert.ToInt16(txtTAmount.Text.Trim());
            objHospitalDetail.Discount1 = Convert.ToInt16(txtDiscount.Text.Trim());
            //objHospitalDetail.DiscountAmount1 = (Convert.ToInt16(txtTAmount.Text.Trim()) * (Convert.ToInt16(txtDiscount.Text.Trim())) / 100);
            //objHospitalDetail.FinalAmount1 = Convert.ToInt16(txtTAmount.Text) - objHospitalDetail.DiscountAmount1;

            objHospitalDetail.PaymentStatus1 = false;

            objHospitalDetail.Insert();

            DataTable tb = (DataTable)Session["dt"];

            for (int i = 1; i < tb.Rows.Count; i++)
            {
                //    objPCServiceDetail.PharmaCompanyDetail_ID1 = PCDetail_ID;
                objHospitalServiceDetail.ServiceDescription1 = tb.Rows[i]["ServiceDescription"].ToString();
                objHospitalServiceDetail.ServiceCharges1 = Convert.ToDecimal(tb.Rows[i]["ServiceCharges"].ToString());
                objHospitalServiceDetail.Insert();
            }

            Reset();

            //string message = "Hospital Service Detail Inserted successfully.";
            //string url = "HospitalDetail.aspx";
            //string script = "window.onload = function(){ alert('";
            //script += message;
            //script += "');";
            //script += "window.location = '";
            //script += url;
            //script += "'; }";
            //ClientScript.RegisterStartupScript(this.GetType(), "Redirect", script, true);
            Response.Write("<script language='javascript'>window.alert('Hospital Service Detail Inserted successfully.');window.location='HospitalDetail.aspx';</script>");

        }


        protected void gvHospital_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHospital.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void gvHospital_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvHospital.EditIndex = -1;
            BindGrid();
        }

        protected void gvHospital_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvHospital.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        
        protected void btnReset_Click(object sender, EventArgs e)
        {
            Reset();

            DataTable tb = (DataTable)Session["dt"];
            tb.Rows.Clear();
            int a = 0;
            if (tb.Rows.Count == 0)
            {
                tb.Rows.Add(tb.NewRow());
                Session["dt"] = tb;

                gvHospital.DataSource = (DataTable)(Session["dt"]);
                gvHospital.DataBind(); // gridview
                a = 1;

            }

            if (a == 1)
            {
                gvHospital.Rows[0].Visible = false;
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminLab/HospitalDetail.aspx");
        }

        void Reset()
        {

            txtDName.Text = "";
            txtAdmitDate.Text = "";
            txtDischargeDate.Text = "";
            ddlHour.ClearSelection();
            ddlHour1.ClearSelection();
            ddlMinute.ClearSelection();
            ddlMinute1.ClearSelection();
            ddlAMPM.ClearSelection();
            ddlAMPM1.ClearSelection();
            txtDiscount.Text = "";
            txtFinalAmount.Text = "";
            txtTAmount.Text = "";
            ddlPName.ClearSelection();
            ddlHName.ClearSelection();
            txtDiscountAmount.Text = "";
            lblgvHospital.Text = "";
            lblcvTAmount.Text = "";
            lblcvAdmitTime.Text = "";
            lblcvDischargeTime.Text = "";
            lblcvDischargeDate.Text = "";
        }

        protected void ddlHName_TextChanged(object sender, EventArgs e)
        {
            if (ddlHName.SelectedIndex == 0)
            {
                lblcvHName.Text = "Please choose Hospital name";
                return;
            }
            else
            {
                lblcvHName.Text = "";

            }

        }

        protected void ddlPName_SelectedIndexChanged(object sender, EventArgs e)
        {
         
            if (ddlPName.SelectedIndex == 0)
            {
                lblcvPName.Text = "Please choose patient name";
                return;
            }
            else
            {
                lblcvPName.Text = "";

            }

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
                objHospitalDetail.DiscountAmount1 = (Convert.ToInt16(txtTAmount.Text.Trim()) * (Convert.ToInt16(txtDiscount.Text.Trim())) / 100);
                objHospitalDetail.FinalAmount1 = Convert.ToInt16(txtTAmount.Text) - objHospitalDetail.DiscountAmount1;
                txtDiscountAmount.Text = Convert.ToString(objHospitalDetail.DiscountAmount1);
                txtFinalAmount.Text = Convert.ToString(objHospitalDetail.FinalAmount1);
                lblcvDiscount.Visible = false;

            }


        }

        protected void txtServiceCharge_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvHospital.Rows[gvHospital.EditIndex];
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
            TextBox txtIServiceCharge = gvHospital.FooterRow.FindControl("txtIServiceCharge") as TextBox;
            Label lblcvIServiceCharge = gvHospital.FooterRow.FindControl("lblcvIServiceCharge") as Label;

            if (txtIServiceCharge.Text != "")
            {
                Regex regx = new Regex(@"^\d+(\.\d{1,2})?$");
                if (regx.IsMatch(txtIServiceCharge.Text))
                {
                  

                    lblcvIServiceCharge.Text = "";

                }
                else
                {
                    lblcvIServiceCharge.Text = "Enter valid Service Charge(e.g 100.12)";
                    return;


                }
            }


        }

       

        protected void ddlHName_SelectedIndexChanged(object sender, EventArgs e)
        {

            FillddlPatientName();
            if (ddlHName.SelectedIndex == 0)
            {
                lblcvHName.Text = "Please choose Hospital name";
                return;
            }
            else
            {
                lblcvHName.Text = "";

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

    }
}