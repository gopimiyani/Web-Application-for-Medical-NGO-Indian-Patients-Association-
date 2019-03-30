<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report_GetTaskDetail.aspx.cs"
    Inherits="IPA1.AdminLab.ReportGetTaskDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            font-size:large;
            font-weight:lighter;
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
            
            System.Data.DataTable tbTaskDetail;
            // BusLib.Transaction.Report objReport = new BusLib.Transaction.Report();

            BusLib.Transaction.Task objTask = new BusLib.Transaction.Task();
            BusLib.Transaction.ServiceDetailReport objReport = new BusLib.Transaction.ServiceDetailReport();
            BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();

            if (Request.QueryString.Count > 0)
            {


                if (Request.QueryString["User_ID"] != "")
                {

                    objReport.User_ID1 = Convert.ToInt16(Request.QueryString["User_ID"].ToString());
                }



                if (Request.QueryString["PinCode"] != "")
                {
                    objReport.PinCode1 = Convert.ToInt32(Request.QueryString["PinCode"]);

                }

                if (Request.QueryString["State"] != "--Select State--")
                {
                    objReport.State1 = Request.QueryString["State"].ToString();
                }

                if (Request.QueryString["City"] != "--Select City--")
                {
                    objReport.City1 = Request.QueryString["City"].ToString();
                }
                if (Request.QueryString["FromDate"] != "")
                {
                    objReport.FromDate1 = ConvertDate((Request.QueryString["FromDate"]));

                }
                else
                    objReport.FromDate1 = "";

                if (Request.QueryString["ToDate"] != "")
                {
                    objReport.ToDate1 = ConvertDate((Request.QueryString["ToDate"]));
                }
                else
                    objReport.ToDate1 = "";

                if (Request.QueryString["Status"] != "---Select Status---")
                {
                    objReport.Status1 = (Request.QueryString["Status"].ToString());
                }

                objReport.Task_GetTaskDetail();
                tbTaskDetail = objReport.Ds.Tables[0];
            }      
            
        %>
   <%else
            {
              %>  

              <table>
              
              <tr>


              <td>
              
              <center><h1><u>Report of Task Detail</u></h1></center>
              <center><h3>No Records Found ...!   </h3></center></td>
              
              </tr>
              </table>


              <%
                  return;
            }
           
            
            
        %>
        <center>
            <h2>
                <u>Report of Task Detail</u></h2>
        </center>
        <table width="100%">
            <tr>
                <td>
                    ADT - Assigned DateTime
                </td>
                <td>
                    CDT - Completion DateTime
                </td>
                <td>
                    ACDT - Actual Completion DateTime
                </td>
            </tr>
        </table>
        <br />
    </div>
    <div>





    <%
        
       if(tbTaskDetail.Rows.Count>0)
  {         
           
                String State = "", City = "", FromDate = "", ToDate = "",Status="";
                int PinCode = 0;

              
                %>
                <table> 
                <tr>
                
              <%

                   if (Request.QueryString["Status"] != "---Select Status---")
                {   
                %>
                
                
                <td class="style5"> <%Status = (Request.QueryString["Status"]);
                       Response.Write("Status: "+ Status); %></td>
               <% }
           
                if (Request.QueryString["PinCode"] != "")
                {
                    %>

                    <td class="style5"> <%PinCode = Convert.ToInt32(Request.QueryString["PinCode"]);
                           Response.Write("PinCode:"+ PinCode);%></td>

               <% }
                if (Request.QueryString["State"] != "--Select State--")
                {
                    %>
                     <td class="style5"> <%State = (Request.QueryString["State"]);
                            Response.Write("State:" +State);%></td>

               <% }

                   if (Request.QueryString["City"] != "--Select City--")
                   {
                 %>  
                  <td class="style5"> <%City = (Request.QueryString["City"]);
                       Response.Write("City:" +City); %></td>

                <%}
      
                if (Request.QueryString["FromDate"] != "")
                  {%>
                   <td class="style5"> <%FromDate = (Request.QueryString["FromDate"]);
                          Response.Write("FromDate:" +FromDate);%></td>

              <%  }


                  if (Request.QueryString["ToDate"] != "")
                  {%>
                     <td class="style5"> <%ToDate = (Request.QueryString["ToDate"]);
                            Response.Write("ToDate:" +ToDate);%></td>
              <%  }%>
              </tr>
              
                
   <%} 
 else{
                           
       %>   
       
            <tr>
            <td>
            <br />
         <center><h2>No Records Found....</h2> </center>  
         
            <%
return;      %>
              </td>
          </tr>
                  
<% } %>
       
       
                 </table>        
       
       <br />
           
       <%     tbTaskDetail = objReport.Ds.Tables[0];

            if (tbTaskDetail.Rows.Count > 0)
            {
                
               
        %>
        <table border="1px" cellpadding="5px" cellspacing="0px" width="100%">
            <tr>
                <% if (Request.QueryString["Status"] == "---Select Status---")
                   {%>
                <td>
                   <b> Status</b>
                </td>
                <%} %>
                <td>
                   <b>Task_ID</b> 
                </td>
                <td>
                    <b>AssignedTo</b>
                </td>
                <td>
                   <b>Subject</b> 
                </td>
                <td>
                    <b>Detail</b>
                </td>
                <td>
                   <b> Priority</b>
                </td>
                <td>
                   <b>ADT</b> 
                </td>
                <td>
                   <b>CDT</b> 
                </td>
                <td>
                    <b>ACDT</b>
                </td>
                <% if (Request.QueryString["Status"] != "Pending" && Request.QueryString["Status"] != "Complete")
                   {%>
                <td>
                   <b>WCP</b> 
                </td>
                <% }%>
                <td>
                    <b>Email</b>
                </td>
            </tr>
            <% 
}
else
{%>
            <tr>
            <td>
          <h3>No Records Found....</h3>  
            <%
return;       %>
            </td>

            </tr>
 <%} %>
            <tr>
                <% if (tbTaskDetail.Rows.Count > 0)
                   {
                       for (int i = 0; i < tbTaskDetail.Rows.Count; i++)
                       {
                           Response.Write("<tr>");
                           if (Request.QueryString["Status"] == "---Select Status---")
                           {
                               Response.Write("<td> " + tbTaskDetail.Rows[i]["Status"].ToString() + " </td>");
                           }
                           Response.Write("<td> " + tbTaskDetail.Rows[i]["Task_ID"].ToString() + " </td>");
                           Response.Write("<td> " + tbTaskDetail.Rows[i]["Name"].ToString() + " </td>");
                           Response.Write("<td> " + tbTaskDetail.Rows[i]["Subject"].ToString() + " </td>");
                           Response.Write("<td> " + tbTaskDetail.Rows[i]["Detail"].ToString() + " </td>");
                           Response.Write("<td> " + tbTaskDetail.Rows[i]["Priority"].ToString() + " </td>");

                           Response.Write("<td> " + tbTaskDetail.Rows[i]["EntryDate"].ToString() + "<br/>" + tbTaskDetail.Rows[i]["EntryTime"].ToString() + " </td>");
                           Response.Write("<td> " + tbTaskDetail.Rows[i]["CompletionDate"].ToString() + "<br/>" + tbTaskDetail.Rows[i]["CompletionTime"].ToString() + " </td>");
                           Response.Write("<td> " + tbTaskDetail.Rows[i]["ActualCompletionDate"].ToString() + "<br/>" + tbTaskDetail.Rows[i]["ActualCompletionTime"].ToString() + " </td>");
                           if (Request.QueryString["Status"] != "Pending" && Request.QueryString["Status"] != "Complete")
                           {
                               Response.Write("<td> " + tbTaskDetail.Rows[i]["WCP"].ToString() + " </td>");
                           }
                           // Response.Write("<td> " + tbUserDetail.Rows[i]["Remarks"].ToString() + " </td>");
                           Response.Write("<td> " + tbTaskDetail.Rows[i]["Email"].ToString() + " </td>");
                           Response.Write("</tr>");
                       }

                   }

            
                %>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
