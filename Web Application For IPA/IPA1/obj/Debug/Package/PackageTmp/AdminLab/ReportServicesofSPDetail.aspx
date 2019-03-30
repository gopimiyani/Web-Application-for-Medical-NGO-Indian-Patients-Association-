<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportServicesofSPDetail.aspx.cs"
    Inherits="IPA1.AdminLab.ReportServicesofSPDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        input[type="text"], input[type="textarea"]
        {
        }
        
        
        .style2
        {
            width: 147px;
            height: 38px;
            color: #FF0000;
        }
        .style5
        {
            width: 500px;
            font-size: large;
            font-weight: lighter;
        }
    </style>
    <title></title>
    <script language="C#" runat="server">
        private string ConvertDate(string Date)
        {
            string Rdate = "";
            if (Date != "")
            {

                Rdate = Date.Substring(6, 4) + "-" + Date.Substring(3, 2) + "-" + Date.Substring(0, 2);
            }
            return Rdate;
        } 
        
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%
             
           
            System.Data.DataTable tbSPDetail;
            BusLib.Transaction.ServiceDetailReport objReport = new BusLib.Transaction.ServiceDetailReport();



            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["UserType"] != "--Select User Type--")
                {
                    objReport.StackHolder1 = Request.QueryString["UserType"].ToString();
                    if (Request.QueryString["User_ID"] != "")
                    {
                        objReport.User_ID1 = Convert.ToInt16(Request.QueryString["User_ID"].ToString());
                    }

                    else
                        objReport.User_ID1 = 0;

                }

                else
                    objReport.StackHolder1 = "";


                if (Request.QueryString["PinCode"] != "")
                {
                    objReport.PinCode1 = Convert.ToInt32(Request.QueryString["PinCode"]);

                }

                if (Request.QueryString["State"] != "--Select State--")
                {
                    objReport.State1 = Request.QueryString["State"].ToString();
                }



                if (Request.QueryString["PStatus"] != "--Select Status--")
                {
                    String PaymentStatus = Request.QueryString["PStatus"].ToString();
                    Boolean PStatus;
                    PStatus = PaymentStatus.Equals("Paid") ? true : false;

                    objReport.PaymentStatus1 = PStatus;
                }

                objReport.SP_GetServiceDetail();

                tbSPDetail = objReport.Ds.Tables[0];
            }
        %>
        <%else
            {
        %>
        <table>
            <tr>
                <td>
                    <center>
                        <h1>
                            <u>Report of Services of Service Provider</u></h1>
                    </center>
                    <center>
                        <h3>
                            No Records Found ...!
                        </h3>
                    </center>
                </td>
            </tr>
        </table>
        <%
    return;
}
           
            
            
        %>
        <center>
            <h2>
                <u>Report Of Services of Service Provider</u></h2>
        </center>
    </div>
    <div>
        <% 

            if (tbSPDetail.Rows.Count > 0)
            {

                String UserType = "", State = "", City = "", PStatus = "";
                int PinCode = 0;

                if (Request.QueryString["UserType"] != "--Select User Type--")
                {   
        %>
        <table>
            <tr>
                <td class="style5">
                    <%UserType = Request.QueryString["UserType"];
                      Response.Write("UserType: " + UserType); %>
                </td>
                <% }

                if (Request.QueryString["PStatus"] != "--Select Status--")
                {
                %>
                <td class="style5">
                    <%PStatus = (Request.QueryString["PStatus"]);
                      Response.Write("Payment Status: " + PStatus);%>
                </td>
                <% }


                    if (Request.QueryString["PinCode"] != "")
                    {
                %>
                <td class="style5">
                    <%PinCode = Convert.ToInt32(Request.QueryString["PinCode"]);
                      Response.Write("PinCode:" + PinCode);%>
                </td>
                <% }
                if (Request.QueryString["State"] != "--Select State--")
                {
                %>
                <td class="style5">
                    <%State = (Request.QueryString["State"]);
                      Response.Write("State:" + State);%>
                </td>
                <% }

                if (Request.QueryString["City"] != "--Select City--")
                {
                %>
                <td class="style5">
                    <%City = (Request.QueryString["City"]);
                      Response.Write("City:" + City); %>
                </td>
                <%}

                %>
            </tr>
            <%}
            else
            {
                           
            %>
            <tr>
                <td>
                    <br />
                    <center>
                        <h2>
                            No Records Found....</h2>
                    </center>
                    <%
      return;      %>
                </td>
            </tr>
            <% } %>
        </table>
        <br />
        <% 
           
            tbSPDetail = objReport.Ds.Tables[0];

            if (tbSPDetail.Rows.Count > 0)
            {
              
               
        %>
        <table border="1px" cellpadding="5px" cellspacing="0px" width="100%">
            <tr>
                <%if (Request.QueryString["UserType"] == "Doctor")
                  { %>
                <td>
                   <b>Name</b> 
                </td>
                <td>
                   <b>Patient_ID</b> 
                </td>
                <td>
                   <b> Service Description</b>
                </td>
                <td>
                   <b>BillNo</b> 
                </td>
                <td>
                   <b>Total Amount</b> 
                </td>
                <td>
                   <b>Discount Amount</b> 
                </td>
                <td>
                   <b> Final Amount</b>
                </td>
                <td>
                    <b>>Payment Status</b>
                </td>
                <%} %>
                <%if (Request.QueryString["UserType"] == "Hospital")
                  { %>
                <td>
                    <b>Name</b>
                </td>
                <td>
                   <b>Patient_ID</b> 
                </td>
                <td>
                   <b>Admit DateTime</b> 
                </td>
                <td>
                   <b>Discharge DateTime</b> 
                </td>
                
                <td>
                    <b>Service Description</b>
                </td>
                <td>
                    <b>Bill No</b>
                </td>
                <td>
                   <b>Total Amount</b> 
                </td>
                <td>
                   <b>Discount Amount</b> 
                </td>
                <td>
                    <b>Final Amount</b>
                </td>
                <td>
                   <b>Payment Status</b> 
                </td>
                <%} %>
                <%if (Request.QueryString["UserType"] == "BloodBank")
                  { %>
                <td>
                    <b>Name</b>
                </td>
                <td>
                   <b>Patient_ID</b> 
                </td>
                <td>
                    <b>BloodGroup</b>
                </td>
                <td>
                    <b>No of Bottle</b>
                </td>
                <td>
                   <b>BillNo</b> 
                </td>
                <td>
                   <b>Total Amount</b> 
                </td>
                <td>
                    <b>Discount Amount</b>
                </td>
                <td>
                    <b>Final Amount</b>
                </td>
                <td>
                    <b>Payment Status</b>
                </td>
                <%} %>
                <%if (Request.QueryString["UserType"] == "PharmaCompany")
                  { %>
                <td>
                    <b>Name</b>
                </td>
                <td>
                    <b>Patient_ID</b>
                </td>
                <td>
                    <b>Item Name</b>
                </td>
                <td>
                    <b>Quantity</b>
                </td>
                <td>
                    <b>Rate</b>
                </td>
                <td>
                   <b>BillNo</b> 
                </td>
                <td>
                   <b>Total Amount</b> 
                </td>
                <td>
                    <b>Discount Amount</b>
                </td>
                <td>
                    <b>Final Amount</b>
                </td>
                <td>
                    <b>Payment Status</b>
                </td>
                <%} 
                %>
                <td>
                    <b>State</b>
                </td>
                <td>
                    <b>City</b>
                </td>
                <td>
                    <b>PinCode</b>
                </td>
            </tr>
            <% 
            }
            else
            {%>
            <tr>
                <td>
                    <h3>
                        No Records Found....</h3>
                    <%
                return;       %>
                </td>
            </tr>
            <%} %>
            <tr>

                <%
                    int TotalAmount = 0, DiscountAmount = 0, FinalAmount = 0;
                    if (tbSPDetail.Rows.Count > 0)
                   {
                       for (int i = 0; i < tbSPDetail.Rows.Count; i++)
                       {
                           Response.Write("<tr>");
                           if (Request.QueryString["UserType"] == "Doctor")
                           {
                               Response.Write("<td> " + tbSPDetail.Rows[i]["Name"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["Patient_ID"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["ServiceDescription"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["BillNo"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["TotalAmount"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["DiscountAmount"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["FinalAmount"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["PaymentStatus"].ToString() + " </td>");
                               TotalAmount += Convert.ToInt32(tbSPDetail.Rows[i]["TotalAmount"]);
                               DiscountAmount += Convert.ToInt32(tbSPDetail.Rows[i]["DiscountAmount"]);
                               FinalAmount += Convert.ToInt32(tbSPDetail.Rows[i]["FinalAmount"]);
                           }



                           if (Request.QueryString["UserType"] == "Hospital")
                           {
                               Response.Write("<td> " + tbSPDetail.Rows[i]["Name"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["Patient_ID"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["AdmitDate"].ToString() + "<br/>" + tbSPDetail.Rows[i]["AdmitTime"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["DischargeDate"].ToString() + "<br/>" + tbSPDetail.Rows[i]["DischargeTime"].ToString() + " </td>");
                               
                               Response.Write("<td> " + tbSPDetail.Rows[i]["ServiceDescription"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["BillNo"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["TotalAmount"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["DiscountAmount"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["FinalAmount"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["PaymentStatus"].ToString() + " </td>");
                               TotalAmount += Convert.ToInt32(tbSPDetail.Rows[i]["TotalAmount"]);
                               DiscountAmount += Convert.ToInt32(tbSPDetail.Rows[i]["DiscountAmount"]);
                               FinalAmount += Convert.ToInt32(tbSPDetail.Rows[i]["FinalAmount"]);
                           }


                           if (Request.QueryString["UserType"] == "PharmaCompany")
                           {
                               Response.Write("<td> " + tbSPDetail.Rows[i]["Name"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["Patient_ID"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["ItemName"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["Quantity"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["Rate"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["BillNo"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["TotalAmount"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["DiscountAmount"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["FinalAmount"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["PaymentStatus"].ToString() + " </td>");
                               TotalAmount += Convert.ToInt32(tbSPDetail.Rows[i]["TotalAmount"]);
                               DiscountAmount += Convert.ToInt32(tbSPDetail.Rows[i]["DiscountAmount"]);
                               FinalAmount += Convert.ToInt32(tbSPDetail.Rows[i]["FinalAmount"]);

                           }

                           if (Request.QueryString["UserType"] == "BloodBank")
                           {
                               Response.Write("<td> " + tbSPDetail.Rows[i]["Name"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["Patient_ID"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["BloodGroup"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["NoOfBottle"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["BillNo"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["TotalAmount"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["DiscountAmount"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["FinalAmount"].ToString() + " </td>");
                               Response.Write("<td> " + tbSPDetail.Rows[i]["PaymentStatus"].ToString() + " </td>");
                               TotalAmount += Convert.ToInt32(tbSPDetail.Rows[i]["TotalAmount"]);
                               DiscountAmount += Convert.ToInt32(tbSPDetail.Rows[i]["DiscountAmount"]);
                               FinalAmount += Convert.ToInt32(tbSPDetail.Rows[i]["FinalAmount"]);
                           }

                           Response.Write("<td> " + tbSPDetail.Rows[i]["State"].ToString() + " </td>");
                           Response.Write("<td> " + tbSPDetail.Rows[i]["City"].ToString() + " </td>");
                           Response.Write("<td> " + tbSPDetail.Rows[i]["PinCode"].ToString() + " </td>");

                           Response.Write("</tr>");
                       }

                   }
                    if (Request.QueryString["UserType"] == "Doctor")
                    {
                        Response.Write("<tr>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td><b>" + TotalAmount + "</b></td>");
                        Response.Write("<td><b>" + DiscountAmount + "</b></td>");
                        Response.Write("<td><b>" + FinalAmount + "</b></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("</tr>");
                    }

                    if (Request.QueryString["UserType"] == "Hospital")
                    {
                        Response.Write("<tr>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td><b>" + TotalAmount + "</b></td>");
                        Response.Write("<td><b>" + DiscountAmount + "</b></td>");
                        Response.Write("<td><b>" + FinalAmount + "</b></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("</tr>");
                    }

                    if (Request.QueryString["UserType"] == "PharmaCompany")
                    {
                        Response.Write("<tr>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td><b>" + TotalAmount + "</b></td>");
                        Response.Write("<td><b>" + DiscountAmount + "</b></td>");
                        Response.Write("<td><b>" + FinalAmount + "</b></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("</tr>");
                    }

                    if (Request.QueryString["UserType"] == "BloodBank")
                    {
                        Response.Write("<tr>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td><b>" + TotalAmount + "</b></td>");
                        Response.Write("<td><b>" + DiscountAmount + "</b></td>");
                        Response.Write("<td><b>" + FinalAmount + "</b></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        Response.Write("<td></td>");
                        
                        Response.Write("</tr>");
                    }
            
                %>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
