<%@ Page Title="" Language="C#" MasterPageFile="~/Visitor/Visitor.Master" AutoEventWireup="true" CodeBehind="GetInvolved.aspx.cs" Inherits="IPA1.Visitor.GetInvolved" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">

td
{
    margin-bottom:30px;
}

</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <section id="work-process">
        <div class="container">
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">Get Involved</h2>
                <p class="text-center wow fadeInDown">
               We have a large number of service providers working dedicatedly 
               to help the poor people.  <br>

                  
                  </p>
            </div>

            <div class="row text-center">
                <div class="col-md-2 col-md-4 col-xs-6">
                    <div class="wow fadeInUp" data-wow-duration="400ms" data-wow-delay="0ms">
                         <a href="#Volunteers" style="color:White;">
                        <div class="icon-circle">
                            <span>
                            
                           <asp:Label ID="lblVolunteers" runat="server" Text=""></asp:Label>
                            </span>
                            
                            <i class="fa fa-user fa-2x" style="margin-top:20px;"></i>
                            
                        </div>
                        </a>
                        <h3>Volunteers  </h3>
                    </div>
                </div>
                <div class="col-md-2 col-md-4 col-xs-6">
                    <div class="wow fadeInUp" data-wow-duration="400ms" data-wow-delay="100ms">
                         <a href="#Hospitals" style="color:White;">
                      
                        <div class="icon-circle">
                            <span>
                             <asp:Label ID="lblHospitals" runat="server" Text=""></asp:Label>
                            </span>
                            <i class="fa fa-plus fa-2x" style="margin-top:20px;"></i>
                        </div>
                        </a>
                        <h3>Hospitals</h3>
                    </div>
                </div>
                <div class="col-md-2 col-md-4 col-xs-6">
                    <div class="wow fadeInUp" data-wow-duration="400ms" data-wow-delay="200ms">
                       <a href="#BloodBanks" style="color:White;">
                      
                        <div class="icon-circle">
                            <span>
                             <asp:Label ID="lblBloodBanks" runat="server" Text=""></asp:Label>
                            </span>
                            <i class="fa fa-tint fa-2x" style="margin-top:20px;"></i>
                        </div>
                        </a>
                        <h3> BloodBanks</h3>
                    </div>
                </div>
                <div class="col-md-2 col-md-4 col-xs-6">
                    <div class="wow fadeInUp" data-wow-duration="400ms" data-wow-delay="300ms">
                       <a href="#PharmaCompanies" style="color:White;">
                      
                        <div class="icon-circle">
                            <span>
                            <asp:Label ID="lblPharmaCompanies" runat="server" Text=""></asp:Label>
                            </span>
                            <i class="fa fa-bar-chart  fa-2x" style="margin-top:20px;"></i>
                        </div>
                       </a>
                        <h3>Pharma-<br />Companies</h3>
                       
                    </div>
                </div>
                <div class="col-md-2 col-md-4 col-xs-6">
                    <div class="wow fadeInUp" data-wow-duration="400ms" data-wow-delay="400ms">
                        <a href="#Doctors" style="color:White;">
                    
                        <div class="icon-circle">
                            <span>
                            <asp:Label ID="lblDoctors" runat="server" Text=""></asp:Label>
                            </span>
                            <i class="fa fa-plus fa-2x" style="margin-top:20px;"></i>
                        </div>
                        </a>
                        <h3>Doctors</h3>
                    </div>
                </div>
                <div class="col-md-2 col-md-4 col-xs-6">
                    <div class="wow fadeInUp" data-wow-duration="400ms" data-wow-delay="500ms">
                          <a href="#Donors" style="color:White;">
                    
                        <div class="icon-circle">
                            <span>
                            <asp:Label ID="lblDonors" runat="server" Text=""></asp:Label>
                            </span>
                            <i class="fa fa-user fa-2x" style="margin-top:20px;"></i>
                        </div>
                         </a>
                        <h3>Donors</h3>
                    </div>
                </div>
            </div>
        </div>
    </section><!--/#work-process-->


    
    <section id="meet-team">

    <% BusLib.Common.Registration objRegistration = new BusLib.Common.Registration(); %>
       
        
    <section id="Volunteers">

    <% 
        objRegistration.StackHolder1 = "Volunteer";
        objRegistration.GetDataSet_Search();
        int f = 0;
     %>
        <div class="container">
                   
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">Volunteers</h2>
                <%--<p class="text-center wow fadeInDown">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut <br> et dolore magna aliqua. Ut enim ad minim veniam</p>--%>
            </div>
            <table>
            <%
                if (objRegistration.Ds.Tables[0].Rows.Count > 0)
	            {
                    f = 1;
		                for (int i = 0; i < objRegistration.Ds.Tables[0].Rows.Count; i++)
			            {
                            if (i % 4 == 0)
                            {%>
                                <tr>
                            <td style="padding-bottom:20px;">
                            <%} %>


              
                <div class="col-sm-6 col-md-3">
                    <div class="wow fadeInUp" data-wow-duration="400ms" data-wow-delay="0ms">
                        <div class="team-img">
                  

                  <%Response.Write("<img src=\"/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[i]["ProfilePic"].ToString() + "\"  class=\"img-responsive\" Width=\"200px\" Height=\"200px\" />");%>
                 <%--  <asp:Image ID="VolProfilePic" runat="server" class="img-responsive" width="200 px" height="200 px">
                   </asp:Image>   
                  
                  
                   <% VolProfilePic.ImageUrl = "/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[i]["ProfilePic"].ToString(); %>
--%>
                      
                        </div>
                      
                        <div class="team-info">
                            <h3>

                            <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["FirstName"].ToString() + " " + objRegistration.Ds.Tables[0].Rows[i]["LastName"].ToString()); %>
                            
                            </h3>
                        </div>
                        <div class="">
                        <i class=" fa fa-map-marker" style="font-size:20px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["Address"].ToString()); %>
                        </div>
                          <div class="">
                        <i class=" fa fa-envelope" style="font-size:15px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["Email"].ToString()); %>
                        </div>
                         <div class="">
                         <i class=" fa fa-phone" style="font-size:20px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["MobileNo"].ToString()); %>
                        </div>
              
                      <%--  <p>Backed by some of the biggest names in the industry, Firefox OS is an open platform that fosters greater</p>
                    --%>
                      <%-- <asp:Button ID="Button1" runat="server" Text="Button"
                        CssClass="btn btn-primary" ></asp:Button>--%>
                    </div>
                </div>
         <% if (i+1%4 == 0 || i+1 >= objRegistration.Ds.Tables[0].Rows.Count) { %>
              
            </td></tr>
        
                   <%        }
                          }
         
			           }   
	           
                    %>
                    </td>
                    </tr>
             </table>
              <% if (f==0) {    %>
                      
                       <p class="text-center wow fadeInUP" style="color:Black;font-size:25px;">
            <br />
                         No Volunteers Joined ...
                       </p>
           <%} %>
            </div>
            </section>
    
    <!-- Hospitals -->
    
    <section id="Hospitals">

    <% 
        objRegistration.StackHolder1 = "Hospital";
        objRegistration.GetDataSet_Search();
        f = 0; 
     %>
        <div class="container" style="margin-top:50px;">
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">Hospitals</h2>
               <%-- <p class="text-center wow fadeInDown">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut <br> et dolore magna aliqua. Ut enim ad minim veniam</p>--%>
            </div>
            <table>
            <%
                if (objRegistration.Ds.Tables[0].Rows.Count > 0)
	            {
                    f = 1;
		                for (int i = 0; i < objRegistration.Ds.Tables[0].Rows.Count; i++)
			            {
                            if (i % 4 == 0)
                            
                            {%>
                                <tr>
                               <td style="padding-bottom:20px;">
                            
                            <%} %>

              
                <div class="col-sm-6 col-md-3">
                    <div class="getinvolved wow fadeInUp" data-wow-duration="400ms" data-wow-delay="0ms">
                        <div class="member-img">
                  
                    <%Response.Write("<img src=\"/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[i]["ProfilePic"].ToString() + "\"  class=\"img-responsive\" Width=\"200px\" Height=\"200px\" />");%>

               <%--    <asp:Image ID="HProfilePic" runat="server" class="img-responsive" width="200 px" height="200 px">
                   </asp:Image>   
                   <% HProfilePic.ImageUrl = "/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[i]["ProfilePic"].ToString(); %>
--%>
                      
                        </div>
                      
                        <div class="member-info">
                            <h3>

                            <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["FirstName"].ToString() + " " + objRegistration.Ds.Tables[0].Rows[i]["LastName"].ToString()); %>
                            
                            </h3>
                        </div>
                        <div class="">
                        <i class=" fa fa-map-marker" style="font-size:20px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["Address"].ToString()); %>
                        </div>
                          <div class="">
                        <i class=" fa fa-envelope" style="font-size:15px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["Email"].ToString()); %>
                        </div>
                         <div class="">
                         <i class=" fa fa-phone" style="font-size:20px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["MobileNo"].ToString()); %>
                        </div>
              
                    </div>
                </div>
         
           <% if (i+1%4 == 0 || i+1 >= objRegistration.Ds.Tables[0].Rows.Count) { %>
              
            </td></tr>
        
                   <%        }
                          }
         
			           }   
	           
                    %>
                    </td>
                    </tr>
             </table>

             <% if (f==0) {    %>
                      
                       <p class="text-center wow fadeInUP" style="color:Black;font-size:25px;">
            <br />
                         No Hospitals Joined ...
                       </p>
           <%} %>

            </div>
            </section>
    

    <!-- BloodBanks -->

    <section id="BloodBanks">

    <% 
        objRegistration.StackHolder1 = "BloodBank";
        objRegistration.GetDataSet_Search();
        f = 0;
     %>
        <div class="container" style="margin-top:50px;">
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">BloodBanks</h2>
               <%-- <p class="text-center wow fadeInDown">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut <br> et dolore magna aliqua. Ut enim ad minim veniam</p>--%>
            </div>
            <table>

            <%
                if (objRegistration.Ds.Tables[0].Rows.Count > 0 && objRegistration.Ds.Tables[0].Rows[0]["User_ID"] !="")
	            {
                    f = 1;
		                for (int i = 0; i < objRegistration.Ds.Tables[0].Rows.Count; i++)
			            {
                            if (i % 4 == 0)
                            
                            {%>
                                <tr>
                               <td style="padding-bottom:20px;">
                            
                            <%} %>

                              <div class="col-sm-6 col-md-3">
                    <div class="getinvolved wow fadeInUp" data-wow-duration="400ms" data-wow-delay="0ms">
                        <div class="member-img">
                    <%Response.Write("<img src=\"/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[i]["ProfilePic"].ToString() + "\"  class=\"img-responsive\" Width=\"200px\" Height=\"200px\" />");%>

                   <%--<asp:Image ID="BProfilePic" runat="server" class="img-responsive" width="200 px" height="200 px">
                   </asp:Image>   
                   <% BProfilePic.ImageUrl = "/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[i]["ProfilePic"].ToString(); %>
--%>
                      
                        </div>
                      
                        <div class="member-info">
                            <h3>

                            <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["FirstName"].ToString() + " " + objRegistration.Ds.Tables[0].Rows[i]["LastName"].ToString()); %>
                            
                            </h3>
                        </div>
                        <div class="">
                        <i class=" fa fa-map-marker" style="font-size:20px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["Address"].ToString()); %>
                        </div>
                          <div class="">
                        <i class=" fa fa-envelope" style="font-size:15px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["Email"].ToString()); %>
                        </div>
                         <div class="">
                         <i class=" fa fa-phone" style="font-size:20px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["MobileNo"].ToString()); %>
                        </div>
              
                      <%--  <p>Backed by some of the biggest names in the industry, Firefox OS is an open platform that fosters greater</p>
                    --%>
                      <%-- <asp:Button ID="Button1" runat="server" Text="Button"
                        CssClass="btn btn-primary" ></asp:Button>--%>
                    </div>
                </div>
         

            <% if (i+1%4 == 0) { %>
              
            </td></tr>
        
                   <%        }
                          }
         
			           }   
	           
                    %>
                    </td>
                    </tr>
             </table>
        <% if (f==0) {    %>
                      
                       <p class="text-center wow fadeInUP" style="color:Black;font-size:25px;">
            <br />
                         No BloodBanks Joined ...
                       </p>
           <%} %>
        
            </div>
            </section>
    
    
    <!-- PharmaCompanies -->

    <section id="PharmaCompanies">

    <% 
        objRegistration.StackHolder1 = "PharmaCompany";
        objRegistration.GetDataSet_Search();
        f = 0;
     %>
        <div class="container" style="margin-top:50px;">
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">PharmaCompanies</h2>
              <%--  <p class="text-center wow fadeInDown">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut <br> et dolore magna aliqua. Ut enim ad minim veniam</p>--%>
            </div>
            <table>

            <%
                if (objRegistration.Ds.Tables[0].Rows.Count > 0)
	            {
                    f = 1;
		                for (int i = 0; i < objRegistration.Ds.Tables[0].Rows.Count; i++)
			            {
                            if (i % 4 == 0)
                            
                            {%>
                                <tr>
                               <td style="padding-bottom:20px;">
                            
                            <%} %>

                            
                <div class="col-sm-6 col-md-3">
                    <div class="getinvolved wow fadeInUp" data-wow-duration="400ms" data-wow-delay="0ms">
                        <div class="member-img">
                   <%Response.Write("<img src=\"/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[i]["ProfilePic"].ToString() + "\"  class=\"img-responsive\" Width=\"200px\" Height=\"200px\" />");%> 
                  
                  <%-- <asp:Image ID="PProfilePic" runat="server" class="img-responsive" width="200 px" height="200 px">
                   </asp:Image>   
                   <% PProfilePic.ImageUrl = "/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[i]["ProfilePic"].ToString(); %>
--%>
                      
                        </div>
                      
                        <div class="member-info">
                            <h3>

                            <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["FirstName"].ToString() + " " + objRegistration.Ds.Tables[0].Rows[i]["LastName"].ToString()); %>
                            
                            </h3>
                        </div>
                        <div class="">
                        <i class=" fa fa-map-marker" style="font-size:20px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["Address"].ToString()); %>
                        </div>
                          <div class="">
                        <i class=" fa fa-envelope" style="font-size:15px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["Email"].ToString()); %>
                        </div>
                         <div class="">
                         <i class=" fa fa-phone" style="font-size:20px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["MobileNo"].ToString()); %>
                        </div>
              
                      <%--  <p>Backed by some of the biggest names in the industry, Firefox OS is an open platform that fosters greater</p>
                    --%>
                      <%-- <asp:Button ID="Button1" runat="server" Text="Button"
                        CssClass="btn btn-primary" ></asp:Button>--%>
                    </div>
                </div>
         

            <% if (i+1%4 == 0) { %>
              
            </td></tr>
        
                   <%        }
                          }
         
			           }   
	           
                    %>
                    </td>
                    </tr>
             </table>

             <% if (f==0) {    %>
                      
                       <p class="text-center wow fadeInUP" style="color:Black;font-size:25px;">
            <br />
                         No PharmaCompanies Joined ...
                       </p>
           <%} %>
            </div>
            </section>
    
    
    <!-- Doctors -->

    <section id="Doctors">

    <% 
        objRegistration.StackHolder1 = "Doctor";
        objRegistration.GetDataSet_Search();
        f = 0;
     %>
        <div class="container" style="margin-top:50px;">
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">Doctors</h2>
                <%--<p class="text-center wow fadeInDown">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut <br> et dolore magna aliqua. Ut enim ad minim veniam</p>--%>
            </div>
            <table>

            <%
                if (objRegistration.Ds.Tables[0].Rows.Count > 0)
	            {
                    f = 1;
		                for (int i = 0; i < objRegistration.Ds.Tables[0].Rows.Count; i++)
			            {
                            if (i % 4 == 0)
                            
                            {%>
                                <tr>
                               <td style="padding-bottom:20px;width:1094px;">
                            
                            <%} %>

                            
                <div class="col-sm-6 col-md-3">
                    <div class="getinvolved wow fadeInUp" data-wow-duration="400ms" data-wow-delay="0ms">
                        <div class="member-img">
                  
                    <%Response.Write("<img src=\"/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[i]["ProfilePic"].ToString() + "\"  class=\"img-responsive\" Width=\"200px\" Height=\"200px\" />");%>

                <%--   <asp:Image ID="DoctorProfilePic" runat="server" class="img-responsive" width="200 px" height="200 px">
                   </asp:Image>   
                   <% DoctorProfilePic.ImageUrl = "/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[i]["ProfilePic"].ToString(); %>
--%>
                      
                        </div>
                      
                        <div class="member-info">
                            <h3>

                            <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["FirstName"].ToString() + " " + objRegistration.Ds.Tables[0].Rows[i]["LastName"].ToString()); %>
                            
                            </h3>
                        </div>
                        <div class="">
                        <i class=" fa fa-map-marker" style="font-size:20px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["Address"].ToString()); %>
                        </div>
                          <div class="">
                        <i class=" fa fa-envelope" style="font-size:15px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["Email"].ToString()); %>
                        </div>
                         <div class="">
                         <i class=" fa fa-phone" style="font-size:20px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["MobileNo"].ToString()); %>
                        </div>
              
                      <%--  <p>Backed by some of the biggest names in the industry, Firefox OS is an open platform that fosters greater</p>
                    --%>
                      <%-- <asp:Button ID="Button1" runat="server" Text="Button"
                        CssClass="btn btn-primary" ></asp:Button>--%>
                    </div>
                </div>
         
           <% if (i + 1 % 4 == 0 || i >= objRegistration.Ds.Tables[0].Rows.Count)
              { %>
              
            </td></tr>
        
                   <%        }
                          }
         
			           }   
	           
                    %>
                    </td>
                    </tr>
             </table>

             <% if (f==0) {    %>
                      
                       <p class="text-center wow fadeInUP" style="color:Black;font-size:25px;">
            <br />
                         No Doctors Joined ...
                       </p>
           <%} %>
            </div>
            </section>
    
    <!-- Donors -->

    <section id="Donors">

    <% 
        objRegistration.StackHolder1 = "Donor";
        objRegistration.GetDataSet_Search();
        f = 0;
     %>
        <div class="container" style="margin-top:50px;">
            <div class="section-header">
                <h2 class="section-title text-center wow fadeInDown">Donors</h2>
              <%--  <p class="text-center wow fadeInDown">Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut <br> et dolore magna aliqua. Ut enim ad minim veniam</p>--%>
            </div>
            <table>
            <%
                if (objRegistration.Ds.Tables[0].Rows.Count > 0)
	            {
                    f = 1;
		                for (int i = 0; i < objRegistration.Ds.Tables[0].Rows.Count; i++)
			            {
                            if (i % 4 == 0)
                            
                            {%>
                                <tr>
                               <td style="padding-bottom:20px;width:1094px;">
                            
                            <%} %>

                              <div class="col-sm-6 col-md-3">
                    <div class="getinvolved wow fadeInUp" data-wow-duration="400ms" data-wow-delay="0ms">
                        <div class="member-img">
                  

                    <%Response.Write("<img src=\"/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[i]["ProfilePic"].ToString() + "\"  class=\"img-responsive\" Width=\"200px\" Height=\"200px\" />");%>

                 <%--  <asp:Image ID="DonorProfilePic" runat="server" class="img-responsive" width="200 px" height="200 px">
                   </asp:Image>   
                   <% DonorProfilePic.ImageUrl = "/ProfilePic/" + objRegistration.Ds.Tables[0].Rows[i]["ProfilePic"].ToString(); %>
--%>
                      
                        </div>
                      
                        <div class="member-info">
                            <h3>

                            <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["FirstName"].ToString() + " " + objRegistration.Ds.Tables[0].Rows[i]["LastName"].ToString()); %>
                            
                            </h3>
                        </div>
                        <div class="">
                        <i class=" fa fa-map-marker" style="font-size:20px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["Address"].ToString()); %>
                        </div>
                          <div class="">
                        <i class=" fa fa-envelope" style="font-size:15px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["Email"].ToString()); %>
                        </div>
                         <div class="">
                         <i class=" fa fa-phone" style="font-size:20px;"></i>
                         <% Response.Write(objRegistration.Ds.Tables[0].Rows[i]["MobileNo"].ToString()); %>
                        </div>
              
                      <%--  <p>Backed by some of the biggest names in the industry, Firefox OS is an open platform that fosters greater</p>
                    --%>
                      <%-- <asp:Button ID="Button1" runat="server" Text="Button"
                        CssClass="btn btn-primary" ></asp:Button>--%>
                    </div>
                </div>
         
           <% if (i + 1 % 4 == 0 || i >= objRegistration.Ds.Tables[0].Rows.Count)
              { %>
              
            </td></tr>
        
                   <%        }
                          }
         
			           }   
	           
                    %>
                    </td>
                    </tr>
             </table>
             <% if (f==0) {    %>
                      
                       <p class="text-center wow fadeInUP" style="color:Black;font-size:25px;">
            <br />
                         No Donors Joined ...
                       </p>
           <%} %>
            </div>
            </section>
    
     <!-- End -->
    
    
            </section>
            

</asp:Content>
