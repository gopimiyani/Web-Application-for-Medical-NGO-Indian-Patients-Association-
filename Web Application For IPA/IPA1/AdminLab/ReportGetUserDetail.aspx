<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportGetUserDetail.aspx.cs"
    Inherits="IPA1.AdminLab.ReportGetUserDetail" %>

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
            
            System.Data.DataTable tbUserDetail;
            // BusLib.Transaction.Report objReport = new BusLib.Transaction.Report();

            BusLib.Common.Registration objRegistration = new BusLib.Common.Registration();

            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["UserType"] != "--Select User Type--")
                {
                    objRegistration.StackHolder1 = Request.QueryString["UserType"].ToString();
                }

                
                
                if (Request.QueryString["PinCode"] != "")
                {
                    objRegistration.PinCode1 = Convert.ToInt32(Request.QueryString["PinCode"]);

                }

                if (Request.QueryString["State"] != "--Select State--")
                {
                    objRegistration.State1 = Request.QueryString["State"].ToString();
                }

                if (Request.QueryString["City"] != "--Select City--")
                {
                    objRegistration.City1 = Request.QueryString["City"].ToString();
                }
                if (Request.QueryString["FromDate"] != "")
                {
                    objRegistration.FromDate1 = ConvertDate((Request.QueryString["FromDate"]));

                }
                else
                    objRegistration.FromDate1 = "";

                if (Request.QueryString["ToDate"] != "")
                {
                    objRegistration.ToDate1 = ConvertDate((Request.QueryString["ToDate"]));
                }
                else
                    objRegistration.ToDate1 = "";

                objRegistration.Regisrtation_GetUserDetail();
                tbUserDetail = objRegistration.Ds.Tables[0];
               
            }
            %>
            <%else
            {
              %>  

              <table>
              
              <tr>


              <td>
              
              <center><h1><u>Report of User Detail</u></h1></center>
              <center><h3>No Records Found ...!   </h3></center></td>
              
              </tr>
              </table>


              <%
                  return;
            }
           
            
            
        %>
        <center>
           <u> <h1>
                Report of User Detail</h1></u>
        </center>
    </div>
    <div>
        <% 
  if(tbUserDetail.Rows.Count>0)
  {         
           
                String UserType = "", State = "", City = "", FromDate = "", ToDate = "";
                int PinCode = 0;
               
                if (Request.QueryString["UserType"] != "--Select User Type--")
                {   
                %>
                <table> 
                <tr>
                <td class="style5"> <%UserType = Request.QueryString["UserType"];
                       Response.Write("UserType: "+ UserType); %></td>
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
        <% 
            
if (tbUserDetail.Rows.Count > 0)
{
    //Response.Write("<table border='1' cellpadding='0px' cellspacing='5px'  WIDTH='100%' ");
                      
                      %>

<table border="1px" cellpadding="5px" cellspacing="0px" width="100%">

            <tr>
                <%if (Request.QueryString["UserType"] == "--Select User Type--")
                  { %>
                <td>
                  <b>UserType</b>  
                </td>
                <%} %>
                <td>
                   <b>User_ID</b> 
                </td>
                <td>
                    <b>UserName</b>
                </td>
                <td>
                    <b>Name</b>
                </td>
                <td>
                    <b>JoinDate</b>
                </td>
                <td>
                   <b>Address</b> 
                </td>
                <td>
                    <b>State</b>
                </td>
                <td>
                    <b>City</b>
                </td>
                <td>
                    <b>PinCode</b>
                </td>
                <td>
                    <b>MobileNo</b>
                </td>
                <td>
                    <b>Email</b>
                </td>
                <%if (Request.QueryString["UserType"] == "Volunteer" ||
                      Request.QueryString["UserType"] == "Donor")
                  { %>
                <td>
                   <b>Date of Birth</b> 
                </td>
                <td>
                    <b>BloodGroup</b>
                </td>
                <%} %>
                <%if (Request.QueryString["UserType"] == "Hospital" ||
                      Request.QueryString["UserType"] == "BloodBank" ||
                      Request.QueryString["UserType"] == "PharmaCompany")
                  { %>
                <td>
                    <b>Contact Person</b>
                </td>
                <td>
                    <b>Website Name</b>
                </td>
                <%} %>
                <%if (Request.QueryString["UserType"] == "Doctor")
                  { %>
                <td>
                    <b>Degree</b>
                </td>
                <td>
                    <b>Specialist In</b>
                </td>
                <%} %>
                <%if (Request.QueryString["UserType"] == "NGO")
                  { %>
                <td>
                    <b>Website</b>
                </td>
                <td>
                   <b>Purpose</b> 
                </td>
                <td>
                   <b>Mission</b> 
                </td>
                <%} %>
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
                <% if (tbUserDetail.Rows.Count > 0)
                   {
                       for (int i = 0; i < tbUserDetail.Rows.Count; i++)
                       {
                           Response.Write("<tr>");
                           if (Request.QueryString["UserType"] == "--Select User Type--")
                           {
                               Response.Write("<td> " + tbUserDetail.Rows[i]["StackHolder"].ToString() + " </td>");
                           }
                           Response.Write("<td> " + tbUserDetail.Rows[i]["User_ID"].ToString() + " </td>");
                           Response.Write("<td> " + tbUserDetail.Rows[i]["UserName"].ToString() + " </td>");
                           Response.Write("<td> " + tbUserDetail.Rows[i]["FirstName"].ToString() + " </td>");
                           Response.Write("<td> " + tbUserDetail.Rows[i]["JoinDate"].ToString() + " </td>");
                           Response.Write("<td> " + tbUserDetail.Rows[i]["Address"].ToString() + " </td>");
                           Response.Write("<td> " + tbUserDetail.Rows[i]["State"].ToString() + " </td>");
                           Response.Write("<td> " + tbUserDetail.Rows[i]["City"].ToString() + " </td>");
                           Response.Write("<td> " + tbUserDetail.Rows[i]["PinCode"].ToString() + " </td>");
                           Response.Write("<td> " + tbUserDetail.Rows[i]["MobileNo"].ToString() + " </td>");
                           Response.Write("<td> " + tbUserDetail.Rows[i]["Email"].ToString() + " </td>");

                           if (Request.QueryString["UserType"] == "Volunteer" ||
                                Request.QueryString["UserType"] == "Donor")
                           {
                               Response.Write("<td> " + tbUserDetail.Rows[i]["BirthDate"].ToString() + " </td>");
                               Response.Write("<td> " + tbUserDetail.Rows[i]["BloodGroup"].ToString() + " </td>");
                           }


                           if (Request.QueryString["UserType"] == "Hospital" ||
                                Request.QueryString["UserType"] == "BloodBank" ||
                                Request.QueryString["UserType"] == "PharmaCompany")
                           {
                               Response.Write("<td> " + tbUserDetail.Rows[i]["ContactPerson"].ToString() + " </td>");
                               Response.Write("<td> " + tbUserDetail.Rows[i]["Website"].ToString() + " </td>");
                           }

                           if (Request.QueryString["UserType"] == "Doctor")
                           {
                               Response.Write("<td> " + tbUserDetail.Rows[i]["Degree"].ToString() + " </td>");
                               Response.Write("<td> " + tbUserDetail.Rows[i]["Disease"].ToString() + " </td>");
                           }

                           if (Request.QueryString["UserType"] == "NGO")
                           {

                               Response.Write("<td> " + tbUserDetail.Rows[i]["Website"].ToString() + " </td>");
                               Response.Write("<td> " + tbUserDetail.Rows[i]["Purpose"].ToString() + " </td>");
                               Response.Write("<td> " + tbUserDetail.Rows[i]["Mission"].ToString() + " </td>");
                           }

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
