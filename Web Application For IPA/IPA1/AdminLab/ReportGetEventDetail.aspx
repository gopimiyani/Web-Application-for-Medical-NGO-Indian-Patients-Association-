<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportGetEventDetail.aspx.cs" Inherits="IPA1.AdminLab.ReportGetEventDetail" %>

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
            
            System.Data.DataTable tbEventDetail;
            BusLib.Transaction.ServiceDetailReport objReport = new BusLib.Transaction.ServiceDetailReport();

            BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();

            if (Request.QueryString.Count > 0)
            {
                
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

                if (Request.QueryString["Location"] != "")
                {
                    objReport.Location1 = Request.QueryString["Location"];
                }

                              
                objReport.Event_GetEventDetail();
                tbEventDetail = objReport.Ds.Tables[0];
            }
               
        %>
         <%else
            {
              %>  

              <table>
              
              <tr>


              <td>
              
              <center><h1><u>Report of Event Detail</u></h1></center>
              <center><h3>No Records Found ...!   </h3></center></td>
              
              </tr>
              </table>


              <%
                  return;
            }
           
            
            
        %>


        <center>
            
               <u><h1> Report of Event Detail</h1></u>
        </center>
    </div>
    <div>

     <% 
  if(tbEventDetail.Rows.Count>0)
  {         
           
                String FromDate = "", ToDate = "";
               
               
              %>
              <table>
              <tr>
              <%
                
      
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


        <% 
           
            tbEventDetail = objReport.Ds.Tables[0];

            if (tbEventDetail.Rows.Count > 0)
            {
                
               
        %>
         <table border="1px" cellpadding="5px" cellspacing="0px" width="100%">
            <tr>
                
                <td>
                 <b>Event_ID</b>   
                </td>
                <td>
                   <b>Admin_ID</b> 
                </td>
                <td>
                    <b>Event Name</b>
                </td>
                <td>
                    <b>Event Description</b>
                </td>
                <td>
                    <b>Event Date</b>
                </td>
                <td>
                    <b>Event EntryDate</b>
                </td>
                <td>
                   <b>Time Duration</b> 
                </td>
                <td>
                   <b> Location</b>
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
                <% if (tbEventDetail.Rows.Count > 0)
                   {
                       for (int i = 0; i < tbEventDetail.Rows.Count; i++)
                       {
                           Response.Write("<tr>");
                           Response.Write("<td> " + tbEventDetail.Rows[i]["Event_ID"].ToString() + " </td>");
                           Response.Write("<td> " + tbEventDetail.Rows[i]["Admin_ID"].ToString() + " </td>");
                           Response.Write("<td> " + tbEventDetail.Rows[i]["EventName"].ToString() + " </td>");
                           Response.Write("<td> " + tbEventDetail.Rows[i]["EventDescription"].ToString() + " </td>");
                           Response.Write("<td> " + tbEventDetail.Rows[i]["EventDate"].ToString() + " </td>");
                           Response.Write("<td> " + tbEventDetail.Rows[i]["EntryDate"].ToString() + " </td>");
                           Response.Write("<td> " + tbEventDetail.Rows[i]["StartTime"].ToString() +"|"+ tbEventDetail.Rows[i]["StartTime"].ToString() +" </td>");
                           Response.Write("<td> " + tbEventDetail.Rows[i]["Location"].ToString() + " </td>");
                          



                       }
                   }

            
                %>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>